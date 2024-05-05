using AjedrezVisual.Properties;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using static System.Windows.Forms.DataFormats;

namespace AjedrezVisual
{
    public partial class Form1 : Form
    {
        Movimientos movimientos = new Movimientos();

        int seleccion = 0;
        string[,] tablero = new string[8, 8];
        bool turno = true;
        string pieza = "";
        Point posicionInicial, posicionFinal;

        public Form1()
        {
            InitializeComponent();
            Jugador();
            ActualizarTablero();
        }

        public void ActualizarTablero()
        {
            int i = 0;
            int j = 0;

            foreach (PictureBox picture in panel1.Controls.OfType<PictureBox>())
            {
                if (picture.Tag != null)
                {
                    tablero[i, j] = picture.Tag.ToString();
                }
                else
                {
                    tablero[i, j] = " ";
                }


                // Incrementa los índices
                j++;
                if (j >= tablero.GetLength(1)) // Si j ha llegado al final de las columnas
                {
                    j = 0; // Resetea j
                    i++; // Incrementa i
                }
            }
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

                        string tag = "";
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                tag += tablero[i, j] + " - ";
                            }
                            tag += "\n";
                        }
                        MessageBox.Show(tag);

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
            string tagValue = "";
            if (seleccion == 1)
            {
                // Obtiene la posición de un control PictureBox
                Point position = GetPictureBoxPosition(sender);
                posicionFinal = position;
                
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
                    }

                    if (tagValue.Contains("White") && Turno)
                    {
                        MessageBox.Show("No puedes mover la pieza a esta posición");
                        return;
                    } else if (tagValue.Contains("Black") && !Turno)
                    {
                        MessageBox.Show("No puedes mover la pieza a esta posición");
                        return;
                    }

                    switch (pictureBox.Tag.ToString())
                    {
                        case "Black_Rook":
                            MessageBox.Show("Test");
                            if (movimientos.MovimientoTorre(posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, tablero))
                            {
                                ActualizarTablero();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover la torre a esta posición");
                                return;
                            }
                        case "White_Rook":
                            MessageBox.Show("Test");
                            if (movimientos.MovimientoTorre(posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, tablero))
                            {
                                ActualizarTablero();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover la torre a esta posición");
                                return;
                            }
                        case "Black_Knight":
                            break;
                        case "White_Knight":
                            break;
                        case "Black_Bishop":
                            break;
                        case "White_Bishop":
                            break;
                        case "Black_Queen":
                            break;
                        case "White_Queen":
                            break;
                        case "Black_King":
                            break;
                        case "White_King":
                            break;
                        case "Black_Pawn":
                            break;
                        case "White_Pawn":
                            break;
                        default:
                            MessageBox.Show("Pieza inválida");
                        break;
                    }

                    // movimientos

                    sender.GetType().GetProperty("Image").SetValue(sender, pbPieza.Image);
                    sender.GetType().GetProperty("Tag").SetValue(sender, pbPieza.Tag);
                    pictureBox.Image = null;
                    pictureBox.Tag = "";
                    pbPieza.Image = null;
                    pbPieza.Tag = "";
                    turno = !turno;
                    Jugador();
                    ActualizarTablero();
                    MessageBox.Show("Se actualiza ");

                    MessageBox.Show(pictureBox9.Tag.ToString() + " Tah");
                    string tag = "";
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            tag += tablero[i, j] + " - ";
                        }
                        tag += "\n";
                    }
                    MessageBox.Show(tag);
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