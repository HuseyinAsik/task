# Task Api

## Database
For install database, there is a script for that inside Script folder. Just run this script.

## Connect to Database
For connect to database, there is a section which is called "DefaultConnection" inside appsetting.json. Just change this line with your connection string which is Task database is installed.

## Project Introduction
After connected to database, project will be open with swagger UI. This UI will include three endpoints:
 1) /api/Employee/region/{id}/employees for getting employees by region Id
 2) /api/Employee/employee for creating new employee
 3) /api/Region/region for creating new region
