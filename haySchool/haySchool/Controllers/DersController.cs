
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using haySchool.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace haySchool.Controllers
{
    public class DersController : Controller
    {



        public IActionResult Index()
        {


            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select * From dersler where ders_aktif=true");
            List<Ders> displayders = new List<Ders>();

            while (datareader.Read())
            {
                var ders = new Ders();
                ders.ders_id = Convert.ToInt32(datareader["ders_id"]);
                ders.ders_adi = datareader["ders_adi"].ToString();
                displayders.Add(ders);
            }
            genel.CloseConnection();
            return View(displayders);
        }



        [HttpGet]
        public IActionResult DersEkle()
        {
            return View();
        }


        [HttpPost]
        public IActionResult DersEkle(Ders ders)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("ders_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_ders_adi", ders.ders_adi);
                    ders.ders_id = Convert.ToInt32(command.ExecuteScalar());

                }
                connection.Close();
            }

            //return View(ders);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DersGuncelle(int id)
        {
         
            Ders ders = new Ders();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from dersler where ders_id=@ders_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ders_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                ders.ders_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                ders.ders_adi = datatable.Rows[0][1].ToString();

                return View(ders);
            }
            else

                return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult DersGuncelle(Ders ders)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("ders_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_ders_id", ders.ders_id);
                    command.Parameters.AddWithValue("p_ders_adi", ders.ders_adi);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }

            return RedirectToAction("Index");
        }

        public ActionResult DersSil(int id)
        {
          
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("ders_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_ders_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }


    }




}
