using haySchool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace haySchool.Controllers
{
    public class TaksitController : Controller
    {


        public IActionResult Index()
        {

            List<Taksit> displaytaksit = new List<Taksit>();
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select taksit_id , taksit_odeme_id, taksit_tarih, taksit_tutar " +
                "from taksitler inner join odemeler on taksitler.taksit_odeme_id = odemeler.odeme_id  where taksit_aktif=true");

            while (datareader.Read())
            {
                var taksit = new Taksit();
                taksit.taksit_id = Convert.ToInt32(datareader["taksit_id"]);
                taksit.taksit_odeme_id = Convert.ToInt32(datareader["taksit_odeme_id"]);
                taksit.taksit_tarih = Convert.ToDateTime(datareader["taksit_tarih"]);
                taksit.taksit_tutar = Convert.ToInt32(datareader["taksit_tutar"]);
               


                displaytaksit.Add(taksit);
            }
            return View(displaytaksit);
        }
        [HttpGet]
        public IActionResult TaksitEkle()
        {
            List<SelectListItem> values1 = new List<SelectListItem>();



            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM odemeler where odeme_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["odeme_id"].ToString(),

                                Value = reader["odeme_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v21 = values1;


                }

            }
            return View();
        }


        [HttpPost]
        public IActionResult TaksitEkle(Taksit taksit)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("taksit_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_taksit_odeme_id", taksit.taksit_odeme_id);
                    command.Parameters.AddWithValue("p_taksit_tarih", taksit.taksit_tarih);
                    command.Parameters.AddWithValue("p_taksit_tutar", taksit.taksit_tutar);
 
                    taksit.taksit_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult TaksitGuncelle(int id)
        {
           


            Taksit taksit = new Taksit();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from taksitler where taksit_id=@taksit_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@taksit_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                taksit.taksit_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                taksit.taksit_odeme_id = Convert.ToInt32(datatable.Rows[0][1].ToString());
                taksit.taksit_tarih = Convert.ToDateTime(datatable.Rows[0][2].ToString());
                taksit.taksit_tutar = Convert.ToInt32(datatable.Rows[0][3].ToString());
              



                return View(taksit);
            }
            else

                return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult TaksitGuncelle(Taksit taksit)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("taksit_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_taksit_id", taksit.taksit_id);
                    command.Parameters.AddWithValue("p_taksit_odeme_id", taksit.taksit_odeme_id);
                    command.Parameters.AddWithValue("p_taksit_tarih", taksit.taksit_tarih);
                    command.Parameters.AddWithValue("p_taksit_tutar", taksit.taksit_tutar);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE taksitler SET taksit_odeme_id=@taksit_odeme_id , taksit_tarih=@taksit_tarih ,
            //    taksit_tutar=@taksit_tutar" +
            //        " WHERE taksit_id=@taksit_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@taksit_id", taksit.taksit_id);
            //        cmd.Parameters.AddWithValue("@taksit_odeme_id", taksit.taksit_odeme_id);
            //        cmd.Parameters.AddWithValue("@taksit_tarih", taksit.taksit_tarih);
            //        cmd.Parameters.AddWithValue("@taksit_tutar", taksit.taksit_tutar);

            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }
        public ActionResult TaksitSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("taksit_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_taksit_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }

    }
}
