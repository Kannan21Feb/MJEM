-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema csat
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema csat
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `csat` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `csat` ;

-- -----------------------------------------------------
-- Table `csat`.`complaint`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`complaint` (
  `ComplaintID` INT(11) NOT NULL AUTO_INCREMENT,
  `UserAreaID` INT(11) NOT NULL,
  `ComplaintCategoryID` INT(11) NOT NULL,
  `Comments` VARCHAR(500) NULL DEFAULT NULL,
  `Attachment` BLOB NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`ComplaintID`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `csat`.`complaintcategory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`complaintcategory` (
  `ComplaintCategoryID` INT(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` VARCHAR(50) NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME(3) NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME(3) NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`ComplaintCategoryID`))
ENGINE = InnoDB
AUTO_INCREMENT = 18
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `csat`.`csatuser`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`csatuser` (
  `CsatUserID` INT(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` INT(11) NOT NULL,
  `FirstName` VARCHAR(50) NULL DEFAULT NULL,
  `LastName` VARCHAR(50) NULL DEFAULT NULL,
  `RoleID` INT(11) NOT NULL,
  `LoginName` VARCHAR(50) NULL DEFAULT NULL,
  `Password` VARCHAR(100) NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`CsatUserID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `csat`.`cssrate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`cssrate` (
  `CssRateID` INT(11) NOT NULL AUTO_INCREMENT,
  `RateName` VARCHAR(50) NOT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME(3) NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME(3) NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`CssRateID`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `csat`.`customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`customer` (
  `CustomerID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME(3) NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME(3) NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`CustomerID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `csat`.`facility`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`facility` (
  `FacilityID` INT(11) NOT NULL AUTO_INCREMENT,
  `Code` VARCHAR(10) NOT NULL,
  `Name` VARCHAR(50) NOT NULL,
  `CustomerID` INT(11) NOT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME(3) NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME(3) NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`FacilityID`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `csat`.`role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`role` (
  `RoleID` INT(11) NOT NULL AUTO_INCREMENT,
  `Code` VARCHAR(10) NOT NULL,
  `Name` VARCHAR(50) NOT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME(3) NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME(3) NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`RoleID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `csat`.`userarea`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`userarea` (
  `UserAreaID` INT(11) NOT NULL,
  `Code` VARCHAR(10) NULL DEFAULT NULL,
  `Name` VARCHAR(50) NOT NULL,
  `FacilityID` INT(11) NOT NULL,
  `QRCodeText` VARCHAR(100) NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME(3) NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME(3) NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`UserAreaID`),
  CONSTRAINT `FK_UserArea_Facility`
    FOREIGN KEY (`FacilityID`)
    REFERENCES `csat`.`facility` (`FacilityID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

CREATE INDEX `FK_UserArea_Facility` ON `csat`.`userarea` (`FacilityID` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `csat`.`survey`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `csat`.`survey` (
  `SurveyID` INT(11) NOT NULL AUTO_INCREMENT,
  `UserAreaID` INT(11) NOT NULL,
  `CssRateID` INT(11) NOT NULL,
  `Comments` VARCHAR(500) NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedAt` DATETIME(3) NULL DEFAULT NULL,
  `ModifiedBy` INT(11) NULL DEFAULT NULL,
  `ModifiedAt` DATETIME(3) NULL DEFAULT NULL,
  `RecordStatus` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`SurveyID`),
  CONSTRAINT `FK_Survey_CssRate`
    FOREIGN KEY (`CssRateID`)
    REFERENCES `csat`.`cssrate` (`CssRateID`),
  CONSTRAINT `FK_Survey_UserArea`
    FOREIGN KEY (`UserAreaID`)
    REFERENCES `csat`.`userarea` (`UserAreaID`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

CREATE INDEX `FK_Survey_CssRate` ON `csat`.`survey` (`CssRateID` ASC) VISIBLE;

CREATE INDEX `FK_Survey_UserArea` ON `csat`.`survey` (`UserAreaID` ASC) VISIBLE;

USE `csat` ;

-- -----------------------------------------------------
-- procedure usp_InsertCSS
-- -----------------------------------------------------

DELIMITER $$
USE `csat`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_InsertCSS`(
In _UserAreaID int,
In _CssRateID int,
In _Comments nvarchar (500) 
)
BEGIN
INSERT INTO Survey                      
          (UserAreaID                      
          ,CssRateID                      
          ,Comments                      
          ,CreatedBy                      
          ,CreatedAt       
          ,ModifiedBy                      
          ,ModifiedAt      
          ,RecordStatus)                      
		  VALUES                       
	      (                      
		  _UserAreaID,                       
		  _CssRateID,                       
		  _Comments,                      
		  1,                       
		  CURDATE(),     
		  1,
		  CURDATE(),     
	       'A'                      
		  );   
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure usp_InsertComplaint
-- -----------------------------------------------------

DELIMITER $$
USE `csat`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_InsertComplaint`(
In _UserAreaID int,
In _ComplaintCategoryID int,
In _Comments nvarchar (500) ,
In _Attachment longblob
)
BEGIN
insert into  Complaint (UserAreaID                     
          ,ComplaintCategoryID                     
          ,Comments 
		  ,Attachment              
          ,CreatedBy                       
          ,CreatedAt        
          ,ModifiedBy                       
          ,ModifiedAt       
          ,RecordStatus)                      
		  VALUES                       
	      (                      
		  _UserAreaID,                       
		  _ComplaintCategoryID,                       
		  _Comments,
		  _Attachment,                      
		  1,                       
		  curdate(),     
		  1,
		  curdate(),     
	       'A'                      
		  );
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure usp_LoadCSS
-- -----------------------------------------------------

DELIMITER $$
USE `csat`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_LoadCSS`( In _Id int)
BEGIN

SELECT UserAreaID,Code,Name,FacilityID 
  FROM UserArea 
WHere RecordStatus = 'A';

SELECT FacilityID,Code,Name 
  FROM Facility 
WHERE RecordStatus = 'A';
IF _Id=1 THEN
SELECT ComplaintCategoryID,CategoryName 
  FROM ComplaintCategory 
WHERE  RecordStatus = 'A';
End IF;
END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
