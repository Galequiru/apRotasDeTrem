namespace apRotasDeTrem
{
    partial class Renfe
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgPeninsulaIberica = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCidades = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSalvarCaminho = new System.Windows.Forms.Button();
            this.dgvRotas = new System.Windows.Forms.DataGridView();
            this.clnOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDistancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAlterarCaminho = new System.Windows.Forms.Button();
            this.btnExcluirCaminho = new System.Windows.Forms.Button();
            this.btnIncluirCaminho = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.NumericUpDown();
            this.txtX = new System.Windows.Forms.NumericUpDown();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExibir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.tpArvore = new System.Windows.Forms.TabPage();
            this.imgArvore = new System.Windows.Forms.PictureBox();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.dlgArquivo = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imgPeninsulaIberica)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpCidades.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).BeginInit();
            this.tpArvore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPeninsulaIberica
            // 
            this.imgPeninsulaIberica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPeninsulaIberica.Image = global::apRotasDeTrem.Properties.Resources.mapaEspanhaPortugal;
            this.imgPeninsulaIberica.Location = new System.Drawing.Point(0, 0);
            this.imgPeninsulaIberica.Name = "imgPeninsulaIberica";
            this.imgPeninsulaIberica.Size = new System.Drawing.Size(717, 578);
            this.imgPeninsulaIberica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPeninsulaIberica.TabIndex = 0;
            this.imgPeninsulaIberica.TabStop = false;
            this.imgPeninsulaIberica.Paint += new System.Windows.Forms.PaintEventHandler(this.imgPeninsulaIberica_Paint);
            this.imgPeninsulaIberica.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgPeninsulaIberica_MouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpCidades);
            this.tabControl1.Controls.Add(this.tpArvore);
            this.tabControl1.Location = new System.Drawing.Point(718, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(414, 597);
            this.tabControl1.TabIndex = 1;
            // 
            // tpCidades
            // 
            this.tpCidades.Controls.Add(this.groupBox2);
            this.tpCidades.Controls.Add(this.groupBox1);
            this.tpCidades.Location = new System.Drawing.Point(4, 22);
            this.tpCidades.Name = "tpCidades";
            this.tpCidades.Padding = new System.Windows.Forms.Padding(3);
            this.tpCidades.Size = new System.Drawing.Size(406, 571);
            this.tpCidades.TabIndex = 0;
            this.tpCidades.Text = "Gerenciamento de cidades";
            this.tpCidades.UseVisualStyleBackColor = true;
            this.tpCidades.Enter += new System.EventHandler(this.tpCidades_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnSalvarCaminho);
            this.groupBox2.Controls.Add(this.dgvRotas);
            this.groupBox2.Controls.Add(this.btnAlterarCaminho);
            this.groupBox2.Controls.Add(this.btnExcluirCaminho);
            this.groupBox2.Controls.Add(this.btnIncluirCaminho);
            this.groupBox2.Location = new System.Drawing.Point(9, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 427);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "rotas";
            // 
            // btnSalvarCaminho
            // 
            this.btnSalvarCaminho.Location = new System.Drawing.Point(299, 20);
            this.btnSalvarCaminho.Name = "btnSalvarCaminho";
            this.btnSalvarCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarCaminho.TabIndex = 4;
            this.btnSalvarCaminho.Text = "salvar";
            this.btnSalvarCaminho.UseVisualStyleBackColor = true;
            this.btnSalvarCaminho.Click += new System.EventHandler(this.btnSalvarCaminho_Click);
            // 
            // dgvRotas
            // 
            this.dgvRotas.AllowUserToAddRows = false;
            this.dgvRotas.AllowUserToDeleteRows = false;
            this.dgvRotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnOrigem,
            this.clnDestino,
            this.clnDistancia,
            this.clnTempo});
            this.dgvRotas.Location = new System.Drawing.Point(10, 49);
            this.dgvRotas.Name = "dgvRotas";
            this.dgvRotas.Size = new System.Drawing.Size(366, 371);
            this.dgvRotas.TabIndex = 3;
            // 
            // clnOrigem
            // 
            this.clnOrigem.Frozen = true;
            this.clnOrigem.HeaderText = "Origem";
            this.clnOrigem.Name = "clnOrigem";
            this.clnOrigem.ReadOnly = true;
            this.clnOrigem.Width = 80;
            // 
            // clnDestino
            // 
            this.clnDestino.HeaderText = "Destino";
            this.clnDestino.Name = "clnDestino";
            this.clnDestino.Width = 80;
            // 
            // clnDistancia
            // 
            this.clnDistancia.HeaderText = "Distância(km)";
            this.clnDistancia.Name = "clnDistancia";
            this.clnDistancia.ReadOnly = true;
            this.clnDistancia.Width = 80;
            // 
            // clnTempo
            // 
            this.clnTempo.HeaderText = "Tempo(min)";
            this.clnTempo.Name = "clnTempo";
            this.clnTempo.ReadOnly = true;
            this.clnTempo.Width = 80;
            // 
            // btnAlterarCaminho
            // 
            this.btnAlterarCaminho.Location = new System.Drawing.Point(204, 20);
            this.btnAlterarCaminho.Name = "btnAlterarCaminho";
            this.btnAlterarCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnAlterarCaminho.TabIndex = 2;
            this.btnAlterarCaminho.Text = "alterar";
            this.btnAlterarCaminho.UseVisualStyleBackColor = true;
            this.btnAlterarCaminho.Click += new System.EventHandler(this.btnAlterarCaminho_Click);
            // 
            // btnExcluirCaminho
            // 
            this.btnExcluirCaminho.Location = new System.Drawing.Point(107, 20);
            this.btnExcluirCaminho.Name = "btnExcluirCaminho";
            this.btnExcluirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirCaminho.TabIndex = 1;
            this.btnExcluirCaminho.Text = "excluir";
            this.btnExcluirCaminho.UseVisualStyleBackColor = true;
            // 
            // btnIncluirCaminho
            // 
            this.btnIncluirCaminho.Location = new System.Drawing.Point(10, 20);
            this.btnIncluirCaminho.Name = "btnIncluirCaminho";
            this.btnIncluirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnIncluirCaminho.TabIndex = 0;
            this.btnIncluirCaminho.Text = "incluir";
            this.btnIncluirCaminho.UseVisualStyleBackColor = true;
            this.btnIncluirCaminho.Click += new System.EventHandler(this.btnIncluirCaminho_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.btnIncluir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAlterar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnExibir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 120);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "cidades";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(301, 19);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtY
            // 
            this.txtY.DecimalPlaces = 3;
            this.txtY.Enabled = false;
            this.txtY.InterceptArrowKeys = false;
            this.txtY.Location = new System.Drawing.Point(301, 89);
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
            this.txtY.Size = new System.Drawing.Size(73, 20);
            this.txtY.TabIndex = 9;
            this.txtY.TabStop = false;
            // 
            // txtX
            // 
            this.txtX.DecimalPlaces = 3;
            this.txtX.Enabled = false;
            this.txtX.InterceptArrowKeys = false;
            this.txtX.Location = new System.Drawing.Point(110, 89);
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(73, 20);
            this.txtX.TabIndex = 8;
            this.txtX.TabStop = false;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(10, 19);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 2;
            this.btnIncluir.Text = "incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "coordenada Y:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(107, 19);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 3;
            this.btnAlterar.Text = "alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "coordenada X:";
            // 
            // btnExibir
            // 
            this.btnExibir.Location = new System.Drawing.Point(204, 19);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(75, 23);
            this.btnExibir.TabIndex = 4;
            this.btnExibir.Text = "exibir";
            this.btnExibir.UseVisualStyleBackColor = true;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome da cidade:";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(110, 57);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(266, 20);
            this.txtNome.TabIndex = 0;
            // 
            // tpArvore
            // 
            this.tpArvore.BackColor = System.Drawing.Color.Gray;
            this.tpArvore.Controls.Add(this.imgArvore);
            this.tpArvore.Location = new System.Drawing.Point(4, 22);
            this.tpArvore.Name = "tpArvore";
            this.tpArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tpArvore.Size = new System.Drawing.Size(406, 571);
            this.tpArvore.TabIndex = 1;
            this.tpArvore.Text = "Árvore";
            this.tpArvore.Enter += new System.EventHandler(this.tpArvore_Enter);
            // 
            // imgArvore
            // 
            this.imgArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgArvore.Location = new System.Drawing.Point(6, 6);
            this.imgArvore.Name = "imgArvore";
            this.imgArvore.Size = new System.Drawing.Size(394, 559);
            this.imgArvore.TabIndex = 0;
            this.imgArvore.TabStop = false;
            this.imgArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.imgArvore_Paint);
            // 
            // lbMensagem
            // 
            this.lbMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMensagem.AutoSize = true;
            this.lbMensagem.Location = new System.Drawing.Point(2, 581);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbMensagem.Size = new System.Drawing.Size(58, 13);
            this.lbMensagem.TabIndex = 2;
            this.lbMensagem.Text = "mensagem";
            // 
            // dlgArquivo
            // 
            this.dlgArquivo.FileName = "openFileDialog1";
            // 
            // Renfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 597);
            this.Controls.Add(this.lbMensagem);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.imgPeninsulaIberica);
            this.Name = "Renfe";
            this.Text = "Renfe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Renfe_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imgPeninsulaIberica)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpCidades.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).EndInit();
            this.tpArvore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgArvore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPeninsulaIberica;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCidades;
        private System.Windows.Forms.TabPage tpArvore;
        private System.Windows.Forms.PictureBox imgArvore;
        private System.Windows.Forms.Label lbMensagem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.NumericUpDown txtY;
        private System.Windows.Forms.NumericUpDown txtX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAlterarCaminho;
        private System.Windows.Forms.Button btnExcluirCaminho;
        private System.Windows.Forms.Button btnIncluirCaminho;
        private System.Windows.Forms.DataGridView dgvRotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDistancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTempo;
        private System.Windows.Forms.Button btnSalvarCaminho;
        private System.Windows.Forms.OpenFileDialog dlgArquivo;
    }
}

