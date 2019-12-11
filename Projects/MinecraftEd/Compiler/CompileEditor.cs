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

            using (CSharpCodeProvider cscp = new CSharpCodeProvider())
            {
                CompilerParameters cp = new CompilerParameters();
                TempFileCollection tfc = new TempFileCollection(@"\Temp");
                CompilerResults cr = new CompilerResults(tfc);

                cp.GenerateExecutable = true;
                cp.GenerateInMemory = false;
                cp.OutputAssembly = "test.exe";

                cr = cscp.CompileAssemblyFromSource(cp, code);

                ce.listBox1.Items.Clear();
                for (int a = 0; a < cr.Errors.Count; a++)
                    ce.listBox1.Items.Add("Error: " +
                        " (File Name) " + cr.Errors[a].FileName +
                        " (Error Message) " + cr.Errors[a].ErrorText +
                        " (Error Line) " + cr.Errors[a].ErrorNumber);

                ce.Show();
            }
        }
    }
}
