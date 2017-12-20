using MySql.Data.MySqlClient;
using SaberesSyllabus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Models
{
    public class Clase
    {
        public long Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        //public BloquesHoras horaInicio { get; set; }
        //public BloquesHoras horaTermino { get; set; }
        //public string horaInicioText { get; set; }
        //public string horaTerminoText { get; set; }
        //public string horario { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public List<Saber> Saberes { get; set; }
        public TipoClase Tipo { get; set; }
        public string TipoClase { get; set; }

        public Clase()
        {
            this.Saberes = new List<Saber>();
        }

        public bool Crear()
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Syllabus"].ConnectionString))
            {
                conn.Open();
                var sqlTran = conn.BeginTransaction();
                try
                {
                    var command = new MySqlCommand() { CommandText = "crearClase", CommandType = CommandType.StoredProcedure };
                    //Setea el valor de los atributos del SP (procedimiento almacenado)
                    command.Parameters.AddWithValue("fecha", this.Fecha); ;
                    command.Parameters.AddWithValue("tema", this.Tema);
                    command.Parameters.AddWithValue("descripcion", this.Descripcion);
                    command.Parameters.AddWithValue("tipoClase", this.Tipo);
                    command.Connection = conn;
                    command.Transaction = sqlTran;
                    command.ExecuteNonQuery();
                    sqlTran.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                }
            }
            return true;
        }


        public List<Clase> ListarClases()
        {
            var clases = new List<Clase>();
            try
            {
                var ds = new DataSet();
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Syllabus"].ConnectionString))
                {
                    var command = new MySqlCommand()
                    {
                        CommandText = "getClases",
                        CommandType = CommandType.StoredProcedure
                    };
                    conn.Open();
                    command.Connection = conn;
                    var sqlda = new MySqlDataAdapter(command);
                    sqlda.Fill(ds);
                    conn.Close();
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Clase c = new Clase();
                    c.CargarDatos(dr);
                    clases.Add(c);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return clases;
        }


        public void CargarDatos(DataRow dr)
        {
            this.Id = Convert.ToInt64(dr["id"].ToString());
            this.Fecha = (DateTime)dr["fecha"];
            //this.horaInicioText = dr["horaInicio"].ToString();
            //this.horaTerminoText = dr["horaTermino"].ToString();
            this.Tema = dr["tema"].ToString();
            this.Descripcion = dr["descripcion"].ToString();
            this.TipoClase = dr["tipoClase"].ToString();

            if (this.TipoClase.Equals("1"))
            {
                this.TipoClase = "Clase";
            }
            if (this.TipoClase.Equals("2"))
            {
                this.TipoClase = "Laboratorio";
            }
            if (this.TipoClase.Equals("3"))
            {
                this.TipoClase = "Ayudantia";
            }

            //HorariosString();

        }




        public void Seleccionar(long id)
        {
            try
            {
                var ds = new DataSet();
                using (var conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["Syllabus"].ConnectionString))
                {
                    var command = new MySqlCommand()
                    {
                        CommandText = "getClaseID",
                        CommandType =
                    CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("id", this.Id);
                    conn.Open();
                    command.Connection = conn;
                    var sqlda = new MySqlDataAdapter(command);
                    sqlda.Fill(ds);
                    conn.Close();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.CargarDatos(ds.Tables[0].Rows[0]);
                }
                else
                {
                    /*
                    this.Nombre = "Not Found";
                    this.Direccion = "Not Found";
                    this.Estado = "Not Found";
                    this.Id = -1;
                    */
                }
            }
            catch (Exception ex)
            {
                //notificar administrador
                throw ex;
            }
        }



        public void EliminarSucursal(long codigo)
        {
            try
            {
                using (var conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["Syllabus"].ConnectionString))
                {
                    var command = new MySqlCommand()
                    {
                        CommandText = "eliminarClase",
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("id", this.Id);
                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                //notificar administrador
                throw ex;
            }
        }
    }

    public enum TipoClase
    {
        //[Description("Clase")]
        Clase=1,
        //[Description("Laboratorio")]
        Laboratorio=2,
        //[Description("Ayudantia")]
        Ayudantia=3,
    }

    public enum BloquesHoras
    {
        Bloque1 = 1,
        Bloque2 = 2,
        Bloque3 = 3,
        Bloque4 = 4,
        Bloque5 = 5,
        Bloque6 = 6,
        Bloque7 = 7,
        Bloque8 = 8,
        Bloque9 = 9,
        Bloque10 = 10,
        Bloque11 = 11

    }

}