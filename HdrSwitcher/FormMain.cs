using HdrLibrary;

namespace HdrSwitcher;

public partial class FormMain : Form
{
    private bool _allowVisible; // ContextMenu's Show command used
    private bool _allowClose; // ContextMenu's Exit command used

    private MonitorTracker.MonitorState? _iconState;
    private readonly MonitorTracker _tracker;


    public FormMain()
    {
        InitializeComponent();

        _tracker = new MonitorTracker(Properties.Settings.Default.MonitorIndex);
        UpdateMonitorState();
    }


    protected override void SetVisibleCore(bool value)
    {
        if (!_allowVisible)
        {
            value = false;
            if (!IsHandleCreated) CreateHandle();
        }

        base.SetVisibleCore(value);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (!_allowClose)
        {
            Hide();
            e.Cancel = true;
        }

        notifyIcon.Dispose();
        base.OnFormClosing(e);
    }

    private void showToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _allowVisible = true;
        Show();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _allowClose = true;
        Application.Exit();
    }

    private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        PopulateMonitorList();
    }

    private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
            return;

        _tracker.ToggleHdrMode();
        UpdateMonitorState();
    }

    private void checkTimer_Tick(object sender, EventArgs e)
    {
        UpdateMonitorState();
    }

    private void SetTrackedMonitor(int monitorIndex)
    {
        _tracker.MonitorIndex = monitorIndex;
        UpdateMonitorState();

        Properties.Settings.Default.MonitorIndex = _tracker.MonitorIndex;
        Properties.Settings.Default.Save();
    }

    private void UpdateMonitorState()
    {
        var (state, monitor) = _tracker.GetMonitorState();
        if (_iconState != state)
        {
            _iconState = state;
            notifyIcon.Icon?.Dispose();
            notifyIcon.Icon = GetStateIcon(state);
            notifyIcon.Text = $"[{state}] {monitor?.FriendlyName ?? "Unknown Monitor"}";
        }
    }

    private Icon GetStateIcon(MonitorTracker.MonitorState state)
    {
        switch (state)
        {
            case MonitorTracker.MonitorState.NotSupported:
                return Properties.Resources.IconUnsupported;
            case MonitorTracker.MonitorState.Off:
                return Properties.Resources.IconDisabled;
            case MonitorTracker.MonitorState.On:
                return Properties.Resources.IconEnabled;

            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown monitor state");
        }
    }

    private void PopulateMonitorList()
    {
        monitorToolStripMenuItem.DropDownItems.Clear();

        var monitors = HdrManager.GetMonitors();
        for (int i = 0; i < monitors.Count; i++)
        {
            MonitorData monitor = monitors[i];
            var state = MonitorTracker.GetMonitorState(monitor);
            var item = new ToolStripMenuItem
            {
                Name = monitor.Name,
                Text = $"[{i + 1}] {monitor.FriendlyName} ({state})",
                Checked = i == _tracker.MonitorIndex,
                Enabled = monitor.HdrSupported
            };

            int index = i;
            item.Click += (_, _) => SetTrackedMonitor(index);

            monitorToolStripMenuItem.DropDownItems.Add(item);
        }
    }
}
