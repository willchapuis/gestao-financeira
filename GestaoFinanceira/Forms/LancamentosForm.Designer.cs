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
            gbDataDespesa = new GroupBox();
            dataDespesaFim = new DateTimePicker();
            dataDespesaInicio = new DateTimePicker();
            label1 = new Label();
            gcDespesas = new DevExpress.XtraGrid.GridControl();
            gvDespesas = new DevExpress.XtraGrid.Views.Grid.GridView();
            SEQ_DESPESA = new DevExpress.XtraGrid.Columns.GridColumn();
            gcDescricaoDespesa = new DevExpress.XtraGrid.Columns.GridColumn();
            gcCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            gcDataCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            gcValorTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            gcMetodoPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            gcParcelas = new DevExpress.XtraGrid.Columns.GridColumn();
            btnVerParcelas = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            gcEditarDespesa = new DevExpress.XtraGrid.Columns.GridColumn();
            btnEditarDespesa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            gcExcluirDespes = new DevExpress.XtraGrid.Columns.GridColumn();
            btnExcluirDespesa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            tpReceitas = new TabPage();
            gbValorDespesa = new GroupBox();
            label2 = new Label();
            txtValorDespesaInicio = new TextBox();
            gbMetodoPagamento = new GroupBox();
            ckDinheiro = new CheckBox();
            ckPix = new CheckBox();
            ckDebito = new CheckBox();
            ckCredito = new CheckBox();
            gbCartao = new GroupBox();
            comboBox1 = new ComboBox();
            tcLancamentos.SuspendLayout();
            tpDespesas.SuspendLayout();
            gbDataDespesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcDespesas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDespesas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVerParcelas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEditarDespesa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnExcluirDespesa).BeginInit();
            gbValorDespesa.SuspendLayout();
            gbMetodoPagamento.SuspendLayout();
            gbCartao.SuspendLayout();
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
            tpDespesas.Controls.Add(gbCartao);
            tpDespesas.Controls.Add(gbMetodoPagamento);
            tpDespesas.Controls.Add(gbValorDespesa);
            tpDespesas.Controls.Add(gbDataDespesa);
            tpDespesas.Controls.Add(gcDespesas);
            tpDespesas.Location = new Point(4, 24);
            tpDespesas.Name = "tpDespesas";
            tpDespesas.Padding = new Padding(3);
            tpDespesas.Size = new Size(792, 548);
            tpDespesas.TabIndex = 0;
            tpDespesas.Text = "Despesas";
            // 
            // gbDataDespesa
            // 
            gbDataDespesa.Controls.Add(dataDespesaFim);
            gbDataDespesa.Controls.Add(dataDespesaInicio);
            gbDataDespesa.Controls.Add(label1);
            gbDataDespesa.Location = new Point(11, 10);
            gbDataDespesa.Name = "gbDataDespesa";
            gbDataDespesa.Size = new Size(245, 55);
            gbDataDespesa.TabIndex = 3;
            gbDataDespesa.TabStop = false;
            gbDataDespesa.Text = "Data da Compra";
            // 
            // dataDespesaFim
            // 
            dataDespesaFim.CustomFormat = "";
            dataDespesaFim.Format = DateTimePickerFormat.Short;
            dataDespesaFim.Location = new Point(135, 22);
            dataDespesaFim.MaxDate = new DateTime(2148, 4, 23, 0, 0, 0, 0);
            dataDespesaFim.MinDate = new DateTime(2020, 4, 23, 0, 0, 0, 0);
            dataDespesaFim.Name = "dataDespesaFim";
            dataDespesaFim.RightToLeft = RightToLeft.No;
            dataDespesaFim.Size = new Size(100, 23);
            dataDespesaFim.TabIndex = 3;
            // 
            // dataDespesaInicio
            // 
            dataDespesaInicio.CustomFormat = "";
            dataDespesaInicio.Format = DateTimePickerFormat.Short;
            dataDespesaInicio.Location = new Point(10, 20);
            dataDespesaInicio.MaxDate = new DateTime(2148, 4, 23, 0, 0, 0, 0);
            dataDespesaInicio.MinDate = new DateTime(2020, 4, 23, 0, 0, 0, 0);
            dataDespesaInicio.Name = "dataDespesaInicio";
            dataDespesaInicio.RightToLeft = RightToLeft.No;
            dataDespesaInicio.Size = new Size(100, 23);
            dataDespesaInicio.TabIndex = 1;
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
            // gcDescricaoDespesa
            // 
            gcDescricaoDespesa.Caption = "Descriçao";
            gcDescricaoDespesa.Name = "gcDescricaoDespesa";
            gcDescricaoDespesa.OptionsColumn.ReadOnly = true;
            gcDescricaoDespesa.Visible = true;
            gcDescricaoDespesa.VisibleIndex = 2;
            // 
            // gcCategoria
            // 
            gcCategoria.Caption = "Categoria";
            gcCategoria.Name = "gcCategoria";
            gcCategoria.OptionsColumn.ReadOnly = true;
            gcCategoria.Visible = true;
            gcCategoria.VisibleIndex = 1;
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
            // gcStatus
            // 
            gcStatus.Caption = "Status";
            gcStatus.FieldName = "STATUS";
            gcStatus.Name = "gcStatus";
            gcStatus.OptionsColumn.ReadOnly = true;
            gcStatus.Visible = true;
            gcStatus.VisibleIndex = 4;
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
            // gcEditarDespesa
            // 
            gcEditarDespesa.Caption = "Editar";
            gcEditarDespesa.ColumnEdit = btnEditarDespesa;
            gcEditarDespesa.Name = "gcEditarDespesa";
            gcEditarDespesa.OptionsColumn.AllowEdit = false;
            gcEditarDespesa.Visible = true;
            gcEditarDespesa.VisibleIndex = 7;
            // 
            // btnEditarDespesa
            // 
            btnEditarDespesa.AutoHeight = false;
            btnEditarDespesa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) });
            btnEditarDespesa.Name = "btnEditarDespesa";
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
            // btnExcluirDespesa
            // 
            btnExcluirDespesa.AutoHeight = false;
            btnExcluirDespesa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) });
            btnExcluirDespesa.Name = "btnExcluirDespesa";
            // 
            // tpReceitas
            // 
            tpReceitas.BackColor = SystemColors.GradientInactiveCaption;
            tpReceitas.Location = new Point(4, 24);
            tpReceitas.Name = "tpReceitas";
            tpReceitas.Padding = new Padding(3);
            tpReceitas.Size = new Size(792, 548);
            tpReceitas.TabIndex = 1;
            tpReceitas.Text = "Receitas";
            // 
            // gbValorDespesa
            // 
            gbValorDespesa.Controls.Add(txtValorDespesaInicio);
            gbValorDespesa.Controls.Add(label2);
            gbValorDespesa.Location = new Point(260, 10);
            gbValorDespesa.Name = "gbValorDespesa";
            gbValorDespesa.Size = new Size(245, 55);
            gbValorDespesa.TabIndex = 4;
            gbValorDespesa.TabStop = false;
            gbValorDespesa.Text = "Valor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 25);
            label2.Name = "label2";
            label2.Size = new Size(13, 15);
            label2.TabIndex = 2;
            label2.Text = "a";
            // 
            // txtValorDespesaInicio
            // 
            txtValorDespesaInicio.Location = new Point(10, 20);
            txtValorDespesaInicio.Name = "txtValorDespesaInicio";
            txtValorDespesaInicio.Size = new Size(100, 23);
            txtValorDespesaInicio.TabIndex = 5;
            // 
            // gbMetodoPagamento
            // 
            gbMetodoPagamento.Controls.Add(ckCredito);
            gbMetodoPagamento.Controls.Add(ckDebito);
            gbMetodoPagamento.Controls.Add(ckPix);
            gbMetodoPagamento.Controls.Add(ckDinheiro);
            gbMetodoPagamento.Location = new Point(10, 70);
            gbMetodoPagamento.Name = "gbMetodoPagamento";
            gbMetodoPagamento.Size = new Size(150, 130);
            gbMetodoPagamento.TabIndex = 5;
            gbMetodoPagamento.TabStop = false;
            gbMetodoPagamento.Text = "Método de Pagamento";
            // 
            // ckDinheiro
            // 
            ckDinheiro.AutoSize = true;
            ckDinheiro.Location = new Point(15, 25);
            ckDinheiro.Name = "ckDinheiro";
            ckDinheiro.Size = new Size(71, 19);
            ckDinheiro.TabIndex = 0;
            ckDinheiro.Text = "Dinheiro";
            ckDinheiro.UseVisualStyleBackColor = true;
            // 
            // ckPix
            // 
            ckPix.AutoSize = true;
            ckPix.Location = new Point(15, 50);
            ckPix.Name = "ckPix";
            ckPix.Size = new Size(42, 19);
            ckPix.TabIndex = 6;
            ckPix.Text = "Pix";
            ckPix.UseVisualStyleBackColor = true;
            // 
            // ckDebito
            // 
            ckDebito.AutoSize = true;
            ckDebito.Location = new Point(15, 75);
            ckDebito.Name = "ckDebito";
            ckDebito.Size = new Size(61, 19);
            ckDebito.TabIndex = 7;
            ckDebito.Text = "Débito";
            ckDebito.UseVisualStyleBackColor = true;
            // 
            // ckCredito
            // 
            ckCredito.AutoSize = true;
            ckCredito.Location = new Point(15, 100);
            ckCredito.Name = "ckCredito";
            ckCredito.Size = new Size(65, 19);
            ckCredito.TabIndex = 8;
            ckCredito.Text = "Crédito";
            ckCredito.UseVisualStyleBackColor = true;
            // 
            // gbCartao
            // 
            gbCartao.Controls.Add(comboBox1);
            gbCartao.Location = new Point(165, 70);
            gbCartao.Name = "gbCartao";
            gbCartao.Size = new Size(220, 55);
            gbCartao.TabIndex = 6;
            gbCartao.TabStop = false;
            gbCartao.Text = "Cartão";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 20);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 23);
            comboBox1.TabIndex = 7;
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
            gbDataDespesa.ResumeLayout(false);
            gbDataDespesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gcDespesas).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDespesas).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVerParcelas).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEditarDespesa).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnExcluirDespesa).EndInit();
            gbValorDespesa.ResumeLayout(false);
            gbValorDespesa.PerformLayout();
            gbMetodoPagamento.ResumeLayout(false);
            gbMetodoPagamento.PerformLayout();
            gbCartao.ResumeLayout(false);
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
        private DateTimePicker dataDespesaInicio;
        private GroupBox gbDataDespesa;
        private Label label1;
        private DateTimePicker dataDespesaFim;
        private GroupBox gbValorDespesa;
        private Label label2;
        private TextBox txtValorDespesaInicio;
        private GroupBox gbMetodoPagamento;
        private CheckBox ckDinheiro;
        private CheckBox ckPix;
        private CheckBox ckDebito;
        private CheckBox ckCredito;
        private GroupBox gbCartao;
        private ComboBox comboBox1;
    }
}