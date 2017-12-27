using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Auto_Junk_Adder
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count;
        int runt;
        string file;
        string VarType;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\run.bat"))
                File.Delete(Directory.GetCurrentDirectory() + "\\run.bat");

            MessageBox.Show("Made by Thaisen and Peatreat\nMake sure this program is in the same folder as your source.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK);
            string[] lines = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\", "*.cpp", SearchOption.AllDirectories);
            listBox1.Items.AddRange(lines);
            listBox2.Select();
            listBox2.Focus();
            label2.Text = "Count: " + count;
            label3.Text = "Total: " + listBox1.Items.Count;
            timer1.Interval = metroTrackBar3.Value;
            timer2.Interval = metroTrackBar3.Value;

            metroComboBox1.Items.Add("Int");
            metroComboBox1.Items.Add("Float");
            metroComboBox1.Items.Add("Long");
            metroComboBox1.Items.Add("Double");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (metroComboBox1.Text == "")
                {
                    MessageBox.Show("Please choose a data type.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK);
                    return;
                }

                count = 0;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("No \".cpp\" files were found.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK);
                return;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            count = 0;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                string[] sln = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\", "*.sln", SearchOption.TopDirectoryOnly);
                listBox2.Items.AddRange(sln);
                if (listBox2.Items.Count > 0)
                {
                    string path = Directory.GetCurrentDirectory() + "\\run.bat";

                    if (!File.Exists(path))
                    {
                        using (var tw = new StreamWriter(path, true))
                        {
                            tw.WriteLine("@echo OFF ");
                            tw.WriteLine("echo *ONLY WORKS FOR VISUAL STUDIO 2017* ");
                            tw.WriteLine("set /p Product=Enter your Visual Studio Product (Community, Enterprise, Professional): ");
                            tw.WriteLine("call \"C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\%Product%\\VC\\Auxiliary\\Build\\vcvarsall.bat\" x86");
                            tw.WriteLine("echo Starting Build for all Projects with proposed changes");
                            tw.WriteLine("\n");
                            tw.WriteLine("set /p Solution=Enter your solution file (Name + Extension): ");
                            tw.WriteLine("devenv \"%~dp0%Solution% \" /build Release ");
                            tw.WriteLine("echo \n");
                            tw.WriteLine("echo All builds completed. ");
                            tw.WriteLine("pause");
                            tw.Close();
                        }
                    }

                    Process proc = null;
                    proc = new Process();
                    proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\";
                    proc.StartInfo.FileName = "run.bat";
                    proc.StartInfo.CreateNoWindow = true;
                    proc.Start();
                    proc.WaitForExit();
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\run.bat"))
                        File.Delete(Directory.GetCurrentDirectory() + "\\run.bat");
                }
                else
                {
                    MessageBox.Show("Place this program in the directory of your \".sln\" file before trying to build.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                MessageBox.Show("Stop generating junk before trying to build.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (timer1.Enabled == false)
                {
                    count = 0;
                    timer2.Start();
                }
                else
                {
                    MessageBox.Show("Please stop generating junk before trying to remove junk.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No \".cpp\" files were found.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void metroTrackBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            metroLabel2.Text = "Var Length: " + metroTrackBar1.Value;
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            metroLabel3.Text = "Func Length: " + metroTrackBar2.Value;
        }

        private void metroTrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            metroLabel4.Text = "Speed: " + metroTrackBar3.Value + " ms";
            timer1.Interval = metroTrackBar3.Value;
            timer2.Interval = metroTrackBar3.Value;
        }

        string Junk;

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Write()
        {

            Random random = new Random();
            int num0 = random.Next(1, 0x5f5e100);
            int num1 = random.Next(1, 0x5f5e100);
            int num2 = random.Next(1, 0x5f5e100);
            int num3 = random.Next(1, 0x5f5e100);
            int num4 = random.Next(1, 0x5f5e100);
            int num5 = random.Next(1, 0x5f5e100);
            int num6 = random.Next(1, 0x5f5e100);
            int num7 = random.Next(1, 0x5f5e100);
            int num8 = random.Next(1, 0x5f5e100);
            int num9 = random.Next(1, 0x5f5e100);
            int num10 = random.Next(1, 0x5f5e100);
            int num11 = random.Next(1, 0x5f5e100);
            int num12 = random.Next(1, 0x5f5e100);
            int num13 = random.Next(1, 0x5f5e100);
            int num14 = random.Next(1, 0x5f5e100);
            int num15 = random.Next(1, 0x5f5e100);
            int num16 = random.Next(1, 0x5f5e100);
            int num17 = random.Next(1, 0x5f5e100);
            int num18 = random.Next(1, 0x5f5e100);
            int num19 = random.Next(1, 0x5f5e100);
            int num20 = random.Next(1, 0x5f5e100);
            int num21 = random.Next(1, 0x5f5e100);
            int num22 = random.Next(1, 0x5f5e100);
            int num23 = random.Next(1, 0x5f5e100);
            int num24 = random.Next(1, 0x5f5e100);
            int num25 = random.Next(1, 0x5f5e100);
            int num26 = random.Next(1, 0x5f5e100);
            int num27 = random.Next(1, 0x5f5e100);
            int num28 = random.Next(1, 0x5f5e100);
            int num29 = random.Next(1, 0x5f5e100);
            int num30 = random.Next(1, 0x5f5e100);
            int num31 = random.Next(1, 0x5f5e100);
            int num32 = random.Next(1, 0x5f5e100);
            int num33 = random.Next(1, 0x5f5e100);
            int num34 = random.Next(1, 0x5f5e100);
            int num35 = random.Next(1, 0x5f5e100);
            int num36 = random.Next(1, 0x5f5e100);
            int num37 = random.Next(1, 0x5f5e100);
            int num38 = random.Next(1, 0x5f5e100);
            int num39 = random.Next(1, 0x5f5e100);
            int num40 = random.Next(1, 0x5f5e100);
            int num41 = random.Next(1, 0x5f5e100);
            int num42 = random.Next(1, 0x5f5e100);
            int num43 = random.Next(1, 0x5f5e100);
            int num44 = random.Next(1, 0x5f5e100);
            int num45 = random.Next(1, 0x5f5e100);
            int num46 = random.Next(1, 0x5f5e100);
            int num47 = random.Next(1, 0x5f5e100);
            int num48 = random.Next(1, 0x5f5e100);
            int num49 = random.Next(1, 0x5f5e100);
            int num50 = random.Next(1, 0x5f5e100);
            int num51 = random.Next(1, 0x5f5e100);
            int num52 = random.Next(1, 0x5f5e100);
            int num53 = random.Next(1, 0x5f5e100);
            int num54 = random.Next(1, 0x5f5e100);
            int num55 = random.Next(1, 0x5f5e100);
            int num56 = random.Next(1, 0x5f5e100);
            int num57 = random.Next(1, 0x5f5e100);
            int num58 = random.Next(1, 0x5f5e100);
            int num59 = random.Next(1, 0x5f5e100);
            int num60 = random.Next(1, 0x5f5e100);
            int num61 = random.Next(1, 0x5f5e100);
            int num62 = random.Next(1, 0x5f5e100);
            int num63 = random.Next(1, 0x5f5e100);
            int num64 = random.Next(1, 0x5f5e100);
            int num65 = random.Next(1, 0x5f5e100);
            int num66 = random.Next(1, 0x5f5e100);
            int num67 = random.Next(1, 0x5f5e100);
            int num68 = random.Next(1, 0x5f5e100);
            int num69 = random.Next(1, 0x5f5e100);
            int num70 = random.Next(1, 0x5f5e100);
            int num71 = random.Next(1, 0x5f5e100);
            int num72 = random.Next(1, 0x5f5e100);
            int num73 = random.Next(1, 0x5f5e100);
            int num74 = random.Next(1, 0x5f5e100);
            int num75 = random.Next(1, 0x5f5e100);
            int num76 = random.Next(1, 0x5f5e100);
            int num77 = random.Next(1, 0x5f5e100);
            int num78 = random.Next(1, 0x5f5e100);
            int num79 = random.Next(1, 0x5f5e100);
            int num80 = random.Next(1, 0x5f5e100);
            int num81 = random.Next(1, 0x5f5e100);
            int num82 = random.Next(1, 0x5f5e100);
            int num83 = random.Next(1, 0x5f5e100);
            int num84 = random.Next(1, 0x5f5e100);
            int num85 = random.Next(1, 0x5f5e100);
            int num86 = random.Next(1, 0x5f5e100);
            int num87 = random.Next(1, 0x5f5e100);
            int num88 = random.Next(1, 0x5f5e100);
            int num89 = random.Next(1, 0x5f5e100);
            int num90 = random.Next(1, 0x5f5e100);
            int num91 = random.Next(1, 0x5f5e100);
            int num92 = random.Next(1, 0x5f5e100);
            int num93 = random.Next(1, 0x5f5e100);
            int num94 = random.Next(1, 0x5f5e100);
            int num95 = random.Next(1, 0x5f5e100);
            int num96 = random.Next(1, 0x5f5e100);
            int num97 = random.Next(1, 0x5f5e100);
            int num98 = random.Next(1, 0x5f5e100);
            int num99 = random.Next(1, 0x5f5e100);
            int num100 = random.Next(1, 0x5f5e100);

            // Seperator

            int num101 = random.Next(-1000000000, 0x5f5e100);
            int num102 = random.Next(-1000000000, 0x5f5e100);
            int num103 = random.Next(-1000000000, 0x5f5e100);
            int num104 = random.Next(-1000000000, 0x5f5e100);
            int num105 = random.Next(-1000000000, 0x5f5e100);
            int num106 = random.Next(-1000000000, 0x5f5e100);
            int num107 = random.Next(-1000000000, 0x5f5e100);
            int num108 = random.Next(-1000000000, 0x5f5e100);
            int num109 = random.Next(-1000000000, 0x5f5e100);
            int num110 = random.Next(-1000000000, 0x5f5e100);
            int num111 = random.Next(-1000000000, 0x5f5e100);
            int num112 = random.Next(-1000000000, 0x5f5e100);
            int num113 = random.Next(-1000000000, 0x5f5e100);
            int num114 = random.Next(-1000000000, 0x5f5e100);
            int num115 = random.Next(-1000000000, 0x5f5e100);
            int num116 = random.Next(-1000000000, 0x5f5e100);
            int num117 = random.Next(-1000000000, 0x5f5e100);
            int num118 = random.Next(-1000000000, 0x5f5e100);
            int num119 = random.Next(-1000000000, 0x5f5e100);
            int num120 = random.Next(-1000000000, 0x5f5e100);
            int num121 = random.Next(-1000000000, 0x5f5e100);
            int num122 = random.Next(-1000000000, 0x5f5e100);
            int num123 = random.Next(-1000000000, 0x5f5e100);
            int num124 = random.Next(-1000000000, 0x5f5e100);
            int num125 = random.Next(-1000000000, 0x5f5e100);
            int num126 = random.Next(-1000000000, 0x5f5e100);
            int num127 = random.Next(-1000000000, 0x5f5e100);
            int num128 = random.Next(-1000000000, 0x5f5e100);
            int num129 = random.Next(-1000000000, 0x5f5e100);
            int num130 = random.Next(-1000000000, 0x5f5e100);
            int num131 = random.Next(-1000000000, 0x5f5e100);
            int num132 = random.Next(-1000000000, 0x5f5e100);
            int num133 = random.Next(-1000000000, 0x5f5e100);
            int num134 = random.Next(-1000000000, 0x5f5e100);
            int num135 = random.Next(-1000000000, 0x5f5e100);
            int num136 = random.Next(-1000000000, 0x5f5e100);
            int num137 = random.Next(-1000000000, 0x5f5e100);
            int num138 = random.Next(-1000000000, 0x5f5e100);
            int num139 = random.Next(-1000000000, 0x5f5e100);
            int num140 = random.Next(-1000000000, 0x5f5e100);
            int num141 = random.Next(-1000000000, 0x5f5e100);
            int num142 = random.Next(-1000000000, 0x5f5e100);
            int num143 = random.Next(-1000000000, 0x5f5e100);
            int num144 = random.Next(-1000000000, 0x5f5e100);
            int num145 = random.Next(-1000000000, 0x5f5e100);
            int num146 = random.Next(-1000000000, 0x5f5e100);
            int num147 = random.Next(-1000000000, 0x5f5e100);
            int num148 = random.Next(-1000000000, 0x5f5e100);
            int num149 = random.Next(-1000000000, 0x5f5e100);
            int num150 = random.Next(-1000000000, 0x5f5e100);
            int num151 = random.Next(-1000000000, 0x5f5e100);
            int num152 = random.Next(-1000000000, 0x5f5e100);
            int num153 = random.Next(-1000000000, 0x5f5e100);
            int num154 = random.Next(-1000000000, 0x5f5e100);
            int num155 = random.Next(-1000000000, 0x5f5e100);
            int num156 = random.Next(-1000000000, 0x5f5e100);
            int num157 = random.Next(-1000000000, 0x5f5e100);
            int num158 = random.Next(-1000000000, 0x5f5e100);
            int num159 = random.Next(-1000000000, 0x5f5e100);
            int num160 = random.Next(-1000000000, 0x5f5e100);
            int num161 = random.Next(-1000000000, 0x5f5e100);
            int num162 = random.Next(-1000000000, 0x5f5e100);
            int num163 = random.Next(-1000000000, 0x5f5e100);
            int num164 = random.Next(-1000000000, 0x5f5e100);
            int num165 = random.Next(-1000000000, 0x5f5e100);
            int num166 = random.Next(-1000000000, 0x5f5e100);
            int num167 = random.Next(-1000000000, 0x5f5e100);
            int num168 = random.Next(-1000000000, 0x5f5e100);
            int num169 = random.Next(-1000000000, 0x5f5e100);
            int num170 = random.Next(-1000000000, 0x5f5e100);
            int num171 = random.Next(-1000000000, 0x5f5e100);
            int num172 = random.Next(-1000000000, 0x5f5e100);
            int num173 = random.Next(-1000000000, 0x5f5e100);
            int num174 = random.Next(-1000000000, 0x5f5e100);
            int num175 = random.Next(-1000000000, 0x5f5e100);
            int num176 = random.Next(-1000000000, 0x5f5e100);
            int num177 = random.Next(-1000000000, 0x5f5e100);
            int num178 = random.Next(-1000000000, 0x5f5e100);
            int num179 = random.Next(-1000000000, 0x5f5e100);
            int num180 = random.Next(-1000000000, 0x5f5e100);
            int num181 = random.Next(-1000000000, 0x5f5e100);
            int num182 = random.Next(-1000000000, 0x5f5e100);
            int num183 = random.Next(-1000000000, 0x5f5e100);
            int num184 = random.Next(-1000000000, 0x5f5e100);
            int num185 = random.Next(-1000000000, 0x5f5e100);
            int num186 = random.Next(-1000000000, 0x5f5e100);
            int num187 = random.Next(-1000000000, 0x5f5e100);
            int num188 = random.Next(-1000000000, 0x5f5e100);
            int num189 = random.Next(-1000000000, 0x5f5e100);
            int num190 = random.Next(-1000000000, 0x5f5e100);
            int num191 = random.Next(-1000000000, 0x5f5e100);
            int num192 = random.Next(-1000000000, 0x5f5e100);
            int num193 = random.Next(-1000000000, 0x5f5e100);
            int num194 = random.Next(-1000000000, 0x5f5e100);
            int num195 = random.Next(-1000000000, 0x5f5e100);
            int num196 = random.Next(-1000000000, 0x5f5e100);
            int num197 = random.Next(-1000000000, 0x5f5e100);
            int num198 = random.Next(-1000000000, 0x5f5e100);
            int num199 = random.Next(-1000000000, 0x5f5e100);
            int num200 = random.Next(-1000000000, 0x5f5e100);

            string FunctionName = RandomString(metroTrackBar2.Value);
            string VarName = RandomString(metroTrackBar1.Value);

            Junk = "// Junk Code By Troll Face & Thaisen's Gen\n" +
            ("void " + FunctionName + num0 + "() ") +
            ("{ ") +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num1, " = " + num101, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num2, " = " + num102, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num3, " = " + num103, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num4, " = " + num104, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num5, " = " + num105, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num6, " = " + num106, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num7, " = " + num107, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num8, " = " + num108, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num9, " = " + num109, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num10, " = " + num110, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num11, " = " + num111, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num12, " = " + num112, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num13, " = " + num113, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num14, " = " + num114, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num15, " = " + num115, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num16, " = " + num116, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num17, " = " + num117, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num18, " = " + num118, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num19, " = " + num119, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num20, " = " + num120, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num21, " = " + num121, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num22, " = " + num122, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num23, " = " + num123, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num24, " = " + num124, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num25, " = " + num125, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num26, " = " + num126, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num27, " = " + num127, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num28, " = " + num128, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num29, " = " + num129, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num30, " = " + num130, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num31, " = " + num131, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num32, " = " + num132, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num33, " = " + num133, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num34, " = " + num134, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num35, " = " + num135, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num36, " = " + num136, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num37, " = " + num137, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num38, " = " + num138, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num39, " = " + num139, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num40, " = " + num140, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num41, " = " + num141, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num42, " = " + num142, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num43, " = " + num143, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num44, " = " + num144, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num45, " = " + num145, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num46, " = " + num146, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num47, " = " + num147, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num48, " = " + num148, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num49, " = " + num149, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num50, " = " + num150, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num51, " = " + num151, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num52, " = " + num152, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num53, " = " + num153, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num54, " = " + num154, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num55, " = " + num155, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num56, " = " + num156, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num57, " = " + num157, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num58, " = " + num158, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num59, " = " + num159, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num60, " = " + num160, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num61, " = " + num161, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num62, " = " + num162, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num63, " = " + num163, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num64, " = " + num164, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num65, " = " + num165, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num66, " = " + num166, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num67, " = " + num167, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num68, " = " + num168, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num69, " = " + num169, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num70, " = " + num170, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num71, " = " + num171, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num72, " = " + num172, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num73, " = " + num173, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num74, " = " + num174, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num75, " = " + num175, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num76, " = " + num176, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num77, " = " + num177, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num78, " = " + num178, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num79, " = " + num179, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num80, " = " + num180, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num81, " = " + num181, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num82, " = " + num182, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num83, " = " + num183, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num84, " = " + num184, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num85, " = " + num185, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num86, " = " + num186, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num87, " = " + num187, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num88, " = " + num188, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num89, " = " + num189, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num90, " = " + num190, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num91, " = " + num191, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num92, " = " + num192, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num93, " = " + num193, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num94, " = " + num194, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num95, " = " + num195, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num96, " = " + num196, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num97, " = " + num197, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num98, " = " + num198, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num99, " = " + num199, ";" })) +
(string.Concat(new object[] { "    " + VarType + " " + VarName, num100, " = " + num101, ";" })) +

///////////////////////////////////////////////////////////////////////////////////////////////

(string.Concat(new object[] { "    " + " " + VarName, num1, " = " + VarName, num2, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num2, " = " + VarName, num3, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num3, " = " + VarName, num4, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num4, " = " + VarName, num5, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num5, " = " + VarName, num6, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num6, " = " + VarName, num7, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num7, " = " + VarName, num8, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num8, " = " + VarName, num9, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num9, " = " + VarName, num10, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num10, " = " + VarName, num11, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num11, " = " + VarName, num12, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num12, " = " + VarName, num13, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num13, " = " + VarName, num14, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num14, " = " + VarName, num15, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num15, " = " + VarName, num16, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num16, " = " + VarName, num17, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num17, " = " + VarName, num18, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num18, " = " + VarName, num19, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num19, " = " + VarName, num20, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num20, " = " + VarName, num21, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num21, " = " + VarName, num22, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num22, " = " + VarName, num23, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num23, " = " + VarName, num24, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num24, " = " + VarName, num25, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num25, " = " + VarName, num26, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num26, " = " + VarName, num27, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num27, " = " + VarName, num28, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num28, " = " + VarName, num29, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num29, " = " + VarName, num30, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num30, " = " + VarName, num31, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num31, " = " + VarName, num32, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num32, " = " + VarName, num33, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num33, " = " + VarName, num34, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num34, " = " + VarName, num35, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num35, " = " + VarName, num36, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num36, " = " + VarName, num37, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num37, " = " + VarName, num38, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num38, " = " + VarName, num39, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num39, " = " + VarName, num40, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num40, " = " + VarName, num41, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num41, " = " + VarName, num42, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num42, " = " + VarName, num43, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num43, " = " + VarName, num44, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num44, " = " + VarName, num45, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num45, " = " + VarName, num46, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num46, " = " + VarName, num47, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num47, " = " + VarName, num48, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num48, " = " + VarName, num49, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num49, " = " + VarName, num50, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num50, " = " + VarName, num51, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num51, " = " + VarName, num52, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num52, " = " + VarName, num53, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num53, " = " + VarName, num54, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num54, " = " + VarName, num55, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num55, " = " + VarName, num56, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num56, " = " + VarName, num57, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num57, " = " + VarName, num58, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num58, " = " + VarName, num59, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num59, " = " + VarName, num60, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num60, " = " + VarName, num61, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num61, " = " + VarName, num62, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num62, " = " + VarName, num63, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num63, " = " + VarName, num64, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num64, " = " + VarName, num65, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num65, " = " + VarName, num66, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num66, " = " + VarName, num67, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num67, " = " + VarName, num68, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num68, " = " + VarName, num69, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num69, " = " + VarName, num70, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num70, " = " + VarName, num71, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num71, " = " + VarName, num72, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num72, " = " + VarName, num73, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num73, " = " + VarName, num74, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num74, " = " + VarName, num75, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num75, " = " + VarName, num76, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num76, " = " + VarName, num77, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num77, " = " + VarName, num78, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num78, " = " + VarName, num79, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num79, " = " + VarName, num80, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num80, " = " + VarName, num81, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num81, " = " + VarName, num82, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num82, " = " + VarName, num83, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num83, " = " + VarName, num84, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num84, " = " + VarName, num85, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num85, " = " + VarName, num86, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num86, " = " + VarName, num87, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num87, " = " + VarName, num88, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num88, " = " + VarName, num89, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num89, " = " + VarName, num90, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num90, " = " + VarName, num91, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num91, " = " + VarName, num92, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num92, " = " + VarName, num93, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num93, " = " + VarName, num94, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num94, " = " + VarName, num95, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num95, " = " + VarName, num96, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num96, " = " + VarName, num97, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num97, " = " + VarName, num98, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num98, " = " + VarName, num99, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num99, " = " + VarName, num100, ";" })) +
(string.Concat(new object[] { "    " + " " + VarName, num100, " = " + VarName, num1, ";" })) +
            ("}\n") +
            "// Junk Finished";

///////////////////////////////////////////////////////////////////////////////////////////////

            file = listBox1.Items[count].ToString();

            string existing = File.ReadAllText(file);
            string createText = existing + Environment.NewLine + Junk;

            File.WriteAllText(file, createText + Environment.NewLine);

            count = count + 1;
            label2.Text = "Count: " + count;
        }

        public void Delete()
        {
            string Pattern = "(// Junk Code By Troll Face & Thaisen's Gen)(.*?)(// Junk Finished)";
            Regex x = new Regex(Pattern, RegexOptions.Singleline);
            string file = listBox1.Items[count].ToString();
            string Text = File.ReadAllText(file);
            Text = x.Replace(Text, "");

            File.WriteAllText(file, Text);

            count = count + 1;
            label2.Text = "Count: " + count;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == listBox1.Items.Count)
            {
                count = 0;
                runt = runt + 1;
                label4.Text = "Passes: " + runt;
            }
            else
            {
                Write();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (count == listBox1.Items.Count)
            {
                count = 0;
                timer2.Stop();
                MessageBox.Show("Successfully removed all previous junk.", "Peatreat & Thaisen's Junk Generator", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Delete();
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VarType = metroComboBox1.Text.ToLower();
        }
    }
}
