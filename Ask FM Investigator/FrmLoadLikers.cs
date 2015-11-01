using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ask_FM_Investigator
{
    public partial class FrmLoadLikers : Form
    {
        private long p;

        public FrmLoadLikers()
        {
            InitializeComponent();
        }

        public FrmLoadLikers(long p)
        {
            InitializeComponent();

            this.textBox1.Text = p.ToString();
        }
    }
}
