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
    public class Evaluaciones
    {
        public static List<Evaluacion> LeerTodo()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_Evaluacion_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Evaluacion> evaluaciones = new List<Evaluacion>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;

                        Enum.TryParse(prodData["tipoEvaluacion"].ToString(), out EnumTipoEvaluacion ETipoEvaluacion);
                        Evaluacion evaluacion = new Evaluacion()
                        {
                            Tipo = ETipoEvaluacion,
                        };
                        evaluaciones.Add(evaluacion);
                    }
                }
                return evaluaciones;
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