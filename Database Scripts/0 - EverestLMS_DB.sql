-- MySQL Script generated by MySQL Workbench
-- Fri Dec  7 20:32:54 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema EverestLMS
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `EverestLMS` ;

-- -----------------------------------------------------
-- Schema EverestLMS
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `EverestLMS` DEFAULT CHARACTER SET utf8 ;
USE `EverestLMS` ;

-- -----------------------------------------------------
-- Table `EverestLMS`.`Nivel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `EverestLMS`.`Nivel` ;

CREATE TABLE IF NOT EXISTS `EverestLMS`.`Nivel` (
  `IdNivel` INT NOT NULL AUTO_INCREMENT,
  `Descripcion` VARCHAR(50) NULL,
  PRIMARY KEY (`IdNivel`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `EverestLMS`.`LineaCarrera`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `EverestLMS`.`LineaCarrera` ;

CREATE TABLE IF NOT EXISTS `EverestLMS`.`LineaCarrera` (
  `IdLineaCarrera` INT NOT NULL AUTO_INCREMENT,
  `Descripcion` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`IdLineaCarrera`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `EverestLMS`.`Participante`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `EverestLMS`.`Participante` ;

CREATE TABLE IF NOT EXISTS `EverestLMS`.`Participante` (
  `IdParticipante` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(100) NOT NULL,
  `Apellido` VARCHAR(100) NOT NULL,
  `Correo` VARCHAR(100) NOT NULL,
  `Genero` VARCHAR(45) NOT NULL,
  `FechaNacimiento` DATETIME NOT NULL,
  `AñosExperiencia` INT NULL,
  `Calificacion` DECIMAL(4,2) NULL,
  `Puntaje` INT NULL,
  `Rol` INT NULL,
  `Photo` VARCHAR(500) NULL,
  `Sede` VARCHAR(100) NOT NULL,
  `Activo` INT NOT NULL,
  `idSherpa` INT NULL,
  `idLineaCarrera` INT NOT NULL,
  `idNivel` INT NOT NULL,
  PRIMARY KEY (`IdParticipante`),
  INDEX `FK_Sherpa_idx` (`idSherpa` ASC),
  INDEX `IDX_idParticipante` (`IdParticipante` ASC),
  INDEX `IDX_idRol` (`Rol` ASC),
  INDEX `FK_Nivel_idx` (`idNivel` ASC),
  INDEX `FK_LineaCarrera_idx` (`idLineaCarrera` ASC),
  CONSTRAINT `FK_Sherpa`
    FOREIGN KEY (`idSherpa`)
    REFERENCES `EverestLMS`.`Participante` (`IdParticipante`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Nivel`
    FOREIGN KEY (`idNivel`)
    REFERENCES `EverestLMS`.`Nivel` (`IdNivel`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_LineaCarrera`
    FOREIGN KEY (`idLineaCarrera`)
    REFERENCES `EverestLMS`.`LineaCarrera` (`IdLineaCarrera`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `EverestLMS`.`Conocimiento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `EverestLMS`.`Conocimiento` ;

CREATE TABLE IF NOT EXISTS `EverestLMS`.`Conocimiento` (
  `IdConocimiento` INT NOT NULL AUTO_INCREMENT,
  `Descripcion` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`IdConocimiento`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `EverestLMS`.`ConocimientoParticipante`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `EverestLMS`.`ConocimientoParticipante` ;

CREATE TABLE IF NOT EXISTS `EverestLMS`.`ConocimientoParticipante` (
  `IdConocimientoParticipante` INT NOT NULL AUTO_INCREMENT,
  `IdConocimiento` INT NOT NULL,
  `IdParticipante` INT NOT NULL,
  PRIMARY KEY (`IdConocimientoParticipante`),
  INDEX `FX_Conocimiento_idx` (`IdConocimiento` ASC),
  INDEX `FX_Participante_idx` (`IdParticipante` ASC),
  CONSTRAINT `FX_Conocimiento`
    FOREIGN KEY (`IdConocimiento`)
    REFERENCES `EverestLMS`.`Conocimiento` (`IdConocimiento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FX_Participante`
    FOREIGN KEY (`IdParticipante`)
    REFERENCES `EverestLMS`.`Participante` (`IdParticipante`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
