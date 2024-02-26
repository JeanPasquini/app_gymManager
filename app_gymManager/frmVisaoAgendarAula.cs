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
    public partial class frmVisaoAgendarAula : Form
    {

        private int proximaPosicaoX = 60;
        private int proximaPosicaoY = 20;
        private int paineisPorLinha = 8; 
        private int contadorPaineis = 0;

        public frmVisaoAgendarAula()
        {
            InitializeComponent();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            AtualizaGrid();
        }

        private void txtVerGrid_Click(object sender, EventArgs e)
        {
            //AtualizaGrid();
        }

        Panel novoPanel;
        private void AtualizaGrid()
        {
            string sql = "SELECT * FROM AULASDISPONIVEIS WHERE ESTADO = 'Disponível'";
            DataTable dataTable = conexaoBanco.GetDataTable(sql);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string titulo = row["TITULO"].ToString();
                    string descricao = row["DESCRICAO"].ToString();
                    string professores = row["PROFESSORES"].ToString();
                    string status = row["ESTADO"].ToString();
                    DateTime dataHora;
                    string dataHoraString = row["DATAHORARIO"].ToString();
                    if (DateTime.TryParse(dataHoraString, out dataHora)) { }
                    string sqlverificar = $"SELECT * FROM AULAINFORMACAO WHERE IDALUNO = '{conexaoBanco.idUser}' AND IDAULA = '{id}'";
                    string valor = conexaoBanco.GetRowAsString(sqlverificar, "ID");
                    if (!string.IsNullOrEmpty(valor))
                    {
                        valor = "Participando";
                    }
                    else
                    {
                        valor = "Disponível";
                    }


                    novoPanel = new Panel();
                    novoPanel.Size = new Size(210, 200);
                    novoPanel.Location = new Point(proximaPosicaoX, proximaPosicaoY);
                    novoPanel.BackColor = Color.LightGray;
                    novoPanel.BorderStyle = BorderStyle.FixedSingle;

                    Label labelStatus = new Label();
                    labelStatus.Text = valor;
                    labelStatus.AutoSize = true;
                    labelStatus.Location = new Point(140, 10);

                    Label labelDiaHora = new Label();
                    labelDiaHora.Text = dataHoraString;
                    labelDiaHora.AutoSize = true;
                    labelDiaHora.Location = new Point(0, 10);

                    Label labelID = new Label();
                    labelID.Text = id;
                    labelID.Size = new Size(0, 0);
                    labelID.Name = "lblid";

                    Button novoButton = new Button();
                    novoButton.Text = "Inscrever-se na Aula";
                    novoButton.Size = new Size(210, 50);
                    novoButton.Location = new Point(0, 150);
                    novoButton.Name = "btnEscolherAula";
                    novoButton.Tag = id;
                    novoButton.Click += NovoButton_Click;

                    TextBox textBoxTitulo = new TextBox();
                    textBoxTitulo.Size = new Size(210, 30);
                    textBoxTitulo.Location = new Point(0, 30);
                    textBoxTitulo.Name = "textBoxTitulo";
                    textBoxTitulo.Text = titulo;
                    textBoxTitulo.ReadOnly = true;

                    TextBox textBoxDescricao = new TextBox();
                    textBoxDescricao.Size = new Size(210, 80);
                    textBoxDescricao.Multiline = true;
                    textBoxDescricao.ScrollBars = ScrollBars.Vertical;
                    textBoxDescricao.Location = new Point(0, 50);
                    textBoxDescricao.Text = descricao;
                    textBoxDescricao.ReadOnly = true;

                    TextBox textBoxProfessores = new TextBox();
                    textBoxProfessores.Size = new Size(210, 30);
                    textBoxProfessores.Location = new Point(0, 130);
                    textBoxProfessores.Text = professores;
                    textBoxProfessores.ReadOnly = true;

                    novoPanel.Controls.Add(textBoxProfessores);
                    novoPanel.Controls.Add(textBoxTitulo);
                    novoPanel.Controls.Add(textBoxDescricao);
                    novoPanel.Controls.Add(novoButton);
                    novoPanel.Controls.Add(labelID);
                    novoPanel.Controls.Add(labelStatus);
                    novoPanel.Controls.Add(labelDiaHora);

                    flowLayoutPanel1.Controls.Add(novoPanel);

                    contadorPaineis++;
                    if (contadorPaineis % paineisPorLinha == 0)
                    {
                        proximaPosicaoY += novoPanel.Height + 10;
                        proximaPosicaoX = 60;
                    }
                    else
                    {
                        proximaPosicaoX += novoPanel.Width + 10;
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum resultado encontrado.");
            }
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && btn.Tag != null)
            {
                string aulaId = btn.Tag.ToString();

                frmCadastroAula frm = new frmCadastroAula(true, int.Parse(aulaId));
                frm.ShowDialog();
            }
        }
    }
}
