
namespace app_gymManager
{
    partial class relatorioAvaliacao
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.AVALIACAOALUNOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbgymmanagerDataSet = new app_gymManager.dbgymmanagerDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AVALIACAOALUNOTableAdapter = new app_gymManager.dbgymmanagerDataSetTableAdapters.AVALIACAOALUNOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.AVALIACAOALUNOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgymmanagerDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // AVALIACAOALUNOBindingSource
            // 
            this.AVALIACAOALUNOBindingSource.DataMember = "AVALIACAOALUNO";
            this.AVALIACAOALUNOBindingSource.DataSource = this.dbgymmanagerDataSet;
            // 
            // dbgymmanagerDataSet
            // 
            this.dbgymmanagerDataSet.DataSetName = "dbgymmanagerDataSet";
            this.dbgymmanagerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.AVALIACAOALUNOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "app_gymManager.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(629, 578);
            this.reportViewer1.TabIndex = 0;
            // 
            // AVALIACAOALUNOTableAdapter
            // 
            this.AVALIACAOALUNOTableAdapter.ClearBeforeFill = true;
            // 
            // relatorioAvaliacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(625, 576);
            this.Controls.Add(this.reportViewer1);
            this.Name = "relatorioAvaliacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avaliação Individual";
            this.Load += new System.EventHandler(this.frmRelatorioAvaliacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AVALIACAOALUNOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgymmanagerDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource AVALIACAOALUNOBindingSource;
        private dbgymmanagerDataSet dbgymmanagerDataSet;
        private dbgymmanagerDataSetTableAdapters.AVALIACAOALUNOTableAdapter AVALIACAOALUNOTableAdapter;
    }
}