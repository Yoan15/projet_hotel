DROP DATABASE IF EXISTS ProjetHotel;
CREATE DATABASE ProjetHotel;
ALTER DATABASE ProjetHotel DEFAULT charset = UTF8;
USE ProjetHotel;

--
-- Table Clients
--
DROP TABLE IF EXISTS Clients;
CREATE TABLE Clients(
   IdClient INT AUTO_INCREMENT PRIMARY KEY,
   NomClient VARCHAR(50) ,
   PrenomClient VARCHAR(50) ,
   MailClient VARCHAR(100) ,
   TelClient VARCHAR(20)
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table EquipementsChambres
--
DROP TABLE IF EXISTS EquipementsChambres;
CREATE TABLE EquipementsChambres(
   IdEquipementChambre INT AUTO_INCREMENT PRIMARY KEY,
   LibelleEquipementChambre VARCHAR(50) ,
   DescriptionEquipementChambre TEXT
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table TypesChambres
--
DROP TABLE IF EXISTS TypesChambres;
CREATE TABLE TypesChambres(
   IdTypeChambre INT AUTO_INCREMENT PRIMARY KEY,
   LibelleTypeChambre VARCHAR(50) ,
   PrixChambre DECIMAL(15,2)
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Prestations
--
DROP TABLE IF EXISTS Prestations;
CREATE TABLE Prestations(
   IdPrestation INT AUTO_INCREMENT PRIMARY KEY,
   LibellePrestation VARCHAR(100) ,
   DescriptionPrestation TEXT,
   PrixPrestation DECIMAL(15,2)
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table ReservationsSejours
--
DROP TABLE IF EXISTS ReservationsSejours;
CREATE TABLE ReservationsSejours(
   IdReservationSejour INT AUTO_INCREMENT PRIMARY KEY,
   NumReservationSejour INT,
   DateDebutReservationSejour DATE,
   DateFinReservationSejour DATE,
   NbPersonnes INT,
   NbChambres INT,
   IdClient INT NOT NULL
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Fidelite
--
DROP TABLE IF EXISTS Fidelite;
CREATE TABLE Fidelite(
   IdFidelite INT AUTO_INCREMENT PRIMARY KEY,
   LibelleFidelite VARCHAR(50) ,
   DescriptionFidelite TEXT
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table StatutsChambres
--
DROP TABLE IF EXISTS StatutsChambres;
CREATE TABLE StatutsChambres(
   IdStatutChambre INT AUTO_INCREMENT PRIMARY KEY,
   LibelleStatutChambre VARCHAR(50)
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Entreprises
--
DROP TABLE IF EXISTS Entreprises;
CREATE TABLE Entreprises(
   IdClient INT PRIMARY KEY,
   NomEntreprise VARCHAR(100) ,
   Siret VARCHAR(50) UNIQUE,
   NumEntreprise INT UNIQUE,
   PourcentageReduction DECIMAL(15,2)
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table TypesEmployes
--
DROP TABLE IF EXISTS TypesEmployes;
CREATE TABLE TypesEmployes(
   IdTypeEmploye INT AUTO_INCREMENT PRIMARY KEY,
   LibelleTypeEmploye VARCHAR(50)
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Etages
--
DROP TABLE IF EXISTS Etages;
CREATE TABLE Etages(
   IdEtage INT AUTO_INCREMENT PRIMARY KEY,
   NumEtage INT UNIQUE
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Particuliers
--
DROP TABLE IF EXISTS Particuliers;
CREATE TABLE Particuliers(
   IdClient INT PRIMARY KEY,
   NumParticulier INT UNIQUE,
   IdFidelite INT NOT NULL 
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table TypesPaiements
--
DROP TABLE IF EXISTS TypesPaiements;
CREATE TABLE TypesPaiements(
   IdTypePaiement INT AUTO_INCREMENT PRIMARY KEY,
   LibelleTypePaiement VARCHAR(50)
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Employés
--
DROP TABLE IF EXISTS Employes;
CREATE TABLE Employes(
   IdEmploye INT AUTO_INCREMENT PRIMARY KEY,
   NomEmploye VARCHAR(50) ,
   PrenomEmploye VARCHAR(50) ,
   Identifiant VARCHAR(50)  NOT NULL UNIQUE,
   Mdp VARCHAR(255)  NOT NULL,
   IdTypeEmploye INT NOT NULL
   
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Chambres
--
DROP TABLE IF EXISTS Chambres;
CREATE TABLE Chambres(
   IdChambre INT AUTO_INCREMENT PRIMARY KEY,
   NumChambre INT UNIQUE,
   IdTypeChambre INT NOT NULL,
   IdStatutChambre INT NOT NULL,
   IdEtage INT NOT NULL
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table PossessionsEquipements
--
DROP TABLE IF EXISTS PossessionsEquipements;
CREATE TABLE PossessionsEquipements(
    IdPossessionsEquipement INT AUTO_INCREMENT PRIMARY KEY,
   IdEquipementChambre INT,
   IdChambre INT
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table HistoriqueChambre
--
DROP TABLE IF EXISTS HistoriqueChambres;
CREATE TABLE HistoriqueChambres(
    IdHistoriqueChambre INT AUTO_INCREMENT PRIMARY KEY,
   IdChambre INT,
   IdReservationSejour INT
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table HistoriquesNettoyages
--
DROP TABLE IF EXISTS HistoriquesNettoyages;
CREATE TABLE HistoriquesNettoyages(
    IdHistoriquesNettoyage INT AUTO_INCREMENT PRIMARY KEY,
   IdEmploye INT,
   IdChambre INT,
   DateHeureNettoyage DATETIME
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Facturations
--
DROP TABLE IF EXISTS Facturations;
CREATE TABLE Facturations(
    IdFacturation INT AUTO_INCREMENT PRIMARY KEY,
   IdPrestation INT,
   IdReservationSejour INT,
   IdTypePaiement INT,
   NumFacture VARCHAR(50),
   QuantitePrestation INT,
   DatePrestation DATETIME
)ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table HistoriqueActionsReservation
--
DROP TABLE IF EXISTS HistoriqueActionsReservations;
CREATE TABLE HistoriqueActionsReservations(
    IdHistoriqueActionsReservation INT AUTO_INCREMENT PRIMARY KEY,
   IdEmploye INT,
   IdReservationSejour INT,
   DateHeureAction DATETIME
)ENGINE=InnoDB DEFAULT charset = UTF8;
