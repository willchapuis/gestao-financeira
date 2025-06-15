namespace GestaoFinanceira.Forms
{
    partial class LancamentosForm
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
            tcLancamentos = new TabControl();
            tpDespesas = new TabPage();
            tpReceitas = new TabPage();
            gcDespesas = new DevExpress.XtraGrid.GridControl();
            gvDespesas = new DevExpress.XtraGrid.Views.Grid.GridView();
            SEQ_DESPESA = new DevExpress.XtraGrid.Columns.GridColumn();
            gcDataCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            gcValorTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            gcMetodoPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            gcCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            gcEditarDespesa = new DevExpress.XtraGrid.Columns.GridColumn();
            gcExcluirDespes = new DevExpress.XtraGrid.Columns.GridColumn();
            gcDescricaoDespesa = new DevExpress.XtraGrid.Columns.GridColumn();
            gcParcelas = new DevExpress.XtraGrid.Columns.GridColumn();
            btnVerParcelas = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnEditarDespesa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnExcluirDespesa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            gbDataCompra = new GroupBox();
            dateTimePicker2 = new DateTimePicker();
            tcLancamentos.SuspendLayout();
            tpDespesas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcDespesas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDespesas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVerParcelas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEditarDespesa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnExcluirDespesa).BeginInit();
            gbDataCompra.SuspendLayout();
            SuspendLayout();
            // 
            // tcLancamentos
            // 
            tcLancamentos.Controls.Add(tpDespesas);
            tcLancamentos.Controls.Add(tpReceitas);
            tcLancamentos.Dock = DockStyle.Fill;
            tcLancamentos.Location = new Point(0, 0);
            tcLancamentos.Name = "tcLancamentos";
            tcLancamentos.SelectedIndex = 0;
            tcLancamentos.Size = new Size(800, 576);
            tcLancamentos.TabIndex = 0;
            // 
            // tpDespesas
            // 
            tpDespesas.BackColor = SystemColors.GradientInactiveCaption;
            tpDespesas.Controls.Add(gbDataCompra);
            tpDespesas.Controls.Add(gcDespesas);
            tpDespesas.Location = new Point(4, 24);
            tpDespesas.Name = "tpDespesas";
            tpDespesas.Padding = new Padding(3);
            tpDespesas.Size = new Size(792, 548);
            tpDespesas.TabIndex = 0;
            tpDespesas.Text = "Despesas";
            // 
            // tpReceitas
            // 
            tpReceitas.BackColor = SystemColors.GradientInactiveCaption;
            tpReceitas.Location = new Point(4, 24);
            tpReceitas.Name = "tpReceitas";
            tpReceitas.Padding = new Padding(3);
            tpReceitas.Size = new Size(792, 422);
            tpReceitas.TabIndex = 1;
            tpReceitas.Text = "Receitas";
            // 
            // gcDespesas
            // 
            gcDespesas.Dock = DockStyle.Bottom;
            gcDespesas.Location = new Point(3, 280);
            gcDespesas.MainView = gvDespesas;
            gcDespesas.Name = "gcDespesas";
            gcDespesas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { btnVerParcelas, btnEditarDespesa, btnExcluirDespesa });
            gcDespesas.Size = new Size(786, 265);
            gcDespesas.TabIndex = 0;
            gcDespesas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvDespesas });
            // 
            // gvDespesas
            // 
            gvDespesas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { SEQ_DESPESA, gcDescricaoDespesa, gcCategoria, gcDataCompra, gcValorTotal, gcStatus, gcMetodoPagamento, gcParcelas, gcEditarDespesa, gcExcluirDespes });
            gvDespesas.GridControl = gcDespesas;
            gvDespesas.Name = "gvDespesas";
            gvDespesas.OptionsView.ShowFooter = true;
            // 
            // SEQ_DESPESA
            // 
            SEQ_DESPESA.Caption = "SEQ_DESPESA";
            SEQ_DESPESA.FieldName = "SEQ_DESPESA";
            SEQ_DESPESA.Name = "SEQ_DESPESA";
            // 
            // gcDataCompra
            // 
            gcDataCompra.Caption = "Data Compra";
            gcDataCompra.FieldName = "DATA_COMPRA";
            gcDataCompra.Name = "gcDataCompra";
            gcDataCompra.OptionsColumn.ReadOnly = true;
            gcDataCompra.Visible = true;
            gcDataCompra.VisibleIndex = 0;
            // 
            // gcValorTotal
            // 
            gcValorTotal.Caption = "Valor";
            gcValorTotal.FieldName = "VALOR_TOTAL";
            gcValorTotal.Name = "gcValorTotal";
            gcValorTotal.OptionsColumn.ReadOnly = true;
            gcValorTotal.Visible = true;
            gcValorTotal.VisibleIndex = 3;
            // 
            // gcMetodoPagamento
            // 
            gcMetodoPagamento.Caption = "Metodo Pagamento";
            gcMetodoPagamento.FieldName = "METODO_PAGAMENTO";
            gcMetodoPagamento.Name = "gcMetodoPagamento";
            gcMetodoPagamento.OptionsColumn.ReadOnly = true;
            gcMetodoPagamento.Visible = true;
            gcMetodoPagamento.VisibleIndex = 5;
            // 
            // gcCategoria
            // 
            gcCategoria.Caption = "Categoria";
            gcCategoria.Name = "gcCategoria";
            gcCategoria.OptionsColumn.ReadOnly = true;
            gcCategoria.Visible = true;
            gcCategoria.VisibleIndex = 1;
            // 
            // gcStatus
            // 
            gcStatus.Caption = "Status";
            gcStatus.FieldName = "STATUS";
            gcStatus.Name = "gcStatus";
            gcStatus.OptionsColumn.ReadOnly = true;
            gcStatus.Visible = true;
            gcStatus.VisibleIndex = 4;
            // 
            // gcEditarDespesa
            // 
            gcEditarDespesa.Caption = "Editar";
            gcEditarDespesa.ColumnEdit = btnEditarDespesa;
            gcEditarDespesa.Name = "gcEditarDespesa";
            gcEditarDespesa.OptionsColumn.AllowEdit = false;
            gcEditarDespesa.Visible = true;
            gcEditarDespesa.VisibleIndex = 7;
            // 
            // gcExcluirDespes
            // 
            gcExcluirDespes.Caption = "Excluir";
            gcExcluirDespes.ColumnEdit = btnExcluirDespesa;
            gcExcluirDespes.Name = "gcExcluirDespes";
            gcExcluirDespes.OptionsColumn.AllowEdit = false;
            gcExcluirDespes.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SEQ_DESPESA", "{0}") });
            gcExcluirDespes.Visible = true;
            gcExcluirDespes.VisibleIndex = 8;
            // 
            // gcDescricaoDespesa
            // 
            gcDescricaoDespesa.Caption = "Descriçao";
            gcDescricaoDespesa.Name = "gcDescricaoDespesa";
            gcDescricaoDespesa.OptionsColumn.ReadOnly = true;
            gcDescricaoDespesa.Visible = true;
            gcDescricaoDespesa.VisibleIndex = 2;
            // 
            // gcParcelas
            // 
            gcParcelas.Caption = "Ver Parcelas";
            gcParcelas.ColumnEdit = btnVerParcelas;
            gcParcelas.Name = "gcParcelas";
            gcParcelas.OptionsColumn.AllowEdit = false;
            gcParcelas.Visible = true;
            gcParcelas.VisibleIndex = 6;
            // 
            // btnVerParcelas
            // 
            btnVerParcelas.AutoHeight = false;
            btnVerParcelas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) });
            btnVerParcelas.Name = "btnVerParcelas";
            // 
            // btnEditarDespesa
            // 
            btnEditarDespesa.AutoHeight = false;
            btnEditarDespesa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) });
            btnEditarDespesa.Name = "btnEditarDespesa";
            // 
            // btnExcluirDespesa
            // 
            btnExcluirDespesa.AutoHeight = false;
            btnExcluirDespesa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) });
            btnExcluirDespesa.Name = "btnExcluirDespesa";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(10, 20);
            dateTimePicker1.MaxDate = new DateTime(2148, 4, 23, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2020, 4, 23, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.No;
            dateTimePicker1.Size = new Size(100, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(115, 25);
            label1.Name = "label1";
            label1.Size = new Size(13, 15);
            label1.TabIndex = 2;
            label1.Text = "a";
            // 
            // gbDataCompra
            // 
            gbDataCompra.Controls.Add(dateTimePicker2);
            gbDataCompra.Controls.Add(dateTimePicker1);
            gbDataCompra.Controls.Add(label1);
            gbDataCompra.Location = new Point(11, 10);
            gbDataCompra.Name = "gbDataCompra";
            gbDataCompra.Size = new Size(245, 55);
            gbDataCompra.TabIndex = 3;
            gbDataCompra.TabStop = false;
            gbDataCompra.Text = "Data da Compra";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "";
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(135, 22);
            dateTimePicker2.MaxDate = new DateTime(2148, 4, 23, 0, 0, 0, 0);
            dateTimePicker2.MinDate = new DateTime(2020, 4, 23, 0, 0, 0, 0);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.RightToLeft = RightToLeft.No;
            dateTimePicker2.Size = new Size(100, 23);
            dateTimePicker2.TabIndex = 3;
            // 
            // LancamentosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 576);
            Controls.Add(tcLancamentos);
            Name = "LancamentosForm";
            Text = "LancamentosForm";
            tcLancamentos.ResumeLayout(false);
            tpDespesas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gcDespesas).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDespesas).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVerParcelas).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEditarDespesa).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnExcluirDespesa).EndInit();
            gbDataCompra.ResumeLayout(false);
            gbDataCompra.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcLancamentos;
        private TabPage tpDespesas;
        private TabPage tpReceitas;
        private DevExpress.XtraGrid.GridControl gcDespesas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDespesas;
        private DevExpress.XtraGrid.Columns.GridColumn SEQ_DESPESA;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescricaoDespesa;
        private DevExpress.XtraGrid.Columns.GridColumn gcCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn gcDataCompra;
        private DevExpress.XtraGrid.Columns.GridColumn gcValorTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcMetodoPagamento;
        private DevExpress.XtraGrid.Columns.GridColumn gcParcelas;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnVerParcelas;
        private DevExpress.XtraGrid.Columns.GridColumn gcEditarDespesa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnEditarDespesa;
        private DevExpress.XtraGrid.Columns.GridColumn gcExcluirDespes;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnExcluirDespesa;
        private DateTimePicker dateTimePicker1;
        private GroupBox gbDataCompra;
        private Label label1;
        private DateTimePicker dateTimePicker2;
    }
}