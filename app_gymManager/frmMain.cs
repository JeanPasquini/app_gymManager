﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public partial class frmMain : Form
    {

        private List<ToolStrip> toolStrips = new List<ToolStrip>();
        public frmMain()
        {
            InitializeComponent();

            toolStrips.Add(toolStrip2);
            toolStrips.Add(toolStrip3);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MostrarToolStrip(toolStrip2);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MostrarToolStrip(toolStrip3);
        }
        private void MostrarToolStrip(ToolStrip toolStripAMostrar)
        {
            foreach (var toolStrip in toolStrips)
            {
                toolStrip.Visible = (toolStrip == toolStripAMostrar);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmInfoVisao frm = new frmInfoVisao();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.ControlBox = false;


            mainTela.Controls.Clear();
            mainTela.Controls.Add(frm);

            frm.Show();
        }
    }
}