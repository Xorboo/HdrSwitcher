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
        toolStripMenuItem2 = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        checkTimer = new System.Windows.Forms.Timer(components);
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
        contextMenuStrip.Items.AddRange(new ToolStripItem[] { monitorToolStripMenuItem, toolStripMenuItem2, exitToolStripMenuItem });
        contextMenuStrip.Name = "contextMenuStrip";
        contextMenuStrip.Size = new Size(132, 58);
        contextMenuStrip.Opening += contextMenuStrip_Opening;
        // 
        // monitorToolStripMenuItem
        // 
        monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
        monitorToolStripMenuItem.Size = new Size(131, 24);
        monitorToolStripMenuItem.Text = "Monitor";
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new Size(128, 6);
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
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FormMain";
        Text = "Form1";
        contextMenuStrip.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem monitorToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Timer checkTimer;
}