using AjedrezVisual.Properties;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace AjedrezVisual
{
    public partial class Form1 : Form
    {
        int seleccion = 0;
        string[,] tablero = new string[8, 8];

        public Form1()
        {
            InitializeComponent();
            CrearTablero();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
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

        private void SeleccionaPieza(object sender, EventArgs e)
        {
            // Obtiene la posición de un control PictureBox

            


            Point position = GetPictureBoxPosition(sender);
            if (sender is PictureBox pictureBox)
            {
                //Stream imageStream = Properties.Resources.ResourceManager.GetObject("Black_Rook").GetType().Assembly.GetManifestResourceStream("myImage.png");
                if (pictureBox.Image != null)
                {
                    string fileName = pictureBox.Tag.ToString();
                    //MessageBox.Show("Filename: " + fileName);
                    pbPieza.Image = pictureBox.Image;
                    pbPieza.Tag = pictureBox.Tag;



                    if (fileName.Contains("White"))
                    {
                        MessageBox.Show("Pieza blanca");
                    }
                    else
                    {
                        MessageBox.Show("Racista");
                    }

                    seleccion = 1;
                }
                else if (seleccion == 0)
                {
                    MessageBox.Show("Selecciona una pieza a mover.");
                }
            }
        }


        private Point GetPictureBoxPosition(object sender)
        {
            // Obtiene la posición de un control PictureBox
            Point point = sender.GetType().Name.ToLower() == "picturebox" ? ((PictureBox)sender).Location : new Point();
            return point;
        }

        private bool MoverPieza(object sender, EventArgs e)
        {
            if(seleccion == 1)
            {
                // Obtiene la posición de un control PictureBox
                Point position = GetPictureBoxPosition(sender);
                sender.GetType().GetProperty("Image").SetValue(sender, pbPieza.Image);
                sender.GetType().GetProperty("Tag").SetValue(sender, pbPieza.Tag);
                //pbPieza.Location = position;
                seleccion = 0;
                return true;
            }
            else
            {
                MessageBox.Show("Selecciona una pieza a mover.");
                return false;
            }
        }

        private void CasillaDestino(object sender, EventArgs e)
        {
            if(MoverPieza(sender, e))
            {
                // Obtiene la posición de un control PictureBox
                pbPieza.Image = null;
                pbPieza.Tag = null;
            }

            //// Obtiene la posición de un control PictureBox
            //Point position = GetPictureBoxPosition(sender);
            //MessageBox.Show("Posición final "+position.ToString());
        }
    }
}
