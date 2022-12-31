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
    public class EtutController : Controller
    {
        public IActionResult Index()
        {
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select etut_id, etut_ogrenci_id, etut_ders_id,etut_sinav_id, " +
                " ogrenci_id, ogrenci_adi, ogrenci_soyadi,ders_id,ders_adi" +
                " from etutler" +
                " inner join ogrenciler on etutler.etut_ogrenci_id=ogrenciler.ogrenci_id " +
                " inner join sinavlar on etutler.etut_sinav_id=sinavlar.sinav_id " +
                "inner join dersler on etutler.etut_ders_id=dersler.ders_id where etut_aktif=true");
            List<Etut> displayetut = new List<Etut>();
            while (datareader.Read())
            {


                var etut = new Etut();
                etut.etut_id = Convert.ToInt32(datareader["etut_id"]);
                etut.etut_ogrenci_adi = datareader["ogrenci_adi"] + " " + datareader["ogrenci_soyadi"].ToString();
                etut.etut_ders_adi = datareader["ders_adi"].ToString();
                etut.etut_sinav_id = Convert.ToInt32(datareader["etut_sinav_id"]);


                displayetut.Add(etut);
            }
            genel.CloseConnection();
            return View(displayetut);


        }
        [HttpGet]
        public IActionResult EtutEkle()
        {

            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();
            List<SelectListItem> values3 = new List<SelectListItem>();

            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogrenciler", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["ogrenci_adi"].ToString() + " " + reader["ogrenci_soyadi"].ToString(),
                                Value = reader["ogrenci_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v8 = values1;


                }



            }
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM dersler", connection))
            //    {
            //        using (NpgsqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                values2.Add(new SelectListItem
            //                {
            //                    Text = reader["ders_adi"].ToString(),

            //                    Value = reader["ders_id"].ToString()


            //            });
            //            }
            //        }

            //        ViewBag.v9 = values2;

            //    }

            //}
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT sinav_ders_id, sinav_date, sinav_id, ders_adi, ders_id" +
                    " FROM sinavlar inner join dersler on sinavlar.sinav_ders_id=dersler.ders_id", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values3.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString() + " " + reader["sinav_date"].ToString(),
                                Value = reader["sinav_id"].ToString()
                            });
                            values2.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString(),
                                Value = reader["sinav_ders_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v9 = values2;
                    ViewBag.v10 = values3;

                }

            }

            return View();
        }


        [HttpPost]
        public IActionResult EtutEkle(Etut etut)
        {

            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("etut_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_etut_ogrenci_id", etut.etut_ogrenci_id);
                    command.Parameters.AddWithValue("p_etut_ders_id", etut.etut_ders_id);
                    command.Parameters.AddWithValue("p_etut_sinav_id", etut.etut_sinav_id);
                    etut.etut_id = Convert.ToInt32(command.ExecuteScalar());

                }
                connection.Close();
            }


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EtutGuncelle(int id)
        {


            List<SelectListItem> values10 = new List<SelectListItem>();
            List<SelectListItem> values11 = new List<SelectListItem>();
            List<SelectListItem> values12 = new List<SelectListItem>();


            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT sinav_ders_id, sinav_date, sinav_id, ders_adi, ders_id" +
                    " FROM sinavlar inner join dersler on sinavlar.sinav_ders_id=dersler.ders_id", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values10.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString() + " " + reader["sinav_date"].ToString(),
                                Value = reader["sinav_id"].ToString()
                            });
                            values11.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString(),
                                Value = reader["sinav_ders_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v10 = values10;
                    ViewBag.v11 = values11;

                }

            }


            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogrenciler", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values12.Add(new SelectListItem
                            {
                                Text = reader["ogrenci_adi"].ToString() + " " + reader["ogrenci_soyadi"].ToString(),
                                Value = reader["ogrenci_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v12 = values12;


                }



            }
            Etut etut = new Etut();
            DataTable datatable = new DataTable();

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from etutler where etut_id=@etut_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@etut_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                etut.etut_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                etut.etut_ogrenci_id = Convert.ToInt32(datatable.Rows[0][1].ToString());
                etut.etut_ders_id = Convert.ToInt32(datatable.Rows[0][2].ToString());

                etut.etut_sinav_id = Convert.ToInt32(datatable.Rows[0][3].ToString());

                return View(etut);
            }
            else

                return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult EtutGuncelle(Etut etut)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("etut_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_etut_id", etut.etut_id);
                    command.Parameters.AddWithValue("p_etut_ogrenci_id", etut.etut_ogrenci_id);
                    command.Parameters.AddWithValue("p_etut_sinav_id", etut.etut_sinav_id);
                    command.Parameters.AddWithValue("p_etut_ders_id", etut.etut_ders_id);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE etutler SET etut_ogrenci_id=@etut_ogrenci_id , " +
            //        "etut_sinav_id=@etut_sinav_id, etut_ders_id=@etut_ders_id WHERE etut_id=@etut_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@etut_id", etut.etut_id);
            //        cmd.Parameters.AddWithValue("@etut_ogrenci_id", etut.etut_ogrenci_id);
            //        cmd.Parameters.AddWithValue("@etut_ders_id", etut.etut_ders_id);
            //        cmd.Parameters.AddWithValue("@etut_sinav_id", etut.etut_sinav_id);



            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }
        public ActionResult EtutSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("etut_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_etut_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");

        }
    }
}
