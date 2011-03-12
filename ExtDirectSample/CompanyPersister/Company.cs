using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Data.SQLite;
using Newtonsoft.Json.Converters;

namespace ExtDirectSample
{
    [JsonObject]
    public class Company
    {

        public Company() : this(0)
        {

        }

        public Company(int id)
        {
            this.Id = id;
            if (this.IsLoaded)
            {
                this.Load();
            }
        }

        public Company(DataRow row)
        {
            this.InitData(row);
        }

        [JsonIgnore]
        public bool IsLoaded
        {
            get
            {
                return this.Id > 0;
            }
        }

        [JsonProperty(PropertyName = "id")]
        public int Id
        {
            get;
            private set;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "employees")]
        public int Employees
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "turnover")]
        public decimal TurnOver
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "started")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Started
        {
            get;
            set;
        }

        public void Save()
        {
            if (this.IsLoaded)
            {
                SQLiteCommand command = new SQLiteCommand("UPDATE Company SET Name = @name, Employees = @employees, TurnOver = @turnover, Started = @started WHERE Id = @id");
                command.Parameters.AddWithValue("@name", this.Name);
                command.Parameters.AddWithValue("@employees", this.Employees);
                command.Parameters.AddWithValue("@turnover", this.TurnOver);
                command.Parameters.AddWithValue("@started", this.Started);
                command.Parameters.AddWithValue("@id", this.Id);
                Database.ExecuteNonQuery(command);
            }
            else
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO Company (Id, Name, Employees, TurnOver, Started) VALUES (NULL, @name, @employees, @turnover, @started)");
                command.Parameters.AddWithValue("@name", this.Name);
                command.Parameters.AddWithValue("@employees", this.Employees);
                command.Parameters.AddWithValue("@turnover", this.TurnOver);
                command.Parameters.AddWithValue("@started", this.Started);
                this.Id = Database.ExecuteID(command);
            }
        }

        public void Destroy()
        {
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Company WHERE Id = @id");
            command.Parameters.AddWithValue("@id", this.Id);
            Database.ExecuteNonQuery(command);
        }

        public void Load()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Company WHERE Id = @id");
            command.Parameters.AddWithValue("@id", this.Id);
            this.InitData(Database.ExecuteRow(command));
        }

        private void InitData(DataRow row)
        {
            if (row != null)
            {
                this.Id = Convert.ToInt32(row["Id"]);
                this.Name = Convert.ToString(row["Name"]);
                this.Employees = Convert.ToInt32(row["Employees"]);
                this.TurnOver = Convert.ToDecimal(row["TurnOver"]);
                this.Started = Convert.ToDateTime(row["Started"]);
            }
        }

    }
}
