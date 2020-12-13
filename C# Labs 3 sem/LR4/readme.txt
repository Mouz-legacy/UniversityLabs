This application takes files from a database that was personally designed by me. 
The database contains 5 tables. 
The dll library DbEssense was written to transfer data from the database to the intermediate class. 
Then, a dll called ServiceLayer was written for parsing data into xml.
A method PushToFtp was written to transfer data to the ftp service. 
The corresponding interfaces for the DLL have been implemented (ISerializer and IValidator). 
All operations with queries to the database are stored as methods written in C #.