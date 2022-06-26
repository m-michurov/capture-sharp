using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CaptureSharp.Core;

namespace WindowCapture.GUI;

public sealed partial class MainWindow : Form {
    private IList<WindowInfo> windows = new List<WindowInfo>();

    public MainWindow() {
        InitializeComponent();

        SelectedDirectory.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        UpdateWindowsList();
    }

    private void UpdateWindowsList() {
        windows = WindowCaptureUtility.ListCapturableWindows();

        WindowsList.DataSource = windows
            .Select(it => $"{it.Title} ({it.ProcessName})")
            .ToList();
    }
}
