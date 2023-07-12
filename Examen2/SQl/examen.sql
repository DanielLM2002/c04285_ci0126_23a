use C04285



INSERT INTO Vehiculo (ID, Nombre, Tipo, Popularidad, Precio, NecesitaLicencia)
--VALUES ('Toyota Camry', 'Terrestre', 'Alta', 25000, 1);
VALUES ( 1 ,'Toyota yaris', 'Terrestre', 'Alta', 50000.21, 1);


select * from Vehiculo

delete from Vehiculo

drop table Vehiculo


CREATE TABLE [dbo].[Vehiculo] (
    [Nombre]           VARCHAR (30) NOT NULL,
    [Tipo]             VARCHAR (30) NOT NULL,
    [Popularidad]      VARCHAR (30) NOT NULL,
    [Precio]           FLOAT (53)   NOT NULL,
    [NecesitaLicencia] BIT          NOT NULL,
    [ID]               INT          NOT NULL,
    CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED ([ID] ASC)
);
