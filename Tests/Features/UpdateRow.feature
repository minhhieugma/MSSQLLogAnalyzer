Feature: Update Row

Scenario: I can track updating a single row
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "UPDATE dbo.Users SET FullName = 'Name 5555' WHERE FullName = 'Name 5';"
	Then the 'dbo.Users' has '10' rows
	And Transaction logs in the last 5 min should be
	| ObjectName    | Operation      | Type | RedoSQL                                                                                                                                    | UndoSQL                                                                                                                                    |
	| [dbo].[Users] | LOP_MODIFY_ROW | DML  | update top(1) [dbo].[Users] set [FullName]=N'Name 5555' where [Id]=5 and [FullName]=N'Name 5' and [CreatedDate]='2023-03-14 04:08:39.547'; | update top(1) [dbo].[Users] set [FullName]=N'Name 5' where [Id]=5 and [FullName]=N'Name 5555' and [CreatedDate]='2023-03-14 04:08:39.547'; |

Scenario: I can track updating two rows
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "UPDATE dbo.Users SET FullName = 'Name 5555' WHERE FullName = 'Name 5';"
		And I execute "UPDATE dbo.Users SET FullName = 'Name 6666' WHERE FullName = 'Name 6';"
	Then the 'dbo.Users' has '10' rows
	And Transaction logs in the last 5 min should be
	| ObjectName    | Operation      | Type | RedoSQL                                                                                                                                    | UndoSQL                                                                                                                                    |
	| [dbo].[Users] | LOP_MODIFY_ROW | DML  | update top(1) [dbo].[Users] set [FullName]=N'Name 5555' where [Id]=5 and [FullName]=N'Name 5' and [CreatedDate]='2023-03-14 04:08:39.547'; | update top(1) [dbo].[Users] set [FullName]=N'Name 5' where [Id]=5 and [FullName]=N'Name 5555' and [CreatedDate]='2023-03-14 04:08:39.547'; |
	| [dbo].[Users] | LOP_MODIFY_ROW | DML  | update top(1) [dbo].[Users] set [FullName]=N'Name 6666' where [Id]=6 and [FullName]=N'Name 6' and [CreatedDate]='2023-03-14 04:08:40.927'; | update top(1) [dbo].[Users] set [FullName]=N'Name 6' where [Id]=6 and [FullName]=N'Name 6666' and [CreatedDate]='2023-03-14 04:08:40.927'; |

Scenario: I can track update statement when I use like condition to filter a single row
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "UPDATE dbo.Users SET FullName = 'Name 5555' WHERE FullName LIKE '%Name 5%';"
	Then the 'dbo.Users' has '10' rows
	And Transaction logs in the last 5 min should be
	| ObjectName    | Operation      | Type | RedoSQL                                                                                                                                    | UndoSQL                                                                                                                                    |
	| [dbo].[Users] | LOP_MODIFY_ROW | DML  | update top(1) [dbo].[Users] set [FullName]=N'Name 5555' where [Id]=5 and [FullName]=N'Name 5' and [CreatedDate]='2023-03-14 04:08:39.547'; | update top(1) [dbo].[Users] set [FullName]=N'Name 5' where [Id]=5 and [FullName]=N'Name 5555' and [CreatedDate]='2023-03-14 04:08:39.547'; |

Scenario: I can track update statement when the where statement takes multi rows
	Given I created the default database
	And the 'dbo.Users' has '10' rows
	When I execute "UPDATE dbo.Users SET FullName = FullName + ' Updated' WHERE FullName = 'Name 5' OR FullName = 'Name 6';"
	Then the 'dbo.Users' has '10' rows
	And Transaction logs in the last 5 min should be
	| ObjectName    | Operation      | Type | RedoSQL                                                                                                                                         | UndoSQL                                                                                                                                         |
	| [dbo].[Users] | LOP_MODIFY_ROW | DML  | update top(1) [dbo].[Users] set [FullName]=N'Name 6 Updated' where [Id]=6 and [FullName]=N'Name 6' and [CreatedDate]='2023-03-14 04:08:40.927'; | update top(1) [dbo].[Users] set [FullName]=N'Name 6' where [Id]=6 and [FullName]=N'Name 6 Updated' and [CreatedDate]='2023-03-14 04:08:40.927'; |
	| [dbo].[Users] | LOP_MODIFY_ROW | DML  | update top(1) [dbo].[Users] set [FullName]=N'Name 5 Updated' where [Id]=5 and [FullName]=N'Name 5' and [CreatedDate]='2023-03-14 04:08:39.547'; | update top(1) [dbo].[Users] set [FullName]=N'Name 5' where [Id]=5 and [FullName]=N'Name 5 Updated' and [CreatedDate]='2023-03-14 04:08:39.547'; |
	