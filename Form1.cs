using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace ClickSharp
{
    public partial class Form1 : Form
    {
        private ulong click;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            click = 0;
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            click++;
            label2.Text = click + "";
            MakeItem("点击次数 +1(共" + click + "次)");
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 清零ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click = 0;
            label2.Text = click + "";
            MakeItem("点击次数清零！");
        }
        private void MakeItem(string text)
        {
            listBox1.Items.Add("[" + DateTime.Now.ToLocalTime().ToString() + "]" + text);
            listBox1.SelectedItem = "[" + DateTime.Now.ToLocalTime().ToString() + "]" + text;
        }

        private void 设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("输入数值：", "设置");
            click = Convert.ToUInt64(str);
            label2.Text = click + "";
            MakeItem("设置数值:" + click);
        }

        private void 文本文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            saveFileDialog1.Filter = "文本文档（*.txt）|*.txt|任意文档（*.*）|*.*|日志文件（*.log）|*.log";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName.ToString(); //获得文件路径
                                                            //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                //给文件名前加上时间
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                //在文件名里加字符
                //saveFileDialog1.FileName.Insert(1,"dameng");

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                ////fs输出带文字或图片的文件，就看需求了
                string all = "";
                foreach (string i in listBox1.Items)
                {
                    all = all + i + '\n';
                }
                File.WriteAllText(path, all);
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ClickSharp v1.0\nMade with C#.NET\n.NET版本 3.5\n作者:Jrh <1424636645@qq.com>", "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
