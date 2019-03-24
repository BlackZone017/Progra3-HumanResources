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
montoTotal int)

---... cont Luis...


--// ---------- CREACION DE CONSTRAINTS ---------- \\--