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

        public bool EditarVehiculo(VehiculosModel vehiculo)
        {
            var consultaActualizacion = $@"UPDATE [dbo].[Vehiculo] SET Nombre='{vehiculo.Nombre}', Tipo='{vehiculo.Tipo}', Popularidad='{vehiculo.Popularidad}', Precio='{vehiculo.Precio}', NecesitaLicencia='{vehiculo.NecesitaLicencia}' WHERE ID='{vehiculo.ID}'";
            SqlCommand comandoParaActualizacion = new SqlCommand(consultaActualizacion, conexion);
            conexion.Open();
            int resultado = comandoParaActualizacion.ExecuteNonQuery();
            conexion.Close();
            return resultado > 0;
        }
        public bool CrearVehiculo(VehiculosModel vehiculo)
        {
            var consultaCreaccion = $@"INSERT INTO [dbo].[Vehiculo] (ID, Nombre, Tipo, Popularidad, Precio, NecesitaLicencia) 
                                       VALUES ('{vehiculo.ID}', '{vehiculo.Nombre}', '{vehiculo.Tipo}', '{vehiculo.Popularidad}', '{vehiculo.Precio}', '{vehiculo.NecesitaLicencia}')";
            SqlCommand comandoParaCreacion = new SqlCommand(consultaCreaccion, conexion);
            conexion.Open();
            int resultado = comandoParaCreacion.ExecuteNonQuery();
            conexion.Close();
            return resultado > 0;
        }

        public bool EliminarVehiculo(int id)
        {
            var consultaEliminacion = $@"DELETE FROM [dbo].[Vehiculo] WHERE ID='{id}'";
            SqlCommand comandoParaEliminacion = new SqlCommand(consultaEliminacion, conexion);
            conexion.Open();
            int resultado = comandoParaEliminacion.ExecuteNonQuery();
            conexion.Close();
            return resultado > 0;
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
                    ID = Convert.ToInt32(columna["ID"]),
                    Nombre = Convert.ToString(columna["Nombre"]),
                    Tipo = Convert.ToString(columna["Tipo"]),
                    Popularidad = Convert.ToString(columna["Popularidad"]),
                    //Precio = Convert.ToString(columna["Precio"]),
                    Precio = (float)decimal.Parse(columna["Precio"].ToString()),
                    NecesitaLicencia = Convert.ToBoolean(columna["NecesitaLicencia"]),

                });
            }
            return vehiculos;
        }
    }
}