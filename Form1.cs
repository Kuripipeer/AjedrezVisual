namespace AjedrezVisual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Location" + button1.Location.X.ToString() +"\n"+button1.Location.Y.ToString());
            //button1.Image = Image.FromFile("C:\\Users\\Usuario\\source\\repos\\AjedrezVisual\\AjedrezVisual\\Resources\\alfil.png");
            
            Application.Exit();


        }
    }
}
