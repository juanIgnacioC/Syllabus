using MySql.Data.MySqlClient;
using SaberesySoluciones.Models;
using SaberesySoluciones.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Repositories
{
    public class Competencias
    {
        public static Competencia Crear(Competencia competencia)
        {
            try
            {
                //Enum.TryParse("Habilitado", out EnumEstado EEstado);
                competencia.Estado = "Habilitado";
                var command = new MySqlCommand() { CommandText = "sp_competencias_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = competencia.Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_descripcion", Direction = System.Data.ParameterDirection.Input, Value = competencia.Descripcion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_dominio", Direction = System.Data.ParameterDirection.Input, Value = competencia.Dominio });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_basico", Direction = System.Data.ParameterDirection.Input, Value = competencia.Basico });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_intermedio", Direction = System.Data.ParameterDirection.Input, Value = competencia.Intermedio });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_avanzado", Direction = System.Data.ParameterDirection.Input, Value = competencia.Avanzado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tiempoDesarrollo", Direction = System.Data.ParameterDirection.Input, Value = competencia.TiempoDesarrollo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = competencia.Estado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_porcentajeLogro", Direction = System.Data.ParameterDirection.Input, Value = 0 });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_codigo", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = DataSource.ExecuteProcedure(command);

                competencia.Codigo = Convert.ToInt32(datos.Parameters["out_codigo"].Value);
                return competencia;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static bool Deshabilitar(int codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_competencias_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value =  codigo});
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value =  "Deshabilitado" });
                var datos = DataSource.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

            }
        }

        public static bool Habilitar(int codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_competencias_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = codigo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = "Habilitado" });
                var datos = DataSource.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

            }
        }

        public static bool Editar(Competencia competencia)
        {
            Boolean estadoConsulta;
            int codigoAnterior;

            try
            {
                codigoAnterior = competencia.Codigo;

                competencia = Crear(competencia);
                if (competencia.Codigo != (-1))
                {
                    estadoConsulta = Deshabilitar(codigoAnterior);
                    if (estadoConsulta == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

            }
        }

        public static List<Competencia> LeerTodo() {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_competencias_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Competencia> comps = new List<Competencia>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        //Enum.TryParse(prodData["dominio"].ToString(), out EnumNivelDominio EDominio);
                        //Enum.TryParse(prodData["estado"].ToString(), out EnumEstado EEstado);
                        var comp = new Competencia()
                        {
                            Codigo = Convert.ToInt32(prodData["codigo"]),
                            Nombre = prodData["nombre"].ToString(),
                            Descripcion = prodData["descripcion"].ToString(),
                            Dominio = prodData["dominio"].ToString(),
                            Basico = prodData["basico"].ToString(),
                            Intermedio = prodData["intermedio"].ToString(),
                            Avanzado = prodData["avanzado"].ToString(),
                            TiempoDesarrollo = prodData["tiempoDesarrollo"].ToString(),
                            Estado = prodData["estado"].ToString()
                        };

                        comps.Add(comp);
                    }
                }
                return comps;
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