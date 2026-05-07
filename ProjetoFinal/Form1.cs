using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class Form1 : Form
    {
        private Bitmap? img1;
        private Bitmap? img2;
        private Bitmap? resultado;

        public Form1()
        {
            InitializeComponent();
        }

        // ============================= CARREGAR / SALVAR =============================

        private void btnCarregar1_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Selecione a Imagem 1",
                Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            img1 = new Bitmap(dlg.FileName);
            picImagem1.Image = img1;
            picImagem1.SizeMode = PictureBoxSizeMode.Zoom;
            lblInfo1.Text = $"Img1: {img1.Width}x{img1.Height}  {System.IO.Path.GetExtension(dlg.FileName).ToUpper()}";
        }

        private void btnCarregar2_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Selecione a Imagem 2",
                Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            img2 = new Bitmap(dlg.FileName);
            picImagem2.Image = img2;
            picImagem2.SizeMode = PictureBoxSizeMode.Zoom;
            lblInfo2.Text = $"Img2: {img2.Width}x{img2.Height}  {System.IO.Path.GetExtension(dlg.FileName).ToUpper()}";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (resultado == null) { Aviso("Nenhum resultado para salvar."); return; }

            using var dlg = new SaveFileDialog
            {
                Title = "Salvar imagem resultante",
                Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg",
                FileName = "resultado"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            resultado.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // ============================= ARITMÉTICAS =============================

        private void btnSomarImagens_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            MostrarResultado(ProcessamentoImagem.SomarImagens(img1!, img2!), "Soma de imagens (A+B)");
        }

        private void btnSomarConstante_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            int c = (int)numConstante.Value;
            MostrarResultado(ProcessamentoImagem.SomarConstante(img1!, c), $"Soma constante {c} — aumento de brilho");
        }

        private void btnSubtrairImagens_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            MostrarResultado(ProcessamentoImagem.SubtrairImagens(img1!, img2!), "Subtração de imagens (A-B)");
        }

        private void btnSubtrairConstante_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            int c = (int)numConstante.Value;
            MostrarResultado(ProcessamentoImagem.SubtrairConstante(img1!, c), $"Subtração constante {c} — redução de brilho");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            double f = (double)numConstante.Value;
            MostrarResultado(ProcessamentoImagem.MultiplicarConstante(img1!, f), $"Multiplicação x{f} — contraste");
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            double f = (double)numConstante.Value;
            if (f == 0) { Aviso("Divisão por zero não é permitida."); return; }
            MostrarResultado(ProcessamentoImagem.DividirConstante(img1!, f), $"Divisão ÷{f} — contraste");
        }

        // ============================= TRANSFORMAÇÕES =============================

        private void btnCinza_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            MostrarResultado(ProcessamentoImagem.ConverterCinza(img1!), "RGB para Escala de Cinza — I=(R+G+B)/3");
        }

        private void btnInvH_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            MostrarResultado(ProcessamentoImagem.InvertarHorizontal(img1!), "Inverter da esquerda para a direita");
        }

        private void btnInvV_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            MostrarResultado(ProcessamentoImagem.InvertarVertical(img1!), "Inverter de cima para baixo");
        }

        private void btnNegativo_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            MostrarResultado(ProcessamentoImagem.Negativo(img1!), "Negativo — G(x,y) = 255 - F(x,y)");
        }

        // ============================= COMBINAÇÕES =============================

        private void btnDiferenca_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            MostrarResultado(ProcessamentoImagem.DiferencaImagens(img1!, img2!), "Diferença — E = (A-B) + (B-A)");
        }

        private void btnBlending_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            double alpha = trackAlpha.Value / 100.0;
            MostrarResultado(
                ProcessamentoImagem.Blending(img1!, img2!, alpha),
                $"Blending — {alpha:F2}×A + {(1 - alpha):F2}×B");
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            MostrarResultado(ProcessamentoImagem.Media(img1!, img2!), "Média — R = (A+B) / 2");
        }

        // ============================= OPERAÇÕES LÓGICAS =============================

        private void btnAnd_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            MostrarResultado(ProcessamentoImagem.And(img1!, img2!), "AND — Img1 AND Img2");
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            MostrarResultado(ProcessamentoImagem.Or(img1!, img2!), "OR — Img1 OR Img2");
        }

        private void btnNotImg1_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            MostrarResultado(ProcessamentoImagem.Not(img1!), "NOT — Imagem 1");
        }

        private void btnNotImg2_Click(object sender, EventArgs e)
        {
            if (img2 == null) { Aviso("Carregue a Imagem 2 primeiro."); return; }
            MostrarResultado(ProcessamentoImagem.Not(img2!), "NOT — Imagem 2");
        }

        private void btnXor_Click(object sender, EventArgs e)
        {
            if (!ValidarDuas()) return;
            MostrarResultado(ProcessamentoImagem.Xor(img1!, img2!), "XOR — Img1 XOR Img2");
        }

        // ============================= AVANÇADAS =============================

        private void btnLimiarizar_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            int t = trackLimiar.Value;
            MostrarResultado(ProcessamentoImagem.Limiarizar(img1!, t), $"Limiarização — T={t}  (G=1 se I≥T)");
        }

        private void btnEqualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            MostrarResultado(ProcessamentoImagem.EqualizarHistograma(img1!), "Equalização de Histograma");
        }

        private void btnSuavizacaoConservativa_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            MostrarResultado(ProcessamentoImagem.SuavizacaoConservativa(img1!), "Suavização Conservativa — vizinhança 3×3");
        }

        private void btnFiltroGaussiano_Click(object sender, EventArgs e)
        {
            if (!ValidarUma()) return;
            int tamanho = (int)nudTamanhoGauss.Value;
            double sigma = (double)nudSigmaGauss.Value;
            MostrarResultado(
                ProcessamentoImagem.FiltroGaussiano(img1!, tamanho, sigma),
                $"Filtro Gaussiano — Kernel {tamanho}×{tamanho}  σ={sigma:F1}");
        }

        // ============================= SLIDERS =============================

        private void trackAlpha_Scroll(object sender, EventArgs e)
        {
            double a = trackAlpha.Value / 100.0;
            lblAlphaVal.Text = $"a={a:F2}";
        }

        private void trackLimiar_Scroll(object sender, EventArgs e)
        {
            lblLimiarVal.Text = $"T={trackLimiar.Value}";
        }

        // ============================= AUXILIARES =============================

        private void MostrarResultado(Bitmap bmp, string info)
        {
            resultado = bmp;
            picResultado.Image = bmp;
            picResultado.SizeMode = PictureBoxSizeMode.Zoom;
            lblResultadoInfo.Text = $"{info}  |  {bmp.Width}x{bmp.Height}px";
        }

        private bool ValidarUma()
        {
            if (img1 == null) { Aviso("Carregue a Imagem 1 primeiro."); return false; }
            return true;
        }

        private bool ValidarDuas()
        {
            if (img1 == null || img2 == null) { Aviso("Carregue as duas imagens primeiro."); return false; }
            return true;
        }

        private void Aviso(string msg) =>
            MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
