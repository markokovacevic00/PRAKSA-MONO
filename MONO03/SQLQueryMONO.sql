DROP TABLE Car;
DROP TABLE Car_dealership;

CREATE TABLE Car_dealership(
    cd_ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    cd_Name varchar(255) NOT NULL,
);


CREATE TABLE Car (
    carId UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    carName varchar(255) NOT NULL,
	carPrice int NOT NULL,
	carMileage int CHECK (carMileage >10),
    carDealershipId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Car_dealership(cd_ID)
);





INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Toyota');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'BMW');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Škoda');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Ford');
INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (default, 'Mercedes-Benz');

SELECT * FROM Car_dealership;


INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Toyota Yaris',22000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Toyota'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Toyota Yaris+',23600, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Toyota'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Toyota Corolla',77000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Toyota'));

INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'BMW 116d',123000 ,(SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'BMW'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'BMW 330i',230000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'BMW'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'BMW M5 CS',840000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'BMW'));

INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default,'Ford Raptor',420000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Ford'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Ford X',135000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Ford'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Ford Mustang',460000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Ford'));


INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Mercedes-Benz A180',72000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Mercedes-Benz C200',160000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Mercedes-Benz E350',430000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));
INSERT INTO Car(carId, carName,carPrice,carDealershipId) VALUES (default, 'Mercedes-Benz AMG GT',1250000, (SELECT cd_ID FROM Car_dealership
WHERE cd_Name = 'Mercedes-Benz'));




-- Indeksi


SELECT *
FROM Car
INNER JOIN Car_dealership ON Car.carId = Car_dealership.cd_ID;




SELECT COUNT(Car.carId) AS "Number of Cars", cd_Name AS "Car Dealership"
FROM Car INNER JOIN Car_dealership ON Car.carId = Car_dealership.cd_ID
GROUP BY cd_Name
HAVING AVG(Car.carPrice) > 390000;



CREATE UNIQUE INDEX CD_INDEX
ON Car_dealership (cd_Name);


SELECT *
FROM Car_dealership WITH(INDEX(CD_INDEX));





SELECT * FROM Car;

UPDATE Car
SET carMileage = 100000
WHERE carName LIKE 'Ford%';


UPDATE Car
SET carMileage = 45000
WHERE carName LIKE 'Merc%';

UPDATE Car
SET carMileage = 40000
WHERE carName LIKE 'BMW%';

UPDATE Car
SET carMileage = 90
WHERE carName LIKE 'Toyota%';

SELECT Car.carName AS "Car name", Car.carMileage "Car Mileage", Car.carId AS "Car dealership ID"
FROM Car
LEFT JOIN Car_dealership
ON Car.carId = Car_dealership.cd_ID
WHERE Car.carMileage <50000;



