namespace WindowsFormsApp1
{
    partial class Scene
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scene));
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.label_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1;
            this.timerUpdate.Tick += new System.EventHandler(this.Update);
            // 
            // label_Info
            // 
            this.label_Info.AutoEllipsis = true;
            this.label_Info.BackColor = System.Drawing.SystemColors.Control;
            this.label_Info.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Info.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_Info.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Info.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label_Info.Location = new System.Drawing.Point(0, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(209, 456);
            this.label_Info.TabIndex = 0;
            this.label_Info.Text = "label1";
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 456);
            this.Controls.Add(this.label_Info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(256, 128);
            this.Name = "Scene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Quit);
            this.Shown += new System.EventHandler(this.Start);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyboardPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownScene);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label label_Info;
    }
}

