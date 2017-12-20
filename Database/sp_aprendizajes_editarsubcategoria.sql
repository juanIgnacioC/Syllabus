DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_editarsubcategoria $$
CREATE PROCEDURE sp_aprendizajes_editarsubcategoria
(
	in_subcategoria TEXT,
	in_subcategoriaid INTEGER
)
BEGIN
	UPDATE subcategoria SET subcategoria = in_subcategoria WHERE id = in_subcategoriaid;
END
$$

