using System;
using System.Windows;
using System.Data;
using System.Data.OleDb;

namespace SystemEvaluation
{
    /// <summary>
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public string connection = "Provider=Microsoft.Ace.OLEDB.12.0; Data Source=" + 
                AppDomain.CurrentDomain.BaseDirectory + "\\db.accdb";
        /*public string connection = "Provider=Microsoft.Ace.OLEDB.12.0;" +
            @"Data Source=D:\!Visual Studio Source\SystemEvaluation\SystemEvaluation\bin\Debug\db.accdb;" +
            "User Id=Admin;Password=;";*/
        public DataTable dataTable;
        public OleDbConnection connect;

        public StudentWindow()
        {
            InitializeComponent();
            connect = new OleDbConnection();
            connect.ConnectionString = connection;
            BindGrid("select * from Студенты");
        }

        public void BindGrid(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            if (connect.State != ConnectionState.Open)
                    connect.Open();

            OleDbCommand cmd = new OleDbCommand(selectSQL, connect); // создаём запрос
            //cmd.Connection = connect;
            //cmd.CommandText = "select * from Сотрудники";


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            dataTable = new DataTable();
            da.Fill(dataTable);
            dgStudents.ItemsSource = dataTable.AsDataView();


            //OleDbDataReader reader = cmd.ExecuteReader(); // получаем данные

            //return reader; // возвращаем
        }

        private void btnToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.Show();
            this.Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudents.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)dgStudents.SelectedItems[0];

                OleDbCommand cmd = new OleDbCommand();
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "delete from Студенты where КодСтудента=" + row["КодСтудента"].ToString();
                cmd.ExecuteNonQuery();
                BindGrid("select * from Студенты");
                MessageBox.Show("Удаление выполнено");
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.Show();
            this.Close();

            if (dgStudents.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)dgStudents.SelectedItems[0];

                addStudentWindow.id.Text = row["КодСтудента"].ToString();
                addStudentWindow.number.Text = row["НомерЗачетнойКнижки"].ToString();
                addStudentWindow.family.Text = row["Фамилия"].ToString();
                addStudentWindow.name.Text = row["Имя"].ToString();
                addStudentWindow.putr.Text = row["Отчество"].ToString();
                addStudentWindow.cbGroup.Text = row["КодГруппы"].ToString();

                addStudentWindow.id.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения");
            }
        }
    }
}
