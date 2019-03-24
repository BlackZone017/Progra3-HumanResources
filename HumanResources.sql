create database HumanResources

use HumanResources

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
estatus varchar(10),
CONSTRAINT PK_Empleado PRIMARY KEY( id ),
/* CONSTRAINT FK_Empleado_Departamneto FOREIGN KEY (idDepartamento)   ------Lo mismo aqui
 REFERENCES Departamneto (id)*/
)

CREATE TABLE Encargado(
idEncargado int identity, 
idEmpleado int not null,					--FORANEA DE EMPLEADO
idDepartamento int not null,				--FORANEA DE DEPARTAMENTO  ---poque la foranea esta aqui tambien
CONSTRAINT PK_Encargado PRIMARY KEY( idEncargado ),
 CONSTRAINT FK_Encargado_Empleado FOREIGN KEY (idEmpleado) 
 REFERENCES Empleado (id),
/* CONSTRAINT FK_Encargado_Departamento FOREIGN KEY (idDepartamento) 
 REFERENCES Departamento (id)*/  
)

CREATE TABLE Departamento(
id int identity,
codigoDepartamento varchar(6),	-- UNIQUE INDEX
nombre varchar(25),
idEncargado int	not null,			--FORANEA DE ENCARGADO   ---poque la foranea esta aqui
CONSTRAINT PK_Departamento PRIMARY KEY( id ),
 /*CONSTRAINT FK_Departamento_Encargado FOREIGN KEY (idEncargado) 
 REFERENCES Encargado (idEncargado)*/
)

CREATE TABLE Cargo(
id int identity,
codigoCargo varchar(6),			-- UNIQUE INDEX
cargo varchar(25),
CONSTRAINT PK_Cargo PRIMARY KEY( id )
)

CREATE TABLE Nomina(
idNomina int identity,
año int,
mes int,
montoTotal decimal(5,2),
CONSTRAINT PK_Nomina PRIMARY KEY( idNomina )
)

---... cont Luis...
CREATE TABLE Salida(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
tipoSalida varchar(10),   ---ver este
motivo varchar(100),
fechaSalida datetime,
CONSTRAINT PK_Salida PRIMARY KEY( id ),
 CONSTRAINT FK_Salida_Empleado FOREIGN KEY (idEmpleado) 
 REFERENCES Empleado (id)
)

CREATE TABLE Vacaciones(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
correspondiente date,
comentarios varchar(200),
CONSTRAINT PK_Vacaciones PRIMARY KEY( id )
)

CREATE TABLE Permisos(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
comentarios varchar(200),
CONSTRAINT PK_Permisos PRIMARY KEY( id ),
 CONSTRAINT FK_Permisos_Empleado FOREIGN KEY (idEmpleado) 
 REFERENCES Empleado (id)
)

CREATE TABLE Licencias(
id int identity,
idEmpleado int not null,  --FORANEA DE EMPLEADO
desde datetime,   
hasta datetime,
motivos varchar(100),
comentarios varchar(100),
CONSTRAINT PK_Licencias PRIMARY KEY( id ),
 CONSTRAINT FK_Licencias_Empleado FOREIGN KEY (idEmpleado) 
 REFERENCES Empleado (id)
)

--// ---------- CREACION DE CONSTRAINTS ---------- \\--