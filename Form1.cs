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
            //Info;
        }

        public void ActualizarTablero()
        {

            int i = 0;
            int j = 0;

            foreach (PictureBox picture in panel1.Controls.OfType<PictureBox>().Reverse<PictureBox>())
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
                        pbPieza.Cursor = Cursors.Hand;
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
                    }
                    else if (tagValue.Contains("Black") && !Turno)
                    {
                        MessageBox.Show("No puedes mover la pieza a esta posición");
                        return;
                    }

                    int ancho = pictureBox.Size.Width;
                    int alto = pictureBox.Size.Height;

                    switch (pictureBox.Tag.ToString())
                    {
                        case "Black_Rook":
                            if (movimientos.MovimientoTorre(posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, tablero, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover la torre a esta posición");
                                return;
                            }
                        case "White_Rook":
                            if (movimientos.MovimientoTorre(posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, tablero, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover la torre a esta posición");
                                return;
                            }
                        case "Black_Knight":
                            if (movimientos.MovimientoCaballo(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el caballo a esta posición");
                                return;
                            }
                        case "White_Knight":
                            if (movimientos.MovimientoCaballo(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el caballo a esta posición");
                                return;
                            }
                            break;
                        case "Black_Bishop":
                            if (movimientos.MovimientoAlfil(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el alfil a esta posición");
                                return;
                            }
                            break;
                        case "White_Bishop":
                            if (movimientos.MovimientoAlfil(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el alfil a esta posición");
                                return;
                            }
                            break;
                        case "Black_Queen":
                            if (movimientos.MovimientoReina(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover la reina a esta posición");
                                return;
                            }
                        case "White_Queen":
                            if (movimientos.MovimientoReina(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover la reina a esta posición");
                                return;
                            }
                        case "Black_King":
                            if (movimientos.MovimientoRey(posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el rey a esta posición");
                                return;
                            }
                        case "White_King":
                            if (movimientos.MovimientoRey(posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el rey a esta posición");
                                return;
                            }
                        case "Black_Pawn":

                            if (movimientos.MovimientoPeon(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el peón a esta posición");
                                return;
                            }
                        case "White_Pawn":

                            if (movimientos.MovimientoPeon(tablero, posicionInicial.X, posicionInicial.Y, posicionFinal.X, posicionFinal.Y, alto, ancho))
                            {
                                MoverPieza(sender, e);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede mover el peón a esta posición");
                                return;
                            }
                        default:
                            MessageBox.Show("Pieza inválida");
                            break;
                    }
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

        private void MoverPieza(object sender, EventArgs e)
        {

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
                sender.GetType().GetProperty("Image").SetValue(sender, pbPieza.Image);
                sender.GetType().GetProperty("Tag").SetValue(sender, pbPieza.Tag);


                pictureBox.Image = null;
                pictureBox.Tag = "";
                pbPieza.Image = null;
                pbPieza.Tag = "";
                turno = !turno;
                Jugador();
                ActualizarTablero();
            }
        }

        private void SelectNewPz(object sender, EventArgs e)
        {
            pbPieza.Cursor = Cursors.Default;
            pbPieza.Image = null;
            pbPieza.Tag = "";
            seleccion = 0;
        }

        private void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Elegir la pieza a mover dando un clic sobre ella y que corresponda al color del turno.\r\n\n2. Para mover la pieza dar doble clic a la dirección de destino.\r\n\n3. Si se desea cambiar a la pieza a mover presionar la imagen que se muestra a la derecha para poder seleccionar la nueva pieza.", "Como jugar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Creditos(object sender, EventArgs e)
        {
            MessageBox.Show("1. Aguilera Hernández Andres\n\n\n2. Becerra Rojas Angel Alejandro\n\n\n3. Moreno Flores Christian Axel", "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}