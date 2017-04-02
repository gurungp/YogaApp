﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YogaApp.Utils;

namespace YogaApp.Views
{
    /// <summary>
    /// Interaction logic for VideoIntro.xaml
    /// </summary>
    public partial class VideoIntro : Page
    {

        public VideoIntro(string value)
        {
            InitializeComponent();
            var name = value;
            Intro.Text = getIntro(name);
            Steps.Text = getSteps(name);
            Tips.Text = getTips(name);
        }

        private string getIntro(string name)
        {
            return ExcelReader.getExcelFile("PoseData.xlsx", name + "Intro");
        }

        private string getSteps(string name)
        {
            return ExcelReader.getExcelFile("PoseData.xlsx", name + "Steps");
        }

        private string getTips(string name)
        {
            return ExcelReader.getExcelFile("PoseData.xlsx", name + "Tips");
        }

        private void VideoPlay_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.Navigate(new Uri("Views/Video.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Kinect_Click(object sender, RoutedEventArgs e)
        {
            //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            string path =
                Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).FullName;

            path += "\\..\\..\\YogaApp-Kinect-cpp\\SkeletonBasics-D2D\\Debug\\SkeletonBasics-D2D.exe";
            Process.Start(path);
        }
    }
}
