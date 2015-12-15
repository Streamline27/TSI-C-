DROP SCHEMA `cs_test`;
CREATE SCHEMA IF NOT EXISTS `cs_test` DEFAULT CHARACTER SET utf8 ;
USE `cs_test` ;

 create TABLE `People` (
            `person_id` bigint(20) NOT NULL AUTO_INCREMENT,
            `first_name` varchar(50) NOT NULL,
            `last_name` varchar(50) NOT NULL,
            `age` bigint(20),
            PRIMARY KEY (`person_id`)
            ) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
            
            
INSERT INTO People (first_name, last_name, age) values("Roman", "Komjakov", 22);
INSERT INTO People (first_name, last_name, age) values("Aleksandr", "Lisicin", 21);
INSERT INTO People (first_name, last_name, age) values("Vladimir", "Grigoriev", 22);