-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 01, 2022 at 04:05 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `solea`
--

-- --------------------------------------------------------

--
-- Table structure for table `answers`
--

CREATE TABLE `answers` (
  `user` varchar(8) NOT NULL,
  `question` text NOT NULL,
  `answer` text NOT NULL,
  `id` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `answers`
--

INSERT INTO `answers` (`user`, `question`, `answer`, `id`) VALUES
('Useris4', 'Hold up, where I can find phone?', 'As useris4 answering to useris2 question. Try remember last place you were with phone.', 2),
('mykolas', 'Does any1 know solution to this?2 + 2 = ?', 'IT is 4', 6),
('testasAI', 'Where is my house?', 'Its outside of your school412', 8),
('testasAI', 'Where is my beer?', 'somewhere', 12),
('test55', 'Where is my beer?', 'house', 13),
('mykolas', 'Testavimui, AUTO_INCREMENTs', 'somewhere', 14),
('testasAI', 'Does any1 know solution to this?2 + 2 = ?', 'i dont know', 15),
('testasAI', 'Testavimui, AUTO_INCREMENTs', 'taekofjasipdjfjkahzdivhasipjq', 16),
('karpol2', 'Does any1 know solution to this?2 + 2 = ?', 'fadsdgasdg', 17),
('mykolas', 'Does any1 know solution to this?2 + 2 = ?', 'dsagsdg', 18),
('karpol2', 'Does any1 know solution to this?2 + 2 = ?', 'rwfda', 19),
('mykolas', 'Testavimui, AUTO_INCREMENTs', 'xcFASDFAS', 20),
('test55', 'who am i', 'fgsdfgsdf', 21),
('karpol5', 'Testavimui, AUTO_INCREMENTs', 'gasdgasdg', 22),
('kazka', 'Idont kniw', 'me either', 23);

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `user` varchar(8) NOT NULL,
  `question` text NOT NULL,
  `id` int(5) NOT NULL,
  `content` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`user`, `question`, `id`, `content`) VALUES
('mykolas', 'Where is my beer?', 3, 'content'),
('karpol2', 'Does any1 know solution to this?2 + 2 = ?', 5, 'something'),
('karpol2', 'Testavimui, AUTO_INCREMENTs', 7, 'contentne'),
('testasAI', 'dasfda', 13, 'dagdsag'),
('Useris2', 'who am i', 14, 'i like to know w'),
('kazka', 'Idont kniw', 15, 'indontknowindontknowkiidas');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(5) NOT NULL,
  `name` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`) VALUES
(141, 'karpol2'),
(162, 'karpol5'),
(153, 'kazka'),
(121, 'mykolas'),
(156, 'test55'),
(154, 'testasAI'),
(111, 'useris1'),
(24, 'Useris2'),
(28, 'Useris4');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `answers`
--
ALTER TABLE `answers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `question` (`question`) USING HASH,
  ADD KEY `userio` (`user`),
  ADD KEY `content` (`content`(1024)),
  ADD KEY `content_3` (`content`(1024)),
  ADD KEY `content_5` (`content`(1024));
ALTER TABLE `questions` ADD FULLTEXT KEY `content_2` (`content`);
ALTER TABLE `questions` ADD FULLTEXT KEY `content_4` (`content`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `answers`
--
ALTER TABLE `answers`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=163;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `userio` FOREIGN KEY (`user`) REFERENCES `users` (`name`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
