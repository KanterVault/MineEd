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
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
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
            this.label_Info.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_Info.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label_Info.Location = new System.Drawing.Point(3, 3);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(161, 201);
            this.label_Info.TabIndex = 0;
            this.label_Info.Text = "label1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(3, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "29.11.2019 2:17:22 6c0b1fed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(3, 207);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(161, 25);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 4;
            // 
            // trackBar2
            // 
            this.trackBar2.AutoSize = false;
            this.trackBar2.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar2.Location = new System.Drawing.Point(3, 235);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(161, 25);
            this.trackBar2.TabIndex = 2;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Value = 10;
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(599, 456);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
    }
}

