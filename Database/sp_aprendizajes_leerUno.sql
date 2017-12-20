DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leerUno $$
CREATE PROCEDURE sp_aprendizajes_leerUno(
	in_codigo VARCHAR(250)
)
BEGIN
	SELECT codigo, categoria, subCategoria, descripcion, porcentajeLogro, estado
	FROM aprendizaje
	WHERE codigo = in_codigo;
END
$$