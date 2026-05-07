using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecnica01
{
    public partial class Form1 : Form
    {
        private Color[,] matrizImagem1;
        private Color[,] matrizImagem2;

        private Bitmap bmp1;
        private Bitmap bmp2;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregarImagem1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a primeira imagem";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            bmp1 = new Bitmap(dlg.FileName);
            picImagem1.Image = bmp1;
            picImagem1.SizeMode = PictureBoxSizeMode.Zoom;

            matrizImagem1 = CarregarMatriz(bmp1);

            lblInfo1.Text = $"Imagem 1: {bmp1.Width} x {bmp1.Height} px\n" +
                            $"Formato: {System.IO.Path.GetExtension(dlg.FileName).ToUpper()}\n" +
                            $"Matriz: {matrizImagem1.GetLength(0)} linhas x {matrizImagem1.GetLength(1)} colunas";

            MostrarAmostraPixels(matrizImagem1, txtPixels1);
        }

        private void btnCarregarImagem2_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecione a segunda imagem";
            dlg.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            bmp2 = new Bitmap(dlg.FileName);
            picImagem2.Image = bmp2;
            picImagem2.SizeMode = PictureBoxSizeMode.Zoom;

            matrizImagem2 = CarregarMatriz(bmp2);

            lblInfo2.Text = $"Imagem 2: {bmp2.Width} x {bmp2.Height} px\n" +
                            $"Formato: {System.IO.Path.GetExtension(dlg.FileName).ToUpper()}\n" +
                            $"Matriz: {matrizImagem2.GetLength(0)} linhas x {matrizImagem2.GetLength(1)} colunas";

            MostrarAmostraPixels(matrizImagem2, txtPixels2);
        }

        // Lê cada pixel da imagem e guarda numa matriz [linha, coluna]
        private Color[,] CarregarMatriz(Bitmap bmp)
        {
            int altura = bmp.Height;
            int largura = bmp.Width;

            Color[,] matriz = new Color[altura, largura];

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    matriz[y, x] = bmp.GetPixel(x, y);
                }
            }

            return matriz;
        }

        // Mostra os primeiros pixels no TextBox só pra visualizar
        private void MostrarAmostraPixels(Color[,] matriz, TextBox txt)
        {
            int linhasAmostra = Math.Min(5, matriz.GetLength(0));
            int colunasAmostra = Math.Min(5, matriz.GetLength(1));

            txt.Clear();
            txt.AppendText("Amostra dos primeiros pixels (R, G, B):\r\n\r\n");

            for (int y = 0; y < linhasAmostra; y++)
            {
                for (int x = 0; x < colunasAmostra; x++)
                {
                    Color c = matriz[y, x];
                    txt.AppendText($"[{y},{x}] R={c.R} G={c.G} B={c.B}   ");
                }
                txt.AppendText("\r\n");
            }
        }
    }
}
