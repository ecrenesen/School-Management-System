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
    public class DevamsizlikController : Controller
    {
        public IActionResult Index()
        {
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select devamsizlik_id, devamsizlik_ogrenci_id, devamsizlik_miktar, devamsizlik_tarih, " +
                " ogrenci_id, ogrenci_adi, ogrenci_soyadi, ogrenci_aktif" +
                " from devamsizliklar" +
                " inner join ogrenciler on devamsizliklar.devamsizlik_ogrenci_id=ogrenciler.ogrenci_id " +
                " where devamsizlik_aktif=true and ogrenci_aktif=true");
            List<Devamsizlik> displaydevamsizlik = new List<Devamsizlik>();
            while (datareader.Read())
            {


                var devamsizlik = new Devamsizlik();
                devamsizlik.devamsizlik_id = Convert.ToInt32(datareader["devamsizlik_id"]);
                  devamsizlik.devamsizlik_ogrenci_adi = datareader["ogrenci_adi"] + " " + datareader["ogrenci_soyadi"].ToString();
                 devamsizlik.devamsizlik_miktar = Convert.ToInt32(datareader["devamsizlik_miktar"]);
                devamsizlik.devamsizlik_tarih = Convert.ToDateTime(datareader["devamsizlik_tarih"]);
  



                displaydevamsizlik.Add(devamsizlik);
            }
            genel.CloseConnection();
            return View(displaydevamsizlik);


        }
        [HttpGet]
        public IActionResult DevamsizlikEkle()
        {
            List<SelectListItem> values2 = new List<SelectListItem>();
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
            return View();
        }

        [HttpPost]
        public IActionResult DevamsizlikEkle(Devamsizlik devamsizlik)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("devamsizlik_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_devamsizlik_ogrenci_id", devamsizlik.devamsizlik_ogrenci_id);
                    command.Parameters.AddWithValue("p_devamsizlik_miktar", devamsizlik.devamsizlik_miktar);
                    command.Parameters.AddWithValue("p_devamsizlik_tarih", devamsizlik.devamsizlik_tarih);
                    devamsizlik.devamsizlik_id = Convert.ToInt32(command.ExecuteScalar());

                }
                connection.Close();
            }

            //return View(ders);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DevamsizlikGuncelle(int id)

        {

            List<SelectListItem> values2 = new List<SelectListItem>();
          



            string connectionString = Genel.conString;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogrenciler  where ogrenci_aktif=true", connection))
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

            Devamsizlik devamsizlik = new Devamsizlik();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from devamsizliklar where devamsizlik_id=@devamsizlik_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@devamsizlik_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                devamsizlik.devamsizlik_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                devamsizlik.devamsizlik_ogrenci_id = Convert.ToInt32(datatable.Rows[0][1].ToString());
                devamsizlik.devamsizlik_miktar = Convert.ToInt32(datatable.Rows[0][2].ToString());
                devamsizlik.devamsizlik_tarih = Convert.ToDateTime(datatable.Rows[0][3].ToString());

                return View(devamsizlik);
            }
            else

                return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult DevamsizlikGuncelle(Devamsizlik devamsizlik)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("devamsizlik_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_devamsizlik_id", devamsizlik.devamsizlik_id);
                    command.Parameters.AddWithValue("p_devamsizlik_ogrenci_id", devamsizlik.devamsizlik_ogrenci_id);
                    command.Parameters.AddWithValue("p_devamsizlik_miktar", devamsizlik.devamsizlik_miktar);
                    command.Parameters.AddWithValue("p_devamsizlik_tarih", devamsizlik.devamsizlik_tarih);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE devamsizliklar SET devamsizlik_ogrenci_id=@devamsizlik_ogrenci_id , " +
            //        "devamsizlik_miktar=@devamsizlik_miktar WHERE devamsizlik_id=@devamsizlik_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@devamsizlik_id", devamsizlik.devamsizlik_id);
            //        cmd.Parameters.AddWithValue("@devamsizlik_ogrenci_id", devamsizlik.devamsizlik_ogrenci_id);
            //        cmd.Parameters.AddWithValue("@devamsizlik_miktar", devamsizlik.devamsizlik_miktar);
            //        cmd.Parameters.AddWithValue("@devamsizlik_tarih", devamsizlik.devamsizlik_tarih);




            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }
        public ActionResult DevamsizlikSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("devamsizlik_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_devamsizlik_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}
