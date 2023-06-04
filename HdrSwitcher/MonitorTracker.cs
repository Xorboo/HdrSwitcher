using HdrLibrary;

namespace HdrSwitcher
{
    public class MonitorTracker
    {
        public enum MonitorState
        {
            NotSupported,
            Off,
            On
        };


        public int MonitorIndex { get; set; }


        public MonitorTracker(int monitorIndex)
        {
            MonitorIndex = monitorIndex;
        }

        public (MonitorState State, MonitorData? monitor) GetMonitorState()
        {
            var monitors = HdrManager.GetMonitors();
            if (monitors.Count == 0)
                return (MonitorState.NotSupported, null);

            CheckMonitorIndex(monitors);

            var monitor = monitors[MonitorIndex];
            return (GetMonitorState(monitor), monitor);
        }

        public void ToggleHdrMode()
        {
            var monitors = HdrManager.GetMonitors();
            if (monitors.Count == 0)
                return;

            CheckMonitorIndex(monitors);

            var monitor = monitors[MonitorIndex];
            HdrManager.SetHdrMode(monitor.Name, !monitor.HdrEnabled);
        }

        public static MonitorState GetMonitorState(MonitorData monitor)
        {
            if (!monitor.HdrSupported)
                return MonitorState.NotSupported;
            return monitor.HdrEnabled ? MonitorState.On : MonitorState.Off;
        }

        private void CheckMonitorIndex(List<MonitorData> monitors)
        {
            if (MonitorIndex < 0 || MonitorIndex >= monitors.Count || !monitors[MonitorIndex].HdrSupported)
                MonitorIndex = Math.Max(0, monitors.FindIndex(m => m.HdrSupported));
        }
    }
}
