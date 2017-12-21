DELIMITER $$
DROP PROCEDURE IF EXISTS sp_curso_crear $$
CREATE PROCEDURE sp_curso_crear
(
	  in_id VARCHAR(250),
  	in_nombre TEXT,
  	in_horasPresenciales INTEGER,
  	in_horasAutonomas INTEGER,
  	in_descripcion TEXT,
  	in_estado TEXT
)
	
BEGIN

	INSERT INTO curso(id, nombre, horasPresenciales, horasAutonomas, descripcion, estado)
	VALUES (in_id, in_nombre, in_horasPresenciales, in_horasAutonomas, in_descripcion, in_estado);


END
$$
