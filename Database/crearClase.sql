DROP PROCEDURE IF EXISTS `crearClase`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `crearClase`(fecha date,tema VARCHAR(250),descripcion VARCHAR(250),tipoClase VARCHAR(250))
BEGIN
	#Routine body goes here...
	INSERT INTO clase
			(
				fecha,tema,descripcion,tipoClase
			)
			VALUES
			(
				fecha,tema,descripcion,tipoClase
			);

		SELECT LAST_INSERT_ID() AS last_id;

END
;;
DELIMITER ;