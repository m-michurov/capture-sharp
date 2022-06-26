namespace WindowCapture.GUI {
    sealed partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ChangeDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectedDirectory = new System.Windows.Forms.TextBox();
            this.WindowsList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshWindows = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeDirectory
            // 
            this.ChangeDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeDirectory.Location = new System.Drawing.Point(2, 325);
            this.ChangeDirectory.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeDirectory.Name = "ChangeDirectory";
            this.ChangeDirectory.Size = new System.Drawing.Size(280, 35);
            this.ChangeDirectory.TabIndex = 1;
            this.ChangeDirectory.Text = "Change Directory";
            this.ChangeDirectory.UseVisualStyleBackColor = true;
            this.ChangeDirectory.Click += new System.EventHandler(this.ChangeDirectory_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(2, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Save to";
            // 
            // SelectedDirectory
            // 
            this.SelectedDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedDirectory.Location = new System.Drawing.Point(2, 302);
            this.SelectedDirectory.Name = "SelectedDirectory";
            this.SelectedDirectory.Size = new System.Drawing.Size(280, 20);
            this.SelectedDirectory.TabIndex = 3;
            // 
            // WindowsList
            // 
            this.WindowsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowsList.FormattingEnabled = true;
            this.WindowsList.Location = new System.Drawing.Point(2, 16);
            this.WindowsList.Margin = new System.Windows.Forms.Padding(0);
            this.WindowsList.Name = "WindowsList";
            this.WindowsList.Size = new System.Drawing.Size(279, 225);
            this.WindowsList.TabIndex = 4;
            this.WindowsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.WindowsList_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Double click to capture";
            // 
            // RefreshWindows
            // 
            this.RefreshWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshWindows.Location = new System.Drawing.Point(2, 242);
            this.RefreshWindows.Margin = new System.Windows.Forms.Padding(0);
            this.RefreshWindows.Name = "RefreshWindows";
            this.RefreshWindows.Size = new System.Drawing.Size(280, 35);
            this.RefreshWindows.TabIndex = 6;
            this.RefreshWindows.Text = "Refresh";
            this.RefreshWindows.UseVisualStyleBackColor = true;
            this.RefreshWindows.Click += new System.EventHandler(this.RefreshWindows_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.RefreshWindows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WindowsList);
            this.Controls.Add(this.SelectedDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangeDirectory);
            this.Name = "MainWindow";
            this.Text = "CaptureSharp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button RefreshWindows;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.ListBox WindowsList;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SelectedDirectory;

        private System.Windows.Forms.Button ChangeDirectory;

        #endregion
    }
}
