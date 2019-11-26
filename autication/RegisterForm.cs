using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace autication
{
    public partial class RegisterForm : Form
    {
        DB db = new DB();
        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            var log = login.Text;
            var pass = password.Text;
            var user = name.Text;
            var pass_2 = password_2.Text;
            if (log != "" && pass != "" && user != "")
            {
            if (pass == pass_2)
            {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @ul", db.getConnection());
                    command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = log;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Пользователь уже есть");
                    }
                    else
                    {
                        MySqlCommand commands = new MySqlCommand("INSERT INTO `user` (login,password,name) VALUES('" + log + "','" + pass + "','" + user + "')", db.getConnection());
                        adapter.SelectCommand = commands;
                        adapter.Fill(table);
                        MessageBox.Show("Поздравляю вы зарегестрированный пользователь!");
                    }
            }
            else MessageBox.Show("Правильно повторите пароль!");
            }
            else MessageBox.Show("Заполните все поля!");
        }
    }
}
