-- --------------------------------------------------------
-- Host:                         dbcontroltareas.ct2rrxcaxo9w.us-east-1.rds.amazonaws.com
-- Server version:               8.0.28 - Source distribution
-- Server OS:                    Linux
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for ProcessSA2
CREATE DATABASE IF NOT EXISTS `ProcessSA2` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ProcessSA2`;

-- Dumping structure for table ProcessSA2.comentario_st
CREATE TABLE IF NOT EXISTS `comentario_st` (
  `id` int NOT NULL AUTO_INCREMENT,
  `comentario` varchar(1000) NOT NULL,
  `fecha` date NOT NULL,
  `subtarea_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `comentario_st_subtarea_fk` (`subtarea_id`),
  CONSTRAINT `comentario_st_subtarea_fk` FOREIGN KEY (`subtarea_id`) REFERENCES `subtarea` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.comentario_st: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.comentario_t
CREATE TABLE IF NOT EXISTS `comentario_t` (
  `id` int NOT NULL AUTO_INCREMENT,
  `comentario` varchar(1000) NOT NULL,
  `fecha` date NOT NULL,
  `tarea_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `comentario_t_tarea_fk` (`tarea_id`),
  CONSTRAINT `comentario_t_tarea_fk` FOREIGN KEY (`tarea_id`) REFERENCES `tarea` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.comentario_t: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.detalletarea
CREATE TABLE IF NOT EXISTS `detalletarea` (
  `id` int NOT NULL AUTO_INCREMENT,
  `acepta` tinyint(1) NOT NULL,
  `rechaza` tinyint(1) NOT NULL,
  `usuario_id` int NOT NULL,
  `tarea_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `detalletarea_tarea_fk` (`tarea_id`),
  KEY `detalletarea_usuario_fk` (`usuario_id`),
  CONSTRAINT `detalletarea_tarea_fk` FOREIGN KEY (`tarea_id`) REFERENCES `tarea` (`id`),
  CONSTRAINT `detalletarea_usuario_fk` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.detalletarea: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.estadotarea
CREATE TABLE IF NOT EXISTS `estadotarea` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombreestado` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.estadotarea: ~4 rows (approximately)
INSERT INTO `estadotarea` (`id`, `nombreestado`) VALUES
	(1, 'En Progeso'),
	(2, 'Completado'),
	(3, 'Detenido'),
	(4, 'Atrasado');

-- Dumping structure for table ProcessSA2.etiqueta
CREATE TABLE IF NOT EXISTS `etiqueta` (
  `id` int NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `color` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.etiqueta: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.flujoproceso
CREATE TABLE IF NOT EXISTS `flujoproceso` (
  `id` int NOT NULL AUTO_INCREMENT,
  `orden` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `deleted` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.flujoproceso: ~4 rows (approximately)
INSERT INTO `flujoproceso` (`id`, `orden`, `nombre`, `deleted`) VALUES
	(1, 0, 'Ninguno', 0),
	(2, 1, 'Por Hacer', 0),
	(3, 2, 'En Proceso', 0),
	(4, 3, 'Finalizado', 0);

-- Dumping structure for table ProcessSA2.grupotrabajo
CREATE TABLE IF NOT EXISTS `grupotrabajo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  `negocio_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `grupotrabajo_negocio_fk` (`negocio_id`),
  CONSTRAINT `grupotrabajo_negocio_fk` FOREIGN KEY (`negocio_id`) REFERENCES `negocio` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.grupotrabajo: ~1 rows (approximately)
INSERT INTO `grupotrabajo` (`id`, `nombre`, `deleted`, `negocio_id`) VALUES
	(1, 'Ninguno', 0, 1);

-- Dumping structure for table ProcessSA2.hst_estado
CREATE TABLE IF NOT EXISTS `hst_estado` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `tarea_id` int NOT NULL,
  `subtarea_id` int NOT NULL,
  `estadotarea_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `hst_estado_estadotarea_fk` (`estadotarea_id`),
  KEY `hst_estado_subtarea_fk` (`subtarea_id`),
  KEY `hst_estado_tarea_fk` (`tarea_id`),
  CONSTRAINT `hst_estado_estadotarea_fk` FOREIGN KEY (`estadotarea_id`) REFERENCES `estadotarea` (`id`),
  CONSTRAINT `hst_estado_subtarea_fk` FOREIGN KEY (`subtarea_id`) REFERENCES `subtarea` (`id`),
  CONSTRAINT `hst_estado_tarea_fk` FOREIGN KEY (`tarea_id`) REFERENCES `tarea` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.hst_estado: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.negocio
CREATE TABLE IF NOT EXISTS `negocio` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `encargado` varchar(60) NOT NULL,
  `correo_encargado` varchar(50) NOT NULL,
  `fecha_ingreso` date NOT NULL,
  `rut` varchar(20) NOT NULL,
  `direccion` varchar(150) NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.negocio: ~1 rows (approximately)
INSERT INTO `negocio` (`id`, `nombre`, `encargado`, `correo_encargado`, `fecha_ingreso`, `rut`, `direccion`, `deleted`) VALUES
	(1, 'Ninguno', 'Ninguno', 'Ninguno', '2022-10-04', '0', 'Ninguno', 0);

-- Dumping structure for table ProcessSA2.prioridad
CREATE TABLE IF NOT EXISTS `prioridad` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.prioridad: ~5 rows (approximately)
INSERT INTO `prioridad` (`id`, `nombre`) VALUES
	(1, 'Ninguna'),
	(2, 'Baja'),
	(3, 'Media'),
	(4, 'Alta'),
	(5, 'Urgente');

-- Dumping structure for table ProcessSA2.problema_st
CREATE TABLE IF NOT EXISTS `problema_st` (
  `id_problemast` int NOT NULL AUTO_INCREMENT,
  `comentario` varchar(500) NOT NULL,
  `subtarea_id` int NOT NULL,
  PRIMARY KEY (`id_problemast`),
  KEY `problema_st_subtarea_fk` (`subtarea_id`),
  CONSTRAINT `problema_st_subtarea_fk` FOREIGN KEY (`subtarea_id`) REFERENCES `subtarea` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.problema_st: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.problema_t
CREATE TABLE IF NOT EXISTS `problema_t` (
  `id_problemat` int NOT NULL AUTO_INCREMENT,
  `comentario` varchar(500) NOT NULL,
  `tarea_id` int NOT NULL,
  PRIMARY KEY (`id_problemat`),
  KEY `problema_t_tarea_fk` (`tarea_id`),
  CONSTRAINT `problema_t_tarea_fk` FOREIGN KEY (`tarea_id`) REFERENCES `tarea` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.problema_t: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.rol: ~4 rows (approximately)
INSERT INTO `rol` (`id`, `nombre`, `deleted`) VALUES
	(1, 'Sin Rol', 0),
	(2, 'AdminDB', 0),
	(3, 'Funcinoario Administrador', 0),
	(4, 'Funcionario', 0);

-- Dumping structure for table ProcessSA2.subtarea
CREATE TABLE IF NOT EXISTS `subtarea` (
  `id` int NOT NULL AUTO_INCREMENT,
  `finalizada` tinyint(1) NOT NULL,
  `responsable` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(500) NOT NULL,
  `tarea_id` int NOT NULL,
  `prioridad_id` int NOT NULL,
  `estadotarea_id` int NOT NULL,
  `etiqueta_id` int NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `subtarea_estadotarea_fk` (`estadotarea_id`),
  KEY `subtarea_prioridad_fk` (`prioridad_id`),
  KEY `subtarea_tarea_fk` (`tarea_id`),
  KEY `subtarea_etiqueta_fk` (`etiqueta_id`),
  CONSTRAINT `subtarea_estadotarea_fk` FOREIGN KEY (`estadotarea_id`) REFERENCES `estadotarea` (`id`),
  CONSTRAINT `subtarea_etiqueta_fk` FOREIGN KEY (`etiqueta_id`) REFERENCES `etiqueta` (`id`),
  CONSTRAINT `subtarea_prioridad_fk` FOREIGN KEY (`prioridad_id`) REFERENCES `prioridad` (`id`),
  CONSTRAINT `subtarea_tarea_fk` FOREIGN KEY (`tarea_id`) REFERENCES `tarea` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.subtarea: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.tarea
CREATE TABLE IF NOT EXISTS `tarea` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(500) NOT NULL,
  `responsable` int NOT NULL,
  `fechainicio` date NOT NULL,
  `fechafin` date NOT NULL,
  `flujoproceso_id` int NOT NULL,
  `grupotrabajo_id` int NOT NULL,
  `estadotarea_id` int NOT NULL,
  `prioridad_id` int NOT NULL,
  `etiqueta_id` int DEFAULT NULL,
  `finalizada` tinyint(1) NOT NULL,
  `esflujo` tinyint(1) NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `tarea_estadotarea_fk` (`estadotarea_id`),
  KEY `tarea_flujoproceso_fk` (`flujoproceso_id`),
  KEY `tarea_grupotrabajo_fk` (`grupotrabajo_id`),
  KEY `tarea_prioridad_fk` (`prioridad_id`),
  KEY `tarea_etiqueta_fk` (`etiqueta_id`) USING BTREE,
  CONSTRAINT `tarea_estadotarea_fk` FOREIGN KEY (`estadotarea_id`) REFERENCES `estadotarea` (`id`),
  CONSTRAINT `tarea_etiqueta_fk` FOREIGN KEY (`etiqueta_id`) REFERENCES `etiqueta` (`id`),
  CONSTRAINT `tarea_flujoproceso_fk` FOREIGN KEY (`flujoproceso_id`) REFERENCES `flujoproceso` (`id`),
  CONSTRAINT `tarea_grupotrabajo_fk` FOREIGN KEY (`grupotrabajo_id`) REFERENCES `grupotrabajo` (`id`),
  CONSTRAINT `tarea_prioridad_fk` FOREIGN KEY (`prioridad_id`) REFERENCES `prioridad` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.tarea: ~0 rows (approximately)

-- Dumping structure for table ProcessSA2.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int NOT NULL AUTO_INCREMENT,
  `correo` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `rut` varchar(30) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellidop` varchar(50) NOT NULL,
  `apellidom` varchar(50) NOT NULL,
  `celular` int DEFAULT NULL,
  `deleted` tinyint(1) NOT NULL,
  `rol_id` int NOT NULL,
  `negocio_id` int NOT NULL,
  `grupotrabajo_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `usuario_grupotrabajo_fk` (`grupotrabajo_id`),
  KEY `usuario_negocio_fk` (`negocio_id`),
  KEY `usuario_rol_fk` (`rol_id`),
  CONSTRAINT `usuario_grupotrabajo_fk` FOREIGN KEY (`grupotrabajo_id`) REFERENCES `grupotrabajo` (`id`),
  CONSTRAINT `usuario_negocio_fk` FOREIGN KEY (`negocio_id`) REFERENCES `negocio` (`id`),
  CONSTRAINT `usuario_rol_fk` FOREIGN KEY (`rol_id`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ProcessSA2.usuario: ~0 rows (approximately)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
