using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace autication
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
          
        }
        RegisterForm forms = new RegisterForm();
        private void label3_Click(object sender, EventArgs e)
        {
            forms.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var log = login.Text;
            var pass = password.Text;
            var name = "";

            DB db = new DB();
            //сколько элементов к конкретному элементу
            DataTable table = new DataTable();
            //команды которые выполняем 
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //команда для таблицы
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @ul AND `password` = @up ", db.getConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = pass;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {   
                MessageBox.Show("Здраствуйте " + table.Rows[0]["name"]+"!");
            }
            else
            {
                MessageBox.Show("Нет такого пользователя");
            }
        }
    }
}
