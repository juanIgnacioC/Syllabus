DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saber_leertodo $$
CREATE PROCEDURE sp_saber_leertodo()
BEGIN
	SELECT id, codigo, descripcion, nivelLogro, estado, porcentajeLogro
	FROM saber;
END
$$
