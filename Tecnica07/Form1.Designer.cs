namespace Tecnica07
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnCarregar  = new Button();
            btnInverter  = new Button();
            btnSalvar    = new Button();
            picOriginal  = new PictureBox();
            picInvertida = new PictureBox();
            lblOriginal  = new Label();
            lblInvertida = new Label();
            lblTitulo    = new Label();
            lblSeta      = new Label();

            // ===== FORM =====
            Text = "Técnica 07 - Inverter Imagem (Cima → Baixo)";
            ClientSize = new Size(960, 580);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "Espelhamento vertical: pixel [y] vai para [altura - 1 - y]";
            lblTitulo.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Size = new Size(700, 26);

            // ===== BOTÕES =====
            btnCarregar.Text = "Carregar Imagem";
            btnCarregar.Location = new Point(20, 48);
            btnCarregar.Size = new Size(155, 34);
            btnCarregar.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregar.ForeColor = Color.White;
            btnCarregar.FlatStyle = FlatStyle.Flat;
            btnCarregar.FlatAppearance.BorderSize = 0;
            btnCarregar.Click += btnCarregar_Click;

            btnInverter.Text = "Inverter  ↕";
            btnInverter.Location = new Point(190, 48);
            btnInverter.Size = new Size(155, 34);
            btnInverter.BackColor = Color.FromArgb(50, 150, 50);
            btnInverter.ForeColor = Color.White;
            btnInverter.FlatStyle = FlatStyle.Flat;
            btnInverter.FlatAppearance.BorderSize = 0;
            btnInverter.Click += btnInverter_Click;

            btnSalvar.Text = "Salvar Resultado";
            btnSalvar.Location = new Point(360, 48);
            btnSalvar.Size = new Size(155, 34);
            btnSalvar.BackColor = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += btnSalvar_Click;

            // ===== PICTURE BOX ORIGINAL =====
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            picOriginal.Location = new Point(20, 100);
            picOriginal.Size = new Size(420, 400);
            picOriginal.BorderStyle = BorderStyle.FixedSingle;
            picOriginal.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();

            lblOriginal.Text = "Nenhuma imagem carregada";
            lblOriginal.Location = new Point(20, 508);
            lblOriginal.Size = new Size(420, 20);
            lblOriginal.ForeColor = Color.DimGray;

            // ===== SETA VERTICAL =====
            lblSeta.Text = "↕";
            lblSeta.Font = new Font("Segoe UI", 26f, FontStyle.Bold);
            lblSeta.ForeColor = Color.FromArgb(0, 120, 215);
            lblSeta.Location = new Point(452, 285);
            lblSeta.Size = new Size(55, 50);
            lblSeta.TextAlign = ContentAlignment.MiddleCenter;

            // ===== PICTURE BOX INVERTIDA =====
            ((System.ComponentModel.ISupportInitialize)picInvertida).BeginInit();
            picInvertida.Location = new Point(520, 100);
            picInvertida.Size = new Size(420, 400);
            picInvertida.BorderStyle = BorderStyle.FixedSingle;
            picInvertida.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picInvertida).EndInit();

            lblInvertida.Text = "Imagem invertida verticalmente";
            lblInvertida.Location = new Point(520, 508);
            lblInvertida.Size = new Size(420, 20);
            lblInvertida.ForeColor = Color.FromArgb(0, 100, 0);

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(btnCarregar);
            Controls.Add(btnInverter);
            Controls.Add(btnSalvar);
            Controls.Add(picOriginal);
            Controls.Add(lblOriginal);
            Controls.Add(lblSeta);
            Controls.Add(picInvertida);
            Controls.Add(lblInvertida);
        }

        private Button btnCarregar, btnInverter, btnSalvar;
        private PictureBox picOriginal, picInvertida;
        private Label lblOriginal, lblInvertida, lblTitulo, lblSeta;
    }
}
