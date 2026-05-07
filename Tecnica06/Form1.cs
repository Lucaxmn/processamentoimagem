using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica06
{
    public partial class Form1 : Form
    {
        private Bitmap? imagemOriginal;
        private Bitmap? imagemInvertida;

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

            picInvertida.Image = null;
            lblInvertida.Text = "Clique em Inverter para ver o resultado";
            imagemInvertida = null;
        }

        private void btnInverter_Click(object sender, EventArgs e)
        {
            if (imagemOriginal == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro.", "Aviso");
                return;
            }

            imagemInvertida = InvertarHorizontal(imagemOriginal);

            picInvertida.Image = imagemInvertida;
            picInvertida.SizeMode = PictureBoxSizeMode.Zoom;
            lblInvertida.Text = $"Invertida (esq → dir): {imagemInvertida.Width}x{imagemInvertida.Height} px";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imagemInvertida == null)
            {
                MessageBox.Show("Inverta a imagem primeiro.", "Aviso");
                return;
            }

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Salvar imagem invertida";
            dlg.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpg";
            dlg.FileName = "invertida";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            imagemInvertida.Save(dlg.FileName);
            MessageBox.Show("Imagem salva com sucesso!", "Salvo");
        }

        // Cada pixel da coluna x vai para a coluna (largura - 1 - x)
        private Bitmap InvertarHorizontal(Bitmap original)
        {
            int largura = original.Width;
            int altura = original.Height;
            Bitmap resultado = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color pixel = original.GetPixel(x, y);
                    resultado.SetPixel(largura - 1 - x, y, pixel);
                }
            }

            return resultado;
        }
    }
}
