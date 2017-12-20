DELIMITER $$
DROP PROCEDURE IF EXISTS sp_aprendizajes_leeraprendizajes $$
CREATE PROCEDURE sp_aprendizajes_leeraprendizajes(
	in_subcategoria INTEGER
)
BEGIN
	SELECT codigo, descripcion, porcentajeLogro, estado
	FROM aprendizaje
	WHERE ref_subCategoria = in_subcategoria;
END
$$
