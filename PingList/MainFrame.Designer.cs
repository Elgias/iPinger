namespace PingList
{
    partial class MainFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.refresh_button = new System.Windows.Forms.Button();
            this.hostStatusGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.settings_button = new System.Windows.Forms.ToolStripButton();
            this.tools_button = new System.Windows.Forms.ToolStripDropDownButton();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.hostStatusGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(683, 406);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(105, 32);
            this.refresh_button.TabIndex = 2;
            this.refresh_button.Text = "Refresh";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // hostStatusGrid
            // 
            this.hostStatusGrid.AllowUserToAddRows = false;
            this.hostStatusGrid.AllowUserToDeleteRows = false;
            this.hostStatusGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.hostStatusGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hostStatusGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hostStatusGrid.Location = new System.Drawing.Point(12, 33);
            this.hostStatusGrid.Name = "hostStatusGrid";
            this.hostStatusGrid.ReadOnly = true;
            this.hostStatusGrid.RowHeadersWidth = 57;
            this.hostStatusGrid.RowTemplate.Height = 32;
            this.hostStatusGrid.Size = new System.Drawing.Size(776, 367);
            this.hostStatusGrid.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings_button,
            this.tools_button});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 31);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // settings_button
            // 
            this.settings_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settings_button.Image = ((System.Drawing.Image)(resources.GetObject("settings_button.Image")));
            this.settings_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(75, 27);
            this.settings_button.Text = "Settings";
            // 
            // tools_button
            // 
            this.tools_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tools_button.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.tools_button.Image = ((System.Drawing.Image)(resources.GetObject("tools_button.Image")));
            this.tools_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tools_button.Name = "tools_button";
            this.tools_button.Size = new System.Drawing.Size(65, 27);
            this.tools_button.Text = "Tools";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.hostStatusGrid);
            this.Controls.Add(this.refresh_button);
            this.Name = "MainFrame";
            this.Text = "iPinger";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hostStatusGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.DataGridView hostStatusGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton settings_button;
        private System.Windows.Forms.ToolStripDropDownButton tools_button;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}
