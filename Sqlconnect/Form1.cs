using Microsoft.Data.SqlClient;
using System.Data;

namespace Sqlconnect
{
    public partial class Form1 : Form
    {
        string sqlconnectionstring =
        int rowSelectionIndex =0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataLoadFromDB();
        }
        private void DataLoadFromDB()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnectionstring);
                string query = "SELECT * FROM Books";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelectedIndex = e.RowIndex;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBoxTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                textBoxPublisher.Text = selectedRow.Cells["Publisher"].Value.ToString();
                textBoxPages.Text = selectedRow.Cells["Pages"].Value.ToString();
            }
        }
    }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string title = textBoxTitle.Text;
                string publisher = textBoxPublisher.Text;
                int pages = int.Parse(textBoxPages.Text);

                SqlConnection sqlConnection = new SqlConnection(sqlconnectionstring);
                string query = "INSERT INTO Books (Title, Publisher, Pages) VALUES (@Title, @Publisher, @Pages)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Title", title);
                sqlCommand.Parameters.AddWithValue("@Publisher", publisher);
                sqlCommand.Parameters.AddWithValue("@Pages", pages);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record inserted successfully.");
                DataLoadFromDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
