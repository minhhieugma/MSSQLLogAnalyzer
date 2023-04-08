Feature: Delete Row

Scenario: I can track deleting a single row
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "DELETE dbo.Users WHERE FullName = 'Name 5';"
	Then the 'dbo.Users' has '9' rows
	And Transaction logs in the last 5 min should be
	| ObjectName    | Operation       | Type | RedoSQL                                                                                                             | UndoSQL                                                                                                                                                                              |
	| [dbo].[Users] | LOP_DELETE_ROWS | DML  | delete top(1) from [dbo].[Users] where [Id]=5 and [FullName]=N'Name 5' and [CreatedDate]='2023-03-14 04:08:39.547'; | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(5,N'Name 5','2023-03-14 04:08:39.547'); set identity_insert [dbo].[Users] off; |
	

Scenario: I can track deleting two rows
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "DELETE dbo.Users WHERE FullName = 'Name 5';"
	When I execute "DELETE dbo.Users WHERE FullName = 'Name 6';"
	Then the 'dbo.Users' has '8' rows
	And Transaction logs in the last 5 min should be
	| ObjectName    | Operation       | Type | RedoSQL                                                                                                             | UndoSQL                                                                                                                                                                              |
	| [dbo].[Users] | LOP_DELETE_ROWS | DML  | delete top(1) from [dbo].[Users] where [Id]=5 and [FullName]=N'Name 5' and [CreatedDate]='2023-03-14 04:08:39.547'; | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(5,N'Name 5','2023-03-14 04:08:39.547'); set identity_insert [dbo].[Users] off; |
	| [dbo].[Users] | LOP_DELETE_ROWS | DML  | delete top(1) from [dbo].[Users] where [Id]=6 and [FullName]=N'Name 6' and [CreatedDate]='2023-03-14 04:08:40.927'; | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(6,N'Name 6','2023-03-14 04:08:40.927'); set identity_insert [dbo].[Users] off; |
