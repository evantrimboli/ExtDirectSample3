using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using System.IO;    

namespace ExtDirectSample
{
    public static class Database
    {

        private const string DB_PATH = "/Database/sample.db";
        private const string CREATE_PATH = "/Database/create.txt";

        private static SQLiteConnection OpenConnection()
        {
            return Database.OpenConnection(false);
        }

        private static SQLiteConnection OpenConnection(bool dontCheck)
        {
            if (!dontCheck)
            {
                Database.EnsureDB();
            }
            string fn = Database.GetPath(DB_PATH);
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + fn + ";Version=3;");
            conn.Open();
            return conn;
        }

        public static int ExecuteID(SQLiteCommand command)
        {
            int id = 0;
            using (SQLiteConnection conn = Database.OpenConnection())
            {
                command.Connection = conn;
                using (command)
                {
                    command.ExecuteNonQuery();

                    SQLiteCommand newid = new SQLiteCommand("select last_insert_rowid();", conn);
                    id = Convert.ToInt32(newid.ExecuteScalar());
                    newid.Dispose();
                }
            }
            return id;
        }

        public static object ExecuteScalar(SQLiteCommand command)
        {
            object o = null;
            using (SQLiteConnection conn = Database.OpenConnection())
            {
                command.Connection = conn;
                using (command)
                {
                    o = command.ExecuteScalar();
                }
            }
            return o;
        }

        public static void ExecuteNonQuery(SQLiteCommand command)
        {
            using (SQLiteConnection conn = Database.OpenConnection())
            {
                command.Connection = conn;
                using (command)
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataSet Execute(SQLiteCommand command)
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = Database.OpenConnection())
            {
                command.Connection = conn;
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(ds);
                }
            }
            return ds;
        }

        public static DataRow ExecuteRow(SQLiteCommand command)
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = Database.OpenConnection())
            {
                command.Connection = conn;
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0];
                }
            }
            return null;
        }

        public static void CreateDB()
        {
            string fn = Database.GetPath(DB_PATH);
            if (Database.DBExists())
            {
                System.IO.File.Delete(fn);
            }
            System.IO.File.Create(fn).Close();

            using (SQLiteConnection conn = Database.OpenConnection(true))
            {
                string init = System.IO.File.ReadAllText(Database.GetPath(CREATE_PATH));
                using (SQLiteCommand command = new SQLiteCommand(init, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void EnsureDB()
        {
            if (!Database.DBExists())
            {
                Database.CreateDB();
            }
        }

        private static bool DBExists()
        {
            return File.Exists(Database.GetPath(DB_PATH));
        }

        private static string GetPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }

    }
}
