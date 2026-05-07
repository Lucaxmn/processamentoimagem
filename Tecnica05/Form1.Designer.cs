namespace Tecnica05
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
            btnConverter = new Button();
            btnSalvar    = new Button();
            picOriginal  = new PictureBox();
            picCinza     = new PictureBox();
            lblOriginal  = new Label();
            lblCinza     = new Label();
            lblTitulo    = new Label();

            // ===== FORM =====
            Text = "Técnica 05 - Converter RGB para Escala de Cinza";
            ClientSize = new Size(900, 560);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== TÍTULO =====
            lblTitulo.Text = "Fórmula: I = (R + G + B) / 3";
            lblTitulo.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 80, 160);
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Size = new Size(400, 28);

            // ===== BOTÃO CARREGAR =====
            btnCarregar.Text = "Carregar Imagem";
            btnCarregar.Location = new Point(20, 50);
            btnCarregar.Size = new Size(160, 34);
            btnCarregar.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregar.ForeColor = Color.White;
            btnCarregar.FlatStyle = FlatStyle.Flat;
            btnCarregar.FlatAppearance.BorderSize = 0;
            btnCarregar.Click += btnCarregar_Click;

            // ===== BOTÃO CONVERTER =====
            btnConverter.Text = "Converter para Cinza";
            btnConverter.Location = new Point(195, 50);
            btnConverter.Size = new Size(180, 34);
            btnConverter.BackColor = Color.FromArgb(50, 150, 50);
            btnConverter.ForeColor = Color.White;
            btnConverter.FlatStyle = FlatStyle.Flat;
            btnConverter.FlatAppearance.BorderSize = 0;
            btnConverter.Click += btnConverter_Click;

            // ===== BOTÃO SALVAR =====
            btnSalvar.Text = "Salvar Resultado";
            btnSalvar.Location = new Point(390, 50);
            btnSalvar.Size = new Size(155, 34);
            btnSalvar.BackColor = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += btnSalvar_Click;

            // ===== PICTURE BOX ORIGINAL =====
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            picOriginal.Location = new Point(20, 100);
            picOriginal.Size = new Size(420, 380);
            picOriginal.BorderStyle = BorderStyle.FixedSingle;
            picOriginal.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();

            lblOriginal.Text = "Nenhuma imagem carregada";
            lblOriginal.Location = new Point(20, 487);
            lblOriginal.Size = new Size(420, 20);
            lblOriginal.ForeColor = Color.DimGray;

            // ===== PICTURE BOX CINZA =====
            ((System.ComponentModel.ISupportInitialize)picCinza).BeginInit();
            picCinza.Location = new Point(460, 100);
            picCinza.Size = new Size(420, 380);
            picCinza.BorderStyle = BorderStyle.FixedSingle;
            picCinza.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picCinza).EndInit();

            lblCinza.Text = "Resultado em escala de cinza";
            lblCinza.Location = new Point(460, 487);
            lblCinza.Size = new Size(420, 20);
            lblCinza.ForeColor = Color.FromArgb(0, 100, 0);

            // ===== ADICIONAR AO FORM =====
            Controls.Add(lblTitulo);
            Controls.Add(btnCarregar);
            Controls.Add(btnConverter);
            Controls.Add(btnSalvar);
            Controls.Add(picOriginal);
            Controls.Add(lblOriginal);
            Controls.Add(picCinza);
            Controls.Add(lblCinza);
        }

        private Button btnCarregar, btnConverter, btnSalvar;
        private PictureBox picOriginal, picCinza;
        private Label lblOriginal, lblCinza, lblTitulo;
    }
}
