insert into project_hours (project_pid, employee_eid, hourdescription, hourdate, hourtimestamp, workhour) values	
	(1, 2 , 'var að skúra', '2015-05-18',  '2014-06-18 10:34:09', 3),
	(1, 2 , 'var að skúra', '2015-05-19',  '2014-06-18 10:34:09', 8),
	(1, 2 , 'var að skúra', '2015-05-20',  '2014-06-18 10:34:09', 3),
	(2, 3 , 'Mála', '2015-04-18',  '2014-06-18 10:34:09', 4),
	(2, 3 , 'Mála', '2015-04-19',  '2014-06-18 10:34:09', 4),
	(2, 3 , 'Mála', '2015-04-20',  '2014-06-18 10:34:09', 4),
	(2, 3 , 'Mála', '2015-04-25',  '2014-06-18 10:34:09', 4)
	
insert into project_messages (project_pid, employee_eid, projectmessage, messagetimestamp) values	
	(1, 1, 'Where did you put the hammer?', '2014-11-19'),
	(1, 3, 'Dont forget to leave in the evening.', '2015-01-20'),
	(2, 3, 'Whose f*ing dog is always at the door?', '2015-03-07'),
	(2, 2, 'What does the fox say?', '2015-05-05')
	
insert into project_costs (project_pid, employee_eid, costdescription, costdate, costtimestamp, cost) values	
	(1, 1, '2 buckets of paint', '2014-11-19', '2014-11-20', 5000),
	(1, 2, '1 shovel', '2015-01-20', '2015-01-25', 2800),
	(1, 3, 'Laptop', '2015-03-08', '2015-03-15', 84900),
	(2, 3, 'Coffeebeans', '2015-05-05', '2015-05-21', 1400)

insert into project_employees (project_pid, employee_eid) values	
	(1, 2),
	(1, 1),
	(2,4),
	(2,5),
	(2,6),
	(3,2),
	(3,3),
	(4,4)
