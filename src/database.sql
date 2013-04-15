CREATE DATABASE hello_world;

USE hello_world;

CREATE USER 'benchmarkdbuser'@'localhost' IDENTIFIED BY 'benchmarkdbpass';

GRANT ALL PRIVILEGES ON hello_world.* TO 'benchmarkdbuser'@'localhost';

CREATE TABLE World (id INT PRIMARY KEY, randomNumber INT);

DELIMITER //
CREATE PROCEDURE SeedWorldTable()
BEGIN
	DECLARE id INT;
	DECLARE maxRows INT;
	DECLARE maxRandomNumber INT;
	DECLARE randomNumber INT;

	SET id = 1;
	SET maxRows = 10000;
	SET maxRandomNumber = ~0 >> 33; #max_int_signed

	WHILE (id <= maxRows) DO
		SET randomNumber = FLOOR(1 + (RAND() * maxRandomNumber));
		INSERT INTO World(id, randomNumber) VALUES(id, randomNumber);
		SET id = id + 1;
	END WHILE;
END//

CALL SeedWorldTable();