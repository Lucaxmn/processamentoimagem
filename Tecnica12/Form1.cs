using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica12
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemCinza;
        private Bitmap? imagemBinaria;

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

            // Converte para escala de cinza ao carregar
            imagemCinza = ConverterCinza(new Bitmap(dlg.FileName));
            picOriginal.Image = imagemCinza;
            picOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            lblOriginal.Text = $"Imagem em cinza: {imagemCinza.Width}x{imagemCinza.Height}";

            // Aplica o limiar atual automaticamente
            AplicarLimiar(trackLimiar.Value);
        }

        private void trackLimiar_Scroll(object sender, EventArgs e)
        {
            int t = trackLimiar.Value;
            lblLimiar.Text = $"Limiar T = {t}   →   pixels ≥ {t} ficam brancos (1),  pixels < {t} ficam pretos (0)";

            if (imagemCinza != null)
                AplicarLimiar(t);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemBinaria == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Salvar imagem binarizada";
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "limiarizada";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemBinaria.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // G(x,y) = 1 (branco) se I(x,y) >= T, senão 0 (preto)
        private void AplicarLimiar(int t)
        {
            imagemBinaria = new Bitmap(imagemCinza!.Width, imagemCinza.Height);

            for (int y = 0; y < imagemCinza.Height; y++)
            {
                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    int intensidade = imagemCinza.GetPixel(x, y).R;

                    int val = intensidade >= t ? 255 : 0;
                    imagemBinaria.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }

            picBinaria.Image = imagemBinaria;
            picBinaria.SizeMode = PictureBoxSizeMode.Zoom;
            lblBinaria.Text = $"Resultado binário — T = {t}";
        }

        // Converte para escala de cinza usando I = (R+G+B)/3
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
