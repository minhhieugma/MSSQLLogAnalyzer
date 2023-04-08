Feature: Insert Row

Scenario: I can track inserting a single row
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "INSERT INTO dbo.Users(FullName, CreatedDate) VALUES('Name 11', '2023-03-19 03:06:33.227');"
	Then the 'dbo.Users' has '11' rows
	And Transaction logs in the last 5 min should be
	|  ObjectName    | Operation       | Type | RedoSQL                                                                                                                                                                                  | UndoSQL                                                                                                                 |
	| [dbo].[Users] | LOP_INSERT_ROWS | DML  | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(1002,N'Name 11','2023-03-19 03:06:33.227'); set identity_insert [dbo].[Users] off; | delete top(1) from [dbo].[Users] where [Id]=1002 and [FullName]=N'Name 11' and [CreatedDate]='2023-03-19 03:06:33.227'; |

Scenario: I can track inserting two rows
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "INSERT INTO dbo.Users(FullName, CreatedDate) VALUES('Name 11', '2023-03-19 03:06:33.227');"
		 And I execute "INSERT INTO dbo.Users(FullName, CreatedDate) VALUES('Name 12', '2023-03-19 03:06:33.227');"
	Then the 'dbo.Users' has '12' rows
	And Transaction logs in the last 5 min should be
	| ObjectName    | Operation       | Type | RedoSQL                                                                                                                                                                                  | UndoSQL                                                                                                                 |
	| [dbo].[Users] | LOP_INSERT_ROWS | DML  | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(1002,N'Name 11','2023-03-19 03:06:33.227'); set identity_insert [dbo].[Users] off; | delete top(1) from [dbo].[Users] where [Id]=1002 and [FullName]=N'Name 11' and [CreatedDate]='2023-03-19 03:06:33.227'; |
	| [dbo].[Users] | LOP_INSERT_ROWS | DML  | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(1003,N'Name 12','2023-03-19 03:06:33.227'); set identity_insert [dbo].[Users] off; | delete top(1) from [dbo].[Users] where [Id]=1003 and [FullName]=N'Name 12' and [CreatedDate]='2023-03-19 03:06:33.227'; |
