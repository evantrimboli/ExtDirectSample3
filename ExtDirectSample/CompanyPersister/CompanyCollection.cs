using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;

namespace ExtDirectSample
{
    public class CompanyCollection : List<Company>
    {

        public enum Direction
        {
            ASC = 1,
            DESC = 2
        }

        private string orderField;
        private Direction orderDiection;

        public void Load()
        {
            this.DoLoad(0, 0);
        }

        public void Page(int start, int limit)
        {
            this.DoLoad(start, limit);
        }

        private void DoLoad(int start, int limit)
        {
            this.Clear();
            this.IsLoaded = false;
            SQLiteCommand command = new SQLiteCommand(this.GetQuery(this.orderField, this.GetDirection(), start, limit));
            DataSet ds = Database.Execute(command);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Company c = new Company(row);
                this.Add(c);
            }
            this.IsLoaded = true;
        }

        private string GetQuery(string order, string direction, int start, int limit)
        {
            string s = String.Format("SELECT * FROM Company ORDER BY {0} {1}", order, direction);
            if (limit > 0)
            {
                s += String.Format(" LIMIT {0} OFFSET {1}", limit.ToString(), start.ToString());
            }
            return s;
        }

        public bool IsLoaded
        {
            get;
            private set;
        }

        public string OrderField
        {
            get
            {
                if (string.IsNullOrEmpty(this.orderField))
                {
                    this.orderField = "Name";
                }
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }

        public Direction OrderDirection
        {
            get;
            set;
        }

        private string GetDirection()
        {
            return this.OrderDirection == Direction.DESC ? "DESC" : "ASC";
        }

    }
}
