using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using SaberesySoluciones.Models;
using SaberesSyllabus.Models;
using SaberesySoluciones.Repositories;

namespace SaberesSyllabus.Repositories
{
    public class Unidades
    {
        public static List<Unidad> LeerTodo()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_Unidad_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Unidad> unidades = new List<Unidad>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;

                        Unidad unidad = new Unidad()
                        {
                            Titulo = prodData["titulo"].ToString(),
                        };
                        unidades.Add(unidad);
                    }
                }
                return unidades;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }
            return null;

        }
    }
}