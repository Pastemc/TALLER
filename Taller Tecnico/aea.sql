-- =============================================
-- SCRIPT BASE DE DATOS: SISTEMA TALLER DE SERVICIO TÉCNICO
-- SQL Server
-- =============================================

-- Crear la base de datos
CREATE DATABASE TallerServicioTecnico;
GO

USE TallerServicioTecnico;
GO

-- =============================================
-- TABLA: Clientes
-- =============================================
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    NombreCompleto NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100),
    Direccion NVARCHAR(200),
    DNI NVARCHAR(20) UNIQUE NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado BIT DEFAULT 1
);

-- =============================================
-- TABLA: Equipos
-- =============================================
CREATE TABLE Equipos (
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    TipoEquipo NVARCHAR(50) NOT NULL, -- Laptop, PC, Impresora, etc.
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    NumeroSerie NVARCHAR(100) UNIQUE,
    Descripcion NVARCHAR(300),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado BIT DEFAULT 1
);

-- =============================================
-- TABLA: Citas
-- =============================================
CREATE TABLE Citas (
    CitaID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    EquipoID INT FOREIGN KEY REFERENCES Equipos(EquipoID),
    FechaCita DATETIME NOT NULL,
    HoraCita TIME NOT NULL,
    Motivo NVARCHAR(300) NOT NULL,
    Estado NVARCHAR(20) DEFAULT 'Pendiente', -- Pendiente, Confirmada, Completada, Cancelada
    Observaciones NVARCHAR(500),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- =============================================
-- TABLA: Servicios
-- =============================================
CREATE TABLE Servicios (
    ServicioID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT FOREIGN KEY REFERENCES Equipos(EquipoID),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    FechaIngreso DATETIME DEFAULT GETDATE(),
    FechaEntrega DATETIME,
    Diagnostico NVARCHAR(500),
    TipoServicio NVARCHAR(100) NOT NULL, -- Reparación, Mantenimiento, Revisión
    EstadoServicio NVARCHAR(20) DEFAULT 'En Proceso', -- En Proceso, Completado, Entregado, Cancelado
    CostoServicio DECIMAL(10,2) DEFAULT 0,
    Tecnico NVARCHAR(100),
    Observaciones NVARCHAR(500),
    Prioridad NVARCHAR(20) DEFAULT 'Normal' -- Alta, Normal, Baja
);

-- =============================================
-- TABLA: Repuestos
-- =============================================
CREATE TABLE Repuestos (
    RepuestoID INT PRIMARY KEY IDENTITY(1,1),
    NombreRepuesto NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(300),
    Marca NVARCHAR(50),
    Stock INT DEFAULT 0,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    StockMinimo INT DEFAULT 5,
    Categoria NVARCHAR(50),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado BIT DEFAULT 1
);

-- =============================================
-- TABLA: DetalleServicio (Repuestos utilizados)
-- =============================================
CREATE TABLE DetalleServicio (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    ServicioID INT FOREIGN KEY REFERENCES Servicios(ServicioID),
    RepuestoID INT FOREIGN KEY REFERENCES Repuestos(RepuestoID),
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL
);

-- =============================================
-- TABLA: Facturas
-- =============================================
CREATE TABLE Facturas (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),
    ServicioID INT FOREIGN KEY REFERENCES Servicios(ServicioID),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    NumeroFactura NVARCHAR(20) UNIQUE NOT NULL,
    FechaEmision DATETIME DEFAULT GETDATE(),
    Subtotal DECIMAL(10,2) NOT NULL,
    IGV DECIMAL(10,2) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    MetodoPago NVARCHAR(50), -- Efectivo, Tarjeta, Transferencia
    Estado NVARCHAR(20) DEFAULT 'Pendiente' -- Pendiente, Pagada, Anulada
);

-- =============================================
-- TABLA: Usuarios (Para el sistema de login)
-- =============================================
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) UNIQUE NOT NULL,
    Contraseña NVARCHAR(100) NOT NULL,
    NombreCompleto NVARCHAR(100) NOT NULL,
    Rol NVARCHAR(20) NOT NULL, -- Administrador, Técnico, Recepcionista
    Email NVARCHAR(100),
    Estado BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- =============================================
-- DATOS DE PRUEBA
-- =============================================

-- Insertar usuario administrador por defecto
INSERT INTO Usuarios (NombreUsuario, Contraseña, NombreCompleto, Rol, Email)
VALUES ('admin', '12345', 'Administrador del Sistema', 'Administrador', 'admin@taller.com');

INSERT INTO Usuarios (NombreUsuario, Contraseña, NombreCompleto, Rol, Email)
VALUES ('tecnico1', '12345', 'Juan Pérez', 'Técnico', 'tecnico1@taller.com');

-- Insertar clientes de prueba
INSERT INTO Clientes (NombreCompleto, Telefono, Email, Direccion, DNI)
VALUES 
('Carlos Mendoza', '987654321', 'carlos@email.com', 'Av. Principal 123', '12345678'),
('María López', '987654322', 'maria@email.com', 'Jr. Los Pinos 456', '23456789'),
('José García', '987654323', 'jose@email.com', 'Calle Real 789', '34567890');

