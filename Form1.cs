using AjedrezVisual.Properties;

namespace AjedrezVisual
{
    public partial class Form1 : Form
    {
        string[,] tablero = new string[8, 8];

        public Form1()
        {
            InitializeComponent();
            CrearTablero();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (PictureBox picture in panel1.Controls.OfType<PictureBox>().Reverse<PictureBox>())
            {
                switch (picture.Name)
                {
                    case "pictureBox1":
                        picture.Image = Resource1.Black_Rook;
                        break;
                    default:
                        picture.Image = null;
                        break;
                }
            }


        }

        public void CrearTablero()
        {
            int i = 0;
            int j = 0;

            foreach (PictureBox picture in panel1.Controls.OfType<PictureBox>().Reverse<PictureBox>())
            {
                tablero[i, j] = picture.Name + " " + picture.Location.X.ToString() + "," + picture.Location.Y.ToString();

                // Incrementa los índices
                j++;
                if (j >= tablero.GetLength(1)) // Si j ha llegado al final de las columnas
                {
                    j = 0; // Resetea j
                    i++; // Incrementa i
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    MessageBox.Show(tablero[i,j]);
                }
            }
        }
    }
}
