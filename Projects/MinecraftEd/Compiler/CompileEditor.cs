using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.IO;

namespace Compiler
{
    public partial class CompileEditor : Form
    {
        public CompileEditor()
        {
            InitializeComponent();
        }

        private FormErrors ce = null;

        private void toolMenu_Compile_Click(object sender, EventArgs e)
        {
            ce = new FormErrors();

            string[] code = new string[9];
            code[0] = textBox1.Text;
            code[1] = textBox2.Text;
            code[2] = textBox3.Text;
            code[3] = textBox4.Text;
            code[4] = textBox5.Text;
            code[5] = textBox6.Text;
            code[6] = textBox7.Text;
            code[7] = textBox8.Text;
            code[8] = textBox9.Text;
            code[9] = textBox10.Text;

            using (CSharpCodeProvider cscp = new CSharpCodeProvider())
            {
                CompilerParameters cp = new CompilerParameters();
                TempFileCollection tfc = new TempFileCollection(@"\Temp");
                CompilerResults cr = new CompilerResults(tfc);

                cp.ReferencedAssemblies.Add("Microsoft.DirectX.AudioVideoPlayback.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.Diagnostics.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.Direct3D.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.Direct3DX.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.DirectDraw.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.DirectInput.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.DirectPlay.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.DirectSound.dll");
                cp.ReferencedAssemblies.Add("Microsoft.DirectX.dll");
                cp.ReferencedAssemblies.Add("Microsoft.VisualC.dll");
                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("System.Data.dll");
                cp.ReferencedAssemblies.Add("System.Deployment.dll");
                cp.ReferencedAssemblies.Add("System.Drawing.dll");
                cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                cp.ReferencedAssemblies.Add("System.Xml.dll");

                //cp.LinkedResources.Add(");

                cp.GenerateExecutable = true;
                cp.GenerateInMemory = false;
                cp.OutputAssembly = "Game.exe";
                cp.TreatWarningsAsErrors = false;
                cp.WarningLevel = 4;
                cp.CompilerOptions = "-platform:x86 /unsafe";

                cr = cscp.CompileAssemblyFromSource(cp, code);

                ce.listBox1.Items.Clear();
                for (int a = 0; a < cr.Errors.Count; a++)
                    ce.listBox1.Items.Add("Error: " +
                        " (File Name) " + cr.Errors[a].FileName +
                        " (Error Message) " + cr.Errors[a].ErrorText +
                        " (Error Assembly) " + cr.PathToAssembly +
                        " (Error Line) " + cr.Errors[a].ErrorNumber);

                ce.Show();
            }
        }

        private void toolMenu_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
