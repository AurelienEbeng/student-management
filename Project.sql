USE master;
GO
ALTER DATABASE[College1en]
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE[College1en];
GO

--Creating the database
IF db_id('College1en') IS NULL CREATE DATABASE College1en;
GO

USE College1en;
GO
 
-- Creating the Programs table 
CREATE TABLE programs
(
    progId VARCHAR(5) NOT NULL ,
    progName VARCHAR(50) NOT NULL,
	Constraint pk_programs PRIMARY KEY(progId)
);






-- Creating the courses table with foreign key
CREATE TABLE courses
(
    cId VARCHAR(7) NOT NULL ,
    cName VARCHAR(50) NOT NULL,
    progId VARCHAR(5) NOT NUll,
    Constraint pk_courses PRIMARY KEY(cId),
    Constraint fk_courses_prog FOREIGN KEY (progId) REFERENCES programs(progId)
    on delete cascade on update cascade
   --foreign key in courses from programs
);








-- Creating the students table with foreign key
CREATE TABLE students
(
    stId VARCHAR(10) NOT NULL ,
    stName VARCHAR(50) NOT NULL,
    progId VARCHAR(5) NOT NUll,
    Constraint pk_students PRIMARY KEY(stId),
    Constraint fk_students_prog FOREIGN KEY (progId) REFERENCES programs(progId)
    on delete no action on update cascade 
);





-- Creating the enrollments table without foreign key
CREATE TABLE enrollments
(
    stId VARCHAR(10) NOT NULL ,
    cId VARCHAR(7) NOT NULL,
    finalGrade INT,
    Constraint pk_enrollments PRIMARY KEY(stId,cId),
    Constraint fk_enroll_stud FOREIGN KEY (stId) REFERENCES students(stId)
    on delete cascade on update cascade,
    Constraint fk_enroll_courses FOREIGN KEY (cId) REFERENCES courses(cId)
    on delete no action on update no action 
);


INSERT INTO programs (progId,progName)
VALUES
	('P0001','Programming'),
	('P0002','Game Development'),
	('P0003','Business');


INSERT INTO courses(cId,cName,progId)
VALUES
	('C000001','C#','P0001'),
	('C000002','Java','P0001'),
	('C000003','Unity Engine','P0002'),
	('C000004','Unreal Engine','P0002'),
	('C000005','Communication','P0003'),
	('C000006','Management','P0003');



INSERT INTO students(stId,stName,progId)
VALUES
	('S000000001','Albert','P0001'),
	('S000000002','Gena','P0002'),
	('S000000003','Merriam','P0003'),
	('S000000004','Roberto','P0001'),
	('S000000005','Louise','P0002'),
	('S000000006','Marima','P0003'),
	('S000000007','Bertrand','P0001'),
	('S000000008','Tania','P0002'),
	('S000000009','Clara','P0003');




INSERT INTO enrollments(stId,cId,finalGrade)
VALUES
	('S000000001','C000001',NULL),
	('S000000002','C000003',NULL),
	('S000000003','C000005',NULL),
	('S000000004','C000002',NULL),
	('S000000005','C000004',NULL),
	('S000000006','C000006',NULL),
	('S000000007','C000001',NULL),
	('S000000008','C000003',NULL),
	('S000000009','C000005',NULL);







 
