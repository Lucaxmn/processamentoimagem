using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica14
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemCinza;
        private Bitmap? imagemEqualizada;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione uma imagem";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemCinza = ConverterCinza(new Bitmap(dlg.FileName));
            imagemEqualizada = null;

            picOriginal.Image = imagemCinza;
            picOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            lblOriginal.Text = $"Original (cinza): {imagemCinza.Width}x{imagemCinza.Height}";

            picEqualizada.Image = null;
            lblEqualizada.Text = "Clique em Equalizar";

            DesenharHistograma(picHistOriginal, CalcularHistograma(imagemCinza), Color.SteelBlue, "Histograma Original");
            picHistEqualizada.Image = null;
        }

        private void btnEqualizar_Click(object sender, EventArgs e)
        {
            if (imagemCinza == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro.", "Aviso");
                return;
            }

            imagemEqualizada = Equalizar(imagemCinza);

            picEqualizada.Image = imagemEqualizada;
            picEqualizada.SizeMode = PictureBoxSizeMode.Zoom;
            lblEqualizada.Text = $"Equalizada: {imagemEqualizada.Width}x{imagemEqualizada.Height}";

            DesenharHistograma(picHistEqualizada, CalcularHistograma(imagemEqualizada), Color.DarkGreen, "Histograma Equalizado");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemEqualizada == null)
            {
                MessageBox.Show("Equalize a imagem primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "equalizada";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemEqualizada.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // Passo 1: conta quantos pixels existem para cada valor de 0 a 255
        private int[] CalcularHistograma(Bitmap img)
        {
            int[] hist = new int[256];

            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                    hist[img.GetPixel(x, y).R]++;

            return hist;
        }

        private Bitmap Equalizar(Bitmap img)
        {
            int totalPixels = img.Width * img.Height;
            int L = 256;

            // Passo 1: histograma
            int[] hist = CalcularHistograma(img);

            // Passo 2: distribuição cumulativa de frequências (CDF)
            int[] cfd = new int[256];
            cfd[0] = hist[0];
            for (int i = 1; i < 256; i++)
                cfd[i] = cfd[i - 1] + hist[i];

            // acha o menor CFD não nulo
            int cfdMin = 0;
            for (int i = 0; i < 256; i++)
            {
                if (cfd[i] > 0) { cfdMin = cfd[i]; break; }
            }

            // Passo 3: h(v) = floor( (CDF(v) - CDF_min) / (MxN - CDF_min) * (L - 1) )
            int[] lut = new int[256];
            int denominador = totalPixels - cfdMin;

            for (int v = 0; v < 256; v++)
            {
                if (denominador == 0)
                    lut[v] = 0;
                else
                    lut[v] = (int)Math.Floor((double)(cfd[v] - cfdMin) / denominador * (L - 1));

                lut[v] = Math.Max(0, Math.Min(255, lut[v]));
            }

            // Aplica a tabela de remapeamento em cada pixel
            Bitmap resultado = new Bitmap(img.Width, img.Height);
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    int v = img.GetPixel(x, y).R;
                    int novoVal = lut[v];
                    resultado.SetPixel(x, y, Color.FromArgb(novoVal, novoVal, novoVal));
                }
            }

            return resultado;
        }

        // Desenha o histograma como barras verticais dentro de um PictureBox
        private void DesenharHistograma(PictureBox pic, int[] hist, Color corBarra, string titulo)
        {
            int w = pic.Width;
            int h = pic.Height;
            Bitmap bmp = new Bitmap(w, h);

            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            int maxVal = 1;
            foreach (int v in hist)
                if (v > maxVal) maxVal = v;

            int margem = 20;
            int areaW = w - margem * 2;
            int areaH = h - margem * 2;

            // barra por valor de cinza (0-255)
            float largBarra = (float)areaW / 256f;

            for (int i = 0; i < 256; i++)
            {
                int altBarra = (int)((double)hist[i] / maxVal * areaH);
                float xBarra = margem + i * largBarra;
                int yBarra = margem + areaH - altBarra;

                g.FillRectangle(new SolidBrush(corBarra),
                    xBarra, yBarra, Math.Max(1, largBarra), altBarra);
            }

            // borda e eixos
            g.DrawRectangle(Pens.Gray, margem, margem, areaW, areaH);
            g.DrawString("0", new Font("Segoe UI", 7f), Brushes.Gray, margem, h - 16);
            g.DrawString("255", new Font("Segoe UI", 7f), Brushes.Gray, w - 30, h - 16);
            g.DrawString(titulo, new Font("Segoe UI", 8f, FontStyle.Bold), Brushes.DimGray, margem, 4);

            pic.Image = bmp;
        }

        private Bitmap ConverterCinza(Bitmap original)
        {
            Bitmap cinza = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original.GetPixel(x, y);
                    int i = (c.R + c.G + c.B) / 3;
                    cinza.SetPixel(x, y, Color.FromArgb(i, i, i));
                }
            }
            return cinza;
        }
    }
}
