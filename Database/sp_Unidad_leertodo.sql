DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leertodo $$
CREATE PROCEDURE sp_Unidad_leertodo()
BEGIN
	SELECT id, titulo
	FROM Unidad;
END
$$