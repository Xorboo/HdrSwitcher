using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HdrLibrary;

public static class HdrManager
{
    public static List<MonitorData> GetMonitors()
    {
        int err = Native.GetDisplayConfigBufferSizes(Native.QDC.QDC_ONLY_ACTIVE_PATHS, out var pathCount,
            out var modeCount);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);

        var paths = new Native.DISPLAYCONFIG_PATH_INFO[pathCount];
        var modes = new Native.DISPLAYCONFIG_MODE_INFO[modeCount];
        err = Native.QueryDisplayConfig(
            Native.QDC.QDC_ONLY_ACTIVE_PATHS, ref pathCount, paths, ref modeCount, modes, IntPtr.Zero);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);

        var monitors = new List<MonitorData>(paths.Length);
        foreach (var path in paths)
        {
            var displayName = GetDisplayName(path.targetInfo);
            var deviceName = GetDeviceName(path.sourceInfo);
            var colorInfo = GetColorInfo(path.targetInfo);

            monitors.Add(new MonitorData
            {
                Name = deviceName.viewGdiDeviceName,
                FriendlyName = displayName.monitorFriendlyDeviceName,
                HdrSupported = colorInfo.advancedColorSupported,
                HdrEnabled = colorInfo.advancedColorEnabled
            });
        }

        return monitors;
    }

    public static void SetHdrMode(string monitorName, bool enableHdr)
    {
        int err = Native.GetDisplayConfigBufferSizes(
            Native.QDC.QDC_ONLY_ACTIVE_PATHS, out var pathCount, out var modeCount);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);

        var paths = new Native.DISPLAYCONFIG_PATH_INFO[pathCount];
        var modes = new Native.DISPLAYCONFIG_MODE_INFO[modeCount];
        err = Native.QueryDisplayConfig(
            Native.QDC.QDC_ONLY_ACTIVE_PATHS, ref pathCount, paths, ref modeCount, modes, IntPtr.Zero);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);

        foreach (var path in paths)
        {
            var deviceName = GetDeviceName(path.sourceInfo);
            if (deviceName.viewGdiDeviceName != monitorName)
                continue;

            var colorInfo = GetColorInfo(path.targetInfo);
            if (!colorInfo.advancedColorSupported)
                break;
            if (colorInfo.advancedColorEnabled == enableHdr)
                break;

            SetHdr(enableHdr, path.targetInfo);
        }
    }

    private static Native.DISPLAYCONFIG_TARGET_DEVICE_NAME GetDisplayName(
        Native.DISPLAYCONFIG_PATH_TARGET_INFO targetInfo)
    {
        var displayNamePacket = new Native.DISPLAYCONFIG_TARGET_DEVICE_NAME
        {
            header = new Native.DISPLAYCONFIG_DEVICE_INFO_HEADER
            {
                type = Native.DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME,
                size = Marshal.SizeOf<Native.DISPLAYCONFIG_TARGET_DEVICE_NAME>(),
                adapterId = targetInfo.adapterId,
                id = targetInfo.id
            },
        };

        int err = Native.DisplayConfigGetDeviceInfo(ref displayNamePacket);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);
        return displayNamePacket;
    }

    private static Native.DISPLAYCONFIG_SOURCE_DEVICE_NAME GetDeviceName(
        Native.DISPLAYCONFIG_PATH_SOURCE_INFO sourceInfo)
    {
        var deviceNamePacket = new Native.DISPLAYCONFIG_SOURCE_DEVICE_NAME
        {
            header = new Native.DISPLAYCONFIG_DEVICE_INFO_HEADER
            {
                type = Native.DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME,
                size = Marshal.SizeOf<Native.DISPLAYCONFIG_SOURCE_DEVICE_NAME>(),
                adapterId = sourceInfo.adapterId,
                id = sourceInfo.id
            },
        };

        int err = Native.DisplayConfigGetDeviceInfo(ref deviceNamePacket);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);
        return deviceNamePacket;
    }

    private static Native.DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO GetColorInfo(
        Native.DISPLAYCONFIG_PATH_TARGET_INFO targetInfo)
    {
        var getColorPacket = new Native.DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO
        {
            header = new Native.DISPLAYCONFIG_DEVICE_INFO_HEADER
            {
                type = Native.DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO,
                size = Marshal.SizeOf<Native.DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO>(),
                adapterId = targetInfo.adapterId,
                id = targetInfo.id
            },
        };

        int err = Native.DisplayConfigGetDeviceInfo(ref getColorPacket);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);
        return getColorPacket;
    }

    private static void SetHdr(bool enableHdr, Native.DISPLAYCONFIG_PATH_TARGET_INFO targetInfo)
    {
        var setColorPacket = new Native.DISPLAYCONFIG_SET_ADVANCED_COLOR_INFO
        {
            header = new Native.DISPLAYCONFIG_DEVICE_INFO_HEADER
            {
                type = Native.DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_STATE,
                size = Marshal.SizeOf<Native.DISPLAYCONFIG_SET_ADVANCED_COLOR_INFO>(),
                adapterId = targetInfo.adapterId,
                id = targetInfo.id
            },
            enableAdvancedColor = enableHdr ? 1U : 0U
        };

        int err = Native.DisplayConfigSetDeviceInfo(ref setColorPacket);
        if (err != Native.ERROR_SUCCESS)
            throw new Win32Exception(err);
    }
}
