DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saberes_leerUno $$
CREATE PROCEDURE sp_saberes_leerUno(
	in_codigo VARCHAR(250)
)
BEGIN
	SELECT codigo, descripcion, nivelLogro, estado, porcentajeLogro
	FROM aprendizaje
	WHERE codigo = in_codigo;
END
$$