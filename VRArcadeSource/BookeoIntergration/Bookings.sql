--
-- Database: `vrarcade`
--
CREATE DATABASE IF NOT EXISTS `vrarcade` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `vrarcade`;
-- --------------------------------------------------------

--
-- Table structure for table `Bookings`
--

DROP TABLE IF EXISTS `Bookings`;
CREATE TABLE `Bookings` (
  `booking_id` bigint(20) NOT NULL,
  `booking_start_time` datetime DEFAULT NULL,
  `booking_end_time` datetime DEFAULT NULL,
  `customer_id` varchar(32) DEFAULT NULL,
  `booking_num_total` int(11) DEFAULT NULL,
  `customer_name` varchar(255) DEFAULT NULL,
  `customer_email` varchar(255) DEFAULT NULL,
  `customer_phone` varchar(255) DEFAULT NULL,
  `booking_creation_time` datetime DEFAULT NULL,
  `booking_prod_name` varchar(255) DEFAULT NULL,
  `booking_prod_id` varchar(255) DEFAULT NULL,
  `total_paid` float DEFAULT NULL,
  `booking_updated` datetime DEFAULT NULL,
  `booking_deleted` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;