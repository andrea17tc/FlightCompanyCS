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

namespace CompanieZborGUI
{
    public partial class Form2 : Form
    {
        Service service;
        public Form2(Service service)
        {
            this.service = service;
            InitializeComponent();
            Form2_Load();
        }

        private void Form2_Load()
        {
            List<string> destinations= service.findAllFlightDestinations().ToList();
            comboBoxDestination.Text = "Destination";
            comboBoxDestination.DataSource = destinations;
            comboBoxDestination.SelectedIndex = 0;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DateOnly d = DateOnly.Parse(dateTimePicker1.Value.ToShortDateString());
            string destination = comboBoxDestination.Text;

            List<Flight> flights = service.findFlightsByDestinationAndDate(destination, d).ToList();
            dataGridView1.DataSource= flights;
        }
    }
}
