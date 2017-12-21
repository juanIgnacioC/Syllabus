DELIMITER $$
DROP PROCEDURE IF EXISTS sp_unidad_crearrelacion $$
CREATE PROCEDURE sp_unidad_crearrelacion
(
	in_idUnidad INTEGER,
	in_idSaber INTEGER
)
BEGIN

  INSERT INTO Unidad_Saber(idUnidad, idSaber)
  VALUES (in_idUnidad, in_idSaber);
END
$$
