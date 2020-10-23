using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIPIMSample
{
    public partial class Form2 : Form
    {
        private bool Accept = true;
        public bool GetAccept()
        {
            return Accept;
        }
        public Form2()
        {
            InitializeComponent();
        }
        public void SetContactName(string ContactName)
        {
            lblFrom.Text = ContactName;
        }
        public void SetSubject(string Subject)
        {
            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accept = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accept = false;
            Close();
        }
    }
}