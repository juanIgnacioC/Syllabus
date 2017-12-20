DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_en_competencia $$
CREATE PROCEDURE sp_aprendizajes_en_competencia(
  in_codigoCompetencia INTEGER
)
BEGIN
  SELECT codigo
  FROM competencia_aprendizaje, Aprendizaje 
  WHERE codigoCompetencia = in_codigoCompetencia AND codigo = codigoAprendizaje;
END
$$