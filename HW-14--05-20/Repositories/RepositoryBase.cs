using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HW_14__05_20.Repositories
{
    public abstract class RepositoryBase<T>
    {
        public string ConnString { get; private set; }
        public RepositoryBase()
        {
            ConnString = "Data source=localhost; Initial catalog=AlifAcademy; Integrated security=true";
        }
        public List<T> SelectAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnString))
                {
                    return db.Query<T>($"SELECT * FROM {typeof(T).Name?.ToUpper()}").ToList();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return null;
            }
        }
    }
}
