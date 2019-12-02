using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static float[][] m1 = null;
        public static float[][] m2 = null;

        public static StringBuilder sb = null;

        private void Start(object sender, EventArgs e)
        {
            m1 = new float[3][];
            for (int y = 0; y < 3; y++) m1[y] = new float[3] { 0.0f, 0.0f, 0.0f };

            m2 = new float[3][];
            for (int y = 0; y < 3; y++) m2[y] = new float[3] { 0.0f, 0.0f, 0.0f };

            sb = new StringBuilder();
        }

        private void SetMatrixValue()
        {
            try
            {
                m1[0][0] = float.Parse(textBox1.Text);
                m1[0][1] = float.Parse(textBox2.Text);
                m1[0][2] = float.Parse(textBox3.Text);
                m1[1][0] = float.Parse(textBox4.Text);
                m1[1][1] = float.Parse(textBox5.Text);
                m1[1][2] = float.Parse(textBox6.Text);
                m1[2][0] = float.Parse(textBox7.Text);
                m1[2][1] = float.Parse(textBox8.Text);
                m1[2][2] = float.Parse(textBox9.Text);
            }
            catch { }
        }

        private void DivMatrixVectors()
        {
            m2 = m1;
            try
            {
                m2[0][0] = float.Parse(textBox10.Text) - m1[0][0];
                m2[0][1] = float.Parse(textBox11.Text) - m1[0][0];
                m2[0][2] = float.Parse(textBox12.Text) - m1[0][0];

                m2[1][0] = m1[1][0] - m1[0][1];
                m2[1][1] = m1[1][1] - m1[0][1];
                m2[1][2] = m1[1][2] - m1[0][1];

                m2[2][0] = m1[2][0] - m1[0][2];
                m2[2][1] = m1[2][1] - m1[0][2];
                m2[2][2] = m1[2][2] - m1[0][2];
            }
            catch { }
        }

        private void SetTextInfo()
        {
            sb.Clear();

            sb.Append("ax: " + m2[0][0] + " ");
            sb.Append("ay: " + m2[0][1] + " ");
            sb.Append("az: " + m2[0][2] + " ");

            sb.Append("\n");

            sb.Append("bx: " + m2[1][0] + " ");
            sb.Append("by: " + m2[1][1] + " ");
            sb.Append("bz: " + m2[1][2] + " ");

            sb.Append("\n");

            sb.Append("cx: " + m2[2][0] + " ");
            sb.Append("cy: " + m2[2][1] + " ");
            sb.Append("cz: " + m2[2][2] + " ");

            label1.Text = sb.ToString();
        }

        private void Update(object sender, EventArgs e)
        {
            SetMatrixValue();
            DivMatrixVectors();
            SetTextInfo();
        }

        private void Quit(object sender, FormClosingEventArgs e)
        {
            sb.Clear();
        }
    }
}
