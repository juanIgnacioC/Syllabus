DELIMITER $$
DROP PROCEDURE IF EXISTS sp_competencias_crear $$
CREATE PROCEDURE sp_competencias_crear
(
    in_nombre TEXT,
    in_descripcion TEXT,
  	in_dominio VARCHAR(250),
  	in_basico TEXT,
  	in_intermedio TEXT,
  	in_avanzado TEXT,
  	in_tiempoDesarrollo VARCHAR(250),
  	in_estado VARCHAR(250),
    in_porcentajeLogro INTEGER,
	OUT out_codigo INTEGER
)
BEGIN

	INSERT INTO competencia(nombre, descripcion, dominio, basico, intermedio, avanzado, tiempoDesarrollo, estado, porcentajeLogro)
	VALUES (in_nombre ,in_descripcion, in_dominio, in_basico, in_intermedio, in_avanzado, in_tiempoDesarrollo, in_estado, in_porcentajeLogro);

	SET out_codigo = LAST_INSERT_ID();
END
$$
