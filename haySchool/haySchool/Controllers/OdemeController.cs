using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



using Npgsql;


using System.Data;

using haySchool.Models;



namespace haySchool.Controllers
{
    public class OdemeController : Controller
    {
       
        public IActionResult Index()
        {
            try
            {


                List<Odeme> displayOdeme = new List<Odeme>();
                Genel genel = new Genel();
                genel.OpenConection();
                NpgsqlDataReader datareader = genel.DataReader("Select odeme_id,odeme_odemetur_id,odeme_toplam,odeme_odenen,odeme_kalan," +
                    "odeme_indirim, odeme_veli_id ,odemetur_id,odemetur_adi,veli_adi, veli_soyadi " +
                    "from odemeler inner join odemeturleri on odemeler.odeme_odemetur_id=odemeturleri.odemetur_id inner join veliler on " +
                    "odemeler.odeme_veli_id=veliler.veli_id  where odeme_aktif=true");



                while (datareader.Read())
                {
                    var odeme = new Odeme();
                    odeme.odeme_id = Convert.ToInt32(datareader["odeme_id"]);
                    odeme.odeme_odemetur_adi = datareader["odemetur_adi"].ToString();
                    odeme.odeme_toplam = Convert.ToDouble(datareader["odeme_toplam"]);
                    odeme.odeme_odenen = Convert.ToDouble(datareader["odeme_odenen"]);
                    odeme.odeme_kalan = Convert.ToDouble(datareader["odeme_kalan"]);
                    odeme.odeme_indirim = Convert.ToDouble(datareader["odeme_indirim"]);
                    odeme.odeme_veli_adi = datareader["veli_adi"] + " " + datareader["veli_soyadi"].ToString();


                    displayOdeme.Add(odeme);
                }
                genel.CloseConnection();
                return View(displayOdeme);
            }
            catch(NpgsqlException e)
            {
                return View("~/Views/Privacy.cshtml");
            }
      
        }


        [HttpGet]
        public IActionResult OdemeEkle()
        {


            List<SelectListItem> values = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();

            string connectionString = Genel.conString;


            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM odemeturleri where odemetur_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values.Add(new SelectListItem
                            {
                                Text = reader["odemetur_adi"].ToString(),
                                Value = reader["odemetur_id"].ToString()
                            });
                        }
                    }
                }
                ViewBag.v1 = values;
            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM veliler", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values2.Add(new SelectListItem
                            {
                                Text = reader["veli_adi"].ToString() + " " + reader["veli_soyadi"].ToString(),


                                Value = reader["veli_id"].ToString()
                            });
                        }
                    }

                    ViewBag.v5 = values2;

                }

            }
            return View();

        }


        [HttpPost]
        public IActionResult OdemeEkle(Odeme odeme)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("odeme_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_odeme_odemetur_id", odeme.odeme_odemetur_id);
                    command.Parameters.AddWithValue("p_odeme_toplam", odeme.odeme_toplam);
                    command.Parameters.AddWithValue("p_odeme_odenen", odeme.odeme_odenen);
                    command.Parameters.AddWithValue("p_odeme_kalan", odeme.odeme_kalan);
                    command.Parameters.AddWithValue("p_odeme_indirim", odeme.odeme_indirim);
                    command.Parameters.AddWithValue("p_odeme_veli_id", odeme.odeme_veli_id);
                    odeme.odeme_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }

            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "INSERT INTO odemeler ( odeme_odemetur_id, odeme_toplam, odeme_odenen, odeme_kalan, odeme_indirim,odeme_veli_id) VALUES" +
            //        "( @odeme_odemetur_id, @odeme_toplam, @odeme_odenen, @odeme_kalan, @odeme_indirim,@odeme_veli_id)";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        //cmd.Parameters.AddWithValue("@odeme_id", odeme.odeme_id);
            //        cmd.Parameters.AddWithValue("@odeme_odemetur_id", odeme.odeme_odemetur_id);
            //        cmd.Parameters.AddWithValue("@odeme_toplam", odeme.odeme_toplam);
            //        cmd.Parameters.AddWithValue("@odeme_odenen", odeme.odeme_odenen);
            //        cmd.Parameters.AddWithValue("@odeme_kalan", odeme.odeme_kalan);
            //        cmd.Parameters.AddWithValue("@odeme_indirim", odeme.odeme_indirim);
            //        cmd.Parameters.AddWithValue("@odeme_veli_id", odeme.odeme_veli_id);


            //        odeme.odeme_id = Convert.ToInt32(cmd.ExecuteScalar());

            //        con.Close();
            //    }
            //}


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OdemeGuncelle(int id)
        {
            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values3 = new List<SelectListItem>();



            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM odemeturleri  where odemetur_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["odemetur_adi"].ToString(),
                                Value = reader["odemetur_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v20 = values1;


                }

            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM veliler", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values3.Add(new SelectListItem
                            {
                                Text = reader["veli_adi"].ToString() + " " + reader["veli_soyadi"].ToString(),


                                Value = reader["veli_id"].ToString()
                            });
                        }
                    }

                    ViewBag.v5 = values3;

                }

            }
            Odeme odeme = new Odeme();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select * from odemeler where odeme_id=@odeme_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@odeme_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                odeme.odeme_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                odeme.odeme_odemetur_id = Convert.ToInt32(datatable.Rows[0][1].ToString());
                odeme.odeme_toplam = Convert.ToDouble(datatable.Rows[0][2].ToString());
                odeme.odeme_odenen = Convert.ToDouble(datatable.Rows[0][3].ToString());
                odeme.odeme_kalan = Convert.ToDouble(datatable.Rows[0][4].ToString());
                odeme.odeme_indirim = Convert.ToDouble(datatable.Rows[0][5].ToString());
                odeme.odeme_veli_id = Convert.ToInt32(datatable.Rows[0][6].ToString());


                return View(odeme);
            }
            else

                return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult OdemeGuncelle(Odeme odeme)
        {


            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("odeme_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_odeme_id", odeme.odeme_id);
                    command.Parameters.AddWithValue("p_odeme_odemetur_id", odeme.odeme_odemetur_id);
                    command.Parameters.AddWithValue("p_odeme_toplam", odeme.odeme_toplam);
                    command.Parameters.AddWithValue("p_odeme_odenen", odeme.odeme_odenen);
                    command.Parameters.AddWithValue("p_odeme_kalan", odeme.odeme_kalan);
                    command.Parameters.AddWithValue("p_odeme_indirim", odeme.odeme_indirim);
                    command.Parameters.AddWithValue("p_odeme_veli_id", odeme.odeme_veli_id);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE odemeler SET odeme_odemetur_id=@odeme_odemetur_id , odeme_toplam=@odeme_toplam," +
            //        " odeme_odenen=@odeme_odenen, odeme_kalan=@odeme_kalan, odeme_indirim=@odeme_indirim WHERE odeme_id=@odeme_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@odeme_id", odeme.odeme_id);
            //        cmd.Parameters.AddWithValue("@odeme_odemetur_id", odeme.odeme_odemetur_id);
            //        cmd.Parameters.AddWithValue("@odeme_toplam", odeme.odeme_toplam);
            //        cmd.Parameters.AddWithValue("@odeme_odenen", odeme.odeme_odenen);
            //        cmd.Parameters.AddWithValue("@odeme_kalan", odeme.odeme_kalan);
            //        cmd.Parameters.AddWithValue("@odeme_indirim", odeme.odeme_indirim);

            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }

        public ActionResult OdemeSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("odeme_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_odeme_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}
