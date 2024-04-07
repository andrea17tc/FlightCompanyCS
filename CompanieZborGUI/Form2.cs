using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanieZborGUI.service;
using CompanieZborGUI.model;
using CompanieZborGUI.utils;

namespace CompanieZborGUI
{
    public partial class Form2 : Form, IObserver
    {
        Service service;
        public Form2(Service service)
        {
            this.service = service;
            service.addObserver(this);
            InitializeComponent();
            Form2_Load();
        }

        private void Form2_Load()
        {
            List<string> destinations= service.findAllFlightDestinations().ToList();
            comboBoxDestination.Text = "Destination";
            comboBoxDestination.DataSource = destinations;
            comboBoxDestination.SelectedIndex = 0;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<Flight> flights = service.findAllAvailableFlights().ToList();
            dataGridView1.DataSource = flights;
            dataGridView1.Columns[4].Visible = false;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker1.Value.Date;
            string destination = comboBoxDestination.Text.Trim();

            List<Flight> flights = service.findFlightsByDestinationAndDate(destination, d).ToList();
            if( flights.Count == 0 )
            {
                dataGridView1.Visible = false;
                labelAllFlights.Visible= false;
                Label noFlights = new Label();
                noFlights.Location = new Point(81, 132);
                noFlights.Text = "No Flights Available For Your Date";
                noFlights.AutoSize = true;
                noFlights.Font = new Font("Calibri", 18);
                noFlights.ForeColor = Color.Red;
                noFlights.Padding = new Padding(2);
                this.Controls.Add(noFlights);

            }
            else
            {
                dataGridView1.DataSource= flights;
                dataGridView1.Columns[4].Visible= false;
            }
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            string stringId = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            int id = int.Parse(stringId);
            if( id == 0 ) 
            {
                MessageBox.Show("Select flight first!");
            }
            else
            {  
                service.setFlightID(id);
                Form3 form = new Form3(service,this);  
                form.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void update()
        {
            Form2_Load();
        }
    }
}
