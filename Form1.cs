using AjedrezVisual.Properties;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using static System.Windows.Forms.DataFormats;

namespace AjedrezVisual
{
    public partial class Form1 : Form
    {
        int seleccion = 0;
        // string[,] tablero = new string[8, 8];
        bool turno = true;
        string pieza = "";
        Point posicionInicial, posicionFinal;

        public Form1()
        {
            InitializeComponent();
            Jugador();
        }

        public bool Turno
        {
            get { return turno; }
            set { turno = value; }
        }
    
        public void Jugador()
        {
            if (Turno)
            {
                lblTurno.Text = "Turno de blancas";
            }
            else
            {
                lblTurno.Text = "Turno de negras";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resource1.Black_Rook;
            pictureBox1.Tag = "Black_Rook";
        }

        private void SeleccionaPieza(object sender, EventArgs e)
        {
            if (seleccion == 0)
            {
                // Obtiene la posición de un control PictureBox
                Point position = GetPictureBoxPosition(sender);
                posicionInicial = position;
            

                if (sender is PictureBox pictureBox)
                {
                    if (pictureBox.Image != null)
                    {
                        string fileName = pictureBox.Tag.ToString();
                        //MessageBox.Show("Filename: " + fileName
                        pbPieza.Image = pictureBox.Image;
                        pbPieza.Tag = pictureBox.Tag;
                        pieza = pictureBox.Name;

                        if (fileName.Contains("Black") && Turno)
                        {
                            MessageBox.Show("No puedes mover");
                            pbPieza.Image = null;
                            pbPieza.Tag = null;
                            return;
                        }
                        else if (fileName.Contains("White") && !Turno)
                        {
                            MessageBox.Show("No puedes mover");
                            pbPieza.Image = null;
                            pbPieza.Tag = null;
                            return;
                        }
                        
                        seleccion++;
                    }
                    else
                    {
                        MessageBox.Show("Selecciona una pieza a mover.");
                    }
                }
            }
        }
        private Point GetPictureBoxPosition(object sender)
        {
            // Obtiene la posición de un control PictureBox
            Point point = sender.GetType().Name.ToLower() == "picturebox" ? ((PictureBox)sender).Location : new Point();
            return point;
        }
        private void CasillaDestino(object sender, EventArgs e)
        {
            string tagValue = "Libre";
            if (seleccion == 1)
            {
                // Obtiene la posición de un control PictureBox
                Point position = GetPictureBoxPosition(sender);
                posicionFinal = position;
                //if (sender is PictureBox pictureBoxWithTag)
                //{
                //    tagValue = pictureBoxWithTag.Tag.ToString();
                //    MessageBox.Show("Tag value: " + tagValue);
                //}else
                //{
                //    MessageBox.Show("No tiene tag");
                //    tagValue = "Libre";
                //}

                if (posicionFinal == posicionInicial)
                {
                    MessageBox.Show("No se puede mover la pieza al mismo lugar");
                    return;
                }

                PictureBox pictureBox = null;
                foreach (Control control in panel1.Controls)
                {
                    if (control.Name == pieza && control is PictureBox)
                    {
                        pictureBox = (PictureBox)control;
                        break;
                    }
                }

                if (pictureBox != null && pictureBox.Image != null)
                {
                    if (sender is PictureBox pictureBoxWithTag)
                    {
                        if (pictureBoxWithTag.Tag != null)
                        {
                            tagValue = pictureBoxWithTag.Tag.ToString();
                        }
                        //Console.WriteLine("Tag value for PictureBox: " + tagValue);
                    }

                    if (tagValue.Contains("White") && tagValue != "Libre" && Turno)
                    {
                        MessageBox.Show("No puedes mover la pieza a esta posición");
                        return;
                    } else if (tagValue.Contains("Black") && tagValue != "Libre" && !Turno)
                    {
                        MessageBox.Show("No puedes mover la pieza a esta posición");
                        return;
                    }

                    sender.GetType().GetProperty("Image").SetValue(sender, pbPieza.Image);
                    sender.GetType().GetProperty("Tag").SetValue(sender, pbPieza.Tag);
                    // PictureBox found, perform actions on it
                    //MessageBox.Show("PictureBox found: " + pictureBox.Name);
                    pictureBox.Image = null;
                    pictureBox.Tag = null;
                    pbPieza.Image = null;
                    pbPieza.Tag = null;
                    turno = !turno;
                    Jugador();
                }
                else
                {
                    MessageBox.Show("No se puede mover la pieza a esta posición");
                }

                seleccion = 0;                
            }
            else
            {
                MessageBox.Show("Selecciona una pieza a mover.");
            }
        }
    }
}
