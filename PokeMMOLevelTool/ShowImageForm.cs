using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeMMOLevelTool
{
    public partial class ShowImageForm : Form
    {
        public ShowImageForm(Image img)
        {
            image = img;
            InitializeComponent();
        }

        Image image;

        private void ShowImageForm_Load(object sender, EventArgs e)
        {
            pictureBox_showPic.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_showPic.Image = image;
        }
    }
}
