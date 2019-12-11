namespace Compiler
{
    partial class CompileEditor
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.chankGenerator = new System.Windows.Forms.TabPage();
            this.editBlocksCollisions = new System.Windows.Forms.TabPage();
            this.meshBuilder = new System.Windows.Forms.TabPage();
            this.mouseAndKeyboardEvents = new System.Windows.Forms.TabPage();
            this.playerCollisions = new System.Windows.Forms.TabPage();
            this.playerMoving = new System.Windows.Forms.TabPage();
            this.program = new System.Windows.Forms.TabPage();
            this.render = new System.Windows.Forms.TabPage();
            this.renderLineScene = new System.Windows.Forms.TabPage();
            this.button_compile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.chankGenerator.SuspendLayout();
            this.editBlocksCollisions.SuspendLayout();
            this.meshBuilder.SuspendLayout();
            this.mouseAndKeyboardEvents.SuspendLayout();
            this.playerCollisions.SuspendLayout();
            this.playerMoving.SuspendLayout();
            this.program.SuspendLayout();
            this.render.SuspendLayout();
            this.renderLineScene.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(166, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 387);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.chankGenerator);
            this.tabControl1.Controls.Add(this.editBlocksCollisions);
            this.tabControl1.Controls.Add(this.meshBuilder);
            this.tabControl1.Controls.Add(this.mouseAndKeyboardEvents);
            this.tabControl1.Controls.Add(this.playerCollisions);
            this.tabControl1.Controls.Add(this.playerMoving);
            this.tabControl1.Controls.Add(this.program);
            this.tabControl1.Controls.Add(this.render);
            this.tabControl1.Controls.Add(this.renderLineScene);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(401, 387);
            this.tabControl1.TabIndex = 0;
            // 
            // chankGenerator
            // 
            this.chankGenerator.Controls.Add(this.textBox1);
            this.chankGenerator.Location = new System.Drawing.Point(4, 22);
            this.chankGenerator.Name = "chankGenerator";
            this.chankGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.chankGenerator.Size = new System.Drawing.Size(393, 361);
            this.chankGenerator.TabIndex = 0;
            this.chankGenerator.Text = "ChankGenerator";
            this.chankGenerator.UseVisualStyleBackColor = true;
            // 
            // editBlocksCollisions
            // 
            this.editBlocksCollisions.Controls.Add(this.textBox2);
            this.editBlocksCollisions.Location = new System.Drawing.Point(4, 22);
            this.editBlocksCollisions.Name = "editBlocksCollisions";
            this.editBlocksCollisions.Padding = new System.Windows.Forms.Padding(3);
            this.editBlocksCollisions.Size = new System.Drawing.Size(393, 361);
            this.editBlocksCollisions.TabIndex = 1;
            this.editBlocksCollisions.Text = "EditBlocksCollisions";
            this.editBlocksCollisions.UseVisualStyleBackColor = true;
            // 
            // meshBuilder
            // 
            this.meshBuilder.Controls.Add(this.textBox3);
            this.meshBuilder.Location = new System.Drawing.Point(4, 22);
            this.meshBuilder.Name = "meshBuilder";
            this.meshBuilder.Size = new System.Drawing.Size(393, 361);
            this.meshBuilder.TabIndex = 2;
            this.meshBuilder.Text = "MeshBuilder";
            this.meshBuilder.UseVisualStyleBackColor = true;
            // 
            // mouseAndKeyboardEvents
            // 
            this.mouseAndKeyboardEvents.Controls.Add(this.textBox4);
            this.mouseAndKeyboardEvents.Location = new System.Drawing.Point(4, 22);
            this.mouseAndKeyboardEvents.Name = "mouseAndKeyboardEvents";
            this.mouseAndKeyboardEvents.Size = new System.Drawing.Size(393, 361);
            this.mouseAndKeyboardEvents.TabIndex = 3;
            this.mouseAndKeyboardEvents.Text = "MouseAndKeyboardEvents";
            this.mouseAndKeyboardEvents.UseVisualStyleBackColor = true;
            // 
            // playerCollisions
            // 
            this.playerCollisions.Controls.Add(this.textBox5);
            this.playerCollisions.Location = new System.Drawing.Point(4, 22);
            this.playerCollisions.Name = "playerCollisions";
            this.playerCollisions.Size = new System.Drawing.Size(393, 361);
            this.playerCollisions.TabIndex = 4;
            this.playerCollisions.Text = "PlayerCollisions";
            this.playerCollisions.UseVisualStyleBackColor = true;
            // 
            // playerMoving
            // 
            this.playerMoving.Controls.Add(this.textBox6);
            this.playerMoving.Location = new System.Drawing.Point(4, 22);
            this.playerMoving.Name = "playerMoving";
            this.playerMoving.Size = new System.Drawing.Size(393, 361);
            this.playerMoving.TabIndex = 5;
            this.playerMoving.Text = "PlayerMoving";
            this.playerMoving.UseVisualStyleBackColor = true;
            // 
            // program
            // 
            this.program.Controls.Add(this.textBox7);
            this.program.Location = new System.Drawing.Point(4, 22);
            this.program.Name = "program";
            this.program.Size = new System.Drawing.Size(393, 361);
            this.program.TabIndex = 6;
            this.program.Text = "Program";
            this.program.UseVisualStyleBackColor = true;
            // 
            // render
            // 
            this.render.Controls.Add(this.textBox9);
            this.render.Location = new System.Drawing.Point(4, 22);
            this.render.Name = "render";
            this.render.Size = new System.Drawing.Size(393, 361);
            this.render.TabIndex = 7;
            this.render.Text = "Render";
            this.render.UseVisualStyleBackColor = true;
            // 
            // renderLineScene
            // 
            this.renderLineScene.Controls.Add(this.textBox8);
            this.renderLineScene.Location = new System.Drawing.Point(4, 22);
            this.renderLineScene.Name = "renderLineScene";
            this.renderLineScene.Size = new System.Drawing.Size(393, 361);
            this.renderLineScene.TabIndex = 8;
            this.renderLineScene.Text = "RenderLineScene";
            this.renderLineScene.UseVisualStyleBackColor = true;
            // 
            // button_compile
            // 
            this.button_compile.Location = new System.Drawing.Point(12, 12);
            this.button_compile.Name = "button_compile";
            this.button_compile.Size = new System.Drawing.Size(148, 24);
            this.button_compile.TabIndex = 1;
            this.button_compile.Text = "Компилировать проект";
            this.button_compile.UseVisualStyleBackColor = true;
            this.button_compile.Click += new System.EventHandler(this.button_compile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(387, 355);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(387, 355);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(393, 361);
            this.textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(0, 0);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(393, 361);
            this.textBox4.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Location = new System.Drawing.Point(0, 0);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(393, 361);
            this.textBox5.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Location = new System.Drawing.Point(0, 0);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(393, 361);
            this.textBox6.TabIndex = 1;
            // 
            // textBox7
            // 
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Location = new System.Drawing.Point(0, 0);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(393, 361);
            this.textBox7.TabIndex = 1;
            // 
            // textBox8
            // 
            this.textBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox8.Location = new System.Drawing.Point(0, 0);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(393, 361);
            this.textBox8.TabIndex = 1;
            // 
            // textBox9
            // 
            this.textBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox9.Location = new System.Drawing.Point(0, 0);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(393, 361);
            this.textBox9.TabIndex = 1;
            // 
            // CompileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 387);
            this.Controls.Add(this.button_compile);
            this.Controls.Add(this.panel1);
            this.Name = "CompileEditor";
            this.Text = "Editor";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.chankGenerator.ResumeLayout(false);
            this.chankGenerator.PerformLayout();
            this.editBlocksCollisions.ResumeLayout(false);
            this.editBlocksCollisions.PerformLayout();
            this.meshBuilder.ResumeLayout(false);
            this.meshBuilder.PerformLayout();
            this.mouseAndKeyboardEvents.ResumeLayout(false);
            this.mouseAndKeyboardEvents.PerformLayout();
            this.playerCollisions.ResumeLayout(false);
            this.playerCollisions.PerformLayout();
            this.playerMoving.ResumeLayout(false);
            this.playerMoving.PerformLayout();
            this.program.ResumeLayout(false);
            this.program.PerformLayout();
            this.render.ResumeLayout(false);
            this.render.PerformLayout();
            this.renderLineScene.ResumeLayout(false);
            this.renderLineScene.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage chankGenerator;
        private System.Windows.Forms.TabPage editBlocksCollisions;
        private System.Windows.Forms.TabPage meshBuilder;
        private System.Windows.Forms.TabPage mouseAndKeyboardEvents;
        private System.Windows.Forms.TabPage playerCollisions;
        private System.Windows.Forms.TabPage playerMoving;
        private System.Windows.Forms.TabPage program;
        private System.Windows.Forms.TabPage render;
        private System.Windows.Forms.TabPage renderLineScene;
        private System.Windows.Forms.Button button_compile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
    }
}

