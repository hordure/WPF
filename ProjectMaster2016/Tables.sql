drop database projectmaster;	
	
create database projectmaster;	
	
create table zipcodes	
(	
	zip int primary key,
	place varchar(255) not null
);	
	
create table employee	
(	
	eid int primary key identity,
	name varchar(255) not null,
	email varchar(255) not null,
	homeaddress varchar(255) not null,
	zip int foreign key references zipcodes(zip),
	phone varchar(255) not null,
	img varbinary(max)
);	
	
create table project	
(	
	pid int primary key identity,
	projectname varchar(255) not null,
	employee_eid int foreign key references employee(eid),
	pdescription varchar(255) not null,
	pdate datetime not null,
	projectdeadline datetime,
	projectisfinished bit  not null default 0
);	
	
create table project_hours	
(	
	project_pid int foreign key references project(pid),
	employee_eid int foreign key references employee(eid),
	hourdescription varchar(255) not null,
	hourdate datetime not null,
	hourtimestamp datetime not null,
	workhour decimal not null,
	phid int primary key identity
);	
	
create table project_messages	
(	
	project_pid int foreign key references project(pid),
	employee_eid int foreign key references employee(eid),
	projectmessage varchar(255) not null,
	messagetimestamp datetime not null,
	pmid int primary key identity
);	
	
create table project_costs	
(	
	project_pid int foreign key references project(pid),
	employee_eid int foreign key references employee(eid),
	costdescription varchar(255) not null,
	costdate datetime not null,
	costtimestamp datetime not null,
	cost int not null,
	pcid int primary key identity
);	

create table project_employees
(
	peid int primary key identity,
	project_pid int foreign key references project(pid),
	employee_eid int foreign key references employee(eid)
);