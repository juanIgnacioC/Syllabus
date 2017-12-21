DELIMITER $$
DROP PROCEDURE IF EXISTS sp_unidades_leersubsaberes $$
CREATE PROCEDURE sp_unidades_leersubsaberes(
	in_codigo VARCHAR(250)
)
BEGIN
	SELECT id, codigo, descripcion, nivelLogro, estado, porcentajeLogro
	FROM unidad_saber, saber
	WHERE idUnidad = in_codigo 
	AND	id = idSaber;
END
$$
