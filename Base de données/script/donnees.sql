-- TypeEmployés
INSERT INTO TypesEmployes VALUES (1, "Gérant");
INSERT INTO TypesEmployes VALUES (2, "Réceptionniste");
INSERT INTO TypesEmployes VALUES (3, "Personnel d'entretien");
-- 
-- Employés
INSERT INTO Employes VALUES(1,"Dupond","Jean","j.dupond","jbvmzr145Gqlkdjfghqmehbmdjbhmzkeghlmzqejbhbhtr",1);
INSERT INTO Employes VALUES(2,"Avotservice","Gilbert","g.avotservice","jszhdikuzjsehrgmozerbgmozejrbgmkezbmoeeRG4",2);
INSERT INTO Employes VALUES(3,"Uitout","Jess","j.uitout","kfbkfnbir!5uhgmieqzrjbgmizearbglmizerqbiblrez",3);
INSERT INTO Employes VALUES(4,"Duchmol","Pierre","p.duchmol","fgjbkljfgdh21smrgzheùoihgzmeorhgmzlerngmze",2);
INSERT INTO Employes VALUES(5,"Patate","Micheline","m.patate","AQEThetha!581qdf14dfg65er4g6e4g65er4ge65rghetrqaethzetheryj",3);
-- 
-- TypesChambres
INSERT INTO TypesChambres VALUES(1,"Standard Simple",54.99);
INSERT INTO TypesChambres VALUES(2,"Standard Double",65);
INSERT INTO TypesChambres VALUES(3,"Deluxe Simple",69.99);
INSERT INTO TypesChambres VALUES(4,"Deluxe Double",134.99);
INSERT INTO TypesChambres VALUES(5,"Suite",249.99);
-- 
-- EquipementsChambres
INSERT INTO EquipementsChambres VALUES(1,"Coffre-fort","Un coffre-fort pour stocker les objets de valeurs en sécurité");
INSERT INTO EquipementsChambres VALUES(2,"Mini-bar","Un mini-bar rempli de différentes boissons alcoolisées ou non");
INSERT INTO EquipementsChambres VALUES(3,"Climatisation","Une climatisation pour réguler la température de la chambre");
-- 
-- Etages
INSERT INTO Etages VALUES(1,0);
INSERT INTO Etages VALUES(2,1);
INSERT INTO Etages VALUES(3,2);
INSERT INTO Etages VALUES(4,3);
-- 
-- StatutsChambres
INSERT INTO StatutsChambres VALUES(1,"Libre");
INSERT INTO StatutsChambres VALUES(2,"Occupé");
INSERT INTO StatutsChambres VALUES(3,"Nettoyage en cours");
-- 
-- Chambres
INSERT INTO Chambres VALUES(1,101,1,1,2);
INSERT INTO Chambres VALUES(2,102,1,2,2);
INSERT INTO Chambres VALUES(3,201,3,3,3);
INSERT INTO Chambres VALUES(4,202,3,1,3);
INSERT INTO Chambres VALUES(5,301,5,2,4);
-- 
-- PossessionsEquipements
INSERT INTO PossessionsEquipements VALUES(1,1,3);
INSERT INTO PossessionsEquipements VALUES(2,1,4);
INSERT INTO PossessionsEquipements VALUES(3,1,5);
INSERT INTO PossessionsEquipements VALUES(4,2,5);
INSERT INTO PossessionsEquipements VALUES(5,3,5);
-- 
-- TypesPaiements
INSERT INTO TypesPaiements VALUES(1,"Espèces");
INSERT INTO TypesPaiements VALUES(2,"Carte bancaire");
INSERT INTO TypesPaiements VALUES(3,"Chèque");
INSERT INTO TypesPaiements VALUES(4,"Chèque vacances");
-- 
-- Prestations
INSERT INTO Prestations VALUES(1,"Petit-déjeuner","Petit-déjeuner servi dans la salle de restauration",5);
INSERT INTO Prestations VALUES(2,"Petit-déjeuner en chambre","Petit-déjeuner servi directement en chambre par un de nos employés",8.99);
INSERT INTO Prestations VALUES(3,"Réveil","Réveil par un employé de l'hôtel à une heure convenue",0);
INSERT INTO Prestations VALUES(4,"Massage","Massage de détente réalisé par notre masseur partenaire",45);
INSERT INTO Prestations VALUES(5,"Lit d'appoint","Ajout d'un lit d'appoint dans une chambre",14.99);
-- 
-- Fidelites
INSERT INTO Fidelites VALUES(1,"Bronze","Réduction de 5% sur les chambres de type Standard");
INSERT INTO Fidelites VALUES(2,"Argent","Réduction de 10% sur les chambres de type Standard et de 5% sur les chambres Deluxe");
INSERT INTO Fidelites VALUES(3,"Or","Réduction de 15% sur les chambres Standard et Deluxe, 5% sur les suites, consommation du mini-bar offerte le premier jour, petit-déjeuner en chambre à prix réduit");
INSERT INTO Fidelites VALUES(4,"Platine","Réduction de 20% sur le séjour, 50% de réduction sur le premier massage");
-- 
-- HistoriquesNettoyages
INSERT INTO HistoriquesNettoyages VALUES(1,3,1,"12/01/2023 09:35");
INSERT INTO HistoriquesNettoyages VALUES(2,5,4,"12/01/2023 09:45");
INSERT INTO HistoriquesNettoyages VALUES(3,5,5,"12/01/2023 10:35");
-- 
-- Clients
INSERT INTO Clients VALUES(1,"Sérien","Jean","jean.sérien@gmail.com","06 01 02 03 04 05");
INSERT INTO Clients VALUES(2,"Megratt","Sam","sam.megratt@gmail,com","06 58 65 48 56 04");
INSERT INTO Clients VALUES(3,"Chmonfiss","Thierry","thierry.chmonfiss@gmail.com","07 54 97 25 35 40");
-- 
-- Particuliers
INSERT INTO Particuliers VALUES(1,10821,"1");
INSERT INTO Particuliers VALUES(3,20058,"3");
-- 
-- Entreprises
INSERT INTO Entreprises VALUES(2,"Exploitation Inc.","54654658464",23554,0.08);
INSERT INTO Entreprises VALUES(3,"Richesse SARL","51514584885",18552,0.1);
-- 
-- ReservationsSejours
INSERT INTO ReservationsSejours VALUES(1,23001,"05/01/2023","15:00","06/01/2023",2,1,1);
INSERT INTO ReservationsSejours VALUES(2,23002,"06/01/2023","17:00","11/01/2023",4,2,3);
INSERT INTO ReservationsSejours VALUES(3,23500,"10/01/2023","18:00","18/01/2023",1,1,2);
INSERT INTO ReservationsSejours VALUES(4,23545,"05/02/2023","13:30","08/02/2023",2,1,3);
-- 
-- HistoriqueActionsReservations
INSERT INTO HistoriqueActionsReservations VALUES(1,2,1, "12/12/2022 15:47");
INSERT INTO HistoriqueActionsReservations VALUES(2,2,2, "28/12/2022 16:12");
INSERT INTO HistoriqueActionsReservations VALUES(3,4,3, "02/01/2023 10:55");
INSERT INTO HistoriqueActionsReservations VALUES(4,2,3, "02/01/2023 16:18");
INSERT INTO HistoriqueActionsReservations VALUES(5,2,4, "12/01/2023 11:08");
-- 
-- Facturations
INSERT INTO Facturations VALUES(1,3,1,1,2301,1,"06/01/2023 07:00");
INSERT INTO Facturations VALUES(2,2,1,1,2301,2,"06/01/2023 07:30");
INSERT INTO Facturations VALUES(3,1,2,4,2302,4,"07/01/2023 09:00");
INSERT INTO Facturations VALUES(4,4,2,4,2302,1,"07/01/2023 14:30");
INSERT INTO Facturations VALUES(5,1,2,4,2302,4,"08/01/2023 09:00");
INSERT INTO Facturations VALUES(6,1,2,4,2302,4,"09/01/2023 09:00");
INSERT INTO Facturations VALUES(7,1,2,4,2302,4,"10/01/2023 09:30");
INSERT INTO Facturations VALUES(8,1,2,4,2302,4,"11/01/2023 07:45");
INSERT INTO Facturations VALUES(9,2,3,2,2304,1,"11/01/2023 08:30");
-- 
-- HistoriquesChambres
INSERT INTO HistoriquesChambres VALUES(1,3,1);
INSERT INTO HistoriquesChambres VALUES(2,3,2);
INSERT INTO HistoriquesChambres VALUES(3,4,2);
INSERT INTO HistoriquesChambres VALUES(4,2,3);
INSERT INTO HistoriquesChambres VALUES(5,5,4);