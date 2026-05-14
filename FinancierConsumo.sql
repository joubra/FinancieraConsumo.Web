/*   BASE DE DATOS: FINANCIERA DE CONSUMO */

 

CREATE DATABASE FinancieraConsumo;
GO
USE FinancieraConsumo;
GO


-- 1. TABLAS Y SEGURIDAD

CREATE TABLE DatosFinanciera (
    IdFinanciera INT PRIMARY KEY IDENTITY(1,1),
    NombreComercial VARCHAR(150) NOT NULL,
    RazonSocial VARCHAR(150) NOT NULL,
    NumeroRUC VARCHAR(20) NOT NULL UNIQUE,
    DireccionUbicacion VARCHAR(255) NOT NULL,
    TelefonoOficina VARCHAR(20) NOT NULL,
    CorreoContacto VARCHAR(100) NULL,
    PaginaWeb VARCHAR(100) NULL,
    RutaLogo VARCHAR(255) NULL
);

CREATE TABLE Rol (
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    NombreRol VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    IdRol INT NOT NULL,
    Estado BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)
);


-- 2. CLIENTES Y SOLICITUDES

CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    DocumentoIdentidad VARCHAR(20) NOT NULL UNIQUE,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    TelefonoCelular VARCHAR(20) NOT NULL,
    CorreoElectronico VARCHAR(100) NULL,
    DireccionDomicilio VARCHAR(255) NOT NULL,
    IngresoMensual DECIMAL(18,2) NOT NULL CHECK (IngresoMensual >= 0),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado BIT DEFAULT 1
);

CREATE TABLE Fiador (
    IdFiador INT PRIMARY KEY IDENTITY(1,1),
    DocumentoIdentidad VARCHAR(20) NOT NULL UNIQUE,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    TelefonoCelular VARCHAR(20) NOT NULL,
    DireccionDomicilio VARCHAR(255) NOT NULL,
    IngresoMensual DECIMAL(18,2) NOT NULL CHECK (IngresoMensual >= 0),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Solicitud_Credito (
    IdSolicitud INT PRIMARY KEY IDENTITY(1,1),
    IdCliente INT NOT NULL,
    IdFiador INT NULL,
    MontoSolicitado DECIMAL(18,2) NOT NULL CHECK (MontoSolicitado > 0),
    PlazoMeses INT NOT NULL CHECK (PlazoMeses > 0),
    IdAnalista INT NOT NULL,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    EstadoSolicitud VARCHAR(20) DEFAULT 'Pendiente' CHECK (EstadoSolicitud IN ('Pendiente','Aprobada','Rechazada')),
    CONSTRAINT FK_Solicitud_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    CONSTRAINT FK_Solicitud_Fiador FOREIGN KEY (IdFiador) REFERENCES Fiador(IdFiador),
    CONSTRAINT FK_Solicitud_Analista FOREIGN KEY (IdAnalista) REFERENCES Usuario(IdUsuario)
);


-- 3. OPERACIONES CREDITICIAS (3NF)

CREATE TABLE Credito (
    IdCredito INT PRIMARY KEY IDENTITY(1,1),
    IdSolicitud INT NOT NULL UNIQUE,
    MontoOtorgado DECIMAL(18,2) NOT NULL,
    TasaInteresAnual DECIMAL(5,2) NOT NULL,
    PlazoMeses INT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaVencimiento DATE NOT NULL,
    EstadoCredito VARCHAR(20) DEFAULT 'Vigente' CHECK (EstadoCredito IN ('Vigente','Cancelado','Vencido','Refinanciado')),
    CONSTRAINT FK_Credito_Solicitud FOREIGN KEY (IdSolicitud) REFERENCES Solicitud_Credito(IdSolicitud)
);

CREATE TABLE Cuota (
    IdCuota INT PRIMARY KEY IDENTITY(1,1),
    IdCredito INT NOT NULL,
    NumeroCuota INT NOT NULL,
    Capital DECIMAL(18,2) NOT NULL,
    Interes DECIMAL(18,2) NOT NULL,
    MoraAcumulada DECIMAL(18,2) DEFAULT 0,
    FechaVencimiento DATE NOT NULL,
    EstadoCuota VARCHAR(20) DEFAULT 'Pendiente',
    CONSTRAINT FK_Cuota_Credito FOREIGN KEY (IdCredito) REFERENCES Credito(IdCredito),
    CONSTRAINT UQ_Cuota UNIQUE (IdCredito, NumeroCuota)
);


-- 4. PAGOS Y AUDITORÍA

CREATE TABLE Pago (
    IdPago INT PRIMARY KEY IDENTITY(1,1),
    IdCredito INT NOT NULL,
    IdUsuarioCajero INT NOT NULL,
    MontoTotal DECIMAL(18,2) NOT NULL,
    FechaPago DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Pago_Credito FOREIGN KEY (IdCredito) REFERENCES Credito(IdCredito),
    CONSTRAINT FK_Pago_Cajero FOREIGN KEY (IdUsuarioCajero) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE PagoDetalle (
    IdPagoDetalle INT PRIMARY KEY IDENTITY(1,1),
    IdPago INT NOT NULL,
    IdCuota INT NOT NULL,
    MontoAplicado DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_PagoDetalle_Pago FOREIGN KEY (IdPago) REFERENCES Pago(IdPago),
    CONSTRAINT FK_PagoDetalle_Cuota FOREIGN KEY (IdCuota) REFERENCES Cuota(IdCuota)
);

CREATE TABLE Mora (
    IdMora INT PRIMARY KEY IDENTITY(1,1),
    IdCuota INT NOT NULL,
    DiasMora INT NOT NULL,
    MontoMora DECIMAL(18,2) NOT NULL,
    FechaCalculo DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Mora_Cuota FOREIGN KEY (IdCuota) REFERENCES Cuota(IdCuota)
);

-- Tabla de Auditoría
CREATE TABLE Auditoria (
    IdLog INT PRIMARY KEY IDENTITY(1,1),
    TablaAfectada VARCHAR(50) NOT NULL,
    TipoOperacion CHAR(1) NOT NULL,
    IdRegistro INT NOT NULL,
    Usuario VARCHAR(50) NOT NULL,
    FechaHora DATETIME DEFAULT GETDATE(),
    ValoresAnterior XML NULL,
    ValoresNuevo XML NULL
);
GO
INSERT INTO Cliente
(
DocumentoIdentidad,
Nombres,
Apellidos,
TelefonoCelular,
CorreoElectronico,
DireccionDomicilio,
IngresoMensual
)
VALUES
(
'001-010101-0001A',
'Juan',
'Pérez',
'88887777',
'juan@gmail.com',
'León, Nicaragua',
1200
);

INSERT INTO Cliente
(
DocumentoIdentidad,
Nombres,
Apellidos,
TelefonoCelular,
CorreoElectronico,
DireccionDomicilio,
IngresoMensual
)
VALUES
(
'001-010101-0002B',
'María',
'López',
'88886666',
'maria@gmail.com',
'Managua, Nicaragua',
1500
);
select *from Cliente