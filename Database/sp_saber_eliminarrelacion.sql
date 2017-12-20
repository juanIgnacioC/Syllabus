DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saber_eliminarrelacion $$
CREATE PROCEDURE sp_saber_eliminarrelacion
(
  in_codigoAprendizaje VARCHAR(250),
  in_codigoSaber VARCHAR(250)
)
BEGIN

  DELETE FROM Aprendizaje_Saber
  WHERE codigoSaber = in_codigoSaber AND
  codigoAprendizaje = in_codigoAprendizaje;
END
$$
