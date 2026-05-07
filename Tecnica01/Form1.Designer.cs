namespace Tecnica01
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
            // -- Controles da Imagem 1
            btnCarregarImagem1 = new Button();
            picImagem1 = new PictureBox();
            lblInfo1 = new Label();
            txtPixels1 = new TextBox();

            // -- Controles da Imagem 2
            btnCarregarImagem2 = new Button();
            picImagem2 = new PictureBox();
            lblInfo2 = new Label();
            txtPixels2 = new TextBox();

            // -- Separador
            separador = new Label();

            // =================== FORM ===================
            Text = "Técnica 01 - Leitura de Imagens e Matrizes de Pixels";
            ClientSize = new Size(1100, 620);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(240, 240, 240);
            Font = new Font("Segoe UI", 9f);

            // =================== BOTÃO 1 ===================
            btnCarregarImagem1.Text = "Carregar Imagem 1";
            btnCarregarImagem1.Location = new Point(20, 15);
            btnCarregarImagem1.Size = new Size(160, 34);
            btnCarregarImagem1.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregarImagem1.ForeColor = Color.White;
            btnCarregarImagem1.FlatStyle = FlatStyle.Flat;
            btnCarregarImagem1.FlatAppearance.BorderSize = 0;
            btnCarregarImagem1.Click += btnCarregarImagem1_Click;

            // =================== PICTURE BOX 1 ===================
            ((System.ComponentModel.ISupportInitialize)picImagem1).BeginInit();
            picImagem1.Location = new Point(20, 60);
            picImagem1.Size = new Size(480, 300);
            picImagem1.BorderStyle = BorderStyle.FixedSingle;
            picImagem1.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picImagem1).EndInit();

            // =================== LABEL INFO 1 ===================
            lblInfo1.Text = "Nenhuma imagem carregada";
            lblInfo1.Location = new Point(20, 370);
            lblInfo1.Size = new Size(480, 60);
            lblInfo1.ForeColor = Color.FromArgb(50, 50, 50);

            // =================== TEXTBOX PIXELS 1 ===================
            txtPixels1.Location = new Point(20, 440);
            txtPixels1.Size = new Size(480, 150);
            txtPixels1.Multiline = true;
            txtPixels1.ScrollBars = ScrollBars.Vertical;
            txtPixels1.ReadOnly = true;
            txtPixels1.BackColor = Color.White;
            txtPixels1.Font = new Font("Consolas", 8.5f);

            // =================== SEPARADOR ===================
            separador.Text = "";
            separador.Location = new Point(535, 0);
            separador.Size = new Size(2, 620);
            separador.BackColor = Color.Silver;

            // =================== BOTÃO 2 ===================
            btnCarregarImagem2.Text = "Carregar Imagem 2";
            btnCarregarImagem2.Location = new Point(560, 15);
            btnCarregarImagem2.Size = new Size(160, 34);
            btnCarregarImagem2.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregarImagem2.ForeColor = Color.White;
            btnCarregarImagem2.FlatStyle = FlatStyle.Flat;
            btnCarregarImagem2.FlatAppearance.BorderSize = 0;
            btnCarregarImagem2.Click += btnCarregarImagem2_Click;

            // =================== PICTURE BOX 2 ===================
            ((System.ComponentModel.ISupportInitialize)picImagem2).BeginInit();
            picImagem2.Location = new Point(560, 60);
            picImagem2.Size = new Size(480, 300);
            picImagem2.BorderStyle = BorderStyle.FixedSingle;
            picImagem2.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picImagem2).EndInit();

            // =================== LABEL INFO 2 ===================
            lblInfo2.Text = "Nenhuma imagem carregada";
            lblInfo2.Location = new Point(560, 370);
            lblInfo2.Size = new Size(480, 60);
            lblInfo2.ForeColor = Color.FromArgb(50, 50, 50);

            // =================== TEXTBOX PIXELS 2 ===================
            txtPixels2.Location = new Point(560, 440);
            txtPixels2.Size = new Size(480, 150);
            txtPixels2.Multiline = true;
            txtPixels2.ScrollBars = ScrollBars.Vertical;
            txtPixels2.ReadOnly = true;
            txtPixels2.BackColor = Color.White;
            txtPixels2.Font = new Font("Consolas", 8.5f);

            // =================== ADICIONAR AO FORM ===================
            Controls.Add(btnCarregarImagem1);
            Controls.Add(picImagem1);
            Controls.Add(lblInfo1);
            Controls.Add(txtPixels1);
            Controls.Add(separador);
            Controls.Add(btnCarregarImagem2);
            Controls.Add(picImagem2);
            Controls.Add(lblInfo2);
            Controls.Add(txtPixels2);
        }

        private Button btnCarregarImagem1;
        private PictureBox picImagem1;
        private Label lblInfo1;
        private TextBox txtPixels1;

        private Button btnCarregarImagem2;
        private PictureBox picImagem2;
        private Label lblInfo2;
        private TextBox txtPixels2;

        private Label separador;
    }
}
