-- Adminer 4.8.1 MySQL 8.2.0 dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

SET NAMES utf8mb4;

DROP TABLE IF EXISTS `Categories`;
CREATE TABLE `Categories` (
  `CategoryId` int NOT NULL AUTO_INCREMENT,
  `CategoryName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`CategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `Categories` (`CategoryId`, `CategoryName`) VALUES
(1,	'Technology'),
(2,	'School'),
(3,	'Play'),
(4,	'Data');

DROP TABLE IF EXISTS `Links`;
CREATE TABLE `Links` (
  `LinkId` int NOT NULL AUTO_INCREMENT,
  `FaviconSrc` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LinkLabel` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LinkName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LinkHref` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsPinned` tinyint(1) NOT NULL DEFAULT '0',
  `LinkCategoryCategoryId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`LinkId`),
  KEY `IX_Links_LinkCategoryCategoryId` (`LinkCategoryCategoryId`),
  CONSTRAINT `FK_Links_Categories_LinkCategoryCategoryId` FOREIGN KEY (`LinkCategoryCategoryId`) REFERENCES `Categories` (`CategoryId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `Links` (`LinkId`, `FaviconSrc`, `LinkLabel`, `LinkName`, `LinkHref`, `IsPinned`, `LinkCategoryCategoryId`) VALUES
(1,	'https://google.com/favicon.ico',	'Finders',	'Google',	'https://google.com',	0,	4),
(2,	'https://chat.openai.com/favicon.ico',	'AI Chatbots',	'ChatGPT',	'https://chat.openai.com',	0,	4),
(3,	'https://www.bing.com/favicon.ico',	'Shitty Finders',	'Bing',	'https://www.bing.com',	0,	4),
(4,	'https://brave.com/static-assets/images/brave-favicon.png',	'Awesome Finders',	'Brave',	'https://brave.com',	0,	4),
(5,	'https://ca.yahoo.com/favicon.ico',	'Finders',	'Yahoo',	'https://ca.yahoo.com/',	0,	4);

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

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20231202191740_InitialCreate',	'6.0.0'),
('20231202223745_InitialCreate1',	'6.0.0'),
('20231202223842_Mig1',	'6.0.0'),
('20231202225744_Mig2',	'6.0.0'),
('20231203014905_Mig3',	'6.0.0'),
('20231203015019_Mig4',	'6.0.0'),
('20231203015604_Mig5',	'6.0.0'),
('20231203015751_Mig6',	'6.0.0'),
('20231203015912_Mig7',	'6.0.0'),
('20231203020201_Mig8',	'6.0.0');

-- 2023-12-03 02:44:19