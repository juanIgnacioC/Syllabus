DELIMITER $$
DROP PROCEDURE IF EXISTS sp_competencias_leersubaprendizajes $$
CREATE PROCEDURE sp_competencias_leersubaprendizajes(
	in_codigo VARCHAR(250)
)
BEGIN
	SELECT codigo, categoria, subcategoria, descripcion, porcentajelogro, estado
	FROM competencia_aprendizaje, aprendizaje
	WHERE codigoCompetencia = in_codigo AND
	codigo = codigoAprendizaje;
END
$$
