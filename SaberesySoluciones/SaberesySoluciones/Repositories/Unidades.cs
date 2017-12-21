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
                            Id = Convert.ToInt32(prodData["Id"]),
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

        public static List<Saber> LeerSubSaberes(int codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_unidades_leersubsaberes", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = codigo });
                var datos = DataSource.GetDataSet(command);

                List<Saber> saberes = new List<Saber>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Enum.TryParse(prodData["nivelLogro"].ToString(), out EnumLogro ELogro);
                        Enum.TryParse(prodData["estado"].ToString(), out EnumEstado EEstado);
                        var sabe = new Saber()
                        {
                            Codigo = Convert.ToString(prodData["codigo"]),
                            Descripcion = prodData["descripcion"].ToString(),
                            Logro = ELogro,
                            Estado = EEstado,
                            PorcentajeLogro = prodData["porcentajeLogro"].ToString(),
                            Id = Convert.ToInt32(prodData["id"])
                        };
                        saberes.Add(sabe);
                    }
                }
                return saberes;
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
    
   /* public static List<Unidad> LeerUnidadesEnSaberes(String codigo)
    {
        try
        {
            var command = new MySqlCommand() { CommandText = "sp_saber_leerrelacion", CommandType = System.Data.CommandType.StoredProcedure };
            command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoAprendizaje", Direction = System.Data.ParameterDirection.Input, Value = codigo });
            var datos = DataSource.GetDataSet(command);

            List<String> codigoSaber = new List<string>();

            if (datos.Tables[0].Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                {
                    var prodData = row;
                    String flotante = prodData["codigoSaber"].ToString();
                    codigoSaber.Add(flotante);
                }
            }

            if (codigoSaber.Count != 0)
            {
                List<Saber> comps = new List<Saber>();

                foreach (var c in codigoSaber)
                {
                    var UnSaber = LeerUno(c);
                    if (UnSaber != null)
                    {
                        comps.Add(UnSaber);
                    }
                }
                if (comps.Count != 0)
                {
                    return comps;
                }

            }
            else
            {
                return null;
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {

        }
        return null;
    }*/
}