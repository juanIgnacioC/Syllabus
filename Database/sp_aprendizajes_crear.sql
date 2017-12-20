DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_crear $$
CREATE PROCEDURE sp_aprendizajes_crear
(

  	in_categoria TEXT,
  	in_subCategoria TEXT,
  	in_descripcion TEXT,
  	in_porcentajeLogro INTEGER,
  	in_estado TEXT,
  	OUT out_codigo INTEGER
)
BEGIN

	INSERT INTO aprendizaje(categoria, subCategoria, descripcion, porcentajeLogro, estado)
	VALUES (in_categoria, in_subCategoria, in_descripcion, in_porcentajeLogro, in_estado);

	SET out_codigo = LAST_INSERT_ID();

END
$$