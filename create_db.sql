
CREATE DATABASE IF NOT EXISTS gestion_notes;
USE gestion_notes;

CREATE TABLE eleves (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL
);

CREATE TABLE notes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    eleve_id INT,
    note DOUBLE,
    FOREIGN KEY (eleve_id) REFERENCES eleves(id)
);
