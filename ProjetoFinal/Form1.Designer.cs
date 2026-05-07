namespace ProjetoFinal
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picImagem1        = new PictureBox();
            picImagem2        = new PictureBox();
            picResultado      = new PictureBox();
            btnCarregar1      = new Button();
            btnCarregar2      = new Button();
            btnSalvar         = new Button();
            lblInfo1          = new Label();
            lblInfo2          = new Label();
            lblResultadoInfo  = new Label();
            lblConstante      = new Label();
            numConstante      = new NumericUpDown();
            lblAlpha          = new Label();
            trackAlpha        = new TrackBar();
            lblAlphaVal       = new Label();
            lblLimiar         = new Label();
            trackLimiar       = new TrackBar();
            lblLimiarVal      = new Label();
            lblSecArit        = new Label();
            lblSecTrans       = new Label();
            lblSecComb        = new Label();
            lblSecBin         = new Label();
            btnSomarImagens      = new Button();
            btnSomarConstante    = new Button();
            btnSubtrairImagens   = new Button();
            btnSubtrairConstante = new Button();
            btnMultiplicar       = new Button();
            btnDividir           = new Button();
            btnCinza    = new Button();
            btnInvH     = new Button();
            btnInvV     = new Button();
            btnNegativo = new Button();
            btnDiferenca = new Button();
            btnBlending  = new Button();
            btnMedia     = new Button();
            btnAnd      = new Button();
            btnOr       = new Button();
            btnNotImg1  = new Button();
            btnNotImg2  = new Button();
            btnXor      = new Button();
            btnLimiarizar             = new Button();
            btnEqualizar              = new Button();
            btnSuavizacaoConservativa = new Button();
            btnFiltroGaussiano        = new Button();
            lblTamanhoGauss           = new Label();
            nudTamanhoGauss           = new NumericUpDown();
            lblSigmaGauss             = new Label();
            nudSigmaGauss             = new NumericUpDown();

            // ===== FORM =====
            Text            = "Processamento de Imagens — Técnicas 1 a 22";
            ClientSize      = new Size(1280, 760);
            StartPosition   = FormStartPosition.CenterScreen;
            BackColor       = Color.FromArgb(240, 242, 245);
            Font            = new Font("Segoe UI", 9f);
            MinimumSize     = new Size(1296, 799);

            // ===== PICTURE BOXES =====
            CriarPic(picImagem1,   10,  10, 380, 250);
            CriarPic(picImagem2,   400, 10, 380, 250);
            CriarPic(picResultado, 790, 10, 480, 250);

            // ===== BOTÕES CARREGAR / SALVAR =====
            CriarBotaoCarregar(btnCarregar1, "Carregar Imagem 1", 10,  266, btnCarregar1_Click);
            CriarBotaoCarregar(btnCarregar2, "Carregar Imagem 2", 400, 266, btnCarregar2_Click);
            CriarBotaoCarregar(btnSalvar,    "Salvar Resultado",  790, 266, btnSalvar_Click);
            btnSalvar.BackColor = Color.FromArgb(170, 75, 0);

            // ===== LABELS DE INFORMAÇÃO =====
            CriarLabelInfo(lblInfo1,         "Nenhuma imagem carregada", 10,  298, 380);
            CriarLabelInfo(lblInfo2,         "Nenhuma imagem carregada", 400, 298, 380);
            CriarLabelInfo(lblResultadoInfo, "Resultado aparecerá aqui", 790, 298, 480);
            lblResultadoInfo.ForeColor = Color.FromArgb(0, 100, 0);

            // ===== CONTROLES (constante, alpha, limiar) =====
            lblConstante.Text      = "Constante:";
            lblConstante.Location  = new Point(10, 330);
            lblConstante.Size      = new Size(72, 22);
            lblConstante.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            ((System.ComponentModel.ISupportInitialize)numConstante).BeginInit();
            numConstante.Location = new Point(85, 327);
            numConstante.Size     = new Size(68, 25);
            numConstante.Minimum  = 1;
            numConstante.Maximum  = 255;
            numConstante.Value    = 50;
            ((System.ComponentModel.ISupportInitialize)numConstante).EndInit();

            lblAlpha.Text      = "Alpha (Blending):";
            lblAlpha.Location  = new Point(162, 330);
            lblAlpha.Size      = new Size(118, 22);
            lblAlpha.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            ((System.ComponentModel.ISupportInitialize)trackAlpha).BeginInit();
            trackAlpha.Location      = new Point(284, 320);
            trackAlpha.Size          = new Size(175, 35);
            trackAlpha.Minimum       = 0;
            trackAlpha.Maximum       = 100;
            trackAlpha.Value         = 50;
            trackAlpha.TickFrequency = 10;
            trackAlpha.Scroll       += trackAlpha_Scroll;
            ((System.ComponentModel.ISupportInitialize)trackAlpha).EndInit();

            lblAlphaVal.Text      = "a=0.50";
            lblAlphaVal.Location  = new Point(463, 330);
            lblAlphaVal.Size      = new Size(68, 22);
            lblAlphaVal.ForeColor = Color.FromArgb(0, 70, 140);
            lblAlphaVal.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            lblLimiar.Text      = "Limiar (T):";
            lblLimiar.Location  = new Point(540, 330);
            lblLimiar.Size      = new Size(78, 22);
            lblLimiar.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            ((System.ComponentModel.ISupportInitialize)trackLimiar).BeginInit();
            trackLimiar.Location      = new Point(622, 320);
            trackLimiar.Size          = new Size(210, 35);
            trackLimiar.Minimum       = 0;
            trackLimiar.Maximum       = 255;
            trackLimiar.Value         = 128;
            trackLimiar.TickFrequency = 25;
            trackLimiar.Scroll       += trackLimiar_Scroll;
            ((System.ComponentModel.ISupportInitialize)trackLimiar).EndInit();

            lblLimiarVal.Text      = "T=128";
            lblLimiarVal.Location  = new Point(836, 330);
            lblLimiarVal.Size      = new Size(55, 22);
            lblLimiarVal.ForeColor = Color.FromArgb(0, 70, 140);
            lblLimiarVal.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            lblTamanhoGauss.Text      = "Gauss N:";
            lblTamanhoGauss.Location  = new Point(905, 330);
            lblTamanhoGauss.Size      = new Size(65, 22);
            lblTamanhoGauss.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            ((System.ComponentModel.ISupportInitialize)nudTamanhoGauss).BeginInit();
            nudTamanhoGauss.Location  = new Point(975, 327);
            nudTamanhoGauss.Size      = new Size(55, 25);
            nudTamanhoGauss.Minimum   = 3;
            nudTamanhoGauss.Maximum   = 21;
            nudTamanhoGauss.Increment = 2;
            nudTamanhoGauss.Value     = 5;
            ((System.ComponentModel.ISupportInitialize)nudTamanhoGauss).EndInit();

            lblSigmaGauss.Text      = "σ:";
            lblSigmaGauss.Location  = new Point(1040, 330);
            lblSigmaGauss.Size      = new Size(20, 22);
            lblSigmaGauss.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            ((System.ComponentModel.ISupportInitialize)nudSigmaGauss).BeginInit();
            nudSigmaGauss.Location      = new Point(1065, 327);
            nudSigmaGauss.Size          = new Size(70, 25);
            nudSigmaGauss.Minimum       = new decimal(new int[] { 1, 0, 0, 65536 });
            nudSigmaGauss.Maximum       = 20;
            nudSigmaGauss.Increment     = new decimal(new int[] { 5, 0, 0, 65536 });
            nudSigmaGauss.DecimalPlaces = 1;
            nudSigmaGauss.Value         = new decimal(new int[] { 10, 0, 0, 65536 });
            ((System.ComponentModel.ISupportInitialize)nudSigmaGauss).EndInit();

            // ===== CABEÇALHOS DE SEÇÃO =====
            CriarSecLabel(lblSecArit,  "ARITMÉTICAS",                    10,  374, 285);
            CriarSecLabel(lblSecTrans, "TRANSFORMAÇÕES",                  303, 374, 285);
            CriarSecLabel(lblSecComb,  "COMBINAÇÕES",                     596, 374, 285);
            CriarSecLabel(lblSecBin,   "LÓGICAS / BINÁRIAS E AVANÇADAS", 889, 374, 381);

            // ===== COLUNA 1 — ARITMÉTICAS (x=10, w=285) =====
            var cA = Color.FromArgb(0, 100, 112);
            CriarBotaoOp(btnSomarImagens,      "Somar Imagens  (A + B)",          10, 396, 285, cA, btnSomarImagens_Click);
            CriarBotaoOp(btnSomarConstante,    "Somar Constante  (+brilho)",      10, 438, 285, cA, btnSomarConstante_Click);
            CriarBotaoOp(btnSubtrairImagens,   "Subtrair Imagens  (A - B)",       10, 480, 285, cA, btnSubtrairImagens_Click);
            CriarBotaoOp(btnSubtrairConstante, "Subtrair Constante  (-brilho)",   10, 522, 285, cA, btnSubtrairConstante_Click);
            CriarBotaoOp(btnMultiplicar,       "Multiplicar por Constante",       10, 564, 285, cA, btnMultiplicar_Click);
            CriarBotaoOp(btnDividir,           "Dividir por Constante",           10, 606, 285, cA, btnDividir_Click);

            // ===== COLUNA 2 — TRANSFORMAÇÕES (x=303, w=285) =====
            var cT = Color.FromArgb(88, 48, 140);
            CriarBotaoOp(btnCinza,    "Escala de Cinza  I = (R+G+B)/3", 303, 396, 285, cT, btnCinza_Click);
            CriarBotaoOp(btnInvH,     "Espelhar Horizontalmente",      303, 438, 285, cT, btnInvH_Click);
            CriarBotaoOp(btnInvV,     "Espelhar Verticalmente",        303, 480, 285, cT, btnInvV_Click);
            CriarBotaoOp(btnNegativo, "Negativo  G(x,y) = 255 - F(x,y)", 303, 522, 285, cT, btnNegativo_Click);

            // ===== COLUNA 3 — COMBINAÇÕES (x=596, w=285) =====
            var cC = Color.FromArgb(35, 115, 40);
            CriarBotaoOp(btnDiferenca, "Diferença  E = (A-B)+(B-A)",   596, 396, 285, cC, btnDiferenca_Click);
            CriarBotaoOp(btnBlending,  "Blending  E = a*A + (1-a)*B",  596, 438, 285, cC, btnBlending_Click);
            CriarBotaoOp(btnMedia,     "Média  R = (A + B) / 2",       596, 480, 285, cC, btnMedia_Click);

            // ===== COLUNA 4 — LÓGICAS / BINÁRIAS E AVANÇADAS (x=889, w=381) =====
            var cB = Color.FromArgb(138, 55, 20);
            CriarBotaoOp(btnAnd,     "AND  (Img1 AND Img2)",  889, 396, 381, cB, btnAnd_Click);
            CriarBotaoOp(btnOr,      "OR   (Img1 OR Img2)",   889, 431, 381, cB, btnOr_Click);
            CriarBotaoOp(btnNotImg1, "NOT  Imagem 1",         889, 466, 381, cB, btnNotImg1_Click);
            CriarBotaoOp(btnNotImg2, "NOT  Imagem 2",         889, 501, 381, cB, btnNotImg2_Click);
            CriarBotaoOp(btnXor,     "XOR  (Img1 XOR Img2)", 889, 536, 381, cB, btnXor_Click);

            var cAdv = Color.FromArgb(95, 30, 100);
            CriarBotaoOp(btnLimiarizar,             "Limiarização  G=1 se I >= T",       889, 571, 381, cAdv, btnLimiarizar_Click);
            CriarBotaoOp(btnEqualizar,              "Equalização de Histograma",          889, 606, 381, cAdv, btnEqualizar_Click);
            CriarBotaoOp(btnSuavizacaoConservativa, "Suavização Conservativa (3×3)",      889, 641, 381, cAdv, btnSuavizacaoConservativa_Click);
            CriarBotaoOp(btnFiltroGaussiano,        "Filtro Gaussiano  N×N  σ",           889, 676, 381, cAdv, btnFiltroGaussiano_Click);

            // ===== ADICIONAR AO FORM =====
            Controls.Add(picImagem1);
            Controls.Add(picImagem2);
            Controls.Add(picResultado);
            Controls.Add(btnCarregar1);
            Controls.Add(btnCarregar2);
            Controls.Add(btnSalvar);
            Controls.Add(lblInfo1);
            Controls.Add(lblInfo2);
            Controls.Add(lblResultadoInfo);
            Controls.Add(lblConstante);
            Controls.Add(numConstante);
            Controls.Add(lblAlpha);
            Controls.Add(trackAlpha);
            Controls.Add(lblAlphaVal);
            Controls.Add(lblLimiar);
            Controls.Add(trackLimiar);
            Controls.Add(lblLimiarVal);
            Controls.Add(lblSecArit);
            Controls.Add(lblSecTrans);
            Controls.Add(lblSecComb);
            Controls.Add(lblSecBin);
            Controls.Add(btnSomarImagens);
            Controls.Add(btnSomarConstante);
            Controls.Add(btnSubtrairImagens);
            Controls.Add(btnSubtrairConstante);
            Controls.Add(btnMultiplicar);
            Controls.Add(btnDividir);
            Controls.Add(btnCinza);
            Controls.Add(btnInvH);
            Controls.Add(btnInvV);
            Controls.Add(btnNegativo);
            Controls.Add(btnDiferenca);
            Controls.Add(btnBlending);
            Controls.Add(btnMedia);
            Controls.Add(btnAnd);
            Controls.Add(btnOr);
            Controls.Add(btnNotImg1);
            Controls.Add(btnNotImg2);
            Controls.Add(btnXor);
            Controls.Add(btnLimiarizar);
            Controls.Add(btnEqualizar);
            Controls.Add(btnSuavizacaoConservativa);
            Controls.Add(btnFiltroGaussiano);
            Controls.Add(lblTamanhoGauss);
            Controls.Add(nudTamanhoGauss);
            Controls.Add(lblSigmaGauss);
            Controls.Add(nudSigmaGauss);
        }

        // ===== HELPERS =====

        private void CriarPic(PictureBox pic, int x, int y, int w, int h)
        {
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            pic.Location    = new Point(x, y);
            pic.Size        = new Size(w, h);
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.BackColor   = Color.White;
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
        }

        private void CriarBotaoCarregar(Button btn, string texto, int x, int y, EventHandler handler)
        {
            btn.Text            = texto;
            btn.Location        = new Point(x, y);
            btn.Size            = new Size(175, 30);
            btn.BackColor       = Color.FromArgb(0, 120, 215);
            btn.ForeColor       = Color.White;
            btn.FlatStyle       = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Click          += handler;
        }

        private void CriarBotaoOp(Button btn, string texto, int x, int y, int w, Color cor, EventHandler handler)
        {
            btn.Text            = texto;
            btn.Location        = new Point(x, y);
            btn.Size            = new Size(w, 34);
            btn.BackColor       = cor;
            btn.ForeColor       = Color.White;
            btn.FlatStyle       = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font            = new Font("Segoe UI", 9f);
            btn.Click          += handler;
        }

        private void CriarLabelInfo(Label lbl, string texto, int x, int y, int w)
        {
            lbl.Text      = texto;
            lbl.Location  = new Point(x, y);
            lbl.Size      = new Size(w, 20);
            lbl.ForeColor = Color.DimGray;
            lbl.Font      = new Font("Segoe UI", 8.5f);
        }

        private void CriarSecLabel(Label lbl, string texto, int x, int y, int w)
        {
            lbl.Text      = texto;
            lbl.Location  = new Point(x, y);
            lbl.Size      = new Size(w, 18);
            lbl.Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(0, 70, 140);
        }

        // ===== CAMPOS =====
        private PictureBox picImagem1, picImagem2, picResultado;
        private Button btnCarregar1, btnCarregar2, btnSalvar;
        private Label lblInfo1, lblInfo2, lblResultadoInfo;
        private Label lblConstante, lblAlpha, lblAlphaVal, lblLimiar, lblLimiarVal;
        private NumericUpDown numConstante;
        private TrackBar trackAlpha, trackLimiar;
        private Label lblSecArit, lblSecTrans, lblSecComb, lblSecBin;
        private Button btnSomarImagens, btnSomarConstante, btnSubtrairImagens, btnSubtrairConstante;
        private Button btnMultiplicar, btnDividir;
        private Button btnCinza, btnInvH, btnInvV, btnNegativo;
        private Button btnDiferenca, btnBlending, btnMedia;
        private Button btnAnd, btnOr, btnNotImg1, btnNotImg2, btnXor;
        private Button btnLimiarizar, btnEqualizar, btnSuavizacaoConservativa, btnFiltroGaussiano;
        private Label lblTamanhoGauss, lblSigmaGauss;
        private NumericUpDown nudTamanhoGauss, nudSigmaGauss;
    }
}
