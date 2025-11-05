CREATE DATABASE TrabajadoresPrueba;
GO
USE TrabajadoresPrueba;
GO

CREATE TABLE Trabajadores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombres NVARCHAR(100),
    Apellidos NVARCHAR(100),
    TipoDocumento NVARCHAR(50),
    NumeroDocumento NVARCHAR(20),
    Sexo NVARCHAR(10),
    FechaNacimiento DATE,
    Foto NVARCHAR(255),
    Direccion NVARCHAR(255)
);
GO

CREATE PROCEDURE sp_ListarTrabajadores
AS
BEGIN
    SELECT * FROM Trabajadores ORDER BY Id DESC;
END;
GO

CREATE PROCEDURE sp_RegistrarTrabajador
(
    @Nombres NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @TipoDocumento NVARCHAR(50),
    @NumeroDocumento NVARCHAR(20),
    @Sexo NVARCHAR(10),
    @FechaNacimiento DATE,
    @Foto NVARCHAR(255),
    @Direccion NVARCHAR(255)
)
AS
BEGIN
    INSERT INTO Trabajadores (Nombres, Apellidos, TipoDocumento, NumeroDocumento, Sexo, FechaNacimiento, Foto, Direccion)
    VALUES (@Nombres, @Apellidos, @TipoDocumento, @NumeroDocumento, @Sexo, @FechaNacimiento, @Foto, @Direccion);
END;
GO

CREATE PROCEDURE sp_EditarTrabajador
(
    @Id INT,
    @Nombres NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @TipoDocumento NVARCHAR(50),
    @NumeroDocumento NVARCHAR(20),
    @Sexo NVARCHAR(10),
    @FechaNacimiento DATE,
    @Foto NVARCHAR(255),
    @Direccion NVARCHAR(255)
)
AS
BEGIN
    UPDATE Trabajadores
    SET Nombres=@Nombres, Apellidos=@Apellidos, TipoDocumento=@TipoDocumento,
        NumeroDocumento=@NumeroDocumento, Sexo=@Sexo, FechaNacimiento=@FechaNacimiento,
        Foto=@Foto, Direccion=@Direccion
    WHERE Id=@Id;
END;
GO

CREATE PROCEDURE sp_EliminarTrabajador (@Id INT)
AS
BEGIN
    DELETE FROM Trabajadores WHERE Id=@Id;
END;
GO
