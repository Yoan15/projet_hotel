ALTER TABLE Entreprises ADD CONSTRAINT FK_Entreprises_Clients FOREIGN KEY (IdClient) REFERENCES Clients (IdClient);

ALTER TABLE Particuliers ADD CONSTRAINT FK_Particuliers_Clients FOREIGN KEY(IdClient) REFERENCES Clients(IdClient);

ALTER TABLE Particuliers ADD CONSTRAINT FK_Particuliers_Fidelites FOREIGN KEY(IdFidelite) REFERENCES Fidelite(IdFidelite);

ALTER TABLE ReservationsSejours ADD CONSTRAINT FK_ReservationsSejours_Clients FOREIGN KEY(IdClient) REFERENCES Clients(IdClient);

ALTER TABLE Employes ADD CONSTRAINT FK_Employes_TypeEmployes FOREIGN KEY(IdTypeEmploye) REFERENCES TypesEmployes(IdTypeEmploye);

ALTER TABLE Chambres ADD CONSTRAINT FK_Chambres_TypesChambres FOREIGN KEY(IdTypeChambre) REFERENCES TypesChambres(IdTypeChambre);

ALTER TABLE Chambres ADD CONSTRAINT FK_Chambres_StatutsChambres FOREIGN KEY(IdStatutChambre) REFERENCES StatutsChambres(IdStatutChambre);

ALTER TABLE Chambres ADD CONSTRAINT FK_Chambres_Etages FOREIGN KEY(IdEtage) REFERENCES Etages(IdEtage);

ALTER TABLE PossessionsEquipements ADD CONSTRAINT FK_PossessionsEquipements_EquipementsChambres FOREIGN KEY(IdEquipementChambre) REFERENCES EquipementsChambres(IdEquipementChambre);

ALTER TABLE PossessionsEquipements ADD CONSTRAINT FK_PossessionsEquipements_Chambres FOREIGN KEY(IdChambre) REFERENCES Chambres(IdChambre);

ALTER TABLE HistoriqueChambres ADD CONSTRAINT FK_HistoriqueChambres_Chambres FOREIGN KEY(IdChambre) REFERENCES Chambres(IdChambre);

ALTER TABLE HistoriqueChambres ADD CONSTRAINT FK_HistoriqueChambres_ReservationsSejours FOREIGN KEY(IdReservationSejour) REFERENCES ReservationsSejours(IdReservationSejour);

ALTER TABLE HistoriquesNettoyages ADD CONSTRAINT FK_HistoriquesNettoyages_Employes FOREIGN KEY(IdEmploye) REFERENCES Employes(IdEmploye);

ALTER TABLE HistoriquesNettoyages ADD CONSTRAINT FK_HistoriquesNettoyages_Chambres FOREIGN KEY(IdChambre) REFERENCES Chambres(IdChambre);

ALTER TABLE Facturations ADD CONSTRAINT FK_Facturations_Prestations FOREIGN KEY(IdPrestation) REFERENCES Prestations(IdPrestation);
ALTER TABLE Facturations ADD CONSTRAINT FK_Facturations_ReservationsSejours FOREIGN KEY(IdReservationSejour) REFERENCES ReservationsSejours(IdReservationSejour);

ALTER TABLE Facturations ADD CONSTRAINT FK_Facturations_TypesPaiements FOREIGN KEY(IdTypePaiement) REFERENCES TypesPaiements(IdTypePaiement);

ALTER TABLE HistoriqueActionsReservations ADD CONSTRAINT FK_HistoriqueActionsReservations_Employes FOREIGN KEY(IdEmploye) REFERENCES Employes(IdEmploye);

ALTER TABLE HistoriqueActionsReservations ADD CONSTRAINT FK_HistoriqueActionsReservations_ReservationsSejours FOREIGN KEY(IdReservationSejour) REFERENCES ReservationsSejours(IdReservationSejour);