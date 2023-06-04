using HdrLibrary;

var monitors = HdrManager.GetMonitors();
var testMonitor = monitors.First(m => m.HdrSupported);
HdrManager.SetHdrMode(testMonitor.Name, !testMonitor.HdrEnabled);

