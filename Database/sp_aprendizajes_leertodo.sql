DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leertodo $$
CREATE PROCEDURE sp_aprendizajes_leertodo()
BEGIN
	SELECT codigo, categoria, subcategoria, descripcion, porcentajelogro, estado
	FROM aprendizaje;
END
$$
