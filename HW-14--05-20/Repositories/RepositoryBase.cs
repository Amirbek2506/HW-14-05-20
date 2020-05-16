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
        public void DeleteById()
        {
            Console.WriteLine("Введите ID человека каторый вы хотели удалить его данны!!!");
            Console.Write("ID: "); int ID = int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(ConnString))
                {
                    var command = $"DELETE FROM {typeof(T).Name?.ToUpper()} WHERE Id ={ID}";
                    db.Execute(command, new { ID });
                    Console.WriteLine("Успешно удален!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
