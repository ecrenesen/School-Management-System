using haySchool.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace haySchool.Controllers
{
    public class VeliController : Controller
    {
        public IActionResult Index()
        {

            List<Veli> displayveli = new List<Veli>();
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select veli_id, veli_adi, veli_soyadi, " +
                "veli_telno,veli_adres from veliler  where veli_aktif=true");

            while (datareader.Read())
            {
                var veliler = new Veli();
                veliler.veli_id = Convert.ToInt32(datareader["veli_id"]);
                veliler.veli_adi = datareader["veli_adi"].ToString();
                veliler.veli_soyadi = datareader["veli_soyadi"].ToString();
                veliler.veli_telno = datareader["veli_telno"].ToString();
                veliler.veli_adres = datareader["veli_adres"].ToString();



                displayveli.Add(veliler);
            }
            return View(displayveli);
        }

        [HttpGet]
        public IActionResult VeliEkle()
        {
            return View();
        }


        [HttpPost]
        public IActionResult VeliEkle(Veli veli)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("veli_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_veli_adi", veli.veli_adi);
                    command.Parameters.AddWithValue("p_veli_soyadi", veli.veli_soyadi);
                    command.Parameters.AddWithValue("p_veli_telno", veli.veli_telno);
                    command.Parameters.AddWithValue("p_veli_adres", veli.veli_adres);

                    veli.veli_id = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }
            //return View(ders);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult VeliGuncelle(int id)
        {
            Veli veli = new Veli();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from veliler where veli_id=@veli_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@veli_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                veli.veli_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                veli.veli_adi = datatable.Rows[0][1].ToString();
                veli.veli_soyadi = datatable.Rows[0][2].ToString();
                veli.veli_telno = datatable.Rows[0][3].ToString();
                veli.veli_adres = datatable.Rows[0][4].ToString();



                return View(veli);
            }
            else

                return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult VeliGuncelle(Veli veli)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("veli_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_veli_id", veli.veli_id);
                    command.Parameters.AddWithValue("p_veli_adi", veli.veli_adi);
                    command.Parameters.AddWithValue("p_veli_soyadi", veli.veli_soyadi);
                    command.Parameters.AddWithValue("p_veli_telno", veli.veli_telno);
                    command.Parameters.AddWithValue("p_veli_adres", veli.veli_adres);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }


            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE veliler SET veli_adi=@veli_adi , veli_soyadi=@veli_soyadi, veli_telno=@veli_telno," +
            //        " veli_adres=@veli_adres WHERE veli_id=@veli_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@veli_id", veli.veli_id);
            //        cmd.Parameters.AddWithValue("@veli_adi", veli.veli_adi);
            //        cmd.Parameters.AddWithValue("@veli_soyadi", veli.veli_soyadi);
            //        cmd.Parameters.AddWithValue("@veli_telno", veli.veli_telno);
            //        cmd.Parameters.AddWithValue("@veli_adres", veli.veli_adres);


            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }
        public ActionResult VeliSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("veli_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_veli_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }


    }
}