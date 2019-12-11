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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompileEditor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.chankGenerator = new System.Windows.Forms.TabPage();
            this.meshBuilder = new System.Windows.Forms.TabPage();
            this.mouseAndKeyboardEvents = new System.Windows.Forms.TabPage();
            this.playerCollisions = new System.Windows.Forms.TabPage();
            this.playerMoving = new System.Windows.Forms.TabPage();
            this.program = new System.Windows.Forms.TabPage();
            this.render = new System.Windows.Forms.TabPage();
            this.renderLineScene = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenu_Compile = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.editBlocksCollisions = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.chankGenerator.SuspendLayout();
            this.meshBuilder.SuspendLayout();
            this.mouseAndKeyboardEvents.SuspendLayout();
            this.playerCollisions.SuspendLayout();
            this.playerMoving.SuspendLayout();
            this.program.SuspendLayout();
            this.render.SuspendLayout();
            this.renderLineScene.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.editBlocksCollisions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 310);
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
            this.tabControl1.Size = new System.Drawing.Size(391, 310);
            this.tabControl1.TabIndex = 0;
            // 
            // chankGenerator
            // 
            this.chankGenerator.Controls.Add(this.textBox1);
            this.chankGenerator.Location = new System.Drawing.Point(4, 22);
            this.chankGenerator.Name = "chankGenerator";
            this.chankGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.chankGenerator.Size = new System.Drawing.Size(383, 284);
            this.chankGenerator.TabIndex = 0;
            this.chankGenerator.Text = "ChankGenerator";
            this.chankGenerator.UseVisualStyleBackColor = true;
            // 
            // meshBuilder
            // 
            this.meshBuilder.Controls.Add(this.textBox3);
            this.meshBuilder.Location = new System.Drawing.Point(4, 22);
            this.meshBuilder.Name = "meshBuilder";
            this.meshBuilder.Size = new System.Drawing.Size(383, 284);
            this.meshBuilder.TabIndex = 2;
            this.meshBuilder.Text = "MeshBuilder";
            this.meshBuilder.UseVisualStyleBackColor = true;
            // 
            // mouseAndKeyboardEvents
            // 
            this.mouseAndKeyboardEvents.Controls.Add(this.textBox4);
            this.mouseAndKeyboardEvents.Location = new System.Drawing.Point(4, 22);
            this.mouseAndKeyboardEvents.Name = "mouseAndKeyboardEvents";
            this.mouseAndKeyboardEvents.Size = new System.Drawing.Size(383, 284);
            this.mouseAndKeyboardEvents.TabIndex = 3;
            this.mouseAndKeyboardEvents.Text = "MouseAndKeyboardEvents";
            this.mouseAndKeyboardEvents.UseVisualStyleBackColor = true;
            // 
            // playerCollisions
            // 
            this.playerCollisions.Controls.Add(this.textBox5);
            this.playerCollisions.Location = new System.Drawing.Point(4, 22);
            this.playerCollisions.Name = "playerCollisions";
            this.playerCollisions.Size = new System.Drawing.Size(383, 284);
            this.playerCollisions.TabIndex = 4;
            this.playerCollisions.Text = "PlayerCollisions";
            this.playerCollisions.UseVisualStyleBackColor = true;
            // 
            // playerMoving
            // 
            this.playerMoving.Controls.Add(this.textBox6);
            this.playerMoving.Location = new System.Drawing.Point(4, 22);
            this.playerMoving.Name = "playerMoving";
            this.playerMoving.Size = new System.Drawing.Size(383, 284);
            this.playerMoving.TabIndex = 5;
            this.playerMoving.Text = "PlayerMoving";
            this.playerMoving.UseVisualStyleBackColor = true;
            // 
            // program
            // 
            this.program.Controls.Add(this.textBox7);
            this.program.Location = new System.Drawing.Point(4, 22);
            this.program.Name = "program";
            this.program.Size = new System.Drawing.Size(383, 284);
            this.program.TabIndex = 6;
            this.program.Text = "Program";
            this.program.UseVisualStyleBackColor = true;
            // 
            // render
            // 
            this.render.Controls.Add(this.textBox9);
            this.render.Location = new System.Drawing.Point(4, 22);
            this.render.Name = "render";
            this.render.Size = new System.Drawing.Size(383, 284);
            this.render.TabIndex = 7;
            this.render.Text = "Render";
            this.render.UseVisualStyleBackColor = true;
            // 
            // renderLineScene
            // 
            this.renderLineScene.Controls.Add(this.textBox8);
            this.renderLineScene.Location = new System.Drawing.Point(4, 22);
            this.renderLineScene.Name = "renderLineScene";
            this.renderLineScene.Size = new System.Drawing.Size(383, 284);
            this.renderLineScene.TabIndex = 8;
            this.renderLineScene.Text = "RenderLineScene";
            this.renderLineScene.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(377, 278);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(383, 284);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(0, 0);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox4.Size = new System.Drawing.Size(383, 284);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Location = new System.Drawing.Point(0, 0);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox5.Size = new System.Drawing.Size(383, 284);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Text;\r\n\r\nnamespace" +
    " WindowsFormsApp1\r\n{\r\n    public static class PlayerCollisions\r\n    {\r\n\r\n    }\r\n" +
    "}\r\n";
            // 
            // textBox6
            // 
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Location = new System.Drawing.Point(0, 0);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox6.Size = new System.Drawing.Size(383, 284);
            this.textBox6.TabIndex = 1;
            this.textBox6.Text = resources.GetString("textBox6.Text");
            // 
            // textBox7
            // 
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Location = new System.Drawing.Point(0, 0);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox7.Size = new System.Drawing.Size(383, 284);
            this.textBox7.TabIndex = 1;
            this.textBox7.Text = resources.GetString("textBox7.Text");
            // 
            // textBox8
            // 
            this.textBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox8.Location = new System.Drawing.Point(0, 0);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox8.Size = new System.Drawing.Size(383, 284);
            this.textBox8.TabIndex = 1;
            this.textBox8.Text = resources.GetString("textBox8.Text");
            // 
            // textBox9
            // 
            this.textBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox9.Location = new System.Drawing.Point(0, 0);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox9.Size = new System.Drawing.Size(383, 284);
            this.textBox9.TabIndex = 1;
            this.textBox9.Text = resources.GetString("textBox9.Text");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(391, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenu_Compile,
            this.сохранитьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.программаToolStripMenuItem.Text = "Программа";
            // 
            // toolMenu_Compile
            // 
            this.toolMenu_Compile.Name = "toolMenu_Compile";
            this.toolMenu_Compile.Size = new System.Drawing.Size(180, 22);
            this.toolMenu_Compile.Text = "Компилировать";
            this.toolMenu_Compile.Click += new System.EventHandler(this.toolMenu_Compile_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(377, 278);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // editBlocksCollisions
            // 
            this.editBlocksCollisions.Controls.Add(this.textBox2);
            this.editBlocksCollisions.Location = new System.Drawing.Point(4, 22);
            this.editBlocksCollisions.Name = "editBlocksCollisions";
            this.editBlocksCollisions.Padding = new System.Windows.Forms.Padding(3);
            this.editBlocksCollisions.Size = new System.Drawing.Size(383, 284);
            this.editBlocksCollisions.TabIndex = 1;
            this.editBlocksCollisions.Text = "EditBlocksCollisions";
            this.editBlocksCollisions.UseVisualStyleBackColor = true;
            // 
            // CompileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 334);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CompileEditor";
            this.Text = "Editor";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.chankGenerator.ResumeLayout(false);
            this.chankGenerator.PerformLayout();
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.editBlocksCollisions.ResumeLayout(false);
            this.editBlocksCollisions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage chankGenerator;
        private System.Windows.Forms.TabPage meshBuilder;
        private System.Windows.Forms.TabPage mouseAndKeyboardEvents;
        private System.Windows.Forms.TabPage playerCollisions;
        private System.Windows.Forms.TabPage playerMoving;
        private System.Windows.Forms.TabPage program;
        private System.Windows.Forms.TabPage render;
        private System.Windows.Forms.TabPage renderLineScene;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolMenu_Compile;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.TabPage editBlocksCollisions;
        private System.Windows.Forms.TextBox textBox2;
    }
}

