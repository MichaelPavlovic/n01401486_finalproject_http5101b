-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 06, 2019 at 11:12 PM
-- Server version: 5.7.24
-- PHP Version: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `page`
--

-- --------------------------------------------------------

--
-- Table structure for table `pages`
--

CREATE TABLE `pages` (
  `pageid` int(20) UNSIGNED NOT NULL,
  `pagetitle` varchar(255) DEFAULT NULL,
  `pagebody` mediumtext,
  `author` varchar(50) DEFAULT NULL,
  `pagecol1` mediumtext,
  `pagecol2` mediumtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pages`
--

INSERT INTO `pages` (`pageid`, `pagetitle`, `pagebody`, `author`, `pagecol1`, `pagecol2`) VALUES
(1, 'Page 1', 'a new page body', 'Some name', 'Some column 1 content for page 1.', 'Some column 2 content for page 1. Some column 2 content for page 1.Some column 2 content for page 1.Some column 2 content for page 1.Some column 2 content for page 1.Some column 2 content for page 1.Some column 2 content for page 1.'),
(2, 'Page 2', 'This is page 2.', 'Another name', 'Some column 1 content for page 2', 'Some column 2 content for page 2'),
(4, 'Test', 'page content page content page content page content page content page content page content page content page content ', 'Michael', 'page content page content page content page content page content page content page content page content ', 'page content page content page content page content page content page content page content page content page content ');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pages`
--
ALTER TABLE `pages`
  ADD PRIMARY KEY (`pageid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pages`
--
ALTER TABLE `pages`
  MODIFY `pageid` int(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
