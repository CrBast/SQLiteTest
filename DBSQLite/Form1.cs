using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.SQLite;

namespace DBSQLite
{
    public partial class Form1 : Form
    {
        private SQLiteCommand sql_Cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(".\\Data\\")){
                if (File.Exists(""))
                {

                }
                else
                {
                    SQLiteConnection.CreateFile(".\\Data\\MyDatabase.db");
                }
            }
            else
            {
                Directory.CreateDirectory(".\\Data\\");
                SQLiteConnection.CreateFile(".\\Data\\MyDatabase.db");
            }
            

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=.\\Data\\MyDatabase.db;Version=3;");
            m_dbConnection.Open();

            string sql = "create table highscores (name varchar(20), score int)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Me', 9001)";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
        
    }
}
