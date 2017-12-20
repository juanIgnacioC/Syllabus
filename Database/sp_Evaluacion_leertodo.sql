DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leertodo $$
CREATE PROCEDURE sp_Evaluacion_leertodo()
BEGIN
	SELECT id, tipoEvaluacion
	FROM Evaluacion;
END
$$