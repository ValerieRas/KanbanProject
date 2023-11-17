-- Utilisateur
INSERT INTO Utilisateur (Nom, Prenom, Email)
VALUES 
  ('Smith', 'John', 'john.smith@example.com'),
  ('Doe', 'Jane', 'jane.doe@example.com'),
  ('Johnson', 'Michael', 'michael.johnson@example.com'),
  ('Brown', 'Emily', 'emily.brown@example.com'),
  ('Wilson', 'David', 'david.wilson@example.com'),
  ('Miller', 'Sophia', 'sophia.miller@example.com'),
  ('Garcia', 'Daniel', 'daniel.garcia@example.com'),
  ('Taylor', 'Olivia', 'olivia.taylor@example.com'),
  ('Clark', 'Ethan', 'ethan.clark@example.com'),
  ('Wright', 'Ava', 'ava.wright@example.com');

-- Projet
INSERT INTO Projet (NomProjet, DateDebut, DateFin)
VALUES 
  ('Project A', '2023-01-01', '2023-02-28'),
  ('Project B', '2023-03-15', '2023-05-30'),
  ('Project C', '2023-06-10', '2023-08-31'),
  ('Project D', '2023-09-15', '2023-12-31');

-- Objectif_projet
INSERT INTO Objectif_projet (DescriptionObjectif, Complete, ID_projet)
VALUES 
  ('Objective 1 for Project A', 0, 1),
  ('Objective 2 for Project A', 0, 1),
  ('Objective 3 for Project A', 0, 1),
  ('Objective 1 for Project B', 0, 2),
  ('Objective 2 for Project B', 0, 2),
  ('Objective 3 for Project B', 0, 2),
  ('Objective 1 for Project C', 0, 3),
  ('Objective 2 for Project C', 0, 3),
  ('Objective 3 for Project C', 0, 3),
  ('Objective 1 for Project D', 0, 4),
  ('Objective 2 for Project D', 0, 4),
  ('Objective 3 for Project D', 0, 4);

-- Statut
INSERT INTO Statut (DescriptionStatus)
VALUES 
  ('Pending'),
  ('In Progress'),
  ('Completed');

-- Tache
INSERT INTO Tache (TitreTache, DescriptionTache, DateCreation, DateLimite, ID_utilisateur, ID_statut, ID_projet)
VALUES 
  ('Task 1 for Project A', 'Description for Task 1', '2023-01-05', '2023-01-15', 1, 1, 1),
  ('Task 2 for Project A', 'Description for Task 2', '2023-01-10', '2023-01-20', 2, 2, 1),
  ('Task 3 for Project A', 'Description for Task 3', '2023-01-15', '2023-01-25', 3, 1, 1),
  ('Task 1 for Project B', 'Description for Task 1', '2023-03-20', '2023-04-05', 4, 2, 2),
  ('Task 2 for Project B', 'Description for Task 2', '2023-03-25', '2023-04-10', 5, 1, 2),
  ('Task 3 for Project B', 'Description for Task 3', '2023-03-30', '2023-04-15', 6, 2, 2),
  ('Task 1 for Project C', 'Description for Task 1', '2023-06-15', '2023-06-30', 7, 1, 3),
  ('Task 2 for Project C', 'Description for Task 2', '2023-06-20', '2023-07-05', 8, 2, 3),
  ('Task 3 for Project C', 'Description for Task 3', '2023-06-25', '2023-07-10', 9, 1, 3),
  ('Task 1 for Project D', 'Description for Task 1', '2023-10-01', '2023-10-15', 10, 2, 4),
  ('Task 2 for Project D', 'Description for Task 2', '2023-10-05', '2023-10-20', 1, 1, 4),
  ('Task 3 for Project D', 'Description for Task 3', '2023-10-10', '2023-10-25', 2, 2, 4);

-- Action_tache
INSERT INTO Action_tache (DescriptionAction, ID_tache, Complete)
VALUES 
  ('Action 1 for Task 1', 1, 0),
  ('Action 2 for Task 1', 1, 0),
  ('Action 3 for Task 1', 1, 0),
  ('Action 1 for Task 2', 2, 0),
  ('Action 2 for Task 2', 2, 0),
  ('Action 3 for Task 2', 2, 0),
  ('Action 1 for Task 3', 3, 0),
  ('Action 2 for Task 3', 3, 0),
  ('Action 3 for Task 3', 3, 0),
  ('Action 1 for Task 4', 4, 0),
  ('Action 2 for Task 4', 4, 0),
  ('Action 3 for Task 4', 4, 0),
  ('Action 1 for Task 5', 5, 0),
  ('Action 2 for Task 5', 5, 0),
  ('Action 3 for Task 5', 5, 0),
  ('Action 1 for Task 6', 6, 0),
  ('Action 2 for Task 6', 6, 0),
  ('Action 3 for Task 6', 6, 0),
  ('Action 1 for Task 7', 7, 0),
  ('Action 2 for Task 7', 7, 0),
  ('Action 3 for Task 7', 7, 0),
  ('Action 1 for Task 8', 8, 0),
  ('Action 2 for Task 8', 8, 0),
  ('Action 3 for Task 8', 8, 0),
  ('Action 1 for Task 9', 9, 0),
  ('Action 2 for Task 9', 9, 0),
  ('Action 3 for Task 9', 9, 0),
  ('Action 1 for Task 10', 10, 0),
  ('Action 2 for Task 10', 10, 0),
  ('Action 3 for Task 10', 10, 0);



  INSERT INTO Membre_projet (ID_utilisateur, ID_projet)
VALUES 
  (1, 1), (2, 1),
  (3, 2), (4, 2),
  (5, 3), (6, 3),
  (7, 4), (8, 4),
  (9, 1), (10, 1),
  (1, 2), (2, 2),
  (3, 3), (4, 3),
  (5, 4), (6, 4),
  (7, 1), (8, 1),
  (9, 2), (10, 2);

-- Statut_projet
INSERT INTO Statut_projet (ID_projet, ID_statut)
VALUES 
  (1, 1), (1, 2), (1, 3),
  (2, 1), (2, 2), (2, 3),
  (3, 1), (3, 2), (3, 3),
  (4, 1), (4, 2), (4, 3);