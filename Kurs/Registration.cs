using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            myButton1.RoundingEnable = true;
            DoubleBuffered = true;
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            if (egoldsEnterMenu1.TextInput == " ")
                return;
            if (egoldsEnterMenu2.TextInput == " ")
                return;
            if (egoldsEnterMenu3.TextInput == " ")
                return;
            if (egoldsEnterMenu4.TextInput == " ")
                return;
            if (egoldsEnterMenu5.TextInput == " ")
                return;
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES (@login, @pass, @name, @surname)", db.GetConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = egoldsEnterMenu3.TextInput;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = egoldsEnterMenu1.TextInput;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = egoldsEnterMenu2.TextInput;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = egoldsEnterMenu4.TextInput;

            db.OpenConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("You were completely registered");
            }
            else
            {
                MessageBox.Show("Account was not created");
            }
            db.CloseConnection();
        }
    }
}
