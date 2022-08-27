CREATE TABLE Administrator
(
AdminId int IDENTITY(1,1) PRIMARY KEY,
AdminFirstName varchar(20) NOT NULL,
AdminLastName varchar(20) NOT NULL,
AdminPhoneNo varchar(15) NOT NULL,
Email varchar(20) NOT NULL,
Password varchar(20) NOT NULL
);


CREATE TABLE Doctor
(
DoctorId int IDENTITY(1,1) PRIMARY KEY,
DoctorFirstName varchar(50) NOT NULL,
DoctorLastName varchar(20) NOT NULL,
Specialize varchar(20) NOT NULL,
DoctorPhoneNo varchar(15) NOT NULL,
Email varchar(20) NOT NULL,
Password varchar(20) NOT NULL
);


CREATE TABLE Patient
(
PatientId int IDENTITY(1,1) PRIMARY KEY,
PatientFirstName varchar(20) NOT NULL,
PatientLastName varchar(20) NOT NULL,
PatientPhoneNo varchar(15) NOT NULL,
Email varchar(20) NOT NULL,
Password varchar(20) NOT NULL
);

