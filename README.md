# Links Dashboard

Link Dashboard with .NET” stands as a core entry in my portfolio—a practical solution for efficient bookmark management.

## Overview: 
I’ve developed this dashboard using MySQL, .NET MVC, Razor Pages, Docker Compose, jQuery, and session authentication.

## Key Features

*User Authentication:* Securely log in, register, and manage sessions for a personalized experience.
*Bookmark Operations:* Easily add, delete, and edit bookmarks based on your preferences.
*Category Management:* Efficiently organize bookmarks by editing existing category names.
*Intuitive Interface:* Streamlined functionalities ensure a seamless user experience.
*Live Demo:- Explore the live demo on the following link. Please note, due to its origin as a part of my final semester project, the codebase isn’t publicly available.

## Folder Structure
This follows a .NET standard MVC Pattern. Consist of the following models: Categories, Links and Users. User admin has special permissions to add, delete, and edit links and categories. Nonadmin and non-registered users can only observe these links and categories.

## How to install
- Modify and run the docker-compose using Docker
- make sure that you have the following environment variables


```
MYSQL_ROOT_PASSWORD=
MYSQL_DATABASE=
MYSQL_USER=
MYSQL_PASSWORD=
MYSQL_HOST=
MYSQL_PORT= 
DB_CONNECTION_STRING=
DB_CONNECTION_STRING_PROD=
```



Please check the demo of this app running: https://links-dashboard.nicolas-castellano.com/
Also check my blog entry: https://nicolas-castellano.com/portfolio/link-dashboard-with-net/
