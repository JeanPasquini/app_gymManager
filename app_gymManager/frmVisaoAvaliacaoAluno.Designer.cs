
namespace app_gymManager
{
    partial class frmVisaoAvaliacaoAluno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVerGrid = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEnviarAvaliacao = new System.Windows.Forms.ToolStripButton();
            this.btnVerAvaliacao = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 315);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerGrid,
            this.btnEditar,
            this.btnEnviarAvaliacao,
            this.btnVerAvaliacao});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnVerGrid
            // 
            this.btnVerGrid.Image = global::app_gymManager.Properties.Resources.rotation16;
            this.btnVerGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerGrid.Name = "btnVerGrid";
            this.btnVerGrid.Size = new System.Drawing.Size(67, 22);
            this.btnVerGrid.Text = "Ver grid";
            this.btnVerGrid.Click += new System.EventHandler(this.txtVerGrid_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::app_gymManager.Properties.Resources.list;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(69, 22);
            this.btnEditar.Text = "Analisar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEnviarAvaliacao
            // 
            this.btnEnviarAvaliacao.Image = global::app_gymManager.Properties.Resources.insert_32x32;
            this.btnEnviarAvaliacao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnviarAvaliacao.Name = "btnEnviarAvaliacao";
            this.btnEnviarAvaliacao.Size = new System.Drawing.Size(113, 22);
            this.btnEnviarAvaliacao.Text = "Enviar Avaliação";
            this.btnEnviarAvaliacao.Click += new System.EventHandler(this.btnEnviarAvaliacao_Click);
            // 
            // btnVerAvaliacao
            // 
            this.btnVerAvaliacao.Image = global::app_gymManager.Properties.Resources.printer;
            this.btnVerAvaliacao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerAvaliacao.Name = "btnVerAvaliacao";
            this.btnVerAvaliacao.Size = new System.Drawing.Size(127, 22);
            this.btnVerAvaliacao.Text = "Imprimir Avaliação";
            this.btnVerAvaliacao.Click += new System.EventHandler(this.btnVerAvaliacao_Click);
            // 
            // frmVisaoAvaliacaoAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 367);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVisaoAvaliacaoAluno";
            this.Text = "frmInfoVisao";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnVerGrid;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEnviarAvaliacao;
        private System.Windows.Forms.ToolStripButton btnVerAvaliacao;
    }
}