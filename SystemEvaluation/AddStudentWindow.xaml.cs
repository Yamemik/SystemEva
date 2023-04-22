using System.Windows;
using System.Data.OleDb;
using System.Data;

namespace SystemEvaluation
{
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
            StudentWindow studentWindow = new StudentWindow();
            OleDbCommand command = new OleDbCommand("select * from Группы",studentWindow.connect);
            cbGroup.ItemsSource = command.ExecuteReader();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            var result = MessageBox.Show("Отменить действие?", "...", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            { this.Close(); studentWindow.Show(); }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            OleDbCommand cmd = new OleDbCommand();

            if (studentWindow.connect.State != ConnectionState.Open)
                studentWindow.connect.Open();
            cmd.Connection = studentWindow.connect;

            if (id.Text != "")
            {
                if (id.IsEnabled == true)
                {
                    if (cbGroup.Text != "cbGroup")
                    {
                        cmd.CommandText = "insert into Студенты(КодСтудента,НомерЗачетнойКнижки,Фамилия,Имя,Отчество,КодГруппы)" +
                            "Values(" 
                            + id.Text + "," +
                            number.Text + "," +
                            "'" + family.Text + "'," +
                            "'" + name.Text + "'," +
                            "'" + putr.Text + "'," +
                            cbGroup.Text +
                                    ")";
                        cmd.ExecuteNonQuery();

                        studentWindow.BindGrid("select * from Студенты");
                        MessageBox.Show("Сохранено..");
                    }
                    else
                    {
                        MessageBox.Show("Выберите группу");
                    }
                }
                else
                {
                    cmd.CommandText = "update Студенты set НомерЗачетнойКнижки=" + number.Text + ",Фамилия='" + family.Text + "',"
                        + "Имя='" + name.Text + "',Отчество='" + putr.Text + "',КодГруппы=" + cbGroup.Text + " " +
                        "where КодСтудента=" + id.Text;
                    cmd.ExecuteNonQuery();

                    studentWindow.BindGrid("select * from Студенты");
                    MessageBox.Show("Employee Details Updated Succesffully...");
                }
            }
            else
            {
                MessageBox.Show("Заполните КодСтудента");
            }
            studentWindow.Show();
            this.Close();
        }
    }
}
