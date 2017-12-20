DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizaje_logrado $$
CREATE PROCEDURE sp_aprendizaje_logrado
(
	in_codigo varchar(256)
)
BEGIN
	SELECT codigo, categoria, subCategoria, descripcion, porcentajeLogro, estado
	FROM competencia_aprendizaje, Aprendizaje 
  	WHERE codigoCompetencia = in_codigoCompetencia AND codigo = codigoAprendizaje;
	END
$$

