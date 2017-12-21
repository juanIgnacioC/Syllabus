using MySql.Data.MySqlClient;
using SaberesySoluciones.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SaberesSyllabus.Models
{
    public class Unidad
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Clase> Clases { get; set; }
        public List<Saber> Saberes { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }

        public Unidad()
        {
            this.Clases = new List<Clase>();
            this.Saberes = new List<Saber>();
            this.Evaluaciones = new List<Evaluacion>();
        }
        
        public bool Crear()
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["syllabus"].ConnectionString))
            {
                conn.Open();
                var sqlTran = conn.BeginTransaction();
                try
                {
                    var command = new MySqlCommand() { CommandText = "crearUnidad", CommandType = CommandType.StoredProcedure };
                    //Setea el valor de los atributos del SP (procedimiento almacenado)
                    command.Parameters.AddWithValue("Titulo", this.Titulo);

                    command.Connection = conn;
                    command.Transaction = sqlTran;
                    command.ExecuteNonQuery();
                    sqlTran.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    //throw ex;
                    sqlTran.Rollback();
                    throw ex;
                }
            }
            return true;
        }

        public List<Unidad> ListarTodos()
        {
            var sucursales = new List<Unidad>();
            try
            {
                var ds = new System.Data.DataSet();
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["syllabus"].ConnectionString))
                {
                    var command = new MySqlCommand() { CommandText = "getTitulo", CommandType = CommandType.StoredProcedure };
                    conn.Open();
                    command.Connection = conn;
                    var sqlda = new MySqlDataAdapter(command);
                    sqlda.Fill(ds);
                    conn.Close();
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Unidad s = new Unidad();
                    s.CargarDatos(dr);
                    sucursales.Add(s);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sucursales;
        }

        public void Seleccionar(String id)
        {
            try
            {
                var ds = new DataSet();
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["syllabus"].ConnectionString))
                {
                    var command = new MySqlCommand() { CommandText = "gettitulo", CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("titulo", Titulo);
                    conn.Open();
                    command.Connection = conn;
                    var sqlda = new MySqlDataAdapter(command);
                    sqlda.Fill(ds);
                    conn.Close();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.CargarDatos(ds.Tables[0].Rows[0]);
                    return;
                }
                else
                {
                    this.Titulo = "Not Found";

                }
            }
            catch (Exception ex)
            {
                //notificar administrador
                throw ex;
            }
        }

        public void CargarDatos(DataRow dr)
        {

            this.Titulo = dr["titulo"].ToString();

        }

    }
}
