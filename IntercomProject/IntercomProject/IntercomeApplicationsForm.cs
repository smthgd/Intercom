﻿using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace IntercomProject
{
    public partial class IntercomeApplicationsForm : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public IntercomeApplicationsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Домофоны;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView4.DataSource = dataTable;
                Controls.Add(dataGridView4);
            }
        }
    }
}
