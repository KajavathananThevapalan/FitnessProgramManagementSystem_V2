create database FitnessPrograms;
use FitnessPrograms;

create table FitnessPrograms(
  FitnessProgramId  Primary Key  ,
  Title varchar(20),
  Duration varchar(20),
  Price Decimal
);

insert into FitnessPrograms (FitnessProgramId,Title,Duration,Price)values(1,'weight Training','6 months',10);  