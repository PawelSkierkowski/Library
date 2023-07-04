CREATE VIEW UserSummaryView AS
SELECT totalBooks.*,
       totalDays.totaldays
FROM   (SELECT u.[id]          AS UserId,
               u.[firstname],
               u.[lastname],
               u.[email],
               Count(t.bookid) AS TotalBooks
        FROM   [dbo].[user] u
               JOIN [dbo].[bookstaken] t
                 ON u.id = t.userid
        GROUP  BY u.id,
                  u.firstname,
                  u.lastname,
                  u.email) totalBooks
       LEFT JOIN (SELECT userid,
                         Abs(Sum(dayscount)) AS TotalDays
                  FROM   (SELECT t1.userid,
                                 t1.datetaken,
                                 t1.dateback,
                                 CASE
                                   WHEN t1.dateback > COALESCE(Greatest(
                                                      Max(t2.dateback),
                                                               t1.datetaken),
                                                      t1.datetaken) THEN
                                   Datediff(d, t1.dateback, COALESCE(
                                   Greatest(Max(t2.dateback), t1.datetaken),
                                 t1.datetaken))
                                   ELSE 0
                                 END AS daysCount
                          FROM   (SELECT u.[id]
                                         AS UserId
                                         ,
                                         t.bookid,
                                         t.datetaken,
                                         Isnull(Lead(datetaken)
                                                  OVER (
                                                    partition BY bookid
                                                    ORDER BY datetaken ASC),
                                         Getdate())
                                         AS
                                         DateBack
                                  FROM   [dbo].[user] u
                                         JOIN [dbo].[bookstaken] t
                                           ON u.id = t.userid
                                  GROUP  BY u.id,
                                            bookid,
                                            datetaken) t1
                                 LEFT JOIN (SELECT u.[id]
                                                   AS
                                                   UserId,
                                                   t.bookid,
                                                   t.datetaken,
                                                   Isnull(Lead(datetaken)
                                           OVER (
                                             partition BY bookid
                                             ORDER BY datetaken ASC),
                                                   Getdate())
                                                   AS
                                                   DateBack
                                            FROM   [dbo].[user] u
                                                   JOIN [dbo].[bookstaken] t
                                                     ON u.id = t.userid
                                            GROUP  BY u.id,
                                                      bookid,
                                                      datetaken) t2
                                        ON t1.userid = t2.userid
                                           AND ( t2.datetaken < t1.datetaken
                                                  OR t2.datetaken = t1.datetaken
                                                     AND t2.dateback <
                                                         t1.dateback )
                          GROUP  BY t1.userid,
                                    t1.datetaken,
                                    t1.dateback) detail
                  GROUP  BY userid) totalDays
              ON totalBooks.userid = totalDays.userid; 