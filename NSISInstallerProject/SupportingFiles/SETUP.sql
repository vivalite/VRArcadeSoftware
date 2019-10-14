CREATE USER 'vrarcade'@'localhost' IDENTIFIED BY 'vrarcade';
CREATE DATABASE vrarcade;
GRANT ALL ON vrarcade.* TO 'vrarcade'@'localhost' IDENTIFIED BY 'vrarcade' WITH GRANT OPTION; 
FLUSH PRIVILEGES;