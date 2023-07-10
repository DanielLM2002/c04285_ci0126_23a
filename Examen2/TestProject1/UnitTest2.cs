using Examen2.Handlers;
using Examen2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data;

namespace Examen2Tests.Handlers
{
    [TestClass]
    public class VehiculosHandlerTests
    {
        private VehiculosHandler handler;
        private Mock<IDbConnection> dbConnection;

        [TestInitialize]
        public void Init()
        {
            dbConnection = new Mock<IDbConnection>();
            handler = new VehiculosHandler(dbConnection.Object);
        }

        [TestMethod]
        public void ObtenerVehiculos_ReturnsListOfVehiculosModel()
        {
            // Arrange
            DataTable fakeTable = new DataTable("Vehiculo");
            fakeTable.Columns.Add("ID", typeof(int));
            fakeTable.Columns.Add("Nombre", typeof(string));
            fakeTable.Columns.Add("Tipo", typeof(string));
            fakeTable.Columns.Add("Popularidad", typeof(string));
            fakeTable.Columns.Add("Precio", typeof(decimal));
            fakeTable.Columns.Add("NecesitaLicencia", typeof(bool));

            DataRow row = fakeTable.NewRow();
            row["ID"] = 1;
            row["Nombre"] = "Car";
            row["Tipo"] = "Coche";
            row["Popularidad"] = "Alta";
            row["Precio"] = 15000.00M;
            row["NecesitaLicencia"] = true;
            fakeTable.Rows.Add(row);

            dbConnection.Setup(x => x.CreateCommand()).Returns(new Mock<IDbCommand>().Object);
            dbConnection.Setup(x => x.Open());

            IDbCommand commandMock = dbConnection.Object.CreateCommand();
            commandMock.CommandText = "SELECT * FROM Vehiculo";
            var readerMock = new Mock<IDataReader>();
            readerMock.Setup(c => c.Read()).Returns(() =>
            {
                var r = row;
                row = null;
                return r != null;
            });
            readerMock.Setup(c => c.IsDBNull(It.IsAny<int>())).Returns(false);
            readerMock.Setup(c => c["ID"]).Returns(() => 1);
            readerMock.Setup(c => c["Nombre"]).Returns(() => "Car");
            readerMock.Setup(c => c["Tipo"]).Returns(() => "Coche");
            readerMock.Setup(c => c["Popularidad"]).Returns(() => "Alta");
            readerMock.Setup(c => c["Precio"]).Returns(() => 15000.00M);
            readerMock.Setup(c => c["NecesitaLicencia"]).Returns(() => true);
            commandMock.Setup(x => x.ExecuteReader()).Returns(readerMock.Object);
            dbConnection.Setup(x => x.CreateCommand()).Returns(commandMock);

            // Act
            List<VehiculosModel> result = handler.ObtenerVehiculos();

            // Assert
            Assert.AreEqual(fakeTable.Rows.Count, result.Count);
            Assert.AreEqual(fakeTable.Rows[0]["ID"], result[0].ID);
            Assert.AreEqual(fakeTable.Rows[0]["Nombre"], result[0].Nombre);
            Assert.AreEqual(fakeTable.Rows[0]["Tipo"], result[0].Tipo);
            Assert.AreEqual(fakeTable.Rows[0]["Popularidad"], result[0].Popularidad);
            Assert.AreEqual(fakeTable.Rows[0]["Precio"], result[0].Precio);
            Assert.AreEqual(fakeTable.Rows[0]["NecesitaLicencia"], result[0].NecesitaLicencia);
        }
    }
}

