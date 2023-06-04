using Microsoft.Win32;

namespace HdrSwitcher
{
    internal static class AutorunManager
    {
        const string AutorunRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        const string AppRegistryName = "Hdr Switcher";

        public static bool AutorunEnabled
        {
            get
            {
                var rk = Registry.CurrentUser.OpenSubKey(AutorunRegistryPath, false);
                return rk?.GetValue(AppRegistryName) != null;
            }
            set
            {
                var rk = Registry.CurrentUser.OpenSubKey(AutorunRegistryPath, true);
                if (value)
                    rk?.SetValue(AppRegistryName, Application.ExecutablePath);
                else
                    rk?.DeleteValue(AppRegistryName, false);
            }
        }
    }
}
