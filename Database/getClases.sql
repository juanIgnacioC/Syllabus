DROP PROCEDURE IF EXISTS `getClases`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getClases`()
BEGIN
	#Routine body goes here...
	select id,fecha,tema,descripcion,tipoClase
	from clase;

END
;;
DELIMITER ;