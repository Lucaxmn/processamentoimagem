namespace Tecnica02
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
            // Imagem 1
            btnCarregar1    = new Button();
            picImagem1      = new PictureBox();
            lblImagem1      = new Label();

            // Imagem 2
            btnCarregar2    = new Button();
            picImagem2      = new PictureBox();
            lblImagem2      = new Label();

            // Resultado
            picResultado    = new PictureBox();
            lblResultado    = new Label();

            // Constante
            lblConstante    = new Label();
            numConstante    = new NumericUpDown();

            // Botões de operação
            btnSomarImagens     = new Button();
            btnSomarConstante   = new Button();
            btnSubtrairImagens  = new Button();
            btnSubtrairConstante= new Button();
            btnMultiplicar      = new Button();
            btnDividir          = new Button();
            btnSalvar           = new Button();

            // Painéis
            panelTopo       = new Panel();
            panelOps        = new Panel();

            // ===== FORM =====
            Text = "Técnica 02 - Operações Aritméticas em Imagens";
            ClientSize = new Size(1200, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ===== PAINEL TOPO (imagens) =====
            panelTopo.Location = new Point(0, 0);
            panelTopo.Size = new Size(1200, 320);
            panelTopo.BackColor = Color.FromArgb(245, 245, 245);

            // --- Imagem 1 ---
            btnCarregar1.Text = "Carregar Imagem 1";
            btnCarregar1.Location = new Point(10, 10);
            btnCarregar1.Size = new Size(155, 30);
            btnCarregar1.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregar1.ForeColor = Color.White;
            btnCarregar1.FlatStyle = FlatStyle.Flat;
            btnCarregar1.FlatAppearance.BorderSize = 0;
            btnCarregar1.Click += btnCarregar1_Click;

            ((System.ComponentModel.ISupportInitialize)picImagem1).BeginInit();
            picImagem1.Location = new Point(10, 48);
            picImagem1.Size = new Size(360, 240);
            picImagem1.BorderStyle = BorderStyle.FixedSingle;
            picImagem1.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picImagem1).EndInit();

            lblImagem1.Text = "Nenhuma imagem";
            lblImagem1.Location = new Point(10, 295);
            lblImagem1.Size = new Size(360, 20);
            lblImagem1.ForeColor = Color.DimGray;

            // --- Imagem 2 ---
            btnCarregar2.Text = "Carregar Imagem 2";
            btnCarregar2.Location = new Point(385, 10);
            btnCarregar2.Size = new Size(155, 30);
            btnCarregar2.BackColor = Color.FromArgb(0, 120, 215);
            btnCarregar2.ForeColor = Color.White;
            btnCarregar2.FlatStyle = FlatStyle.Flat;
            btnCarregar2.FlatAppearance.BorderSize = 0;
            btnCarregar2.Click += btnCarregar2_Click;

            ((System.ComponentModel.ISupportInitialize)picImagem2).BeginInit();
            picImagem2.Location = new Point(385, 48);
            picImagem2.Size = new Size(360, 240);
            picImagem2.BorderStyle = BorderStyle.FixedSingle;
            picImagem2.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picImagem2).EndInit();

            lblImagem2.Text = "Nenhuma imagem (usada nas operações a e c)";
            lblImagem2.Location = new Point(385, 295);
            lblImagem2.Size = new Size(360, 20);
            lblImagem2.ForeColor = Color.DimGray;

            // --- Resultado ---
            ((System.ComponentModel.ISupportInitialize)picResultado).BeginInit();
            picResultado.Location = new Point(770, 48);
            picResultado.Size = new Size(420, 240);
            picResultado.BorderStyle = BorderStyle.FixedSingle;
            picResultado.BackColor = Color.White;
            ((System.ComponentModel.ISupportInitialize)picResultado).EndInit();

            lblResultado.Text = "Resultado aparecerá aqui";
            lblResultado.Location = new Point(770, 295);
            lblResultado.Size = new Size(420, 40);
            lblResultado.ForeColor = Color.FromArgb(0, 100, 0);

            // --- Botão Salvar ---
            btnSalvar.Text = "Salvar Resultado";
            btnSalvar.Location = new Point(770, 10);
            btnSalvar.Size = new Size(155, 30);
            btnSalvar.BackColor = Color.FromArgb(180, 80, 0);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += btnSalvar_Click;

            panelTopo.Controls.Add(btnCarregar1);
            panelTopo.Controls.Add(picImagem1);
            panelTopo.Controls.Add(lblImagem1);
            panelTopo.Controls.Add(btnCarregar2);
            panelTopo.Controls.Add(picImagem2);
            panelTopo.Controls.Add(lblImagem2);
            panelTopo.Controls.Add(picResultado);
            panelTopo.Controls.Add(lblResultado);
            panelTopo.Controls.Add(btnSalvar);

            // ===== PAINEL OPERAÇÕES =====
            panelOps.Location = new Point(0, 330);
            panelOps.Size = new Size(1200, 370);
            panelOps.BackColor = Color.FromArgb(230, 230, 230);

            // --- Constante ---
            lblConstante.Text = "Constante:";
            lblConstante.Location = new Point(10, 18);
            lblConstante.Size = new Size(75, 20);
            lblConstante.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            ((System.ComponentModel.ISupportInitialize)numConstante).BeginInit();
            numConstante.Location = new Point(90, 15);
            numConstante.Size = new Size(80, 26);
            numConstante.Minimum = 1;
            numConstante.Maximum = 255;
            numConstante.Value = 50;
            numConstante.Font = new Font("Segoe UI", 10f);
            ((System.ComponentModel.ISupportInitialize)numConstante).EndInit();

            // --- Botões de operação ---
            CriarBotaoOp(btnSomarImagens,      "a) Somar duas imagens",             10,  60, btnSomarImagens_Click);
            CriarBotaoOp(btnSomarConstante,    "b) Somar constante (+ brilho)",     10, 110, btnSomarConstante_Click);
            CriarBotaoOp(btnSubtrairImagens,   "c) Subtrair duas imagens",          10, 160, btnSubtrairImagens_Click);
            CriarBotaoOp(btnSubtrairConstante, "d) Subtrair constante (- brilho)",  10, 210, btnSubtrairConstante_Click);
            CriarBotaoOp(btnMultiplicar,       "e) Multiplicar constante (contraste)", 10, 260, btnMultiplicar_Click);
            CriarBotaoOp(btnDividir,           "f) Dividir constante (contraste)",  10, 310, btnDividir_Click);

            panelOps.Controls.Add(lblConstante);
            panelOps.Controls.Add(numConstante);
            panelOps.Controls.Add(btnSomarImagens);
            panelOps.Controls.Add(btnSomarConstante);
            panelOps.Controls.Add(btnSubtrairImagens);
            panelOps.Controls.Add(btnSubtrairConstante);
            panelOps.Controls.Add(btnMultiplicar);
            panelOps.Controls.Add(btnDividir);

            // ===== ADICIONAR AO FORM =====
            Controls.Add(panelTopo);
            Controls.Add(panelOps);
        }

        private void CriarBotaoOp(Button btn, string texto, int x, int y, EventHandler handler)
        {
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(310, 36);
            btn.BackColor = Color.FromArgb(50, 150, 50);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5f);
            btn.Click += handler;
        }

        private Button btnCarregar1, btnCarregar2;
        private PictureBox picImagem1, picImagem2, picResultado;
        private Label lblImagem1, lblImagem2, lblResultado;
        private Label lblConstante;
        private NumericUpDown numConstante;
        private Button btnSomarImagens, btnSomarConstante;
        private Button btnSubtrairImagens, btnSubtrairConstante;
        private Button btnMultiplicar, btnDividir;
        private Button btnSalvar;
        private Panel panelTopo, panelOps;
    }
}
