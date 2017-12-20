DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saber_logrado_leertodo $$
CREATE PROCEDURE sp_saber_logrado_leertodo
(
	in_codigo TEXT
)
BEGIN
	SELECT aprendizaje.codigo, aprendizaje.categoria, aprendizaje.subCategoria, aprendizaje.descripcion, aprendizaje.porcentajeLogro, aprendizaje.estado
	FROM aprendizaje, aprendizaje_saber, saber
	WHERE aprendizaje.codigo = in_codigo AND 
	aprendizaje_saber.codigoAprendizaje = in_codigo AND 
	saber.codigo = aprendizaje_saber.idSaber;
END
$$
