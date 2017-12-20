DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_editarcategoria $$
CREATE PROCEDURE sp_aprendizajes_editarcategoria
(
	in_categoria VARCHAR(250),
	in_categoriaprev VARCHAR(250)
)
BEGIN
	UPDATE categoria SET categoria = in_categoria WHERE categoria = in_categoriaprev;
END
$$