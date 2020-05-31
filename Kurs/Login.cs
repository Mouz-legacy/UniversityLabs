using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            buttonLogin1.RoundingEnable = true;
            DoubleBuffered = true;
        }

        private void buttonLogin1_Click(object sender, EventArgs e)
        {
            string loginUser = loginField1.TextInput;
            string passUser = passwordField1.TextInput;

            DataBase db = new DataBase();//Работа с БД
            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.GetConnection());//Получаем доступ ко всем записям из таблица users в нашей бд
            //и проверяем на соответсвие с введёнными данными(юзаем заглушки)
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            //Теперь обращаемся к адаптеру

            adapter.SelectCommand = command;//Выполняем выбранную команду
            adapter.Fill(dataTable);

            if(dataTable.Rows.Count > 0)//Если хотя бы 1 ряд совпал, то со 100% увереностью можем его логинить
            {
                MessageBox.Show("Seccesfully Log in");
            }
            else
            {
                MessageBox.Show("Check entered data or register new account");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Registration();
        }
    }
}
