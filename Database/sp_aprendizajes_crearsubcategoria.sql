DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_crearsubcategoria $$
CREATE PROCEDURE sp_aprendizajes_crearsubcategoria
(
	in_categoria VARCHAR(250),
	in_subcategoria TEXT,
	OUT out_subcategoriaid INTEGER
)
BEGIN

DECLARE out_count INTEGER DEFAULT 0;

SELECT count(*) INTO out_count FROM subcategoria WHERE ref_categoria = in_categoria;

INSERT INTO subcategoria(subcategoria, ref_categoria, codigo) VALUES (in_subcategoria, in_categoria, (out_count+1));

SET out_subcategoriaid = LAST_INSERT_ID();
	
END
$$

