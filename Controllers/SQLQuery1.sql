CREATE DATABASE EPSDB;
GO
USE EPSDB;
GO
INSERT INTO Departamento (Nombre) VALUES ('Antioquia'), ('Cundinamarca');
INSERT INTO Municipio (Nombre, DepartamentoId, Codigo) VALUES ('Medellín', 1, '001'), ('Bogotá', 2, '002');
INSERT INTO PlanEPS (Nombre, Cobertura) VALUES ('Plan Básico', 'Nacional'), ('Plan Premium', 'Nacional');
INSERT INTO Afiliado (Nombre, Documento, Email, FechaNacimiento) VALUES ('Luis Morales', '123456789', 'luis@example.com', '1990-05-15');


-- =========================================
-- Script completo para crear base de datos EPSDB
-- Incluye todas las tablas, relaciones PK/FK e índices
-- =========================================

-- 1. Crear la base de datos
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'EPSDB')
BEGIN
    CREATE DATABASE EPSDB;
END
GO

-- 2. Seleccionar la base de datos
USE EPSDB;
GO

-- 3. Crear tablas

-- Departamento
CREATE TABLE Departamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
GO

-- Municipio
CREATE TABLE Municipio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    DepartamentoId INT NOT NULL,
    Codigo VARCHAR(10) NOT NULL,
    CONSTRAINT FK_Municipio_Departamento FOREIGN KEY (DepartamentoId) REFERENCES Departamento(Id)
);
GO

-- PlanEPS
CREATE TABLE PlanEPS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Cobertura VARCHAR(50) NOT NULL
);
GO

-- Afiliado
CREATE TABLE Afiliado (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Documento VARCHAR(20) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    FechaNacimiento DATETIME2 NOT NULL
);
GO

-- Categoria
CREATE TABLE Categoria (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
GO

-- Cita
CREATE TABLE Cita (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AfiliadoId INT NOT NULL,
    Fecha DATETIME2 NOT NULL,
    Hora TIME NOT NULL,
    CONSTRAINT FK_Cita_Afiliado FOREIGN KEY (AfiliadoId) REFERENCES Afiliado(Id)
);
GO

-- AfiliadoDetalle
CREATE TABLE AfiliadoDetalle (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AfiliadoId INT NOT NULL,
    TipoDetalle VARCHAR(50) NOT NULL,
    Valor VARCHAR(100) NOT NULL,
    FechaRegistro DATETIME2 NOT NULL,
    CONSTRAINT FK_AfiliadoDetalle_Afiliado FOREIGN KEY (AfiliadoId) REFERENCES Afiliado(Id)
);
GO

-- Contrato
CREATE TABLE Contrato (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AfiliadoId INT NOT NULL,
    PlanEPSId INT NOT NULL,
    FechaInicio DATETIME2 NOT NULL,
    FechaFin DATETIME2 NULL,
    CONSTRAINT FK_Contrato_Afiliado FOREIGN KEY (AfiliadoId) REFERENCES Afiliado(Id),
    CONSTRAINT FK_Contrato_PlanEPS FOREIGN KEY (PlanEPSId) REFERENCES PlanEPS(Id)
);
GO

-- Pago
CREATE TABLE Pago (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ContratoId INT NOT NULL,
    Valor DECIMAL(18,2) NOT NULL CHECK (Valor >= 0),
    Fecha DATETIME2 NOT NULL,
    CONSTRAINT FK_Pago_Contrato FOREIGN KEY (ContratoId) REFERENCES Contrato(Id)
);
GO

-- Factura
CREATE TABLE Factura (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PagoId INT NOT NULL UNIQUE,
    Numero VARCHAR(50) NOT NULL,
    Fecha DATETIME2 NOT NULL,
    CONSTRAINT FK_Factura_Pago FOREIGN KEY (PagoId) REFERENCES Pago(Id)
);
GO

-- HistoriaMedica
CREATE TABLE HistoriaMedica (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AfiliadoId INT NOT NULL,
    Diagnostico VARCHAR(100) NOT NULL,
    Fecha DATETIME2 NOT NULL,
    CONSTRAINT FK_HistoriaMedica_Afiliado FOREIGN KEY (AfiliadoId) REFERENCES Afiliado(Id)
);
GO

-- Indicador
CREATE TABLE Indicador (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Valor DECIMAL(18,2) NOT NULL CHECK (Valor >= 0)
);
GO

-- Reporte
CREATE TABLE Reporte (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL,
    Fecha DATETIME2 NOT NULL
);
GO

-- Usuario
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Clave VARCHAR(50) NOT NULL
);
GO

-- Rol
CREATE TABLE Rol (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200) NOT NULL
);
GO

-- 4. Crear índices recomendados
CREATE UNIQUE INDEX UX_Afiliado_Documento ON Afiliado(Documento);
CREATE UNIQUE INDEX UX_Factura_Numero ON Factura(Numero);
GO

-- =========================================
-- Script finalizado
-- Instrucciones:
-- 1. Abrir SQL Server Management Studio.
-- 2. Copiar y pegar todo el script en una nueva consulta.
-- 3. Ejecutar.
-- 4. Se creará la base de datos EPSDB con todas las tablas, relaciones PK/FK e índices.
-- 5. Para generar el diagrama ER:
--      - En EPSDB -> Database Diagrams -> New Database Diagram
--      - Agregar todas las tablas
--      - Ajustar posiciones y exportar como imagen para incluir en tu trabajo
-- =========================================
