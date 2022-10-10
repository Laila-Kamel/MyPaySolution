# MyPaySolution
## Project Description
This application class reads the records of employees from a csv file and create a list of details for employee. A pay record class  with two child classes (residentPayRecord and WorkingHolidayPayRecord) receives the employees record from the csvImporter and calculates taxes for each type of employee depending on the type either resident employee or working holiday employee. After calculation of the tax, net and gross for each employee, these details are printed on the console as well written in a csv files.
## NUnit Test
Test methods added:
- _records field is not null and contains five objects
-	Gross amount calculated for each employee is correct
-	Tax amount calculated for each employee is correct
-	Net amount calculated for each employee is correct
-	writer successfully writes a file to the export folder by checking if the file exists.
