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
-- Table structure for table `theaters`
--

DROP TABLE IF EXISTS `theaters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `theaters` (
  `TheaterId` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NumberOfSeats` int NOT NULL,
  PRIMARY KEY (`TheaterId`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `theaters`
--

LOCK TABLES `theaters` WRITE;
/*!40000 ALTER TABLE `theaters` DISABLE KEYS */;
INSERT INTO `theaters` VALUES (1,'August Wilson Theatre','245 W 52nd St, New York, NY 10019',1219),(2,'Belasco Theatre','111 W 44th St, New York, NY 10036',1018),(3,'Bernard B. Jacobs Theatre','242 W 45th St, New York, NY 10036',1108),(4,'Booth Theatre','222 W 45th St, New York, NY 10036',784),(5,'Broadhurst Theatre','235 W 44th St, New York, NY 10036',1202),(6,'Broadway Theatre','1681 Broadway, New York, NY 10019',1762),(7,'Circle in the Square Theatre','235 W 50th St, New York, NY 10019',776),(8,'Cort Theatre','138 W 48th St, New York, NY 10036',1096),(9,'Ethel Barrymore Theatre','243 W 47th St, New York, NY 10036',1080),(10,'Eugene O\'Neill Theatre','230 W 49th St, New York, NY 10019',1108),(11,'Gershwin Theatre','222 W 51st St, New York, NY 10019',1933),(12,'Hudson Theatre','141 W 44th St, New York, NY 10036',984),(13,'Imperial Theatre','249 W 45th St, New York, NY 10036',1435),(14,'John Golden Theatre','252 W 45th St, New York, NY 10036',805),(15,'Longacre Theatre','220 W 48th St, New York, NY 10036',1098),(16,'Lunt-Fontanne Theatre','205 W 46th St, New York, NY 10036',1509),(17,'Lyceum Theatre','149 W 45th St, New York, NY 10036',922),(18,'Lyric Theatre','214 W 43rd St, New York, NY 10036',1992),(19,'Majestic Theatre','245 W 44th St, New York, NY 10036',1637),(20,'Marquis Theatre','1535 Broadway, New York, NY 10036',1617),(21,'Minskoff Theatre','200 W 45th St, New York, NY 10036',1710),(22,'Music Box Theatre','239 W 45th St, New York, NY 10036',1009),(23,'Nederlander Theatre','208 W 41st St, New York, NY 10036',1197),(24,'Neil Simon Theatre','250 W 52nd St, New York, NY 10019',1444),(25,'New Amsterdam Theatre','214 W 42nd St, New York, NY 10036',1747),(26,'Palace Theatre','1564 Broadway, New York, NY 10036',1746),(27,'Richard Rodgers Theatre','226 W 46th St, New York, NY 10036',1410),(28,'St. James Theatre','246 W 44th St, New York, NY 10036',1688),(29,'Stephen Sondheim Theatre','124 W 43rd St, New York, NY 10036',1055),(30,'Studio 54','254 W 54th St, New York, NY 10019',1008),(31,'Theatre 80','80 St. Marks Pl, New York, NY 10003',163),(32,'Vivian Beaumont Theater','150 W 65th St, New York, NY 10023',1103),(33,'Walter Kerr Theatre','219 W 48th St, New York, NY 10036',975),(34,'Winter Garden Theatre','1634 Broadway, New York, NY 10019',1526),(35,'New World Stages','340 W 50th St, New York, NY 10019',499),(36,'Helen Hayes Theatre','240 W 44th St, New York, NY 10036',597),(37,'Lunt-Fontanne Theatre','205 W 46th St, New York, NY 10036',1509),(38,'Broadway Comedy Club','318 W 53rd St, New York, NY 10019',150),(39,'Hudson Guild Theatre','441 W 26th St, New York, NY 10001',99),(40,'Flea Theater','20 Thomas St, New York, NY 10007',74),(41,'The Tank','312 W 36th St, New York, NY 10018',75),(42,'Oteo','dsaf',123);
/*!40000 ALTER TABLE `theaters` ENABLE KEYS */;
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
