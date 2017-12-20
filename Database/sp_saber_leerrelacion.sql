DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saber_leerrelacion $$
CREATE PROCEDURE sp_saber_leerrelacion(
	in_codigoAprendizaje VARCHAR(250)
)
BEGIN
	SELECT codigoSaber
	FROM Aprendizaje_Saber
	WHERE codigoAprendizaje = in_codigoAprendizaje;
END
$$
