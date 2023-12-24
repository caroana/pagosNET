CREATE DATABASE pagos;
USE pagos;
-- Tabla de Usuarios
CREATE TABLE Usuarios (
    IDUsuario varchar(10) UNIQUE NOT NULL,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    Contraseña VARCHAR(255) NOT NULL, -- Se almacenará el hash de la contraseña
    TipoUsuario VARCHAR(20) NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    PRIMARY KEY (IDUsuario),
    INDEX idx_IDUsuario, (IDUsuario) -- Índice en el campo IDUsuario
    INDEX idx_NombreUsuario (NombreUsuario) -- Índice en el campo NombreUsuario
  
);

-- Tabla de Comercios
CREATE TABLE Comercios (
    CodigoComercio INT UNIQUE NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    NIT VARCHAR(20) NOT NULL,
    Direccion VARCHAR(255) NOT NULL
    PRIMARY KEY (CodigoComercio),
  INDEX PK_Comercio_Codigo (CodigoComercio),
  INDEX IX_Comercio_Nombre (Nombre),
  INDEX IX_Comercio_NIT (NIT)
);

-- Tabla de Transacciones
CREATE TABLE Transacciones (
    CodigoTransaccion INT UNIQUE NOT NULL,
    CodigoComercio INT NOT NULL,
    IDUsuario INT NOT NULL,
    MedioPago INT NOT NULL,
    EstadoTransaccion INT NOT NULL,
    Total FLOAT( NOT NULL,
    Fecha DATETIME NOT NULL,
    Concepto VARCHAR(255) NOT NULL,
    PRIMARY KEY (CodigoTransaccion),
    FOREIGN KEY (CodigoComercio) REFERENCES Comercios(CodigoComercio),
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario),
    INDEX idx_CodigoTransaccion (CodigoTransaccion), -- Índice en el campo CodigoTransaccion
    INDEX idx_IDComercio (CodigoComercio), -- Índice en el campo CodigoComercio
    INDEX idx_IDUsuario (IDUsuario), -- Índice en el campo IDUsuario
    INDEX idx_Fecha (Fecha) -- Índice en el campo Fecha

    
);




  
