Feature: Mixed Operations

    Scenario: I can track multi operations
        Given I created the default database
        And the 'dbo.Users' has '10' rows
        When I execute "INSERT INTO dbo.Users(FullName, CreatedDate) VALUES('Name 11', '2023-03-19 03:06:33.227');"
        And I execute "UPDATE dbo.Users SET FullName = 'Name 5555' WHERE FullName = 'Name 5';"
        And I execute "DELETE dbo.Users WHERE FullName = 'Name 3';"
        Then the 'dbo.Users' has '10' rows
        And Transaction logs in the last 5 min should be
          | ObjectName    | Operation       | Type | RedoSQL                                                                                                                                                                                  | UndoSQL                                                                                                                                                                              |
          | [dbo].[Users] | LOP_INSERT_ROWS | DML  | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(1002,N'Name 11','2023-03-19 03:06:33.227'); set identity_insert [dbo].[Users] off; | delete top(1) from [dbo].[Users] where [Id]=1002 and [FullName]=N'Name 11' and [CreatedDate]='2023-03-19 03:06:33.227';                                                              |
          | [dbo].[Users] | LOP_MODIFY_ROW  | DML  | update top(1) [dbo].[Users] set [FullName]=N'Name 5555' where [Id]=5 and [FullName]=N'Name 5' and [CreatedDate]='2023-03-14 04:08:39.547';                                               | update top(1) [dbo].[Users] set [FullName]=N'Name 5' where [Id]=5 and [FullName]=N'Name 5555' and [CreatedDate]='2023-03-14 04:08:39.547';                                           |
          | [dbo].[Users] | LOP_DELETE_ROWS | DML  | delete top(1) from [dbo].[Users] where [Id]=3 and [FullName]=N'Name 3' and [CreatedDate]='2023-03-14 04:08:37.103';                                                                      | set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[CreatedDate]) values(3,N'Name 3','2023-03-14 04:08:37.103'); set identity_insert [dbo].[Users] off; |