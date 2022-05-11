-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 11, 2022 at 09:39 AM
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
  `user` varchar(15) NOT NULL,
  `question` varchar(50) NOT NULL,
  `answer` text NOT NULL,
  `id` int(5) NOT NULL,
  `likes` int(2) NOT NULL,
  `dislikes` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `answers`
--

INSERT INTO `answers` (`user`, `question`, `answer`, `id`, `likes`, `dislikes`) VALUES
('karpol2', 'Ukraine vs Russia', 'I hope Ukraine wins this war. #SlavaUkraine', 1, 5, 2),
('Useris2', 'Pizza or tacos?', 'Pizzas ofc.', 24, 5, 0),
('mykolas', 'Luka Doncic in a game 1 loss to the Suns: 45/12/8 ', 'Luka deserves MVPs', 26, 4, 0),
('kazka', 'Amber vs Depp, who wsins?', 'Justice for Johnny Depp', 27, 2, 0),
('mykolas', 'testas', 'fasefsafsfsaf', 28, 1, 2),
('kazom', 'Kazom test', 'kazom answer test123', 29, 4, 1),
('kazom', 'About Lithuania', 'asdfaee', 30, 2, 3),
('kazom', 'kazom test1234', 'super answerss', 31, 0, 4);

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `user` varchar(15) NOT NULL,
  `question` varchar(50) NOT NULL,
  `id` int(5) NOT NULL,
  `content` text NOT NULL,
  `likes` int(2) NOT NULL,
  `dislikes` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`user`, `question`, `id`, `content`, `likes`, `dislikes`) VALUES
('karpol2', 'Amber vs Depp, who wsins?', 1, 'In my opinion, I think Depp should win this, because he deserves justice. Amber should go to hell. Well what are your opinions?', 2, 1),
('test55', 'Who wins this time nba mvp?', 2, 'So far, I can tell, that Antetokounmpo, Embiid and Jokic are front runners, but, in my opinion, Jokic should win this season\'s mvp, because of its master of pass, scoring abilities.', 1, 1),
('Useris4', 'Carp is best', 3, 'Guys, what are your favourite fish? Mine is carp, because basically, carps are almost everywhere, and indeed nice type of fish.', 0, 0),
('testasAI', 'Robot will invade world in 100 years', 4, 'Listening to news, checking newspapers and living, we can see that our future technology will achieve that point where robots will start live as humans. I think thats not really good idea, it can cause serious problems... like apocalypse?', 5, 0),
('test55', 'Is Elden Ring tiring game', 5, 'So far, I\'ve played for 120hours, and yet, I am struggling to defeat third boss, the gameplay is insane, but difficulty of this game is insane-hard game.\r\n\r\nAny reccomendation to beat this game?', 3, 0),
('mykolas', 'In your opinion, is it worth studying at KTU?', 6, 'So far, I have received informations about Kaunas Technology University, is that this place is quite expensive with costs of study. I am not sure if is worth travelling to Lithuania and studying there. What are your opinions? If you\'re KTU student, I would appreciate your opinion 100%.', 2, 1),
('useris1', 'KTU dormitory', 7, 'Guys, what issues you are having living in dormitories? I saw one cockroach so far, but, what about you?', 1, 5),
('karpol2', 'What\'s the story behind one of your scars?', 8, 'I\'ve got scar from accidentally cutting finger with sharp knife, it\'s still sensitive, but I would say it\'s looking awesome while having this scar.', 4, 4),
('test55', 'If you could live in a book, TV show, or movie, wh', 9, 'If you could live in a book, TV show, or movie, what would it be? ', 2, 1),
('Useris2', 'What do you like most about your family?', 10, 'I like most about my family is that they\'re trustworthy, always by your hands, always waiting for you, always help you from serious problems.', 1, 1),
('useris1', 'Pizza or tacos?', 11, 'Pizza for life, what about you guys?', 2, 0),
('karpol2', 'What languages do you speak?', 12, 'Since I am not good with learning languages, so far I can only chat(not talk) English language, Lithuanian, and a bit of Russian language.', 3, 0),
('karpol2', 'Ukraine vs Russia', 13, 'Well, I think this discussion is about how thing goes between Ukraine and Russia. I heard that Russia got attacked by Ukraine in one region, but I don\'t remember correctly. But of course, I wish Russia canceled war, or shouldn\'t start war at all. #SlavaUkraini', 5, 0),
('kazka', 'Luka Doncic in a game 1 loss to the Suns: 45/12/8 ', 14, 'Not a bad game from Luka, but the suns still pull through and go up 1-0 in the series\r\n\r\n', 4, 2),
('Useris2', 'What\'s the best piece of advice you ever received?', 15, 'Never give up. Thats the best advice for me, for you, for everyone.', 1, 0),
('karpol2', 'Who inspires you to be better?', 16, 'Noone. I focus on my own, i don\'t have anyone to inspire, not really much looking forward to inspire from someone.', 4, 0),
('Useris2', 'About Lithuania', 17, 'Hello guys, is it worth living in Lithuania? What are situation there?', 2, 5),
('karpol2', 'This is question title.', 18, 'This is a question title\'s description/content. (For test purposes.)', 4, 1),
('Useris2', 'testas', 19, 'fsaefsafasf', 2, 1),
('kazom', 'Kazom test', 20, 'kazom content test4', 0, 0),
('kazom', 'kazom test1234', 21, 'kazomtesat1241efsafass', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(5) NOT NULL,
  `name` varchar(15) NOT NULL,
  `currency` int(6) NOT NULL,
  `email` varchar(40) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `currency`, `email`, `password`) VALUES
(24, 'Useris2', 14, 'useris2@gmail.com', 'randomizas'),
(28, 'Useris4', 20, 'useris4@gmail.c', 'passwordz'),
(111, 'useris1', 300, 'useris1@gmail.c', 'kebabas123'),
(121, 'mykolas', 200, 'mykolas@gmail.c', 'cesnakinis'),
(141, 'karpol2', 120, 'karpol2@gmail.c', 'kentauras'),
(153, 'kazka', 400, 'kazka@gmail.com', 'kentauras'),
(154, 'testasAI', 254, 'testasAi@gmail.', 'alio'),
(156, 'test55', 60, 'test55@gmail.co', 'Neatpazyst'),
(163, 'Testaskarpol2', 300, 'karpolisc@gmail.com', 'ilgasis'),
(164, 'kazom', 0, 'kazom@gmail.com', 'kazom123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `answers`
--
ALTER TABLE `answers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userio nickas` (`user`),
  ADD KEY `questionai` (`question`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `question` (`question`),
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
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=165;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `answers`
--
ALTER TABLE `answers`
  ADD CONSTRAINT `questionai` FOREIGN KEY (`question`) REFERENCES `questions` (`question`) ON UPDATE CASCADE,
  ADD CONSTRAINT `userio nickas` FOREIGN KEY (`user`) REFERENCES `users` (`name`);

--
-- Constraints for table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `userio` FOREIGN KEY (`user`) REFERENCES `users` (`name`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
