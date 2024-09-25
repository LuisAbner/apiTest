use Libreria;
create table users(
	id_user int IDENTITY(1,1) PRIMARY KEY,
	username nvarchar(150) not null,
	password_us nvarchar(max) not null,
	role_id int FOREIGN KEY REFERENCES roles(id_role)
)

create table roles (
	id_role int IDENTITY(1,1) PRIMARY KEY,
	role nvarchar(150) not null,
)
create table genders (
	id_gender int IDENTITY(1,1) PRIMARY KEY,
	gender varchar(150) not null,
	estatus bit not null 
)

create table author(
	id_author int IDENTITY(1,1) PRIMARY KEY,
	author varchar(150) not null
)

create table book (
	id_book int IDENTITY(1,1) PRIMARY KEY,
	book_name varchar(150) not null,
	page int not null,
	author_id int FOREIGN KEY REFERENCES author(id_author)
)

create table book_gender(
	id_book_gender int IDENTITY(1,1) PRIMARY KEY,
	book_id int FOREIGN KEY REFERENCES book(id_book),
	gender_id int FOREIGN KEY REFERENCES genders(id_gender)
)

 

 select * from users u inner join roles r on u.role_id = r.id_role  ;
 

