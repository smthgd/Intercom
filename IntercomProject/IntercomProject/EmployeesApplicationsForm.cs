using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace IntercomProject
{
    public partial class EmployeesApplicationsForm : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public EmployeesApplicationsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT Фамилия, Имя, Отчество, 'Сотрудник' AS Тип FROM Сотрудники UNION SELECT Фамилия, Имя, Отчество, 'Пользователь' AS Тип FROM Пользователи;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView3.DataSource = dataTable;
                Controls.Add(dataGridView3);
            }
        }
    }
}
