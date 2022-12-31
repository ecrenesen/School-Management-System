
using Npgsql;
using System.Data;

namespace haySchool.Models
{
    public  class Genel
    {


       public static string conString = "Server=localhost;Port=5432;Database=schoolManagementSystem;User Id=postgres;Password=12345;";

        NpgsqlConnection con;

        public void OpenConection()
        {
            con = new NpgsqlConnection(conString);
            con.Open();
        }


        public void CloseConnection()
        {
            con.Close();
        }

      


        //update ,delete
        public void ExecuteQueries(string sorgu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
        }

       
        //listeleme bilgisi
        public NpgsqlDataReader DataReader(string sorgu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        
        



    }
}
