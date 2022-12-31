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
    public class OgretmenController : Controller
    {
        

        public IActionResult Index(int id)
        {

            List<Ogretmen> displayogretmen = new List<Ogretmen>();
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select ogretmen_id,ogretmen_ders_id, ogretmen_adi, ogretmen_soyadi,ogretmen_telno,ders_id,ders_adi" +
                " from ogretmenler inner join dersler on ogretmenler.ogretmen_ders_id=dersler.ders_id  where ogretmen_aktif=true and ogretmen_ders_id=" + id.ToString());

            while (datareader.Read())
            {
                var ogretmen = new Ogretmen();
                ogretmen.ogretmen_id = Convert.ToInt32(datareader["ogretmen_id"]);
                ogretmen.ogretmen_ders_adi = datareader["ders_adi"].ToString();
                ogretmen.ogretmen_adi = datareader["ogretmen_adi"].ToString();
                ogretmen.ogretmen_soyadi = datareader["ogretmen_soyadi"].ToString();
                ogretmen.ogretmen_telno= datareader["ogretmen_telno"].ToString();
                


                displayogretmen.Add(ogretmen);
            }
            return View(displayogretmen);
        }
        [HttpGet]
        public IActionResult OgretmenEkle()
        {
            List<SelectListItem> values = new List<SelectListItem>();

            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM dersler where ders_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values.Add(new SelectListItem
                            {
                                Text = reader["ders_adi"].ToString(),
                                Value = reader["ders_id"].ToString()
                            });
                        }
                    }
                }
                ViewBag.v1 = values;
            }

            return View();
        }


        [HttpPost]
        public IActionResult OgretmenEkle(Ogretmen ogretmen)
        {


            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("ogretmen_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_ogretmen_ders_id", ogretmen.ogretmen_ders_id);
                    command.Parameters.AddWithValue("p_ogretmen_adi", ogretmen.ogretmen_adi);
                    command.Parameters.AddWithValue("p_ogretmen_soyadi", ogretmen.ogretmen_soyadi);
                    command.Parameters.AddWithValue("p_ogretmen_telno", ogretmen.ogretmen_telno);

                    ogretmen.ogretmen_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{


            //    string query = "INSERT INTO ogretmenler ( ogretmen_ders_id, ogretmen_adi, ogretmen_soyadi, ogretmen_telno) VALUES" +
            //        "( @ogretmen_ders_id, @ogretmen_adi, @ogretmen_soyadi, @ogretmen_telno)";
            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        //ogretmen.ogretmen_id = Convert.ToInt32(cmd.ExecuteScalar());

            //        cmd.Parameters.AddWithValue("@ogretmen_ders_id", ogretmen.ogretmen_ders_id);
            //        cmd.Parameters.AddWithValue("@ogretmen_adi", ogretmen.ogretmen_adi);
            //        cmd.Parameters.AddWithValue("@ogretmen_soyadi", ogretmen.ogretmen_soyadi);
            //        cmd.Parameters.AddWithValue("@ogretmen_telno", ogretmen.ogretmen_telno);
            //        ogretmen.ogretmen_id = Convert.ToInt32(cmd.ExecuteScalar());
            //        con.Close();
            //    }
            //}

            //return View(ders);
            return Redirect("/Ogretmen/Index/"+ogretmen.ogretmen_ders_id);
        }

        [HttpGet]
        public IActionResult OgretmenGuncelle(int id)
        {

            List<SelectListItem> values1 = new List<SelectListItem>();
          



            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM dersler where ders_aktif=true", connection))
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

            Ogretmen ogretmen = new Ogretmen();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from ogretmenler where ogretmen_id=@ogretmen_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ogretmen_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                ogretmen.ogretmen_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                ogretmen.ogretmen_ders_id = Convert.ToInt32(datatable.Rows[0][1].ToString());
                ogretmen.ogretmen_adi = datatable.Rows[0][2].ToString();
                ogretmen.ogretmen_soyadi = datatable.Rows[0][3].ToString();
                ogretmen.ogretmen_telno = datatable.Rows[0][4].ToString();
              


                return View(ogretmen);
            }
            else

                return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult OgretmenGuncelle(Ogretmen ogretmen)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("ogretmen_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_ogretmen_id", ogretmen.ogretmen_id);
                    command.Parameters.AddWithValue("p_ogretmen_ders_id", ogretmen.ogretmen_ders_id);
                    command.Parameters.AddWithValue("p_ogretmen_adi", ogretmen.ogretmen_adi);
                    command.Parameters.AddWithValue("p_ogretmen_soyadi", ogretmen.ogretmen_soyadi);
                    command.Parameters.AddWithValue("p_ogretmen_telno", ogretmen.ogretmen_telno);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE ogretmenler SET ogretmen_ders_id=@ogretmen_ders_id , ogretmen_adi=@ogretmen_adi,
            //    ogretmen_soyadi=@ogretmen_soyadi," +
            //        " ogretmen_telno=@ogretmen_telno WHERE ogretmen_id=@ogretmen_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@ogretmen_id", ogretmen.ogretmen_id);
            //        cmd.Parameters.AddWithValue("@ogretmen_ders_id", ogretmen.ogretmen_ders_id);
            //        cmd.Parameters.AddWithValue("@ogretmen_adi", ogretmen.ogretmen_adi);
            //        cmd.Parameters.AddWithValue("@ogretmen_soyadi", ogretmen.ogretmen_soyadi);
            //        cmd.Parameters.AddWithValue("@ogretmen_telno", ogretmen.ogretmen_telno);


            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
         return View("~/Views/Home/Index.cshtml");

        }
        public ActionResult OgretmenSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("ogretmen_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_ogretmen_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }


    }
}