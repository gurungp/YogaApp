﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YogaApp
{
    public partial class TutorialPage : Form
    {
        CategoryPage categoryPage;
        public TutorialPage(CategoryPage cP)
        {
            InitializeComponent();
            categoryPage = cP;
        }

        private void playVideobutton_Click(object sender, EventArgs e)
        {
            string path = "https://www.youtube.com/v/rSgIZ4wW8Fw?autoplay=1";
            axShockwaveFlash1.LoadMovie(0, path);
        }
      

        private void backPreviousbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            categoryPage.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - categoryPage.Width) / 2,
                         (Screen.PrimaryScreen.WorkingArea.Height - categoryPage.Height) / 2);
            categoryPage.Show();
            
        }
    }
}