-- Insertar equipos de prueba
INSERT INTO Equipos (ClienteID, TipoEquipo, Marca, Modelo, NumeroSerie, Descripcion)
VALUES 
(1, 'Laptop', 'HP', 'Pavilion 15', 'HP2024001', 'Laptop color negro, 8GB RAM'),
(2, 'PC Escritorio', 'Dell', 'OptiPlex 7090', 'DELL2024001', 'PC de oficina completo'),
(3, 'Impresora', 'Epson', 'L3210', 'EPSON2024001', 'Impresora multifuncional');

-- Insertar repuestos de prueba
INSERT INTO Repuestos (NombreRepuesto, Descripcion, Marca, Stock, PrecioUnitario, StockMinimo, Categoria)
VALUES 
('Memoria RAM 8GB DDR4', 'Memoria RAM para laptops y PCs', 'Kingston', 15, 150.00, 5, 'Memoria'),
('Disco Duro 1TB', 'Disco duro SATA 2.5 pulgadas', 'Seagate', 10, 200.00, 3, 'Almacenamiento'),
('Teclado USB', 'Teclado estándar USB', 'Logitech', 20, 45.00, 5, 'Periféricos'),
('Mouse Inalámbrico', 'Mouse óptico inalámbrico', 'Logitech', 25, 35.00, 5, 'Periféricos'),
('Pasta Térmica', 'Pasta térmica para procesadores', 'Arctic', 30, 15.00, 10, 'Insumos');

-- Insertar citas de prueba
INSERT INTO Citas (ClienteID, EquipoID, FechaCita, HoraCita, Motivo, Estado)
VALUES 
(1, 1, '2025-11-10', '10:00:00', 'Mantenimiento preventivo', 'Confirmada'),
(2, 2, '2025-11-11', '14:00:00', 'Revisión de hardware', 'Pendiente');

-- Insertar servicios de prueba
INSERT INTO Servicios (EquipoID, ClienteID, FechaIngreso, Diagnostico, TipoServicio, EstadoServicio, CostoServicio, Tecnico, Prioridad)
VALUES 
(1, 1, GETDATE(), 'Laptop lenta, requiere limpieza y optimización', 'Mantenimiento', 'En Proceso', 150.00, 'Juan Pérez', 'Normal'),
(3, 3, GETDATE(), 'Impresora no imprime a color', 'Reparación', 'En Proceso', 80.00, 'Juan Pérez', 'Alta');

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

-- Procedimiento para registrar cliente
GO
CREATE PROCEDURE sp_RegistrarCliente
    @NombreCompleto NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Email NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @DNI NVARCHAR(20)
AS
BEGIN
    INSERT INTO Clientes (NombreCompleto, Telefono, Email, Direccion, DNI)
    VALUES (@NombreCompleto, @Telefono, @Email, @Direccion, @DNI);
    
    SELECT SCOPE_IDENTITY() AS ClienteID;
END
GO

-- Procedimiento para registrar equipo
CREATE PROCEDURE sp_RegistrarEquipo
    @ClienteID INT,
    @TipoEquipo NVARCHAR(50),
    @Marca NVARCHAR(50),
    @Modelo NVARCHAR(50),
    @NumeroSerie NVARCHAR(100),
    @Descripcion NVARCHAR(300)
AS
BEGIN
    INSERT INTO Equipos (ClienteID, TipoEquipo, Marca, Modelo, NumeroSerie, Descripcion)
    VALUES (@ClienteID, @TipoEquipo, @Marca, @Modelo, @NumeroSerie, @Descripcion);
    
    SELECT SCOPE_IDENTITY() AS EquipoID;
END
GO

-- Procedimiento para actualizar stock de repuestos
CREATE PROCEDURE sp_ActualizarStockRepuesto
    @RepuestoID INT,
    @Cantidad INT
AS
BEGIN
    UPDATE Repuestos
    SET Stock = Stock - @Cantidad
    WHERE RepuestoID = @RepuestoID;
END
GO

-- Procedimiento para obtener repuestos con stock bajo
CREATE PROCEDURE sp_RepuestosBajoStock
AS
BEGIN
    SELECT * FROM Repuestos
    WHERE Stock <= StockMinimo AND Estado = 1
    ORDER BY Stock ASC;
END
GO

-- Vista para servicios activos
CREATE VIEW vw_ServiciosActivos AS
SELECT 
    s.ServicioID,
    c.NombreCompleto AS Cliente,
    c.Telefono,
    e.TipoEquipo,
    e.Marca,
    e.Modelo,
    s.FechaIngreso,
    s.EstadoServicio,
    s.TipoServicio,
    s.Prioridad,
    s.Tecnico
FROM Servicios s
INNER JOIN Clientes c ON s.ClienteID = c.ClienteID
INNER JOIN Equipos e ON s.EquipoID = e.EquipoID
WHERE s.EstadoServicio IN ('En Proceso', 'Pendiente');
GO

SELECT * FROM vw_ServiciosActivos;
GO

PRINT 'Base de datos creada exitosamente!';