# Pierre's Sweets and Treats

### Created by Noah Lundquist in October of 2022

## Links

* [Repository](https://github.com/nalundquist/PierreTreats)

## Description

Pierre is back and even more enthusiastic about gluten.  Interface for looking at delicious treats of many (to-many) flavors.  You can register as a user and gander at the goodies or login as Pierre himself and add/edit/delete entries at your leisure.  Note there is no seed data for treats and flavors so, uh, you actually have to login as pierre to see user functionality. 

## Features

* Login with role privileges
* As Admin add, delete, and modify treats and flavors
* As a user read all you'd like about said treats and flavors


## Technologies Used

* Built in VS Code (v.1.70.1) using the following languages:
	* C#
	* HTML
	* CSS

* ASP.Net Core
* MySQL Database
* MySQL Workbench
* Entity Framework

## Installation

* Download [Git Bash](https://git-scm.com/downloads)
* Input the following into Git Bash to clone this repository onto your computer:

		>git clone https://github.com/nalundquist/PierreTreats


* Enter the cloned project folder "/PierreTreats/PierreTreats" and type:

		>dotnet restore

followed by

		>dotnet build

*After this, create an appsettings.json file in the root /PierreTreats folder (sub in your own set username and password for the bracketed bits)

		{
  		"ConnectionStrings": {
      	"DefaultConnection": "Server=localhost;Port=3306;database=pierre_treats;uid=[USERNAME];pwd=[PASSWORD];"
  		}
		}

* next, type into console in the root directory:

		>dotnet ef database update

* Finally, navigate to the / directory in git bash (if you navigated away) and type  

		>dotnet run

Follwing this you can navigate to http://localhost:5000 in the browser of your choice to navigate around the interface.  

To log in as Pierre to modify the database use UserName: PierreIsBest | Password: 3cL@1r

## Known Bugs

Just figured out user roles and seeding in an administrator so there's some rough edges; for some reason Pierre's name, email and favorite food will not display despite being in the database.  In addition I did not route for denials of access so if you attempt to delete, edit or add without privileges you'll just bounce to a "Hello World" page.  

## License

Licensed under [GNU GPL 3.0](https://www.gnu.org/licenses/gpl-3.0.en.html)