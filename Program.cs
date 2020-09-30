using System;
using Npgsql;

namespace Version
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun";

            using var coni = new NpgsqlConnection(cs);
            coni.Open();

            var sql = "select * from musteri where bakiye>2000 order by id";

            using var cmd = new NpgsqlCommand(sql, coni);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"PostgreSQL version: {Int32.Parse(reader["id"].ToString())} {reader["ad"].ToString()} {reader["soyad"].ToString()} {reader["sehir"].ToString()} {Int32.Parse(reader["bakiye"].ToString())}");
                
                // val = Int32.Parse(reader[0].ToString());
                //do whatever you like
            }
            // var version = cmd.ExecuteNonQuery();
            // Console.WriteLine($"PostgreSQL version: {version}");
        }
    }
}