create database HumanResources

use HumanResources

--// ---------- ELIMINACION DE TABLAS ---------- \\--
DROP TABLE empleado
DROP TABLE encargado
DROP TABLE Departamento
DROP TABLE cargo
DROP TABLE nomina
DROP TABLE salida
DROP TABLE vacaciones
DROP TABLE permisos
DROP TABLE Licencias

--// ---------- CREACION DE TABLAS ---------- \\--
CREATE TABLE Empleado(
id int identity,
codigoEmpleado varchar(6),		-- UNIQUE INDEX
nombre varchar(20),
apellido varchar(20),
telefono varchar(15),
idDepartamento int not null,	--FORANEA DE DEPARTAMENTO
idCargo int not null,			--FORANEA DE CARGO
fechaIngreso datetime,
salario int,
estatus varchar(10)
)

CREATE TABLE Encargado(
idEncargado int identity, 
idEmpleado int not null			--FORANEA DE EMPLEADO
)

CREATE TABLE Departamento(
id int identity,
codigoDepartamento varchar(6),	-- UNIQUE INDEX
nombre varchar(25),
idEncargado int	not null		--FORANEA DE ENCARGADO
)

CREATE TABLE Cargo(
id int identity,
codigoCargo varchar(6),			-- UNIQUE INDEX
cargo varchar(25)
)

CREATE TABLE Nomina(
idNomina int identity,
año int,
mes int,
montoTotal decimal(11,2)
)

CREATE TABLE Salida(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
tipoSalida varchar(10),   ---ver este
motivo varchar(100),
fechaSalida datetime
)

CREATE TABLE Vacaciones(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
correspondiente date,
comentarios varchar(200)
)

CREATE TABLE Permisos(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
comentarios varchar(200)
)

CREATE TABLE Licencias(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
motivos varchar(100),
comentarios varchar(100)
)

--// ---------- CREACION DE TABLAS ---------- \\--

ALTER TABLE empleado ADD CONSTRAINT PK_Empleado PRIMARY KEY( id )
ALTER TABLE encargado ADD CONSTRAINT PK_Encargado PRIMARY KEY( idEncargado )
ALTER TABLE departamento ADD CONSTRAINT PK_Departamento PRIMARY KEY( id )
ALTER TABLE cargo ADD CONSTRAINT PK_Cargo PRIMARY KEY( id )
ALTER TABLE nomina ADD CONSTRAINT PK_Nomina PRIMARY KEY( idNomina )
ALTER TABLE salida ADD CONSTRAINT PK_Salida PRIMARY KEY( id )
ALTER TABLE Vacaciones ADD CONSTRAINT PK_Vacaciones PRIMARY KEY( id )
ALTER TABLE permisos ADD CONSTRAINT PK_Permisos PRIMARY KEY( id )
ALTER TABLE licencias ADD CONSTRAINT PK_Licencias PRIMARY KEY( id )

ALTER TABLE empleado ADD CONSTRAINT FK_Empleado_Departamneto FOREIGN KEY (idDepartamento) REFERENCES Departamento (id)
ALTER TABLE empleado ADD CONSTRAINT FK_Empleado_Cargo FOREIGN KEY (idCargo) REFERENCES Cargo (id)
ALTER TABLE encargado ADD CONSTRAINT FK_Encargado_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)
ALTER TABLE departamento ADD CONSTRAINT FK_Departamento_Encargado FOREIGN KEY (idEncargado) REFERENCES Encargado (idEncargado)
ALTER TABLE salida ADD CONSTRAINT FK_Salida_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)
ALTER TABLE permisos ADD CONSTRAINT FK_Permisos_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)
ALTER TABLE licencias ADD CONSTRAINT FK_Licencias_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)

ALTER TABLE empleado ADD CONSTRAINT UQ_codigoEmpleado UNIQUE( codigoEmpleado )
ALTER TABLE departamento ADD CONSTRAINT UQ_codigoDepartamento UNIQUE( codigoDepartamento )
ALTER TABLE cargo ADD CONSTRAINT UQ_codigoCargo UNIQUE( codigoCargo )




