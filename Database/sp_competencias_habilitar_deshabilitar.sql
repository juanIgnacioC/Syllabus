DELIMITER $$
DROP PROCEDURE IF EXISTS sp_competencias_habilitar_deshabilitar $$
CREATE PROCEDURE sp_competencias_habilitar_deshabilitar
(
	in_codigo int,
	in_estado VARCHAR(250)
	
)
BEGIN

	UPDATE competencia
	SET estado = in_estado
	WHERE codigo = in_codigo;
END
$$