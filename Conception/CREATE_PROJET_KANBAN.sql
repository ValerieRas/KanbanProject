CREATE TABLE Utilisateur(
   ID_utilisateur INT IDENTITY(1,1),
   Nom VARCHAR(50)  NOT NULL,
   Prenom VARCHAR(50)  NOT NULL,
   Email VARCHAR(50) ,
   PRIMARY KEY(ID_utilisateur)
);

CREATE TABLE Projet(
   ID_projet INT IDENTITY(1,1),
   NomProjet VARCHAR(50)  NOT NULL,
   DateDebut DATE NOT NULL,
   DateFin DATE,
   PRIMARY KEY(ID_projet)
);

CREATE TABLE Objectif_projet(
   ID_objectif_projet INT IDENTITY(1,1),
   DescriptionObjectif VARCHAR(50) ,
   Complete BIT,
   ID_projet INT NOT NULL,
   PRIMARY KEY(ID_objectif_projet),
   FOREIGN KEY(ID_projet) REFERENCES Projet(ID_projet)
);



CREATE TABLE Statut(
   ID_statut INT IDENTITY(1,1),
   DescriptionStatus VARCHAR(50)  NOT NULL,
   PRIMARY KEY(ID_statut)
);

CREATE TABLE Tache(
   ID_tache INT IDENTITY(1,1),
   TitreTache VARCHAR(50)  NOT NULL,
   DescriptionTache VARCHAR(50) ,
   DateCreation DATE,
   DateLimite DATE,
   ID_utilisateur INT NOT NULL,
   ID_statut INT NOT NULL,
   ID_projet INT NOT NULL,
   PRIMARY KEY(ID_tache),
   FOREIGN KEY(ID_utilisateur) REFERENCES Utilisateur(ID_utilisateur),
   FOREIGN KEY(ID_statut) REFERENCES Statut(ID_statut),
   FOREIGN KEY(ID_projet) REFERENCES Projet(ID_projet)
);

CREATE TABLE Action_tache(
   ID_action_tache INT IDENTITY(1,1),
   DescriptionAction VARCHAR(50) ,
   ID_tache INT NOT NULL,
   Complete BIT,
   PRIMARY KEY(ID_action_tache),
   FOREIGN KEY(ID_tache) REFERENCES Tache(ID_tache)
);


CREATE TABLE Membre_projet(
   ID_utilisateur INT,
   ID_projet INT,
   PRIMARY KEY(ID_utilisateur, ID_projet),
   FOREIGN KEY(ID_utilisateur) REFERENCES Utilisateur(ID_utilisateur),
   FOREIGN KEY(ID_projet) REFERENCES Projet(ID_projet)
);

CREATE TABLE Statut_projet(
   ID_projet INT,
   ID_statut INT,
   PRIMARY KEY(ID_projet, ID_statut),
   FOREIGN KEY(ID_projet) REFERENCES Projet(ID_projet),
   FOREIGN KEY(ID_statut) REFERENCES Statut(ID_statut)
);
