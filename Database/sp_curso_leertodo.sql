DELIMITER $$
DROP PROCEDURE IF EXISTS sp_curso_leertodo $$
CREATE PROCEDURE sp_curso_leertodo()
BEGIN
	SELECT id, nombre, horasPresenciales, horasAutonomas, descripcion, estado
	FROM curso;
END
$$