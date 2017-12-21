DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saber_crearrelacion $$
CREATE PROCEDURE sp_saber_crearrelacion
(
	in_codigoAprendizaje VARCHAR(250),
	in_idSaber VARCHAR(250)
)
BEGIN

  INSERT INTO Aprendizaje_Saber(codigoAprendizaje, idSaber)
  VALUES (in_codigoAprendizaje, in_idSaber);
END
$$
