-- Adminer 4.8.1 MySQL 8.2.0 dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

SET NAMES utf8mb4;


DROP TABLE IF EXISTS `Users`;
CREATE TABLE `Users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PasswordSalt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PasswordConfirmation` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `Users` (`UserId`, `Username`, `PasswordHash`, `PasswordSalt`, `Password`, `PasswordConfirmation`) VALUES
(1,	'user1',	'fJHP/11IQtB2Thr+EcRMHc/nVlNCVzkASHiV/cmci/E=',	'66294dc0-dc0d-4231-87ca-8c81dd142d10',	'',	'');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20231202191740_InitialCreate',	'6.0.0'),
('20231202223745_InitialCreate1',	'6.0.0'),
('20231202223842_Mig1',	'6.0.0');

-- 2023-12-02 22:40:15

-- Adminer 4.8.1 MySQL 8.2.0 dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

SET NAMES utf8mb4;

DROP TABLE IF EXISTS `Links`;
CREATE TABLE `Links` (
  `LinkId` int NOT NULL AUTO_INCREMENT,
  `FaviconSrc` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LinkLabel` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LinkName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LinkCategory` int DEFAULT NULL,
  `LinkHref` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LinkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `Links` (`LinkId`, `FaviconSrc`, `LinkLabel`, `LinkName`, `LinkCategory`, `LinkHref`) VALUES
(1,	'https://google.com/favicon.ico',	'Finders',	'Google',	3,	'https://google.com');

-- 2023-12-02 22:54:35