using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SaberesSyllabus.Models;
using SaberesySoluciones.Repositories;
using SaberesySoluciones.Models;

namespace SaberesSyllabus.Repositories
{
    public class Aprendizajes
    {
        public static Aprendizaje Crear(Aprendizaje aprendizaje)
        {
            try
            {
                Enum.TryParse("Habilitado", out EnumEstado EEstado);
                aprendizaje.Estado = EEstado;
                var command = new MySqlCommand() { CommandText = "sp_aprendizajes_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_categoria", Direction = System.Data.ParameterDirection.Input, Value = aprendizaje.Categoria });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_subCategoria", Direction = System.Data.ParameterDirection.Input, Value = aprendizaje.SubCategoria });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_descripcion", Direction = System.Data.ParameterDirection.Input, Value = aprendizaje.Descripcion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_porcentajeLogro", Direction = System.Data.ParameterDirection.Input, Value = 0 });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = aprendizaje.Estado.ToString() });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_codigo", Direction = System.Data.ParameterDirection.Output, Value = -1 });

                var datos = DataSource.ExecuteProcedure(command);

                aprendizaje.Codigo = Convert.ToInt32(datos.Parameters["out_codigo"].Value);

                return aprendizaje;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static List<Saber> LeerSubSaberes(int codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_aprendizajes_leersubsaberes", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = codigo});
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

        public static bool Editar(Aprendizaje aprendizaje)
        {
            return false;
        }

        public static Boolean CrearAprendizajeEncompetencia(String codigoA, String codigoS)
        {
            try
            {

                var command = new MySqlCommand() { CommandText = "sp_competencia_crearrelacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoCompetencia", Direction = System.Data.ParameterDirection.Input, Value = codigoA });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoAprendizaje", Direction = System.Data.ParameterDirection.Input, Value = codigoS });
                DataSource.ExecuteProcedure(command);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static bool Habilitar(string codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_aprendizajes_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = codigo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = "Habilitado" });
                DataSource.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static bool Deshabilitar(string codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_aprendizajes_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = codigo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = "Deshabilitado" });
                DataSource.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static Boolean Nose(String codigoA, String codigoS)
        {
            try
            {

                var command = new MySqlCommand() { CommandText = "sp_saber_crearrelacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoAprendizaje", Direction = System.Data.ParameterDirection.Input, Value = codigoA });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoSaber", Direction = System.Data.ParameterDirection.Input, Value = codigoS });
                DataSource.ExecuteProcedure(command);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public static List<Aprendizaje> LeerTodo()
        {
            try
            {

                System.Diagnostics.Debug.WriteLine("leeeeeeeer Controlleeeeeeeeeeeer");
                var command = new MySqlCommand() { CommandText = "sp_aprendizajes_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);
                System.Diagnostics.Debug.WriteLine("leido spppppppppppppppppp");


                List<Aprendizaje> aprendizajes = new List<Aprendizaje>();
                if (datos.Tables[0].Rows.Count > 0)
                {

                    System.Diagnostics.Debug.WriteLine("leeeeeeeer if-foreach");
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {

                        System.Diagnostics.Debug.WriteLine("leeeeeeeer foreaachhhhhhhhhh");
                        var prodData = row;
                        Enum.TryParse(prodData["estado"].ToString(), out EnumEstado EEstado);
                        var aprendizaje = new Aprendizaje()
                        {
                            Codigo = Convert.ToInt32(prodData["codigo"]),
                            Categoria = prodData["categoria"].ToString(),
                            SubCategoria = prodData["subCategoria"].ToString(),
                            Descripcion = prodData["descripcion"].ToString(),
                            PorcentajeLogro = Convert.ToInt32(prodData["porcentajeLogro"]),
                            Estado = EEstado
                        };
                        aprendizajes.Add(aprendizaje);
                    }
                }
                return aprendizajes;
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

        public static List<Aprendizaje> LeerHabilitados() {

            try
            {
                var command = new MySqlCommand() { CommandText = "sp_aprendizajes_leerHabilitados", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Aprendizaje> apr = new List<Aprendizaje>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Enum.TryParse("Habilitado", out EnumEstado EEstado);
                        var appr = new Aprendizaje()
                        {
                            Codigo = Convert.ToInt32(prodData["codigo"]),
                            Categoria = prodData["categoria"].ToString(),
                            SubCategoria = prodData["subCategoria"].ToString(),
                            Descripcion = prodData["descripcion"].ToString(),
                            PorcentajeLogro = Convert.ToInt32(prodData["porcentajeLogro"]),
                            Estado = EEstado
                        };

                        apr.Add(appr);
                    }
                }
                return apr;
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

    /*public static Boolean Nose(String codigoA, String codigoS)
    {
        try
        {

            var command = new MySqlCommand() { CommandText = "sp_saber_crearrelacion", CommandType = System.Data.CommandType.StoredProcedure };
            command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoAprendizaje", Direction = System.Data.ParameterDirection.Input, Value = codigoA });
            command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoSaber", Direction = System.Data.ParameterDirection.Input, Value = codigoS });
            DataSource.ExecuteProcedure(command);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }*/
}