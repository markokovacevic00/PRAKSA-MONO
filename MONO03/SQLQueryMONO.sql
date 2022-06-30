DROP TABLE Car;
DROP TABLE Car_dealership;

CREATE TABLE Car_dealership(
    cd_ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    cd_Name varchar(255) NOT NULL,
);


CREATE TABLE Car (
    cID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    cname varchar(255) NOT NULL,
	cPrice int NOT NULL,
    cd_ID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Car_dealership(cd_ID)
);





INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Toyota');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'BMW');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Škoda');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Ford');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Mercedes-Benz');

SELECT * FROM Car;


INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Toyota Yaris',22000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Toyota'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Toyota Yaris+',23600, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Toyota'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Toyota Corolla',77000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Toyota'));

INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'BMW 116d',123000 ,(SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'BMW'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'BMW 330i',230000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'BMW'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'BMW M5 CS',840000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'BMW'));

INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default,'Ford Raptor',420000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Ford'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Ford X',135000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Ford'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Ford Mustang',460000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Ford'));


INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Mercedes-Benz A180',72000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Mercedes-Benz C200',160000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Mercedes-Benz E350',430000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));
INSERT INTO Car(cID, cName,cPrice,cd_ID) VALUES (default, 'Mercedes-Benz AMG GT',1250000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));




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




