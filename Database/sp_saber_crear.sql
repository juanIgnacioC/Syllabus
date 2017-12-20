DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saber_crear $$
CREATE PROCEDURE sp_saber_crear
(
	in_codigo TEXT,
  	in_descripcion TEXT,
  	in_nivelLogro TEXT,
  	in_estado TEXT,
  	in_porcentajeLogro INTEGER,
  	OUT out_id INTEGER
)
	
BEGIN

	INSERT INTO saber(codigo, descripcion, nivelLogro, estado, porcentajeLogro)
	VALUES (in_codigo, in_descripcion, in_nivelLogro, in_estado, in_porcentajeLogro);
	SET out_id = LAST_INSERT_ID();

END
$$
