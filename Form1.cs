namespace AjedrezVisual
{
    public partial class Form1 : Form
    {
        string[,] tablero = new string[8, 8];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            foreach (Control control in panel1.Controls.OfType<PictureBox>())
            {
                PictureBox pictureBox = (PictureBox)control;
                tablero[i, j] = pictureBox.Name + " " + pictureBox.Location.X.ToString() + "," + pictureBox.Location.Y.ToString();

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
