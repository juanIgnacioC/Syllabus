using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaberesySoluciones.Models;
using SaberesSyllabus.Models;
using SaberesySoluciones.Repositories;

namespace SaberesySoluciones.ViewModel
{

    public class SaberesLogrados
    {
        public List<Aprendizaje> aprendizajes { get; set; }
        public List<Saber> saberes { get; set; }
        public List<Competencia> competencias { get; set; }
        public List<String> resultados { get; set; }

        public SaberesLogrados()
        {
            this.aprendizajes = new List<Aprendizaje>();
            this.saberes = new List<Saber>();
            this.competencias = new List<Competencia>();
        }

        public static List<Competencia> LeerTodo()
        {
            try
            {

                var commandC = new MySqlCommand() { CommandText = "sp_competencias_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datosC = DataSource.GetDataSet(commandC);
                
                List<Competencia> componentes = new List<Competencia>();

                if (datosC.Tables[0].Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("leeeeeeeer Competencias");

                    foreach (System.Data.DataRow row in datosC.Tables[0].Rows)
                    {
                        var prodData = row;
                        var competencia = new Competencia()
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

                        System.Diagnostics.Debug.WriteLine("codC: " + competencia.Codigo);


                        var commandA = new MySqlCommand() { CommandText = "sp_competencias_leersubaprendizajes", CommandType = System.Data.CommandType.StoredProcedure };
                        commandA.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = competencia.Codigo });
                        var datosA = DataSource.GetDataSet(commandA);

                        int nAprendizajes = 0;
                        List<int> porcentajesA = new List<int>();
                        System.Diagnostics.Debug.WriteLine("A");

                        List<Aprendizaje> aprendizajes = new List<Aprendizaje>();

                        if (datosA.Tables[0].Rows.Count > 0)
                        {
                            foreach (System.Data.DataRow rowA in datosA.Tables[0].Rows)
                            {
                                var prodDataA = rowA;

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

                                var commandS = new MySqlCommand() { CommandText = "sp_aprendizajes_leersubsaberes", CommandType = System.Data.CommandType.StoredProcedure };
                                commandA.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = aprendizaje.Codigo });
                                var datosS = DataSource.GetDataSet(commandA);

                                List<int> porcentajesS = new List<int>();

                                int nSaberes = 0;
                                List<Saber> saberes = new List<Saber>();
                                if (datosS.Tables[0].Rows.Count > 0)
                                {
                                    System.Diagnostics.Debug.WriteLine("leeeeeeeer Saberes");
                                    foreach (System.Data.DataRow rowS in datosS.Tables[0].Rows)
                                    {

                                        var prodDataS = rowS;

                                        Enum.TryParse(prodDataS["nivelLogro"].ToString(), out EnumLogro ELogro);
                                        Enum.TryParse(prodDataS["estado"].ToString(), out EnumEstado EEEstado);
                                        var saber = new Saber()
                                        {
                                            Codigo = Convert.ToString(prodData["codigo"]),
                                            Descripcion = prodData["descripcion"].ToString(),
                                            Logro = ELogro,
                                            Estado = EEEstado,
                                            PorcentajeLogro = prodData["porcentajeLogro"].ToString(),
                                            Id = Convert.ToInt32(prodData["id"])
                                        };

                                        porcentajesS.Add(Convert.ToInt32(saber.PorcentajeLogro));
                                        nSaberes++;

                                        //agregar saber a componentes
                                        saberes.Add(saber);

                                    }
                                }
                                //calculo de porcentaje del aprendizaje actual
                                int porcentajeAprendizaje = calcularPorcentaje(porcentajesS);

                                porcentajesA.Add(aprendizaje.PorcentajeLogro);
                                nAprendizajes++;

                                //se agregan los aprendizajes a los componentes
                                aprendizaje.PorcentajeLogro = porcentajeAprendizaje;
                                aprendizajes.Add(aprendizaje);

                            }
                        }

                        //calculo de porcentaje de la competencia actual
                        int porcentajeCompetencia = calcularPorcentaje(porcentajesA);

                        competencia.PorcentajeLogro = porcentajeCompetencia;
                        componentes.Add(competencia);
                        
                    }
                }
                //retorna lista de componentes completa
                return componentes;
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


        public static int calcularPorcentaje(List<int> porcentajes)
        {
            int resultado = 0;
            int tamano = 0;
            foreach (var item in porcentajes)
            {
                resultado += item;
                tamano++;
            }
            resultado = resultado / tamano;
            System.Diagnostics.Debug.WriteLine("resultado: " + resultado);
            Console.WriteLine("resultado: " + resultado);
            return resultado;
        }
    }
}