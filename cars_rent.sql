-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 01 Haz 2025, 23:42:02
-- Sunucu sürümü: 5.7.24
-- PHP Sürümü: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `cars_rent`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cars`
--

CREATE TABLE `cars` (
  `id` int(11) NOT NULL,
  `brand` varchar(50) NOT NULL,
  `model` varchar(100) NOT NULL,
  `transmission` varchar(50) DEFAULT NULL,
  `engine_capacity` float DEFAULT NULL,
  `fuel_type` varchar(50) DEFAULT NULL,
  `horsepower` int(11) DEFAULT NULL,
  `drive_type` varchar(50) DEFAULT NULL,
  `acceleration` float DEFAULT NULL,
  `engine_type` varchar(50) DEFAULT NULL,
  `fuel_consumption` float DEFAULT NULL,
  `electric_range` int(11) DEFAULT NULL,
  `status` tinyint(1) DEFAULT '1',
  `reserved_by` varchar(100) DEFAULT NULL,
  `image_path` varchar(255) DEFAULT NULL,
  `reserved_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `cars`
--

INSERT INTO `cars` (`id`, `brand`, `model`, `transmission`, `engine_capacity`, `fuel_type`, `horsepower`, `drive_type`, `acceleration`, `engine_type`, `fuel_consumption`, `electric_range`, `status`, `reserved_by`, `image_path`, `reserved_at`) VALUES
(1, 'Ford', 'Focus III 1.6 MT SYNC Edition', 'mekanik', 1.6, '95', 105, 'ön tekerlekten çekişli', 12.4, 'benzin', 6, NULL, 1, '1212', 'Resources/Car_Photo/Ford_Focus_III_1.6_MT_SYNC_Edition/1.jpg', '2025-06-02 01:19:25'),
(2, 'Toyota', 'Auris II 1.2 MT', 'mekanik', 1.2, '95', 116, 'ön tekerlekten çekişli', 10.1, 'benzin', 4.7, NULL, 1, 'projeka2002@gmail.com', NULL, NULL),
(3, 'Mitsubishi', 'Outlander IV 2.4 AT', 'otomatik', 2.4, '92', 306, 'dört tekerlekten çekişli', 7.9, 'hibrit', 0.8, 86, 1, 'projeka2002@gmail.com', NULL, NULL),
(4, 'Hyundai', 'Palisade II 2.5 AT Caligraphy', 'otomatik', 2.5, '95', 281, 'dört tekerlekten çekişli', 7.7, 'benzin', 8.7, NULL, 1, 'firtsa@gmail.com', NULL, NULL),
(5, 'Jetour', 'X70 I 1.5 AMT Luxury', 'robot', 1.5, '92', 147, 'ön tekerlekten çekişli', 13, 'benzin', 7.8, NULL, 1, NULL, NULL, NULL),
(6, 'LiXiang', 'L7 I 1.5 AT Max', 'otomatik', 1.5, '95', 449, 'dört tekerlekten çekişli', 5.3, 'hibrit', 7.4, 190, 1, 'projeka2002@gmail.com', NULL, NULL),
(7, 'Toyota', '4Runner VI 2.4 AT Limited', 'otomatik', 2.4, '95', 278, 'dört tekerlekten çekişli', 7.5, 'benzin', 13.8, NULL, 1, 'valeriiburmakin@gmail.com', NULL, NULL),
(8, 'Hongqi', 'E-HS9 AT Comfort', 'otomatik', NULL, 'elektrik', 435, 'dört tekerlekten çekişli', 6.5, 'elektrik', NULL, 460, 1, 'projeka2002@gmail.com', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `car_images`
--

CREATE TABLE `car_images` (
  `id` int(11) NOT NULL,
  `car_id` int(11) DEFAULT NULL,
  `image_path` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `reserved_cars`
--

CREATE TABLE `reserved_cars` (
  `id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `car_id` int(11) DEFAULT NULL,
  `reserved_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `phone_number` varchar(15) NOT NULL,
  `isAdmin` tinyint(1) DEFAULT '0',
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `first_name`, `last_name`, `phone_number`, `isAdmin`, `password`) VALUES
(2, 'jeka', 'example@example.com', 'John', 'Canady', '+901213234346', 0, 'f190ce9ac8445d249747cab7be43f7d5'),
(7, 'oleg', 'firtsa@gmail.com', 'Oleg', 'Olegovich', '+905435432323', 1, '78f5fe6a55af8be3e3656888c6bb7511'),
(9, 'woldemar', 'woldemar@gmail.com', 'Woldemar', 'Gost', '+909998887766', 0, '1e48c4420b7073bc11916c6c1de226bb'),
(10, 'Mert', 'merttasdemir@gmail.com', 'Mert', 'Taşdemir', '+905354345454', 0, '21db9faf6536455109758041d4f247f5'),
(12, 'Darky', 'darkygost@gmail.com', 'Darky', 'Gost', '+905514771233', 1, '43e32fadbdfc6398cf01267defe4094f'),
(13, 'Sam', 'projeka2002@gmail.com', 'Sam', 'Samsa', '+901233211234', 0, '332532dcfaa1cbf61e2a266bd723612c'),
(14, 'Timon', 'TimonPumpon@gmail.com', 'Timon', 'Pumpon', '+901212323446', 0, 'c18bd005a3e26db22dccf373e32bff86'),
(15, 'rolan', 'rolan@ukr.net', 'Rolan', 'Abramyan', '+901231232323', 0, '25d5ff0e2799d2072fdd57fef8982249'),
(16, 'rolik', 'rolan@gmail.com', 'Rolan', 'Abramyan', '+3809122311223', 0, '25d5ff0e2799d2072fdd57fef8982249'),
(20, 'rolan2', 'rolan2@gmail.com', 'Rolan', 'Abramyan', '+3809122311223', 0, 'b220e42fb41ee249bfeb7dab7ca9e1ee'),
(21, 'mishka', 'mısha@gmail.com', 'Mıkhaıl', 'Mukoyan', '+901234325243', 0, 'ede55c5bd3339cf5ffd5983fd2c2eb4a'),
(22, 'Bob', 'bobmail@ukr.net', 'Bob', 'Derby', '+3801239998866', 0, '9f9d51bc70ef21ca5c14f307980a29d8'),
(23, 'Kendall', 'valeriiburmakin@gmail.com', 'Valeriy', 'Burmakin', '+901415231236', 0, '15146457de521aa82ee723b95d2f66c5'),
(25, 'IG', 'darkygost@ukr.net', 'Ievgenii', 'Gostyshchev', '+901233214142', 0, '5c5d50f01bd8349741a056659040bc6d'),
(26, 'aysun', 'aysunyılmaz@gmail.com', 'Aysun', 'Yılmaz', '+900001112233', 0, '74b89ebf42bd21027118c3fc6d76d2db'),
(27, 'bb', 'bb@gmail.com', 'Burak', 'Biber', '+901233218698', 0, '21ad0bd836b90d08f4cf640b4c298e7c'),
(28, 'John', 'John@gmail.com', 'John', 'Brimstone', '+904352342136', 0, '527bd5b5d689e2c32ae974c6229ff785'),
(30, 'yagiz', 'yagizoge@hotmail.com', 'Yagiz', 'Öge', '+908887776644', 0, '43e8f2cec3708a7b5419c0e75d1eb523'),
(33, 'timpim', 'timpim@gmail.com', 'tim', 'pim', '+908473652312', 0, '501fee60f7a8ea3b82c9fd8787670b70'),
(34, 'ElifE', 'ElifEfteli@gmail.com', 'Elif', 'Efteli', '+908876656644', 0, '0f1c78952d98426fd16518600905d68d'),
(36, 'Burak', 'BurakK@gmail.com', 'Burak', 'Kocael', '+908467576644', 0, '39109a5bb10ccb7aff1313d369804b74'),
(37, 'Bardak', 'BurakB@gmail.com', 'Burak', 'Baran', '+907474758798', 1, '35cb08d4d646f496f6e4372f9d48bc4b'),
(38, 'MertM', 'origamibest2002@gmail.com', 'Mert', 'Tas', '+904352342132', 0, '0dfeacb6d5df938273f057bc99506dd7'),
(39, 'IK', 'podcast.miscast@gmail.com', 'Ilya', 'Kazakov', '+904332221236', 0, '8c8a58fa97c205ff222de3685497742c'),
(40, 'adSoyad', 'adsoyad@gmail.com', 'ad', 'soyad', 'adsoyad', 0, 'e7d74fc7f9f50561846441a4ed88d89d'),
(41, 'Ddk', 'ddkk@gmail.com', 'ddkk', 'kkdd', '+304400043349', 0, '$2a$11$yl.V938vYWyOfvZMhM.T2.kK5QqVuTlIcoEwZaj9QxiJLWenBtN46'),
(42, 'Hoh', 'Hoh@gmail.com', 'Hoh', 'Bobson', '+484848382', 0, '$2a$11$6R9T2YGL5yo8gsUSsCyS0OKBERcK7YOwgtudTmj.oB6gxRyxso5bW'),
(43, 'Bib', 'Bi@gmail.com', 'Bi', 'B', '+90545443433232', 0, '$2a$11$Di1o31Xto2cWyQRFPV45buWConR6WNBQ2dG3HjUr6CSm1mEyWzbh2'),
(44, 'bnb', 'bnb', 'bnb', 'bnb', 'nbn', 0, '$2a$11$ke8LvQb1TQotDHdMZOVGsu2SimS1CTROMuEICKecFAuaQEvy4mPmq'),
(45, 'nin', 'nin@gmail.com', 'nin', 'nin', '+9032323232', 0, '$2a$11$Dy0OMiMbO/BJP4346FUBguT6BlFnB6sGA1bEhMqmB7q2HNZ66XMsu'),
(46, 'non', 'non@gmail.com', 'non', 'non', '+9032324212332', 0, '$2a$11$Ncrr6dL3nWhkKc6NOrEv8.3HBHvFQd5wEvvLldFQp6xKNEy5hUBQm'),
(47, 'nono', 'nono@gmail.com', 'nono', 'nono', '+9032384812', 0, '$2a$11$l.R52ACBnlUv2Jh/tAHpb.4bbbhAuaL953Z3nmOP1OaRl8QOWPeni'),
(48, 'noni', 'noni@gmail.com', 'noni', 'noni', '+90323412', 0, '$2a$11$k9eCLbHiH1l5FRr347rHLe1qClme97QDBJ46C4hayAtxu4tAZU6rS'),
(49, 'nani', 'nani', 'nani', 'nani', 'nani', 0, '$2a$11$BzrHswUCUr.ECUCgKdk08.8QyYHSk0xKThb26NzIOpa.oJwTOQfRW'),
(50, '1212', '1212', '1212', '1212', '1212', 0, '$2a$11$MGXQnVVHUIZOeZZHwIsyjeiNgUqoU4XOHVaKbimedtsteUSlYMKt6'),
(51, 'Yusuf', 'yusuf@gmail.com', 'Yusuf', 'Y', '+905443332321', 0, '$2a$11$ILeiy9ZIR2Fk8Y7dpEeWSe2LHzmF.CU8bZLX8vMCwTWMqNUFeMxVC');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `car_images`
--
ALTER TABLE `car_images`
  ADD PRIMARY KEY (`id`),
  ADD KEY `car_id` (`car_id`);

--
-- Tablo için indeksler `reserved_cars`
--
ALTER TABLE `reserved_cars`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `car_id` (`car_id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `cars`
--
ALTER TABLE `cars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Tablo için AUTO_INCREMENT değeri `car_images`
--
ALTER TABLE `car_images`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `reserved_cars`
--
ALTER TABLE `reserved_cars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `car_images`
--
ALTER TABLE `car_images`
  ADD CONSTRAINT `car_images_ibfk_1` FOREIGN KEY (`car_id`) REFERENCES `cars` (`id`) ON DELETE CASCADE;

--
-- Tablo kısıtlamaları `reserved_cars`
--
ALTER TABLE `reserved_cars`
  ADD CONSTRAINT `reserved_cars_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `reserved_cars_ibfk_2` FOREIGN KEY (`car_id`) REFERENCES `cars` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
