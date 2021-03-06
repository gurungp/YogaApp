﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using YogaApp.Utils;


namespace YogaApp
{
    public partial class TutorialPage : Form
    {
        delegate void SetAppCloseCallback(Button btn);

        CategoryPage categoryPage;
        CategoryList categoryList;
        public string exchangeName = null;
        public string videoPath = null;
        public string videoDescription = null;


        public TutorialPage(CategoryPage cP)
        {
            InitializeComponent();
            categoryPage = cP;
        }

        public TutorialPage(CategoryList cL)
        {
            InitializeComponent();
            categoryList = cL;

            // add video local path
            try
            {
                exchangeName = categoryList.getName().Name;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            
        }

        private void playVideobutton_Click(object sender, EventArgs e)
        {
            exchangeName = categoryList.getName().Name;
            videoPath = compareVideoPath(exchangeName);
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            path += videoPath;
            axWindowsMediaPlayer1.URL = path;

            // add other post here
        }


        private void backPreviousbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            categoryList.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - categoryList.Width) / 2,
                         (Screen.PrimaryScreen.WorkingArea.Height - categoryList.Height) / 2);
            categoryList.Show();
            axWindowsMediaPlayer1.close();
            foreach (var process in Process.GetProcessesByName("KinectExplorer-D2D"))
            {
                Console.WriteLine(process.ToString());
                process.Kill();
            }
        }

        private void tryPoseButton_Click(object sender, EventArgs e)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            path += "\\..\\..\\KinectExplorer-D2D\\Debug\\KinectExplorer-D2D.exe";
            //Process.Start(path);

            Process cppApp = new Process();
            cppApp.Exited += new EventHandler(cppApp_Exited);
            cppApp.StartInfo.FileName = path;
            cppApp.EnableRaisingEvents = true;
            cppApp.Start();
        }

        void cppApp_Exited(object sender, EventArgs e)
        {
            clickBackButton(button4);
        }

        void clickBackButton(Button btn)
        {
            if (button4.InvokeRequired)
            {
                SetAppCloseCallback d = new SetAppCloseCallback(clickBackButton);
                Invoke(d, new object[] { btn });
            } else
            {
                btn.PerformClick();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
            exchangeName = categoryList.getName().Name;
            videoDescription = compareVideoDescription(exchangeName);
            richTextBox1.Text = videoDescription;
        }

        public string compareVideoPath(string ExchangeName)
        {
            return ExcelReader.getExcelFile("PoseData.xlsx", ExchangeName + "VideoPath");
        }

        public string compareVideoDescription(string ExchangeName)
        {
            return ExcelReader.getExcelFile("PoseData.xlsx", ExchangeName + "VideoDescription");
        }
    }
}
