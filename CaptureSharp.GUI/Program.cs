using System;
using System.Windows.Forms;

namespace WindowCapture.GUI;

internal static class Program {
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(defaultValue: false);
        Application.Run(new MainWindow());
    }
}
