using haySchool.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Collections.Generic;
using System;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace haySchool.Controllers
{
    public class SonucController : Controller
    {
        public IActionResult Index()
        {
            List<Sonuc> displaysonuc = new List<Sonuc>();
            Genel genel = new Genel();
            genel.OpenConection();

            NpgsqlDataReader datareader = genel.DataReader("Select sonuc_id,sonuc_sinav_id, sonuc_ogrenci_id, " +
                "sonuc_puan, sonuc_ders_id, sinav_id, sinav_date, ogrenci_id, ogrenci_adi, ogrenci_soyadi, ders_id, ders_adi from sonuclar inner join" +
                " sinavlar on " +
                "sonuclar.sonuc_sinav_id = sinavlar.sinav_id inner join ogrenciler on sonuclar.sonuc_ogrenci_id=ogrenciler.ogrenci_id " +
                "inner join dersler on sonuclar.sonuc_ders_id=dersler.ders_id  where sonuc_aktif=true");

            while (datareader.Read())
            {
                var sonuc = new Sonuc();
                sonuc.sonuc_id = Convert.ToInt32(datareader["sonuc_id"]);
                sonuc.sonuc_sinav_adi = datareader["ders_adi"].ToString() + " " + Convert.ToDateTime( datareader["sinav_date"]);
                sonuc.sonuc_ogrenci_adi = datareader["ogrenci_adi"] + " " + datareader["ogrenci_soyadi"].ToString();
                sonuc.sonuc_puan = Convert.ToInt32(datareader["sonuc_puan"]);

                displaysonuc.Add(sonuc);
            }
            return View(displaysonuc);
        }

        [HttpGet]
        public IActionResult SonucEkle()
        {

            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();
            List<SelectListItem> values3 = new List<SelectListItem>();



            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM sinavlar where sinav_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["sinav_date"].ToString(),

                                Value = reader["sinav_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v21 = values1;


                }

            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogrenciler where ogrenci_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values2.Add(new SelectListItem
                            {
                                Text = reader["ogrenci_adi"].ToString() + " " + reader["ogrenci_soyadi"].ToString(),


                                Value = reader["ogrenci_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v25 = values2;


                }

            }


            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM dersler where ders_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values3.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString(),


                                Value = reader["ders_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v26 = values3;


                }

            }

            return View();
        }


        [HttpPost]
        public IActionResult SonucEkle(Sonuc sonuc)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("sonuc_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_sonuc_sinav_id", sonuc.sonuc_sinav_id);
                    command.Parameters.AddWithValue("p_sonuc_ogrenci_id", sonuc.sonuc_ogrenci_id);
                    command.Parameters.AddWithValue("p_sonuc_puan", sonuc.sonuc_puan);
                    command.Parameters.AddWithValue("p_sonuc_ders_id", sonuc.sonuc_ders_id);
                    sonuc.sonuc_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
            //return View(ders);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SonucGuncelle(int id)
        {

            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();
            List<SelectListItem> values3 = new List<SelectListItem>();



            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM sinavlar where sinav_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["sinav_date"].ToString(),

                                Value = reader["sinav_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v21 = values1;


                }

            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogrenciler where ogrenci_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values2.Add(new SelectListItem
                            {
                                Text = reader["ogrenci_adi"].ToString() + " " + reader["ogrenci_soyadi"].ToString(),


                                Value = reader["ogrenci_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v25 = values2;


                }

            }


            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM dersler where ders_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values3.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString(),


                                Value = reader["ders_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v26 = values3;


                }

            }   

            Sonuc sonuc = new Sonuc();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from sonuclar where sonuc_id=@sonuc_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@sonuc_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                sonuc.sonuc_id   = Convert.ToInt32(datatable.Rows[0][0].ToString());
                sonuc.sonuc_sinav_id = Convert.ToInt32(datatable.Rows[0][1].ToString());
                sonuc.sonuc_ogrenci_id = Convert.ToInt32(datatable.Rows[0][2].ToString());
                sonuc.sonuc_puan = Convert.ToInt32(datatable.Rows[0][3].ToString());
                sonuc.sonuc_ders_id = Convert.ToInt32(datatable.Rows[0][4].ToString());
               


                return View(sonuc);
            }
            else

                return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult SonucGuncelle(Sonuc sonuc)
        {

            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("sonuc_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_sonuc_id", sonuc.sonuc_id);
                    command.Parameters.AddWithValue("p_sonuc_sinav_id", sonuc.sonuc_sinav_id);
                    command.Parameters.AddWithValue("p_sonuc_ogrenci_id", sonuc.sonuc_ogrenci_id);
                    command.Parameters.AddWithValue("p_sonuc_puan", sonuc.sonuc_puan);
                    command.Parameters.AddWithValue("p_sonuc_ders_id", sonuc.sonuc_ders_id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE sonuclar SET sonuc_sinav_id=@sonuc_sinav_id , sonuc_ogrenci_id=@sonuc_ogrenci_id," +
            //        " sonuc_puan=@sonuc_puan, sonuc_ders_id=@sonuc_ders_id" +
            //        " WHERE sonuc_id=@sonuc_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@sonuc_id", sonuc.sonuc_id);
            //        cmd.Parameters.AddWithValue("@sonuc_sinav_id", sonuc.sonuc_sinav_id);
            //        cmd.Parameters.AddWithValue("@sonuc_ogrenci_id", sonuc.sonuc_ogrenci_id);
            //        cmd.Parameters.AddWithValue("@sonuc_puan", sonuc.sonuc_puan);
            //        cmd.Parameters.AddWithValue("@sonuc_ders_id", sonuc.sonuc_ders_id);

            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }

        public ActionResult SonucSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("sonuc_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_sonuc_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}
