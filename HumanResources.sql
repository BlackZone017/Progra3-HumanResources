/**Trigger*/

CREATE TRIGGER salidaEmpleado		--Crea un trigger llamado salidaEmpleado
   ON  Salida						--Se ejecutara en la tabla Salida
   AFTER INSERT,UPDATE				--Se ejecutara despues de un Insert o un Update a la tabla
   AS
   BEGIN
	declare @idEmpleado int

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucci�n 
	SET NOCOUNT ON;
        
	-- Le paso el valor del idEmpleado de la tabla salida, a la variable ya creada
    SET @idEmpleado = (SELECT e.idEmpleado FROM INSERTED e)
	
	-- Finalmente, pongo como inactivo en la tabla empleado... el empleado que se introdujo en la tabla salida
	UPDATE empleado SET estatus ='Inactivo' WHERE id = @idEmpleado
	
END
GO

create database HumanResources
use HumanResources

--// ---------- ELIMINACION DE TABLAS ---------- \\--
DROP TABLE empleado
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
salario decimal(13,2),
estatus varchar(10),
idManager int
)

CREATE TABLE Departamento(
id int identity,
codigoDepartamento varchar(6),	-- UNIQUE INDEX
nombre varchar(25),
idManager int
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
montoTotal decimal(13,2)
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
correspondiente int,
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

--// ---------- CREACION DE CONSTRAINTS ---------- \\--

--//-----------          PK        ----------------\\--

ALTER TABLE empleado ADD CONSTRAINT PK_Empleado PRIMARY KEY( id )
ALTER TABLE departamento ADD CONSTRAINT PK_Departamento PRIMARY KEY( id )
ALTER TABLE cargo ADD CONSTRAINT PK_Cargo PRIMARY KEY( id )
ALTER TABLE nomina ADD CONSTRAINT PK_Nomina PRIMARY KEY( idNomina )
ALTER TABLE salida ADD CONSTRAINT PK_Salida PRIMARY KEY( id )
ALTER TABLE Vacaciones ADD CONSTRAINT PK_Vacaciones PRIMARY KEY( id )
ALTER TABLE permisos ADD CONSTRAINT PK_Permisos PRIMARY KEY( id )
ALTER TABLE licencias ADD CONSTRAINT PK_Licencias PRIMARY KEY( id )

--//-----------          FK        ----------------\\--

ALTER TABLE empleado ADD CONSTRAINT FK_Empleado_Departamneto FOREIGN KEY (idDepartamento) REFERENCES Departamento (id)
ALTER TABLE empleado ADD CONSTRAINT FK_Empleado_Cargo FOREIGN KEY (idCargo) REFERENCES Cargo (id)
ALTER TABLE salida ADD CONSTRAINT FK_Salida_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)
ALTER TABLE permisos ADD CONSTRAINT FK_Permisos_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)
ALTER TABLE licencias ADD CONSTRAINT FK_Licencias_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)
ALTER TABLE vacaciones ADD CONSTRAINT FK_vacaciones_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado (id)

--//-----------          UQ       ----------------\\--

ALTER TABLE empleado ADD CONSTRAINT UQ_codigoEmpleado UNIQUE( codigoEmpleado )
ALTER TABLE departamento ADD CONSTRAINT UQ_codigoDepartamento UNIQUE( codigoDepartamento )
ALTER TABLE cargo ADD CONSTRAINT UQ_codigoCargo UNIQUE( codigoCargo )



--// ---------- INSERTS ---------- \\--
INSERT INTO Departamento VALUES('DP-001','IT',1)
INSERT INTO Departamento VALUES('DP-002','Bases de Datos',2)
INSERT INTO Departamento VALUES('DP-003','RR HH',3)
INSERT INTO Departamento VALUES('DP-004','Mercadeo',4)
INSERT INTO Departamento VALUES('DP-005','Finanzas',5)

INSERT INTO cargo VALUES('CG-001','Gerente')
INSERT INTO cargo VALUES('CG-002','Sub-Gerente')
INSERT INTO cargo VALUES('CG-003','Desarrollador')
INSERT INTO cargo VALUES('CG-004','DBA')
INSERT INTO cargo VALUES('CG-005','Analista')

INSERT INTO empleado VALUES('EM-001','Gouri','Ramirez','809-728-2393',2,4,GETDATE()-10,30000,'Activo',1)
INSERT INTO empleado VALUES('EM-002','Alejandro','Santos','829-261-4569',1,3,GETDATE()-8,25000,'Activo',2)
INSERT INTO empleado VALUES('EM-003','Wilber','Tapia','809-597-5412',3,5,GETDATE()-5,28000,'Inactivo',null)
INSERT INTO empleado VALUES('EM-004','Kisandro','Feliz','809-569-7895',3,1,GETDATE(),35000,'Activo',4)
INSERT INTO empleado VALUES('EM-005','Domingo','Burgos','849-825-3652',4,2,GETDATE()+1,29500,'Activo',5)
INSERT INTO empleado VALUES('EM-006','Cristian','Feliz','809-025-4568',5,5,GETDATE()+6,21000,'Inactivo',null)

--Registro insertado para probar salida antes de crear el trigger
INSERT INTO empleado VALUES('EM-007','Oliver','Queen','809-111-1234',5, 2, '2019-04-13',25000,'activo',null)

--Creo el trigger y luego ejecuto esta query
INSERT INTO salida VALUES(7,'despido','HA sido despedido','2019-05-13')


INSERT INTO vacaciones VALUES(1,GETDATE()-15,GETDATE()-7,2019,'Vacaciones Familiares')
INSERT INTO vacaciones VALUES(2,GETDATE()-4,GETDATE()+1,2019,'Vacaciones a otro pais')
INSERT INTO vacaciones VALUES(4,GETDATE()-1,GETDATE()+5,2019,'Vacaciones Vacaciones')

INSERT INTO permisos VALUES(5,GETDATE(),GETDATE()+1,'Hijo Enfermo')
INSERT INTO permisos VALUES(4,GETDATE()+6,GETDATE() +8,'Problemas de Salud')

INSERT INTO Licencias VALUES(4,GETDATE()+8,GETDATE()+31,'Salud','Comentario 1')

SELECT * FROM empleado
SELECT * FROM Departamento
SELECT * FROM cargo
SELECT * FROM salida
SELECT * FROM vacaciones
SELECT * FROM permisos
SELECT * FROM Licencias

--FALTANTES POR INSERTS--
SELECT * FROM nomina

exec sp_columns empleado