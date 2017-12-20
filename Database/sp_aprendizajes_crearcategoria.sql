DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_crearcategoria $$
CREATE PROCEDURE sp_aprendizajes_crearcategoria
(
	in_categoria VARCHAR(250)
)
BEGIN
	INSERT INTO categoria(categoria)
	VALUES (in_categoria);
END
$$