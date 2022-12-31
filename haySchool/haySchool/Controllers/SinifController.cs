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
    public class SinifController : Controller
    {

        public IActionResult Index()
        {
            List<Sinif> displaysinif = new List<Sinif>();
            Genel genel = new Genel();
            genel.OpenConection();

            NpgsqlDataReader datareader = genel.DataReader("Select sinif_id, sinif_sube, sinif_ogretmen_id, " +
                "sinif_mevcut, ogretmen_adi, ogretmen_soyadi from siniflar inner join ogretmenler on " +
                "sinif_ogretmen_id=ogretmen_id  where sinif_aktif=true");

            while (datareader.Read())
            {
                var sinif = new Sinif();
                sinif.sinif_id = Convert.ToInt32(datareader["sinif_id"]);
                sinif.sinif_sube = Convert.ToInt32(datareader["sinif_sube"]);
                sinif.sinif_ogretmen_adi = datareader["ogretmen_adi"] + " " + datareader["ogretmen_soyadi"].ToString();
                sinif.sinif_mevcut = Convert.ToInt32(datareader["sinif_mevcut"]);

                displaysinif.Add(sinif);
            }
            return View(displaysinif);

        }
        [HttpGet]
        public IActionResult SinifEkle()
        {
            List<SelectListItem> values = new List<SelectListItem>();

            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ogretmenler where ogretmen_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values.Add(new SelectListItem
                            {
                                Text = reader["ogretmen_adi"].ToString() + " " + reader["ogretmen_soyadi"].ToString(),
                                Value = reader["ogretmen_id"].ToString()
                            });
                        }
                    }
                }
                ViewBag.v2 = values;
            }

            return View();
        }


        [HttpPost]
        public IActionResult SinifEkle(Sinif sinif)
        {

            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("sinif_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_sinif_sube", sinif.sinif_sube);
                    command.Parameters.AddWithValue("p_sinif_ogretmen_id", sinif.sinif_ogretmen_id);
                    command.Parameters.AddWithValue("p_sinif_mevcut", sinif.sinif_mevcut);
                    sinif.sinif_id = Convert.ToInt32(command.ExecuteScalar());

                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "INSERT INTO siniflar ( sinif_sube, sinif_ogretmen_id, sinif_mevcut) VALUES" +
            //        "( @sinif_sube, @sinif_ogretmen_id, @sinif_mevcut)";

            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        //cmd.Parameters.AddWithValue("@sinif_id", sinif.sinif_id);
            //        //sinif.sinif_sube = Convert.ToInt32(cmd.ExecuteScalar());
            //        cmd.Parameters.AddWithValue("@sinif_sube", sinif.sinif_sube);
            //        cmd.Parameters.AddWithValue("@sinif_ogretmen_id", sinif.sinif_ogretmen_id);
            //        cmd.Parameters.AddWithValue("@sinif_mevcut", sinif.sinif_mevcut);

            //        sinif.sinif_id = Convert.ToInt32(cmd.ExecuteScalar());
            //        con.Close();
            //    }
            //}
            //return View(ders);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SinifGuncelle(int id)
        {

            List<SelectListItem> values3 = new List<SelectListItem>();
            string connectionString = Genel.conString;

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
                    ViewBag.v23 = values3;


                }

            }
            Sinif sinif = new Sinif();
            DataTable datatable = new DataTable();

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from siniflar where sinif_id=@sinif_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@sinif_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                sinif.sinif_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                sinif.sinif_sube = Convert.ToInt32(datatable.Rows[0][1].ToString());
                sinif.sinif_ogretmen_id = Convert.ToInt32(datatable.Rows[0][2].ToString());
                sinif.sinif_mevcut = Convert.ToInt32(datatable.Rows[0][3].ToString());



                return View(sinif);
            }
            else

                return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult SinifGuncelle(Sinif sinif)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("sinif_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_sinif_id", sinif.sinif_id);
                    command.Parameters.AddWithValue("p_sinif_sube", sinif.sinif_sube);
                    command.Parameters.AddWithValue("p_sinif_ogretmen_id", sinif.sinif_ogretmen_id);
                    command.Parameters.AddWithValue("p_sinif_mevcut", sinif.sinif_mevcut);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE siniflar SET sinif_sube=@sinif_sube , sinif_ogretmen_id=@sinif_ogretmen_id,
            //    sinif_mevcut=@sinif_mevcut" +
            //        " WHERE sinif_id=@sinif_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@sinif_id", sinif.sinif_id);
            //        cmd.Parameters.AddWithValue("@sinif_sube", sinif.sinif_sube);
            //        cmd.Parameters.AddWithValue("@sinif_ogretmen_id", sinif.sinif_ogretmen_id);
            //        cmd.Parameters.AddWithValue("@sinif_mevcut", sinif.sinif_mevcut);

            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }

        public static List<Sinif> GetSinifs()
        {
            List<Sinif> sinifobj = new List<Sinif>();
            string connection = Genel.conString;
            using (NpgsqlConnection npsqlconn = new NpgsqlConnection(connection))
            {
                using (NpgsqlCommand npgsqlcomm = new NpgsqlCommand("select * from siniflar "))
                {
                    using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter())
                    {
                        npgsqlcomm.Connection = npsqlconn;
                        npsqlconn.Open();
                        sda.SelectCommand = npgsqlcomm;
                        NpgsqlDataReader sdr = npgsqlcomm.ExecuteReader();
                        while (sdr.Read())
                        {
                            Sinif obj = new Sinif();
                            obj.sinif_ogretmen_adi = sdr["sinif_ogretmen_adi"].ToString();
                            sinifobj.Add(obj);
                        }


                    }
                    return sinifobj;
                }
            }
        }
        public ActionResult SinifSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("sinif_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_sinif_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }

    }
}