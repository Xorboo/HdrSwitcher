namespace HdrSwitcher;

partial class FormMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        notifyIcon = new NotifyIcon(components);
        contextMenuStrip = new ContextMenuStrip(components);
        monitorToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        autorunToolStripMenuItem = new ToolStripMenuItem();
        separatorToolStripMenuItem = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        checkTimer = new System.Windows.Forms.Timer(components);
        label1 = new Label();
        contextMenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // notifyIcon
        // 
        notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
        notifyIcon.ContextMenuStrip = contextMenuStrip;
        notifyIcon.Text = "Unknown State";
        notifyIcon.Visible = true;
        notifyIcon.MouseClick += notifyIcon_MouseClick;
        // 
        // contextMenuStrip
        // 
        contextMenuStrip.ImageScalingSize = new Size(20, 20);
        contextMenuStrip.Items.AddRange(new ToolStripItem[] { monitorToolStripMenuItem, settingsToolStripMenuItem, separatorToolStripMenuItem, exitToolStripMenuItem });
        contextMenuStrip.Name = "contextMenuStrip";
        contextMenuStrip.Size = new Size(132, 82);
        contextMenuStrip.Opening += contextMenuStrip_Opening;
        // 
        // monitorToolStripMenuItem
        // 
        monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
        monitorToolStripMenuItem.Size = new Size(131, 24);
        monitorToolStripMenuItem.Text = "Monitor";
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { autorunToolStripMenuItem });
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(131, 24);
        settingsToolStripMenuItem.Text = "Settings";
        // 
        // autorunToolStripMenuItem
        // 
        autorunToolStripMenuItem.Name = "autorunToolStripMenuItem";
        autorunToolStripMenuItem.Size = new Size(224, 26);
        autorunToolStripMenuItem.Text = "Run on startup";
        autorunToolStripMenuItem.Click += autorunToolStripMenuItem_Click;
        // 
        // separatorToolStripMenuItem
        // 
        separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
        separatorToolStripMenuItem.Size = new Size(128, 6);
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(131, 24);
        exitToolStripMenuItem.Text = "Exit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        // 
        // checkTimer
        // 
        checkTimer.Enabled = true;
        checkTimer.Interval = 5000;
        checkTimer.Tick += checkTimer_Tick;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(449, 184);
        label1.TabIndex = 1;
        label1.Text = "You weren't supposed to be able to get here you know";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FormMain
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(473, 202);
        Controls.Add(label1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FormMain";
        Text = "HDR Switcher by Xorboo";
        contextMenuStrip.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem monitorToolStripMenuItem;
    private ToolStripSeparator separatorToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Timer checkTimer;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripMenuItem autorunToolStripMenuItem;
    private Label label1;
}