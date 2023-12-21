CREATE DATABASE  IF NOT EXISTS `broadwayshows` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `broadwayshows`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: broadwayshows
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `castcrews`
--

DROP TABLE IF EXISTS `castcrews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `castcrews` (
  `SSN` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `WorkingPositionID` int NOT NULL,
  `Gender` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ShowId` int NOT NULL,
  `TheaterId` int NOT NULL,
  PRIMARY KEY (`SSN`),
  KEY `IX_CastCrews_ShowId` (`ShowId`),
  KEY `IX_CastCrews_TheaterId` (`TheaterId`),
  KEY `IX_CastCrews_WorkingPositionID` (`WorkingPositionID`),
  CONSTRAINT `FK_CastCrews_Shows_ShowId` FOREIGN KEY (`ShowId`) REFERENCES `shows` (`ShowId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_CastCrews_Theaters_TheaterId` FOREIGN KEY (`TheaterId`) REFERENCES `theaters` (`TheaterId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_CastCrews_WorkingPositions_WorkingPositionID` FOREIGN KEY (`WorkingPositionID`) REFERENCES `workingpositions` (`WorkingPositionID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=998868333 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `castcrews`
--

LOCK TABLES `castcrews` WRITE;
/*!40000 ALTER TABLE `castcrews` DISABLE KEYS */;
INSERT INTO `castcrews` VALUES (106240583,'Frank',1,'M',5,4),(112703629,'Jack',7,'M',10,29),(113715369,'Frank',4,'M',3,2),(115783095,'Alice',7,'M',15,34),(116237256,'Alice',1,'M',13,12),(119404175,'Grace',3,'M',9,8),(122770934,'Grace',7,'M',13,12),(126652625,'Bob',4,'F',2,21),(126929743,'Frank',6,'M',19,18),(132935112,'Jack',5,'M',5,24),(134925409,'Alice',4,'M',6,5),(136466032,'Grace',4,'M',3,2),(137899517,'Bob',1,'F',5,24),(137906766,'Henry',1,'M',2,1),(145637406,'Ella',6,'F',7,6),(146133502,'Frank',7,'M',11,30),(146455852,'David',4,'M',3,22),(149050233,'David',6,'M',10,29),(151382349,'Bob',2,'F',6,25),(151522325,'Grace',4,'M',7,26),(151560473,'Grace',2,'M',20,39),(153086836,'Frank',5,'M',17,16),(153108177,'David',3,'M',20,19),(154300274,'Isabel',5,'M',9,28),(156703888,'Henry',2,'M',2,21),(157238730,'Henry',4,'M',17,16),(158272211,'David',4,'M',4,3),(163822197,'Alice',3,'M',20,19),(165014097,'Ella',3,'F',10,9),(167416783,'David',3,'M',16,15),(167489498,'Isabel',1,'M',3,22),(170274411,'Ella',1,'F',15,34),(172067934,'Bob',1,'F',7,26),(174612121,'Alice',1,'M',5,24),(175358737,'Isabel',4,'M',11,10),(175773453,'Grace',2,'M',14,33),(175821738,'Bob',4,'F',6,5),(176847570,'Frank',7,'M',9,28),(184913234,'Ella',5,'F',19,18),(185090314,'Jack',5,'M',8,27),(185228092,'Frank',2,'M',10,29),(190670000,'Charlie',3,'M',15,14),(191928146,'Henry',6,'M',6,5),(193282884,'Frank',7,'M',20,39),(194372181,'Henry',2,'M',4,23),(195708582,'Alice',2,'M',11,10),(204784315,'Frank',3,'M',20,19),(206081043,'Grace',5,'M',16,15),(211754044,'Ella',2,'F',3,22),(213116097,'Jack',2,'M',17,36),(214072157,'Frank',4,'M',10,9),(215034533,'Charlie',6,'M',11,10),(216870891,'Ella',5,'F',6,25),(218917363,'Henry',1,'M',17,36),(226856487,'David',3,'M',2,1),(239253427,'Grace',4,'M',8,7),(239253842,'Grace',5,'M',6,25),(241184080,'Henry',5,'M',3,2),(860796670,'Oteo',1,'M',4,14),(998868332,'Oteo',1,'M',4,10);
/*!40000 ALTER TABLE `castcrews` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-30 18:36:06
