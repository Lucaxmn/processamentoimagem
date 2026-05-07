using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica02
{
    public partial class Form1 : Form
    {
        private Bitmap? imagem1;
        private Bitmap? imagem2;

        public Form1()
        {
            InitializeComponent();
        }

        // ===================== CARREGAR IMAGENS =====================

        private void btnCarregar1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";
            dlg.Title = "Selecione a Imagem 1";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagem1 = new Bitmap(dlg.FileName);
            picImagem1.Image = imagem1;
            picImagem1.SizeMode = PictureBoxSizeMode.Zoom;
            lblImagem1.Text = $"Imagem 1: {imagem1.Width}x{imagem1.Height}";
        }

        private void btnCarregar2_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";
            dlg.Title = "Selecione a Imagem 2";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagem2 = new Bitmap(dlg.FileName);
            picImagem2.Image = imagem2;
            picImagem2.SizeMode = PictureBoxSizeMode.Zoom;
            lblImagem2.Text = $"Imagem 2: {imagem2.Width}x{imagem2.Height}";
        }

        // ===================== OPERAÇÕES =====================

        // a) Soma de duas imagens
        private void btnSomarImagens_Click(object sender, EventArgs e)
        {
            if (imagem1 == null || imagem2 == null)
            {
                MessageBox.Show("Carregue as duas imagens primeiro.", "Aviso");
                return;
            }

            int largura = Math.Min(imagem1.Width, imagem2.Width);
            int altura = Math.Min(imagem1.Height, imagem2.Height);
            Bitmap resultado = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color c1 = imagem1.GetPixel(x, y);
                    Color c2 = imagem2.GetPixel(x, y);

                    // OVERFLOW: se passar de 255, trava em 255
                    int r = Math.Min(c1.R + c2.R, 255);
                    int g = Math.Min(c1.G + c2.G, 255);
                    int b = Math.Min(c1.B + c2.B, 255);

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            MostrarResultado(resultado, "a) Soma de duas imagens");
        }

        // b) Somar constante em cada pixel (aumentar brilho)
        private void btnSomarConstante_Click(object sender, EventArgs e)
        {
            if (imagem1 == null)
            {
                MessageBox.Show("Carregue a Imagem 1 primeiro.", "Aviso");
                return;
            }

            int constante = (int)numConstante.Value;
            Bitmap resultado = new Bitmap(imagem1.Width, imagem1.Height);

            for (int y = 0; y < imagem1.Height; y++)
            {
                for (int x = 0; x < imagem1.Width; x++)
                {
                    Color c = imagem1.GetPixel(x, y);

                    // OVERFLOW: trava em 255
                    int r = Math.Min(c.R + constante, 255);
                    int g = Math.Min(c.G + constante, 255);
                    int b = Math.Min(c.B + constante, 255);

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            MostrarResultado(resultado, $"b) Soma constante {constante} (aumento de brilho)");
        }

        // c) Subtrair duas imagens
        private void btnSubtrairImagens_Click(object sender, EventArgs e)
        {
            if (imagem1 == null || imagem2 == null)
            {
                MessageBox.Show("Carregue as duas imagens primeiro.", "Aviso");
                return;
            }

            int largura = Math.Min(imagem1.Width, imagem2.Width);
            int altura = Math.Min(imagem1.Height, imagem2.Height);
            Bitmap resultado = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color c1 = imagem1.GetPixel(x, y);
                    Color c2 = imagem2.GetPixel(x, y);

                    // UNDERFLOW: se ficar abaixo de 0, trava em 0
                    int r = Math.Max(c1.R - c2.R, 0);
                    int g = Math.Max(c1.G - c2.G, 0);
                    int b = Math.Max(c1.B - c2.B, 0);

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            MostrarResultado(resultado, "c) Subtração de duas imagens");
        }

        // d) Subtrair constante de cada pixel (diminuir brilho)
        private void btnSubtrairConstante_Click(object sender, EventArgs e)
        {
            if (imagem1 == null)
            {
                MessageBox.Show("Carregue a Imagem 1 primeiro.", "Aviso");
                return;
            }

            int constante = (int)numConstante.Value;
            Bitmap resultado = new Bitmap(imagem1.Width, imagem1.Height);

            for (int y = 0; y < imagem1.Height; y++)
            {
                for (int x = 0; x < imagem1.Width; x++)
                {
                    Color c = imagem1.GetPixel(x, y);

                    // UNDERFLOW: trava em 0
                    int r = Math.Max(c.R - constante, 0);
                    int g = Math.Max(c.G - constante, 0);
                    int b = Math.Max(c.B - constante, 0);

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            MostrarResultado(resultado, $"d) Subtração constante {constante} (redução de brilho)");
        }

        // e) Multiplicar constante em cada pixel (contraste)
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (imagem1 == null)
            {
                MessageBox.Show("Carregue a Imagem 1 primeiro.", "Aviso");
                return;
            }

            double fator = (double)numConstante.Value;
            Bitmap resultado = new Bitmap(imagem1.Width, imagem1.Height);

            for (int y = 0; y < imagem1.Height; y++)
            {
                for (int x = 0; x < imagem1.Width; x++)
                {
                    Color c = imagem1.GetPixel(x, y);

                    // OVERFLOW: trava em 255 / UNDERFLOW: trava em 0
                    int r = Travar((int)(c.R * fator));
                    int g = Travar((int)(c.G * fator));
                    int b = Travar((int)(c.B * fator));

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            MostrarResultado(resultado, $"e) Multiplicação por {fator} (contraste)");
        }

        // f) Dividir constante em cada pixel (contraste)
        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (imagem1 == null)
            {
                MessageBox.Show("Carregue a Imagem 1 primeiro.", "Aviso");
                return;
            }

            double fator = (double)numConstante.Value;

            if (fator == 0)
            {
                MessageBox.Show("Divisão por zero não é permitida.", "Aviso");
                return;
            }

            Bitmap resultado = new Bitmap(imagem1.Width, imagem1.Height);

            for (int y = 0; y < imagem1.Height; y++)
            {
                for (int x = 0; x < imagem1.Width; x++)
                {
                    Color c = imagem1.GetPixel(x, y);

                    // OVERFLOW: trava em 255 / UNDERFLOW: trava em 0
                    int r = Travar((int)(c.R / fator));
                    int g = Travar((int)(c.G / fator));
                    int b = Travar((int)(c.B / fator));

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            MostrarResultado(resultado, $"f) Divisão por {fator} (contraste)");
        }

        // ===================== AUXILIARES =====================

        // Garante que o valor fique entre 0 e 255
        private int Travar(int valor)
        {
            if (valor > 255) return 255;
            if (valor < 0) return 0;
            return valor;
        }

        // 4) Salvar imagem resultante em arquivo
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (picResultado.Image == null)
            {
                MessageBox.Show("Nenhum resultado para salvar. Aplique uma operação primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Salvar imagem resultante";
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "resultado";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            picResultado.Image.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        private void MostrarResultado(Bitmap bmp, string titulo)
        {
            picResultado.Image = bmp;
            picResultado.SizeMode = PictureBoxSizeMode.Zoom;
            lblResultado.Text = $"Resultado — {titulo}\n{bmp.Width}x{bmp.Height} px";
        }
    }
}
