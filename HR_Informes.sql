
--NOTA: Los create view funcionan.... pero marcan error porque deben
	--	ser lo unico que contenga el archivo.sql 
	--	(no debe haber otra cosa que no sea la sentencia del create view)

---------------------- QUERIES INFORMES ----------------------

----NOMINAS----


----EMPLEADOS ACTIVOS----
create view EmpleadosActivos as 
SELECT * FROM Empleado WHERE estatus = 'ACTIVO';

SELECT * FROM EmpleadosActivos


----EMPLEADOS INACTIVOS----
create view EmpleadosInactivos as 
SELECT * FROM Empleado WHERE estatus = 'INACTIVO';

SELECT * FROM EmpleadosInactivos


----DEPARTAMENTOS----
SELECT * FROM Departamento  --Vista sera generada en ASP

----CARGOS----
Select * from Cargo			--Vista sera generada en ASP

--------ENTRADAS-------
----Entradas de empleados por mes. 
--  Visualizar las entradas (empleados creados, ingresados) 
--	en un mes determinado por el usuario 

--Linq en ASP para esta query
SELECT (nombre + ' ' + apellido) "Empleado",CAST(fechaIngreso as varchar(12)) as 'Ingreso' FROM empleado
WHERE DATEPART(Month,fechaIngreso) = 3 --Siendo 3 el mes que ponga el usuario (variable mes)


--------SALIDAS--------
--Linq en asp para esta query
--Salida de empleados por mes. Visualizar las salidas (empleados creados, ingresados) en un mes determinado por el usuario
ALTER PROCEDURE salidasMes(@mes int)
AS BEGIN
SELECT e.nombre +' '+e.apellido as "Empleado" ,s.* FROM salida s
JOIN Empleado e ON (s.idEmpleado = e.id)
WHERE DATEPART(Month,fechaSalida) = @mes --Siendo 3 el mes que ponga el usuario (variable mes)
END 

exec salidasMes 4

SELECT * FROM Salida
--------VACACIONES--------
--Linq en asp para esta query para que el usuario pueda buscar por año
SELECT * FROM vacaciones
where correspondiente = 2019 --Siende 2019 el año que ponga el usuario


--------PERMISOS---------

--Linq en sql para esta consulta
SELECT e.nombre + ' ' + apellido as 'Empleado' ,p.* 
FROM permisos p
JOIN Empleado e ON (p.idEmpleado = e.id)
WHERE idEmpleado = 4 --Siendo 4 el id del Empleado que el usuario quiera buscar
