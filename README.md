# Care when using SQL DateTime in .NET Projects with Entity Framework

I saw this weird behaviour in .NET when querying the database based on a .NET DateTime property which Entity Framework was mapping to a SQL DateTime. Here is the database (CreatedDates & Modified will be different for you if run application uses DateTime.Now)

# Database 
# Blogs
![Image of Blogs DB](https://github.com/mh453Uol/.NET-DateTime-And-Sql-DateTime-Issues/blob/master/BlogsImg.PNG)

# Posts
![Image of Posts DB](https://github.com/mh453Uol/.NET-DateTime-And-Sql-DateTime-Issues/blob/master/PostsImg.PNG) 
```
using(var context = new DatabaseContext())
{
	//Get the first blog from the database which is Majid Blog
  var blog = context.Blogs.First(); 

		
	//Returns 0 records!!. We find a record where the 
  //createdDate is equal to the blog createdDate. This should return a record however it doesn’t due to precision.
  var blogByCreatedDate = context.Blogs
      .Where(b => b.CreatedDate == blog.CreatedDate)
      .ToList();
}
```
# Why this happenns
Were using SQL DateTime, and from documentation it has:
Accuracy: Rounded to increments of .000, .003, or .007 seconds

So the accuracy is rounded.

Where as .NET DateTime has a precision of 100ns.

So .NET DateTime is more precise here is picture. 

![Image of Precision](https://github.com/mh453Uol/.NET-DateTime-And-Sql-DateTime-Issues/blob/master/Precision.png) 

  
# How to fix this issue

The reason why this is happen is due to precision. Please use datetime2 which has a larger date range, a larger default fractional precision, and optional user-specified precision. It has the same precision of .NET DateTime. Also SQL recommend using “the time, date, datetime2 and datetimeoffset data types for new work”.

# What if I can’t change the datatype to datetime2

If you want to have the nice and clean option of doing the followings 
```
.Where(b => b.CreatedDate == blog.CreatedDate)
```

1.	You can remove the millisecond from your .NET Datetime before persisting the record in the database. Please see [Here](https://github.com/mh453Uol/.NET-DateTime-And-Sql-DateTime-Issues/blob/master/TrucatingDateTime/TruncateDateTime.cs) for a handy extension method to remove milliseconds.

2.  
```
var blog = context.Blogs.Where(b =>
                    (b.CreatedDate.Year == createdDate.Year
                    && b.CreatedDate.Month == createdDate.Month
                    && b.CreatedDate.Day == createdDate.Day
                    && b.CreatedDate.Hour == createdDate.Hour
                    && b.CreatedDate.Minute == createdDate.Minute
                    && b.CreatedDate.Second == createdDate.Second))
                    .FirstOrDefault();//May find more than one record
```
Code looks messy having option of a.CreatedDate == b.CreateDate reads better.

All in all it’s best to use SQL datetime2 it has more precision.

# Setup example locally
1. Clone repo.
2. Open in visual studio.
3. Open package manager and type update-database this will create the database and add dummy data. Change connection string in Context if you are having issues.
4. Run 

Thanks!
	


