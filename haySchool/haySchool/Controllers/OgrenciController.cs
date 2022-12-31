using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using haySchool.Models;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace haySchool.Controllers
{
    public class OgrenciController : Controller
    {

        public IActionResult Index()
        {

            List<Ogrenci> displayogrenci = new List<Ogrenci>();
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select ogrenci_id, ogrenci_tcno, ogrenci_adi, " +
                "ogrenci_soyadi,ogrenci_sinif_id," +
                "ogrenci_kayit_tarihi, ogrenci_devamsizlik, sinif_id, sinif_sube, ogrenci_veli_id, veli_id, veli_adi, veli_soyadi " +
                "from ogrenciler " +
                "inner join siniflar on " +
                "ogrenciler.ogrenci_sinif_id=siniflar.sinif_id inner join veliler on " +
                "ogrenciler.ogrenci_veli_id=veliler.veli_id  where ogrenci_aktif=true");

            while (datareader.Read())
            {
                var ogrenci = new Ogrenci();
                ogrenci.ogrenci_id = Convert.ToInt32(datareader["ogrenci_id"]);
                ogrenci.ogrenci_tcno = datareader["ogrenci_tcno"].ToString();
                ogrenci.ogrenci_adi = datareader["ogrenci_adi"].ToString();
                ogrenci.ogrenci_soyadi = datareader["ogrenci_soyadi"].ToString();
                ogrenci.ogrenci_sinif_adi = datareader["sinif_sube"].ToString();
                ogrenci.ogrenci_devamsizlik = Convert.ToInt32(datareader["ogrenci_devamsizlik"]);
                ogrenci.ogrenci_kayit_tarihi = Convert.ToDateTime(datareader["ogrenci_kayit_tarihi"]);
                ogrenci.ogrenci_veli_adi = datareader["veli_adi"] + " " + datareader["veli_soyadi"].ToString();


                displayogrenci.Add(ogrenci);
            }
            return View(displayogrenci);
        }
        [HttpGet]
        public IActionResult OgrenciEkle()
        {
            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();

            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM siniflar where sinif_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["sinif_sube"].ToString(),
                                Value = reader["sinif_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v4 = values1;


                }
                


            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM veliler where veli_aktif=true", connection))
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
        public IActionResult OgrenciEkle(Ogrenci ogrenci)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("ogrenci_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_ogrenci_tcno", ogrenci.ogrenci_tcno);
                    command.Parameters.AddWithValue("p_ogrenci_adi", ogrenci.ogrenci_adi);
                    command.Parameters.AddWithValue("p_ogrenci_soyadi", ogrenci.ogrenci_soyadi);
                    command.Parameters.AddWithValue("p_ogrenci_sinif_id", ogrenci.ogrenci_sinif_id);
                    command.Parameters.AddWithValue("p_ogrenci_devamsizlik", 0);
                    command.Parameters.AddWithValue("p_ogrenci_kayit_tarihi", ogrenci.ogrenci_kayit_tarihi);
                    command.Parameters.AddWithValue("p_ogrenci_veli_id", ogrenci.ogrenci_veli_id);


                    ogrenci.ogrenci_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{


            //    string query = "INSERT INTO ogrenciler ( ogrenci_tcno, ogrenci_adi, ogrenci_soyadi, ogrenci_sinif_id, ogrenci_kayit_tarihi, " +
            //        "ogrenci_veli_id )" +
            //        " VALUES" +
            //        "( @ogrenci_tcno, @ogrenci_adi, @ogrenci_soyadi, @ogrenci_sinif_id, @ogrenci_kayit_tarihi, @ogrenci_veli_id )";
            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        //ogretmen.ogretmen_id = Convert.ToInt32(cmd.ExecuteScalar());

            //        cmd.Parameters.AddWithValue("@ogrenci_tcno", ogrenci.ogrenci_tcno);
            //        cmd.Parameters.AddWithValue("@ogrenci_adi", ogrenci.ogrenci_adi);
            //        cmd.Parameters.AddWithValue("@ogrenci_soyadi", ogrenci.ogrenci_soyadi);
            //        cmd.Parameters.AddWithValue("@ogrenci_sinif_id", ogrenci.ogrenci_sinif_id);
            //        cmd.Parameters.AddWithValue("@ogrenci_kayit_tarihi", ogrenci.ogrenci_kayit_tarihi);
            //        cmd.Parameters.AddWithValue("@ogrenci_veli_id", ogrenci.ogrenci_veli_id);



            //        ogrenci.ogrenci_id = Convert.ToInt32(cmd.ExecuteScalar());
            //        con.Close();
            //    }
            //}

            //return View(ders);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OgrenciGuncelle(int id)
        { 
            List<SelectListItem> values1 = new List<SelectListItem>();
            List<SelectListItem> values2 = new List<SelectListItem>();
            

            string connectionString = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM siniflar where sinif_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values1.Add(new SelectListItem
                            {
                                Text = reader["sinif_Sube"].ToString(),
                                Value = reader["sinif_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v15 = values1;


                }

            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM veliler  where veli_aktif=true", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values2.Add(new SelectListItem
                            {
                                Text = reader["veli_adi"].ToString(),
                                Value = reader["veli_id"].ToString()
                            });
                        }
                    }
                    ViewBag.v17 = values2;


                }

            }



            Ogrenci ogrenci = new Ogrenci();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from ogrenciler where ogrenci_id=@ogrenci_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ogrenci_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                ogrenci.ogrenci_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                ogrenci.ogrenci_tcno = datatable.Rows[0][1].ToString();
                ogrenci.ogrenci_adi = datatable.Rows[0][2].ToString();
                ogrenci.ogrenci_soyadi = datatable.Rows[0][3].ToString();
                //ogrenci.ogrenci_sinif_id = Convert.ToInt32(datatable.Rows[0][4].ToString());
                ogrenci.ogrenci_kayit_tarihi = Convert.ToDateTime(datatable.Rows[0][5].ToString());
                //ogrenci.ogrenci_veli_id = Convert.ToInt32(datatable.Rows[0][6].ToString());




                return View(ogrenci);
            }
            else

                return RedirectToAction("Index");

           
     

        }

        [HttpPost]
        public IActionResult OgrenciGuncelle(Ogrenci ogrenci)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("ogrenci_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_ogrenci_id", ogrenci.ogrenci_id);
                    command.Parameters.AddWithValue("p_ogrenci_tcno", ogrenci.ogrenci_tcno);
                    command.Parameters.AddWithValue("p_ogrenci_adi", ogrenci.ogrenci_adi);
                    command.Parameters.AddWithValue("p_ogrenci_soyadi", ogrenci.ogrenci_soyadi);
                    command.Parameters.AddWithValue("p_ogrenci_sinif_id", ogrenci.ogrenci_sinif_id);
                    command.Parameters.AddWithValue("p_ogrenci_veli_id", ogrenci.ogrenci_veli_id);
                    command.Parameters.AddWithValue("p_ogrenci_devamsizlik", ogrenci.ogrenci_devamsizlik);
                    command.Parameters.AddWithValue("p_ogrenci_kayit_tarihi", ogrenci.ogrenci_kayit_tarihi);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE ogrenciler SET ogrenci_tcno=@ogrenci_tcno , " +
            //        " ogrenci_adi=@ogrenci_adi, ogrenci_soyadi=@ogrenci_soyadi , " +
            //        " ogrenci_sinif_id=@ogrenci_sinif_id , ogrenci_veli_id=@ogrenci_veli_id , ogrenci_devamsizlik= @ogrenci_devamsizlik, ogrenci_kayit_tarihi=@ogrenci_kayit_tarihi " +
            //        " WHERE ogrenci_id= @ogrenci_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@ogrenci_id", ogrenci.ogrenci_id);
            //        cmd.Parameters.AddWithValue("@ogrenci_tcno", ogrenci.ogrenci_tcno);
            //        cmd.Parameters.AddWithValue("@ogrenci_adi", ogrenci.ogrenci_adi);
            //        cmd.Parameters.AddWithValue("@ogrenci_soyadi", ogrenci.ogrenci_soyadi);
            //        cmd.Parameters.AddWithValue("@ogrenci_sinif_id", ogrenci.ogrenci_sinif_id);
            //        cmd.Parameters.AddWithValue("@ogrenci_kayit_tarihi", ogrenci.ogrenci_kayit_tarihi);
            //        cmd.Parameters.AddWithValue("@ogrenci_devamsizlik", ogrenci.ogrenci_devamsizlik);

            //        cmd.Parameters.AddWithValue("@ogrenci_veli_id", ogrenci.ogrenci_veli_id);


            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");


        }

        public IActionResult ogrList(int id)
        {
            List<Ogrenci> displayogrenci = new List<Ogrenci>();
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select * from ogrenciler  where ogrenci_sinif_id = " + id.ToString());

            while (datareader.Read())
            {
                var ogrenci = new Ogrenci();
                ogrenci.ogrenci_id = Convert.ToInt32(datareader["ogrenci_id"]);
                ogrenci.ogrenci_tcno = datareader["ogrenci_tcno"].ToString();
                ogrenci.ogrenci_adi = datareader["ogrenci_adi"].ToString();
                ogrenci.ogrenci_soyadi = datareader["ogrenci_soyadi"].ToString();
               
                ogrenci.ogrenci_kayit_tarihi = Convert.ToDateTime(datareader["ogrenci_kayit_tarihi"]);
                ogrenci.ogrenci_devamsizlik = Convert.ToInt32(datareader["ogrenci_devamsizlik"]);




                displayogrenci.Add(ogrenci);
            }
            return View(displayogrenci);
        }

        public ActionResult OgrenciSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("ogrenci_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_ogrenci_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }



}