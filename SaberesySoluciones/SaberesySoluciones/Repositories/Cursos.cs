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
    public class Cursos
    {

        public static Curso Crear(Curso curso)
        {
            Console.WriteLine("Dentro de crear del repositorio de cursos");
            try
            {
                Enum.TryParse("Habilitado", out EnumEstado EEstado);
                curso.Estado = EEstado;

                var command = new MySqlCommand() { CommandText = "sp_curso_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = curso.Id.ToString() });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = curso.Nombre.ToString() });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_horasPresenciales", Direction = System.Data.ParameterDirection.Input, Value = curso.HorasPresenciales });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_horasAutonomas", Direction = System.Data.ParameterDirection.Input, Value = curso.HorasAutonomas });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_descripcion", Direction = System.Data.ParameterDirection.Input, Value = curso.Descripcion.ToString() });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = curso.Estado.ToString() });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });

                var datos = DataSource.ExecuteProcedure(command);

                curso.Id = datos.Parameters["out_id"].Value.ToString();
                Console.WriteLine("retornando el curso creado");
                return curso;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("hay error");
                return null;
            }


        }

        public static List<Curso> LeerTodo()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_curso_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Curso> cursos = new List<Curso>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;

                        // Enum.TryParse(prodData["nivelLogro"].ToString(), out EnumLogro ELogro);
                        Enum.TryParse(prodData["estado"].ToString(), out EnumEstado EEstado);
                        var cur = new Curso()
                        {
                            Id = Convert.ToString(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            Descripcion = prodData["descripcion"].ToString(),
                            //Logro = ELogro,
                            Estado = EEstado,
                            HorasPresenciales = Convert.ToInt32(prodData["horasPresenciales"]),
                            HorasAutonomas = Convert.ToInt32(prodData["horasAutonomas"]),
                            //Id = Convert.ToInt32(prodData["id"])
                        };
                        cursos.Add(cur);
                    }
                }
                return cursos;
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