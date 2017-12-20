DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leertodo $$
CREATE PROCEDURE sp_UnidadEvaluacion_leertodo()
BEGIN
	SELECT idUnidad, idEvaluacion
	FROM Unidad_Evaluacion;
END
$$