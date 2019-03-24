create database HumanResources

use HumanResources

--// ---------- CREACION DE TABLAS ---------- \\--
CREATE TABLE Empleado(
id int primary key identity,
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
idEncargado int primary key identity, 
idEmpleado int,					--FORANEA DE EMPLEADO
idDepartamento int				--FORANEA DE DEPARTAMENTO
)

CREATE TABLE Departamento(
id int primary key identity,
codigoDepartamento varchar(6),	-- UNIQUE INDEX
nombre varchar(25),
idEncargado int					--FORANEA DE ENCARGADO
)

CREATE TABLE Cargo(
id int primary key identity,
codigoCargo varchar(6),			-- UNIQUE INDEX
cargo varchar(25)
)

CREATE TABLE Nomina(
idNomina int primary key identity,
año int,
mes int,
montoTotal decimal(5,2)
)

---... cont Luis...
CREATE TABLE Salida(
id int primary key identity,
idEmpleado int,  --FORANEA DE EMPLEADO
tipoSalida varchar(10),   ---ver este
motivo varchar(100),
fechaSalida datetime
)

CREATE TABLE Vacaciones(
id int primary key identity,
idEmpleado int,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
correspondiente date,
comentarios varchar(200)
)

CREATE TABLE Permisos(
id int primary key identity,
idEmpleado int,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
comentarios varchar(200)
)

CREATE TABLE Licencias(
id int identity,
idEmpleado int,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
motivos varchar(100),
comentarios varchar(100),
CONSTRAINT PK_Licencias PRIMARY KEY( id )

)

--// ---------- CREACION DE CONSTRAINTS ---------- \\--