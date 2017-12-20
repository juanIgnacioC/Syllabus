DELIMITER $$
DROP PROCEDURE IF EXISTS sp_saber_leerHabilitados $$
CREATE PROCEDURE sp_saber_leerHabilitados()
BEGIN
	SELECT id, codigo, descripcion, nivelLogro, estado, porcentajeLogro
	FROM saber
	WHERE estado = 'Habilitado';
END
$$
