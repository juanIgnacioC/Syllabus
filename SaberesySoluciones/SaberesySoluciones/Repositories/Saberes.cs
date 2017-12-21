using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using SaberesySoluciones.Models;
using SaberesSyllabus.Models;
using SaberesySoluciones.Repositories;

namespace SaberesySoluciones.Repositories

{
    public class Saberes
    {
        public static Saber Crear(Saber saber)
        {
            try
            {
                Enum.TryParse("Habilitado", out EnumEstado EEstado);
                saber.Estado = EEstado;

                var command = new MySqlCommand() { CommandText = "sp_saber_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = saber.Codigo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_descripcion", Direction = System.Data.ParameterDirection.Input, Value = saber.Descripcion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nivelLogro", Direction = System.Data.ParameterDirection.Input, Value = saber.Logro.ToString() });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = saber.Estado.ToString() });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_porcentajeLogro", Direction = System.Data.ParameterDirection.Input, Value = saber.PorcentajeLogro });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });

                var datos = DataSource.ExecuteProcedure(command);

                saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);

                return saber;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static bool Deshabilitar(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_saberes_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = "Deshabilitado" });
                DataSource.ExecuteProcedure(command);
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

        public static bool Habilitar(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_saberes_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
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

        public static bool Editar(Saber saber)
        {
            Boolean estadoConsulta;
            int idAnterior;

            try
            {
                idAnterior = saber.Id;

                saber = Crear(saber);
                if (saber.Id != (-1))
                {
                    estadoConsulta = Deshabilitar(idAnterior);
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

        public static List<Saber> LeerTodo()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_saber_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Saber> sabers = new List<Saber>();
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
                        sabers.Add(sabe);
                    }
                }
                return sabers;
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

        public static Saber LeerUno(String codigo) {

            try
            {
                var command = new MySqlCommand() { CommandText = "sp_saberes_leerUno", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = codigo });
                var datos = DataSource.GetDataSet(command);

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
                        PorcentajeLogro = prodData["porcentajeLogro"].ToString()
                    };
                    return sabe;
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
        }

        public static List<Saber> LeerHabilitado()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_saber_leerHabilitados", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Saber> sabers = new List<Saber>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;

                        Enum.TryParse(prodData["nivelLogro"].ToString(), out EnumLogro ELogro);
                        Enum.TryParse("Habilitado", out EnumEstado EEstado);
                        var sabe = new Saber()
                        {
                            Codigo = Convert.ToString(prodData["codigo"]),
                            Descripcion = prodData["descripcion"].ToString(),
                            Logro = ELogro,
                            Estado = EEstado,
                            PorcentajeLogro = prodData["porcentajeLogro"].ToString(),
                            Id = Convert.ToInt32(prodData["id"])

                        };
                        sabers.Add(sabe);
                    }
                }
                return sabers;
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

        public static List<Saber> LeerSaberesEnAprendizaje(String codigo)
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

                    foreach (var c in codigoSaber) {
                        var UnSaber = LeerUno(c);
                        if (UnSaber != null) {
                            comps.Add(UnSaber);
                        }
                    }
                    if (comps.Count != 0) {
                        return comps;
                    }
                    
                }
                else {
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
        }

        public static Boolean CrearSaberEnAprendizaje(String codigoA, String codigoS)
        {
            try
            {

                var command = new MySqlCommand() { CommandText = "sp_saber_crearrelacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoAprendizaje", Direction = System.Data.ParameterDirection.Input, Value = codigoA});
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idSaber", Direction = System.Data.ParameterDirection.Input, Value = codigoS });
                DataSource.ExecuteProcedure(command);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static Boolean EliminarSaberEnAprendizaje(String codigoA, String codigoS)
        {
            try
            {

                var command = new MySqlCommand() { CommandText = "sp_saber_eliminarrelacion", CommandType = System.Data.CommandType.StoredProcedure };
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
    }
}