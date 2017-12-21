DELIMITER $$
DROP PROCEDURE IF EXISTS sp_competencia_crearrelacion $$
CREATE PROCEDURE sp_competencia_crearrelacion
(
	in_codigoCompetencia INTEGER,
	in_codigoAprendizaje INTEGER
)
BEGIN

  INSERT INTO Competencia_Aprendizaje(codigoCompetencia, codigoAprendizaje)
  VALUES (in_codigoCompetencia, in_codigoAprendizaje);
END
$$
