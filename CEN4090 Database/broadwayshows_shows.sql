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
-- Table structure for table `shows`
--

DROP TABLE IF EXISTS `shows`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shows` (
  `ShowId` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ReleaseDate` date NOT NULL,
  `Image` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `GenreId` int NOT NULL,
  `TheaterId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`ShowId`),
  KEY `IX_Shows_GenreId` (`GenreId`),
  KEY `IX_Shows_TheaterId` (`TheaterId`),
  CONSTRAINT `FK_Shows_Genres_GenreId` FOREIGN KEY (`GenreId`) REFERENCES `genres` (`GenreId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shows`
--

LOCK TABLES `shows` WRITE;
/*!40000 ALTER TABLE `shows` DISABLE KEYS */;
INSERT INTO `shows` VALUES (2,'Matilda the Musical','2013-04-11','Matilda_the_Musical.jpg',4,0),(3,'Aladdin','2014-04-20','Aladdin.jpg',6,0),(4,'The Phantom of the Opera','1988-01-26','Phantom_of_the_Opera.jpg',3,0),(5,'Chicago','1996-11-14','Chicago.jpg',4,0),(6,'The Lion King','1997-11-13','The_Lion_King.jpg',5,0),(7,'Wicked','2003-10-30','Wicked.jpg',6,0),(8,'Les Misérables','1987-03-12','Les_Misérables.jpg',3,0),(9,'Mamma Mia!','2001-10-18','Mamma_Mia!.jpg',4,0),(10,'Rent','1996-04-29','Rent.jpg',7,0),(11,'Hamilton','2015-08-06','Hamilton.jpg',8,0),(13,'Miss Saigon','1991-04-11','Miss_Saigon.jpg',3,0),(14,'The Book of Mormon','2011-03-24','The_Book_of_Mormon.jpg',4,0),(15,'Jersey Boys','2005-11-06','Jersey_Boys.jpg',10,0),(16,'Dear Evan Hansen','2016-12-04','Dear_Evan_Hansen.jpg',3,0),(17,'Waitress','2016-04-24','Waitress.jpg',3,0),(19,'Hairspray','2002-08-15','Hairspray.jpg',4,0),(20,'Avenue Q','2003-07-31','Avenue_Q.jpg',4,0);
/*!40000 ALTER TABLE `shows` ENABLE KEYS */;
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
