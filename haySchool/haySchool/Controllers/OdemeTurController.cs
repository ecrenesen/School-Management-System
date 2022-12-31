using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using haySchool.Models;

namespace haySchool.Controllers
{
    public class OdemeTurController : Controller
    {
        public IActionResult Index()
        {
            List<OdemeTur> displayOdemeTur = new List<OdemeTur>();
            Genel genel = new Genel();
            genel.OpenConection();
            NpgsqlDataReader datareader = genel.DataReader("Select * From odemeturleri  where odemetur_aktif=true");

            while (datareader.Read())
            {
                var odemeTur = new OdemeTur();
                odemeTur.odemetur_id = Convert.ToInt32(datareader["odemetur_id"]);
                odemeTur.odemetur_adi = datareader["odemetur_adi"].ToString();


                displayOdemeTur.Add(odemeTur);
            }
            return View(displayOdemeTur);
        }
        [HttpGet]
        public IActionResult OdemeTurEkle()
        {
          
            return View();
        }


        [HttpPost]
        public IActionResult OdemeTurEkle(OdemeTur odemeTur)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("odemetur_ekle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_odemetur_adi", odemeTur.odemetur_adi);
                    odemeTur.odemetur_id = Convert.ToInt32(command.ExecuteScalar());

                }
                connection.Close();
            }

            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "INSERT INTO odemeturleri ( odemetur_adi) VALUES ( @odemetur_adi)";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        //cmd.Parameters.AddWithValue("@odemeTur_id", odemeTur.odemetur_id);
            //        cmd.Parameters.AddWithValue("@odemeTur_adi", odemeTur.odemetur_adi);
            //        odemeTur.odemetur_id = Convert.ToInt32(cmd.ExecuteScalar());

            //        con.Close();
            //    }
            //}

            //return View(ders);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult OdemeTurGuncelle(int id)
        {
            OdemeTur odemetur = new OdemeTur();
            DataTable datatable = new DataTable();
            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();
                string query = "select* from odemeturleri where odemetur_id=@odemetur_id";
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(query, connection);
                npgsqlDataAdapter.SelectCommand.Parameters.AddWithValue("@odemetur_id", id);
                npgsqlDataAdapter.Fill(datatable);

            }
            if (datatable.Rows.Count == 1)
            {
                odemetur.odemetur_id = Convert.ToInt32(datatable.Rows[0][0].ToString());
                odemetur.odemetur_adi = datatable.Rows[0][1].ToString();

                return View(odemetur);
            }
            else

                return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult OdemeTurGuncelle(OdemeTur odemeTur)
        {
            string constr = Genel.conString;

            using (NpgsqlConnection connection = new NpgsqlConnection(constr))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("odemetur_guncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_odemetur_id", odemeTur.odemetur_id);
                    command.Parameters.AddWithValue("p_odemetur_adi", odemeTur.odemetur_adi);


                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            //string constr = Genel.conString;
            //using (NpgsqlConnection con = new NpgsqlConnection(constr))
            //{
            //    string query = "UPDATE odemeturleri SET odemetur_adi=@odemetur_adi WHERE odemetur_id=@odemetur_id";


            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();

            //        cmd.Parameters.AddWithValue("@odemetur_id", odemeTur.odemetur_id);
            //        cmd.Parameters.AddWithValue("@odemetur_adi", odemeTur.odemetur_adi);

            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            return RedirectToAction("Index");
        }
        public ActionResult OdemeTurSil(int id)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(Genel.conString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("odemetur_sil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_odemetur_id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToAction("Index");
        }

    }
}