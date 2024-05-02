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
            Application.Restart();
            foreach (PictureBox picture in panel1.Controls.OfType<PictureBox>().Reverse<PictureBox>())
            {
                switch (picture.Name)
                {
                    case "pictureBox1":
                        picture.Image = Resource1.White_Rook;
                        break;
                    case "pictureBox2":
                        picture.Image = Resource1.White_Knight;
                        break;    
                    case "pictureBox3":
                            picture.Image = Resource1.White_Bishop;
                        break;
                    case "pictureBox4":
                            picture.Image = Resource1.White_Queen;
                        break;
                    case "pictureBox5":
                            picture.Image = Resource1.White_King;
                        break;
                    case "pictureBox6":
                            picture.Image = Resource1.White_Bishop;
                        break;
                    case "pictureBox7":
                            picture.Image = Resource1.White_Knight;
                        break;
                        case "pictureBox8":
                            picture.Image = Resource1.White_Rook;
                        break;
                        case "pictureBox9":
                            picture.Image = Resource1.White_Pawn;
                        break;
                        case "pictureBox10":
                            picture.Image = Resource1.White_Pawn;
                        break;
                        case "pictureBox11":
                            picture.Image = Resource1.White_Pawn;
                        break;
                        case "pictureBox12":
                            picture.Image = Resource1.White_Pawn;
                        break;
                        case "pictureBox13":
                            picture.Image = Resource1.White_Pawn;
                        break;
                        case "pictureBox14":
                            picture.Image = Resource1.White_Pawn;
                        break;
                        case "pictureBox15":
                            picture.Image = Resource1.White_Pawn;
                        break;
                        case "pictureBox16":
                            picture.Image = Resource1.White_Pawn;
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
            pictureBox1.Image = Resource1.Black_Rook;
            //for (int i = 0; i < tablero.GetLength(0); i++)
            //{
            //    for (int j = 0; j < tablero.GetLength(1); j++)
            //    {
            //        MessageBox.Show(tablero[i,j]);
            //    }
            //}
        }
    }
}
