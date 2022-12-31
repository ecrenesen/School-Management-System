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
    public class SinavController : Controller
    {



        public IActionResult Index()
        {

            List<Sinav> displaysinav = new List<Sinav>();
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select sinav_id , sinav_ogretmen_id, sinav_ders_id,sinav_sinif_id, sinav_date, sinif_id, " +
                "sinif_sube,ders_id, ders_adi, ogretmen_id, ogretmen_adi, ogretmen_soyadi  from sinavlar inner join siniflar on sinavlar.sinav_sinif_id = siniflar.sinif_id " +
                "inner join dersler on sinavlar.sinav_ders_id = dersler.ders_id inner join ogretmenler on sinavlar.sinav_ogretmen_id = ogretmenler.ogretmen_id  where sinav_aktif=true");

            while (datareader.Read())
            {
                var sinav = new Sinav();
                sinav.sinav_id = Convert.ToInt32(datareader["sinav_id"]);
                sinav.sinav_ders_adi = datareader["ders_adi"].ToString();
                sinav.sinav_sinif_id = Convert.ToInt32(datareader["sinif_sube"]);
                sinav.sinav_date = Convert.ToDateTime(datareader["sinav_date"]);
                sinav.sinav_ogretmen_adi = datareader["ogretmen_adi"] + " " + datareader["ogretmen_soyadi"].ToString();

                displaysinav.Add(sinav);
            }
            return View(displaysinav);
        }
        [HttpGet]
        public IActionResult SinavEkle()
        {

            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();
            List<SelectListItem> values3 = new List<SelectListItem>();

            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM dersler", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString(),
                                Value = reader["ders_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v6 = values1;


                }



            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM siniflar where sinif_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values2.Add(new SelectListItem
                            {
                                Text = reader["sinif_sube"].ToString(),
                                Value = reader["sinif_id"].ToString()
                            });
                        }
                    }

                    ViewBag.v7 = values2;

                }

            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogretmenler where ogretmen_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values3.Add(new SelectListItem
                            {
                                Text = reader["ogretmen_adi"].ToString() + " " + reader["ogretmen_soyadi"].ToString(),


                                Value = reader["ogretmen_id"].ToString()
                            });
                        }
                    }

                    ViewBag.v10 = values3;

                }

            }

            return View();

        }


        [HttpPost]
        public IActionResult SinavEkle(Sinav sinav)
        {

            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("sinav_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_sinav_ders_id", sinav.sinav_ders_id);
                    command.Parameters.AddWithValue("p_sinav_sinif_id", sinav.sinav_sinif_id);
                    command.Parameters.AddWithValue("p_sinav_date", sinav.sinav_date);
                    command.Parameters.AddWithValue("p_sinav_ogretmen_id", sinav.sinav_ogretmen_id);

                    sinav.sinav_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SinavGuncelle(int id)
        {

            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();
            List<SelectListItem> values3 = new List<SelectListItem>();



            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM dersler ders_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString(),
                                Value = reader["ders_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v21 = values1;


                }

            }

          

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM siniflar sinif_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values2.Add(new SelectListItem
                            {
                                Text = reader["sinif_sube"].ToString(),
                                Value = reader["sinif_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v22 = values2;


                }

            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogretmenler ogretmen_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values3.Add(new SelectListItem
                            {
                                Text = reader["ogretmen_adi"].ToString() + " " + reader["ogretmen_soyadi"].ToString(),
                                Value = reader["ogretmen_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v23 = values3;


                }

            }



            Sinav sinav = new Sinav();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from sinavlar where sinav_id=@sinav_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@sinav_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                sinav.sinav_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                sinav.sinav_ders_id = Convert.ToInt32(datatable.Rows[0][1].ToString());
                sinav.sinav_sinif_id = Convert.ToInt32(datatable.Rows[0][2].ToString());
                sinav.sinav_date = Convert.ToDateTime(datatable.Rows[0][3].ToString());
                sinav.sinav_ogretmen_id = Convert.ToInt32(datatable.Rows[0][4].ToString());



                return View(sinav);
            }
            else

                return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult SinavGuncelle(Sinav sinav)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("sinav_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_sinav_id", sinav.sinav_id);
                    command.Parameters.AddWithValue("p_sinav_ders_id", sinav.sinav_ders_id);
                    command.Parameters.AddWithValue("p_sinav_sinif_id", sinav.sinav_sinif_id);
                    command.Parameters.AddWithValue("p_sinav_date", sinav.sinav_date);
                    command.Parameters.AddWithValue("p_sinav_ogretmen_id", sinav.sinav_ogretmen_id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE sinavlar SET sinav_ders_id=@sinav_ders_id ,
            //    sinav_sinif_id=@sinav_sinif_id , sinav_date=@sinav_date, " +
            //        "sinav_ogretmen_id=@sinav_ogretmen_id" +
            //        " WHERE sinav_id=@sinav_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@sinav_id", sinav.sinav_id);
            //        cmd.Parameters.AddWithValue("@sinav_ders_id", sinav.sinav_ders_id);
            //        cmd.Parameters.AddWithValue("@sinav_sinif_id", sinav.sinav_sinif_id);
            //        cmd.Parameters.AddWithValue("@sinav_date", sinav.sinav_date);
            //        cmd.Parameters.AddWithValue("@sinav_ogretmen_id", sinav.sinav_ogretmen_id);

            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }
        public ActionResult SinavSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("sinav_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_sinav_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }

    }
}