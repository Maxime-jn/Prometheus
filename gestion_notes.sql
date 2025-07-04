-- phpMyAdmin SQL Dump
-- version 5.2.1deb3
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : jeu. 05 juin 2025 à 13:37
-- Version du serveur : 10.11.13-MariaDB-0ubuntu0.24.04.1
-- Version de PHP : 8.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestion_notes`
--

CREATE DATABASE IF NOT EXISTS `gestion_notes` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
-- --------------------------------------------------------

USE `gestion_notes`;
--
-- Structure de la table `cours`
--

CREATE TABLE `cours` (
  `id` int(11) NOT NULL,
  `nom` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `cours`
--

INSERT INTO `cours` (`id`, `nom`) VALUES
(1, 'Math'),
(2, 'Français'),
(3, 'Histoire'),
(4, 'Physique'),
(5, 'Informatique');

-- --------------------------------------------------------

--
-- Structure de la table `eleves`
--

CREATE TABLE `eleves` (
  `id` int(11) NOT NULL,
  `nom` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `eleves`
--

INSERT INTO `eleves` (`id`, `nom`) VALUES
(1, 'Alice'),
(2, 'Bob'),
(3, 'Charlie'),
(4, 'Diana'),
(5, 'Ethan');

-- --------------------------------------------------------

--
-- Structure de la table `notes`
--

CREATE TABLE `notes` (
  `id` int(11) NOT NULL,
  `eleve_id` int(11) DEFAULT NULL,
  `cours_id` int(11) DEFAULT NULL,
  `valeur` double DEFAULT NULL,
  `ponderation` int(11) DEFAULT NULL CHECK (`ponderation` between 1 and 5),
  `date_note` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `notes`
--

INSERT INTO `notes` (`id`, `eleve_id`, `cours_id`, `valeur`, `ponderation`, `date_note`) VALUES
(1, 1, 2, 5.9, 2, '2025-02-10'),
(2, 1, 2, 4, 1, '2025-02-11'),
(3, 1, 4, 4.5, 3, '2025-02-12'),
(4, 1, 3, 3.3, 1, '2025-02-13'),
(5, 1, 3, 5.9, 3, '2025-02-14'),
(6, 1, 4, 3.3, 3, '2025-02-15'),
(7, 1, 1, 5.4, 3, '2025-02-16'),
(8, 1, 4, 3.5, 2, '2025-02-17'),
(9, 1, 3, 4.5, 2, '2025-02-18'),
(10, 1, 1, 3.9, 1, '2025-02-19'),
(11, 1, 5, 3.2, 2, '2025-02-20'),
(12, 1, 1, 3.9, 1, '2025-02-21'),
(13, 1, 2, 3.4, 1, '2025-02-22'),
(14, 1, 5, 4.5, 1, '2025-02-23'),
(15, 1, 4, 5.2, 3, '2025-02-24'),
(16, 2, 3, 4.2, 1, '2025-02-10'),
(17, 2, 1, 3.2, 2, '2025-02-11'),
(18, 2, 3, 3.5, 3, '2025-02-12'),
(19, 2, 2, 3.4, 3, '2025-02-13'),
(20, 2, 3, 3.3, 3, '2025-02-14'),
(21, 2, 5, 4.3, 2, '2025-02-15'),
(22, 2, 4, 5.8, 1, '2025-02-16'),
(23, 2, 1, 5.2, 3, '2025-02-17'),
(24, 2, 3, 5.5, 1, '2025-02-18'),
(25, 2, 2, 3.3, 3, '2025-02-19'),
(26, 2, 5, 4.4, 3, '2025-02-20'),
(27, 2, 4, 5.3, 2, '2025-02-21'),
(28, 2, 4, 4.3, 3, '2025-02-22'),
(29, 2, 5, 5.3, 3, '2025-02-23'),
(30, 2, 5, 6, 2, '2025-02-24'),
(31, 3, 5, 4.1, 1, '2025-02-10'),
(32, 3, 1, 4.5, 1, '2025-02-11'),
(33, 3, 3, 5.3, 1, '2025-02-12'),
(34, 3, 2, 5, 2, '2025-02-13'),
(35, 3, 1, 5.8, 3, '2025-02-14'),
(36, 3, 2, 4.2, 3, '2025-02-15'),
(37, 3, 4, 4.9, 2, '2025-02-16'),
(38, 3, 1, 4.8, 2, '2025-02-17'),
(39, 3, 3, 4.4, 1, '2025-02-18'),
(40, 3, 4, 3.4, 3, '2025-02-19'),
(41, 3, 5, 4.2, 1, '2025-02-20'),
(42, 3, 3, 4.8, 2, '2025-02-21'),
(43, 3, 1, 5.1, 2, '2025-02-22'),
(44, 3, 3, 3.9, 3, '2025-02-23'),
(45, 3, 1, 5.8, 2, '2025-02-24'),
(46, 4, 3, 3.7, 1, '2025-02-10'),
(47, 4, 4, 5.9, 1, '2025-02-11'),
(48, 4, 3, 5.9, 1, '2025-02-12'),
(49, 4, 4, 3, 3, '2025-02-13'),
(50, 4, 3, 4.4, 1, '2025-02-14'),
(51, 4, 4, 5.3, 3, '2025-02-15'),
(52, 4, 2, 6, 2, '2025-02-16'),
(53, 4, 4, 4.9, 2, '2025-02-17'),
(54, 4, 1, 3.5, 2, '2025-02-18'),
(55, 4, 3, 3.7, 3, '2025-02-19'),
(56, 4, 5, 4.1, 3, '2025-02-20'),
(57, 4, 4, 4.4, 2, '2025-02-21'),
(58, 4, 5, 4.9, 1, '2025-02-22'),
(59, 4, 3, 4.3, 3, '2025-02-23'),
(60, 4, 1, 5.8, 2, '2025-02-24'),
(61, 5, 5, 5.5, 2, '2025-02-10'),
(62, 5, 2, 4.1, 3, '2025-02-11'),
(63, 5, 2, 5, 1, '2025-02-12'),
(64, 5, 4, 5.5, 2, '2025-02-13'),
(65, 5, 1, 4.4, 2, '2025-02-14'),
(66, 5, 2, 4.9, 1, '2025-02-15'),
(67, 5, 3, 5.4, 1, '2025-02-16'),
(68, 5, 1, 4.2, 1, '2025-02-17'),
(69, 5, 2, 5.5, 2, '2025-02-18'),
(70, 5, 1, 5.9, 1, '2025-02-19'),
(71, 5, 1, 3.3, 2, '2025-02-20'),
(72, 5, 5, 3.3, 3, '2025-02-21'),
(73, 5, 1, 5.5, 2, '2025-02-22'),
(74, 5, 4, 5.1, 2, '2025-02-23'),
(75, 5, 2, 5.1, 2, '2025-02-24'),
(76, 1, 1, 3.7, 3, '2025-10-10'),
(77, 1, 1, 4.9, 2, '2025-10-11'),
(78, 1, 3, 3.9, 1, '2025-10-12'),
(79, 1, 1, 3.4, 1, '2025-10-13'),
(80, 1, 1, 5.3, 3, '2025-10-14'),
(81, 1, 4, 3.8, 3, '2025-10-15'),
(82, 1, 4, 3.4, 3, '2025-10-16'),
(83, 1, 3, 3.9, 1, '2025-10-17'),
(84, 1, 2, 5.7, 1, '2025-10-18'),
(85, 1, 5, 5, 3, '2025-10-19'),
(86, 1, 4, 3.8, 3, '2025-10-20'),
(87, 1, 3, 4.1, 3, '2025-10-21'),
(88, 1, 3, 4.6, 1, '2025-10-22'),
(89, 1, 4, 3, 1, '2025-10-23'),
(90, 1, 2, 3.3, 1, '2025-10-24'),
(91, 2, 2, 3.2, 1, '2025-10-10'),
(92, 2, 1, 4.2, 2, '2025-10-11'),
(93, 2, 1, 5.8, 3, '2025-10-12'),
(94, 2, 2, 3.8, 1, '2025-10-13'),
(95, 2, 5, 5.2, 1, '2025-10-14'),
(96, 2, 2, 3.2, 3, '2025-10-15'),
(97, 2, 3, 5.7, 3, '2025-10-16'),
(98, 2, 5, 5.3, 2, '2025-10-17'),
(99, 2, 2, 5.2, 1, '2025-10-18'),
(100, 2, 5, 4.3, 1, '2025-10-19'),
(101, 2, 5, 5.6, 3, '2025-10-20'),
(102, 2, 5, 3.6, 3, '2025-10-21'),
(103, 2, 4, 3.2, 3, '2025-10-22'),
(104, 2, 3, 3.6, 2, '2025-10-23'),
(105, 2, 3, 4.5, 2, '2025-10-24'),
(106, 3, 2, 4.5, 1, '2025-10-10'),
(107, 3, 1, 3.9, 1, '2025-10-11'),
(108, 3, 1, 5.3, 2, '2025-10-12'),
(109, 3, 4, 4.1, 3, '2025-10-13'),
(110, 3, 5, 5.9, 1, '2025-10-14'),
(111, 3, 4, 4.8, 1, '2025-10-15'),
(112, 3, 1, 4.5, 3, '2025-10-16'),
(113, 3, 2, 4.9, 1, '2025-10-17'),
(114, 3, 3, 5.3, 2, '2025-10-18'),
(115, 3, 1, 4.9, 3, '2025-10-19'),
(116, 3, 5, 4.1, 1, '2025-10-20'),
(117, 3, 5, 3.3, 1, '2025-10-21'),
(118, 3, 3, 4.8, 2, '2025-10-22'),
(119, 3, 1, 4.8, 3, '2025-10-23'),
(120, 3, 5, 4.4, 1, '2025-10-24'),
(121, 4, 4, 5.2, 1, '2025-10-10'),
(122, 4, 2, 4, 1, '2025-10-11'),
(123, 4, 5, 3.8, 3, '2025-10-12'),
(124, 4, 3, 3.3, 2, '2025-10-13'),
(125, 4, 1, 4.9, 3, '2025-10-14'),
(126, 4, 3, 3.6, 3, '2025-10-15'),
(127, 4, 5, 5.7, 1, '2025-10-16'),
(128, 4, 5, 4, 3, '2025-10-17'),
(129, 4, 2, 4.2, 2, '2025-10-18'),
(130, 4, 1, 3.9, 2, '2025-10-19'),
(131, 4, 4, 3, 3, '2025-10-20'),
(132, 4, 4, 5, 1, '2025-10-21'),
(133, 4, 2, 5.5, 1, '2025-10-22'),
(134, 4, 4, 3, 2, '2025-10-23'),
(135, 4, 2, 5.2, 3, '2025-10-24'),
(136, 5, 5, 5.6, 2, '2025-10-10'),
(137, 5, 1, 3, 2, '2025-10-11'),
(138, 5, 1, 4.1, 1, '2025-10-12'),
(139, 5, 1, 4.8, 3, '2025-10-13'),
(140, 5, 3, 3.7, 1, '2025-10-14'),
(141, 5, 4, 3.3, 3, '2025-10-15'),
(142, 5, 1, 4.3, 2, '2025-10-16'),
(143, 5, 2, 4.8, 2, '2025-10-17'),
(144, 5, 5, 4.1, 2, '2025-10-18'),
(145, 5, 1, 4.8, 1, '2025-10-19'),
(146, 5, 1, 4, 3, '2025-10-20'),
(147, 5, 2, 3.7, 1, '2025-10-21'),
(148, 5, 1, 4.5, 3, '2025-10-22'),
(149, 5, 2, 5.8, 2, '2025-10-23'),
(150, 5, 3, 3, 1, '2025-10-24');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `cours`
--
ALTER TABLE `cours`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `eleves`
--
ALTER TABLE `eleves`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `notes`
--
ALTER TABLE `notes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `eleve_id` (`eleve_id`),
  ADD KEY `cours_id` (`cours_id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `cours`
--
ALTER TABLE `cours`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `eleves`
--
ALTER TABLE `eleves`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `notes`
--
ALTER TABLE `notes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=151;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `notes`
--
ALTER TABLE `notes`
  ADD CONSTRAINT `notes_ibfk_1` FOREIGN KEY (`eleve_id`) REFERENCES `eleves` (`id`),
  ADD CONSTRAINT `notes_ibfk_2` FOREIGN KEY (`cours_id`) REFERENCES `cours` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
