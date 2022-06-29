DROP TABLE Car;
DROP TABLE Car_dealership;

CREATE TABLE Car_dealership(
    cd_ID int NOT NULL PRIMARY KEY,
    cd_Name varchar(255) NOT NULL,
);


CREATE TABLE Car (
    cID int NOT NULL PRIMARY KEY,
    cname varchar(255) NOT NULL,
	cPrice int NOT NULL,
    cd_ID int FOREIGN KEY REFERENCES Car_dealership(cd_ID)
);






INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (1, 'Toyota');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (2, 'BMW');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (3, 'Škoda');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (4, 'Ford');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (5, 'Mercedes-Benz');


INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (5, 'Toyota Yaris',22000, 1);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (6, 'Toyota Yaris+',23600, 1);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (7, 'Toyota Corolla',77000, 1);

INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (8, 'BMW 116d',123000 ,2);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (9, 'BMW 330i',230000, 2);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (10, 'BMW M5 CS',840000, 2);

INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (11,'Ford Raptor',420000, 4);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (12, 'Ford X',135000, 4);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (13, 'Ford Mustang',460000, 4);


INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (1, 'Mercedes-Benz A180',72000, 5);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (2, 'Mercedes-Benz C200',160000, 5);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (3, 'Mercedes-Benz E350',430000, 5);
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (4, 'Mercedes-Benz AMG GT',1250000, 5);




-- Indeksi


SELECT cID, cname, cPrice
FROM Car
INNER JOIN Car_dealership ON Car.cd_ID = Car_dealership.cd_ID
WHERE Car_dealership.cd_Name = 'Mercedes-Benz' AND Car.cPrice > 100000;



SELECT COUNT(Car.cd_ID) AS "Number of Cars", cd_Name AS "Car Dealership"
FROM Car INNER JOIN Car_dealership ON Car.cd_ID = Car_dealership.cd_ID
GROUP BY cd_Name
HAVING AVG(Car.cPrice) > 390000;


SELECT Car.cname AS "Car name", Car.cMileage "Car Mileage", Car.cd_ID AS "Car dealership ID"
FROM Car
LEFT JOIN Car_dealership
ON Car.cID = Car_dealership.cd_ID
WHERE Car.cMileage <50000;





CREATE UNIQUE INDEX CD_INDEX
ON Car_dealership (cd_Name);


SELECT *
FROM Car_dealership WITH(INDEX(CD_INDEX));


ALTER TABLE Car
ADD cMileage int CHECK (cMileage >10);


SELECT * FROM Car;

UPDATE Car
SET cMileage = 100000
WHERE cname LIKE 'Ford%';


UPDATE Car
SET cMileage = 45000
WHERE cname LIKE 'Merc%';

UPDATE Car
SET cMileage = 40000
WHERE cname LIKE 'BMW%';

UPDATE Car
SET cMileage = 90
WHERE cname LIKE 'Toyota%';




