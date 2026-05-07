using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica13
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemOriginal;
        private Bitmap? imagemNegativa;

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

            imagemOriginal = new Bitmap(dlg.FileName);
            picOriginal.Image = imagemOriginal;
            picOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            lblOriginal.Text = $"Original: {imagemOriginal.Width}x{imagemOriginal.Height} px";

            picNegativa.Image = null;
            lblNegativa.Text = "Clique em Gerar Negativo";
            imagemNegativa = null;
        }

        private void btnNegativo_Click(object sender, EventArgs e)
        {
            if (imagemOriginal == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro.", "Aviso");
                return;
            }

            imagemNegativa = GerarNegativo(imagemOriginal);
            picNegativa.Image = imagemNegativa;
            picNegativa.SizeMode = PictureBoxSizeMode.Zoom;
            lblNegativa.Text = $"Negativo: {imagemNegativa.Width}x{imagemNegativa.Height} px";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemNegativa == null)
            {
                MessageBox.Show("Gere o negativo primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Salvar imagem negativa";
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "negativo";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemNegativa.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // G(x,y) = 255 - F(x,y) — aplicado canal a canal (funciona em colorido e cinza)
        private Bitmap GerarNegativo(Bitmap original)
        {
            Bitmap negativo = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original.GetPixel(x, y);

                    int r = 255 - c.R;
                    int g = 255 - c.G;
                    int b = 255 - c.B;

                    negativo.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return negativo;
        }
    }
}
