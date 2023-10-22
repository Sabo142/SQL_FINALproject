-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: test
-- ------------------------------------------------------
-- Server version	8.1.0

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
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `questionID` int NOT NULL AUTO_INCREMENT,
  `Text` varchar(128) DEFAULT NULL,
  `Ans1` varchar(128) DEFAULT NULL,
  `Ans2` varchar(128) DEFAULT NULL,
  `Ans3` varchar(128) DEFAULT NULL,
  `Ans4` varchar(128) DEFAULT NULL,
  `CurrectID` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`questionID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'In which country are there no mosquitoes?','Ireland','Iceland','Afganistan','Japan','2'),(2,'To which category does the tomato belong?','Vegtable','Electronics','Fruit','Organs','3'),(3,'What is the name of the galaxy in which our solar system is located?','Andromeda','Milky way','Maglan','Spirolina','2'),(4,'What alcohol is in a White Russian cocktail?','Vodka','Whisky','Rum','Tekilla','1'),(5,'Where was the Lego game invented?','Belgium','Sweden','Finland','Denemark','4'),(6,'What are glasses for one eye called?','Monogram','Unimatrist','Monicle','monocof','3'),(7,'What action is prohibited for the number 0?','Addition','Subtraction','Division','Multiplication','3'),(8,'Who painted the famous painting \"The Scream\"','Michelangelo','Da Vinci','Pablo Picasso','Edward Monack','4'),(9,'Which country has the fewest people?','Japan','South Korea','China','Mexico','2'),(10,'which day is two days before tomorrow','Today','the day before yesterday','Tommorow','Yesterday','4');
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-22  2:56:26
