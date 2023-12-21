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
-- Table structure for table `ticketsales`
--

DROP TABLE IF EXISTS `ticketsales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticketsales` (
  `TicketNumber` int NOT NULL AUTO_INCREMENT,
  `Time` time NOT NULL,
  `Date` date NOT NULL,
  `NumberOfTickets` int NOT NULL,
  `Price` decimal(65,2) NOT NULL,
  `TheaterId` int NOT NULL,
  `ShowId` int NOT NULL DEFAULT '0',
  `ShowsShowId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`TicketNumber`),
  KEY `IX_TicketSales_TheaterId` (`TheaterId`),
  KEY `IX_TicketSales_ShowsShowId` (`ShowsShowId`),
  CONSTRAINT `FK_TicketSales_Theaters_TheaterId` FOREIGN KEY (`TheaterId`) REFERENCES `theaters` (`TheaterId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticketsales`
--

LOCK TABLES `ticketsales` WRITE;
/*!40000 ALTER TABLE `ticketsales` DISABLE KEYS */;
INSERT INTO `ticketsales` VALUES (1,'12:00:00','2023-11-08',100,99.00,12,0,0),(2,'00:30:00','2023-11-08',90,90.00,11,0,0),(3,'00:00:00','2023-11-08',700,20.00,16,0,0),(4,'19:30:00','2023-11-08',200,50.00,25,0,0),(5,'18:30:00','2023-11-09',200,50.00,5,0,0),(6,'19:30:00','2023-11-09',200,50.00,5,0,0),(7,'18:00:00','2023-12-04',676,200.00,1,0,0);
/*!40000 ALTER TABLE `ticketsales` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-30 18:36:07
