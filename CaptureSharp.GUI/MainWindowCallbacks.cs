using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CaptureSharp.Core;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WindowCapture.GUI;

public partial class MainWindow {
    private void ChangeDirectory_Click(object sender, EventArgs e) {
        var dialog = new CommonOpenFileDialog {
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop), IsFolderPicker = true
        };

        var result = dialog.ShowDialog();

        if (CommonFileDialogResult.Ok != result || string.IsNullOrWhiteSpace(dialog.FileName)) {
            return;
        }

        SelectedDirectory.Text = dialog.FileName;
    }

    private void RefreshWindows_Click(object sender, EventArgs e) => UpdateWindowsList();

    private static void ShowError(string what) =>
        MessageBox.Show(
            what,
            caption: @"Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );

    private static bool ShowQuestion(string what) =>
        DialogResult.Yes == MessageBox.Show(
            what,
            caption: @"Window is minimized",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

    private void WindowsList_MouseDoubleClick(object sender, MouseEventArgs e) {
        if (string.IsNullOrWhiteSpace(SelectedDirectory.Text)) {
            ShowError(what: @"Select a save directory");

            return;
        }

        var selected = windows[WindowsList.SelectedIndex];

        if (WindowCaptureUtility.IsWindowMinimized(selected.Handle)) {
            if (ShowQuestion(what: @"Cannot capture a minimized window. Restore it?")) {
                WindowCaptureUtility.RestoreWindow(selected.Handle);
            }

            return;
        }

        using var image = CaptureSharp.Core.WindowCapture.Capture(selected.Handle);

        if (image is null) {
            ShowError($@"Failed to capture {selected.ProcessName}.");
            return;
        }

        var savePath = $"{SelectedDirectory.Text}\\{selected.ProcessName} {DateTime.Now:yyyymmdd_hhmmss}.png";

        try {
            image.Save(savePath, ImageFormat.Png);
        } catch (Exception) {
            ShowError(what: @"Failed to save captured image. Check save directory path.");
        }
    }
}
