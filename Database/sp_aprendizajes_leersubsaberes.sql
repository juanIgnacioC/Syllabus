DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leersubsaberes $$
CREATE PROCEDURE sp_aprendizajes_leersubsaberes(
	in_codigo VARCHAR(250)
)
BEGIN
	SELECT id, codigo, descripcion, nivelLogro, estado, porcentajeLogro
	FROM aprendizaje_saber, saber
	WHERE codigoAprendizaje = in_codigo AND
	id = idSaber;
END
$$
