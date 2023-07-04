CREATE VIEW BooksSearchView AS
SELECT 
	b.[ID] as Id
   ,b.[Title]
   ,b.[Description]
   ,b.[AuthorID] as AuthorId
   ,a.[FirstName] as AuthorFirstName
   ,a.[MiddleName] as AuthorMiddleName
   ,a.[LastName] as AuthorLastName
   ,t.[UserID] as UserId
   ,u.[FirstName] as UserFirstName
   ,u.[LastName] as UserLastName
   ,u.[Email] as UserEmail	
FROM Book b
  INNER JOIN [Author] a ON a.ID = b.AuthorID
  LEFT JOIN [BooksTaken] t ON t.BookID = b.ID
  LEFT JOIN [User] u ON u.ID = t.UserID
GROUP BY t.UserID 	
   ,b.[ID]
   ,b.[Title]
   ,b.[Description]
   ,b.[AuthorID]
   ,a.[FirstName]
   ,a.[MiddleName]
   ,a.[LastName]
   ,t.[UserID]
   ,u.[FirstName]
   ,u.[LastName]
   ,u.[Email];