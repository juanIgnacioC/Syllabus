DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leercategorias $$
CREATE PROCEDURE sp_aprendizajes_leercategorias()
BEGIN
	SELECT categoria
	FROM categoria;
END
$$
