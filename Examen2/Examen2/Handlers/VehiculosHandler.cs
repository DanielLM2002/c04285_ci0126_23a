using System;
using System.Collections.Generic;
using Examen2.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;


namespace Examen2.Handlers
{
    public class VehiculosHandler
    {
        private SqlConnection conexion;
        private string rutaConexion;
        public VehiculosHandler()
        {
            var builder = WebApplication.CreateBuilder();
            rutaConexion = builder.Configuration.GetConnectionString("ContextoVehiculos");
            conexion = new SqlConnection(rutaConexion);
        }
        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }
        public List<VehiculosModel> ObtenerVehiculos()
        {
            List<VehiculosModel> vehiculos = new List<VehiculosModel>();
            string consulta = "SELECT * FROM Vehiculo";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                vehiculos.Add(
                new VehiculosModel
                {
                    //ID = Convert.ToInt32(columna["Id"]),
                    //Nombre = Convert.ToString(columna["Nombre"]),
                    //Año = Convert.ToInt32(columna["Año"]),
                    Nombre = Convert.ToString(columna["Nombre"]),
                    Tipo = Convert.ToString(columna["Tipo"]),
                    Popularidad = Convert.ToString(columna["Popularidad"]),
                    Precio = Convert.ToInt32(columna["Precio"]),
                    NecesitaLicencia = Convert.ToBoolean(columna["NecesitaLicencia"]),

                });
            }
            return vehiculos;
        }
    }
}