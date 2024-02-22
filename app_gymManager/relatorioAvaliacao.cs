using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public partial class relatorioAvaliacao : Form
    {
        private int id;
        public relatorioAvaliacao(int id)
        {
            this.id = id;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmRelatorioAvaliacao_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Dock = DockStyle.Fill;
            this.AVALIACAOALUNOTableAdapter.Fill(this.dbgymmanagerDataSet.AVALIACAOALUNO);
            string sql = $"SELECT * FROM AVALIACAOALUNO WHERE ID = '{id}'";
            string idaluno = conexaoBanco.GetRowAsString(sql, "IDALUNO");
            string sqlAluno = $"SELECT * FROM LUSUARIO WHERE ID = '{idaluno}'";


            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", conexaoBanco.GetDataTable(sql)));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", conexaoBanco.GetDataTable(sqlAluno)));
            this.reportViewer1.RefreshReport();
            
        }
    }
}
