using CompanieZborGUI.service;

namespace CompanieZborGUI
{
    public partial class Form1 : Form
    {
        private Service service;
        public Form1(Service service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            if (service.findUser(username, password))
            {
                Form2 form = new Form2(service);
                form.Show();
            }
            else
            {
                MessageBox.Show("Username si/sau parola incorecta!");
            }
        }
    }
}