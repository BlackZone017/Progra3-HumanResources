CREATE DATABASE prueba

use prueba

DROP TABLE empleado

CREATE TABLE empleado(
nombre varchar(30),
sueldo int,
fechaIngreso datetime)

INSERT INTO empleado VALUES('Gouri',25000,'2019-01-25')
INSERT INTO empleado VALUES('Yeduin',25000,'2019-01-26')

INSERT INTO empleado VALUES('darwin',30000,'2019-02-14')

SELECT * FROM Empleado

create procedure nomina(@fecha date)
as begin

SELECT sum(sueldo) as 'total' FROM empleado
WHERE fechaIngreso between  (select min(fechaIngreso) from empleado) and @fecha

end

exec nomina '2019-02-28'

SELECT SUM(SUELDO) FROM empleado

SELECT * FROM empleado
DELETE FROM empleado WHERE nombre in ('Gouri')
SELECT * FROM empleado

--CALCULAR NOMINA
use HumanResources

SELECT * FROM nomina

SELECT * FROM Empleado

exec Calcular_Nomina
exec sp_columns nomina
alter table nomina alter column mes varchar(15)

alter procedure Calcular_Nomina
as
begin

    DECLARE @Año int
    DECLARE @Mes varchar(15)
    DECLARE @TOTAL decimal(13,2)

    select @TOTAL = sum(Salario) from EMPLEADO where Estatus = 'Activo'

    select @Año = DATENAME(YEAR,GETDATE())

    select @Mes = DATENAME(MONTH,GETDATE())

    Begin try
            Begin tran


                if exists(select * from NOMINA where Año = @Año and mes = @Mes)
                    BEGIN
                        delete from NOMINA where Año = @Año and mes = @Mes
                        insert into NOMINA values (@Año, @Mes, @TOTAL)
                    END

                ELSE

                insert into NOMINA values (@Año, @Mes, @TOTAL)

                commit
        end try
        begin    catch
            rollback        print'Hay    errores'+ERROR_MESSAGE()
        end    catch


    select * from NOMINA

end

go