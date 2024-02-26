
namespace app_gymManager
{
    partial class frmCadastroAula
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProfessores = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTituloAula = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricaoAula = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQtdeAlunos = new System.Windows.Forms.TextBox();
            this.txtHoraAula = new System.Windows.Forms.MaskedTextBox();
            this.txtDataAula = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParticiparAula = new System.Windows.Forms.Button();
            this.btnVerParticipantes = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(171, 352);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(252, 352);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 5;
            this.btnCadastrar.Text = "Criar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtProfessores);
            this.groupBox2.Location = new System.Drawing.Point(12, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 70);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Membros Inferiores";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Professores(as)";
            // 
            // txtProfessores
            // 
            this.txtProfessores.Location = new System.Drawing.Point(8, 41);
            this.txtProfessores.Name = "txtProfessores";
            this.txtProfessores.Size = new System.Drawing.Size(290, 20);
            this.txtProfessores.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Título da Aula";
            // 
            // txtTituloAula
            // 
            this.txtTituloAula.Location = new System.Drawing.Point(11, 39);
            this.txtTituloAula.Name = "txtTituloAula";
            this.txtTituloAula.Size = new System.Drawing.Size(287, 20);
            this.txtTituloAula.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDescricaoAula);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtTituloAula);
            this.groupBox3.Location = new System.Drawing.Point(12, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 187);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informações Aulas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descrição";
            // 
            // txtDescricaoAula
            // 
            this.txtDescricaoAula.Location = new System.Drawing.Point(11, 78);
            this.txtDescricaoAula.Multiline = true;
            this.txtDescricaoAula.Name = "txtDescricaoAula";
            this.txtDescricaoAula.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoAula.Size = new System.Drawing.Size(287, 87);
            this.txtDescricaoAula.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtStatus);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtQtdeAlunos);
            this.groupBox4.Controls.Add(this.txtHoraAula);
            this.groupBox4.Controls.Add(this.txtDataAula);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 65);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dados Aula";
            // 
            // txtStatus
            // 
            this.txtStatus.FormattingEnabled = true;
            this.txtStatus.Items.AddRange(new object[] {
            "Disponível",
            "Finalizada"});
            this.txtStatus.Location = new System.Drawing.Point(169, 36);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(96, 21);
            this.txtStatus.TabIndex = 21;
            this.txtStatus.Text = "Disponível";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Qtde";
            // 
            // txtQtdeAlunos
            // 
            this.txtQtdeAlunos.Location = new System.Drawing.Point(271, 36);
            this.txtQtdeAlunos.Name = "txtQtdeAlunos";
            this.txtQtdeAlunos.ReadOnly = true;
            this.txtQtdeAlunos.Size = new System.Drawing.Size(27, 20);
            this.txtQtdeAlunos.TabIndex = 16;
            this.txtQtdeAlunos.Text = "0";
            // 
            // txtHoraAula
            // 
            this.txtHoraAula.Location = new System.Drawing.Point(121, 36);
            this.txtHoraAula.Mask = "00:00";
            this.txtHoraAula.Name = "txtHoraAula";
            this.txtHoraAula.Size = new System.Drawing.Size(42, 20);
            this.txtHoraAula.TabIndex = 17;
            this.txtHoraAula.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataAula
            // 
            this.txtDataAula.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataAula.Location = new System.Drawing.Point(11, 36);
            this.txtDataAula.Name = "txtDataAula";
            this.txtDataAula.Size = new System.Drawing.Size(104, 20);
            this.txtDataAula.TabIndex = 16;
            this.txtDataAula.Value = new System.DateTime(2024, 2, 16, 10, 1, 14, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Dia da Aula";
            // 
            // btnParticiparAula
            // 
            this.btnParticiparAula.Location = new System.Drawing.Point(12, 352);
            this.btnParticiparAula.Name = "btnParticiparAula";
            this.btnParticiparAula.Size = new System.Drawing.Size(75, 23);
            this.btnParticiparAula.TabIndex = 24;
            this.btnParticiparAula.Text = "Participar";
            this.btnParticiparAula.UseVisualStyleBackColor = true;
            this.btnParticiparAula.Visible = false;
            this.btnParticiparAula.Click += new System.EventHandler(this.btnParticiparAula_Click);
            // 
            // btnVerParticipantes
            // 
            this.btnVerParticipantes.Location = new System.Drawing.Point(93, 352);
            this.btnVerParticipantes.Name = "btnVerParticipantes";
            this.btnVerParticipantes.Size = new System.Drawing.Size(72, 23);
            this.btnVerParticipantes.TabIndex = 25;
            this.btnVerParticipantes.Text = "Ver Part.";
            this.btnVerParticipantes.UseVisualStyleBackColor = true;
            this.btnVerParticipantes.Visible = false;
            this.btnVerParticipantes.Click += new System.EventHandler(this.btnVerParticipantes_Click);
            // 
            // frmCadastroAula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 383);
            this.Controls.Add(this.btnVerParticipantes);
            this.Controls.Add(this.btnParticiparAula);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmCadastroAula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aula";
            this.Load += new System.EventHandler(this.frmCadastroUsuario_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProfessores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTituloAula;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker txtDataAula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricaoAula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtHoraAula;
        private System.Windows.Forms.Button btnParticiparAula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQtdeAlunos;
        private System.Windows.Forms.ComboBox txtStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVerParticipantes;
    }
}