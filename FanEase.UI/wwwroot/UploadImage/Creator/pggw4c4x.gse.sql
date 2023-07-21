
--UseDataBase

use  FanEase



--SP AddUser [Done]
Create procedure [dbo].[AddUser]  
(  
  @UserId varchar(6),
   @profilePhoto varchar (Max),  
   @videoCount  int,
   @address varchar (Max),
   @city varchar (Max),
   @country varchar (Max),
   @email  varchar (Max),
   @contactNo varchar (10),
   @isActive bit,
   @creationDate datetime,
   @userName varchar (Max),
   @password varchar (Max),
   @FirstName varchar (Max), 
   @LastName varchar (Max)
)  
as 

begin 
SET @UserId = LEFT(@FirstName, 1) + LEFT(@LastName, 1) + RIGHT(@contactNo, 4);
   Insert into Users 
   values(@UserId,@profilePhoto,@videoCount,@address,@city,@country, @email,@contactNo,@isActive,@creationDate,@userName,@password,@FirstName,@LastName)
End



--Get AllUserList [Done]

Create Procedure [dbo].[GetUserList]  
as  
begin  
   select * from Users
End



--Get UserById [Done]

CREATE PROCEDURE [dbo].[GetUserById]
    @USERID varchar(6)
AS
BEGIN
    DECLARE @USER_ID varchar(6) = @USERID; -- Declare and assign the value to the variable
    
    SELECT FirstName, LastName, videoCount, address, city, country, email, contactNo, isActive, creationDate, userName, [password]
    FROM Users
    WHERE UserId = @USER_ID;
END;



--Alter GetUserById 
ALTER PROCEDURE [dbo].[GetUserById]
    @Id varchar(6)
AS
BEGIN
    DECLARE @USER_ID varchar(6) = @Id; -- Declare and assign the value to the variable
    
    SELECT FirstName, LastName, videoCount, address, city, country, email, contactNo, isActive, creationDate, userName, [password]
    FROM Users
    WHERE UserId = @USER_ID;
END;



--GetUserByUserName
CREATE PROCEDURE [dbo].[GetUserByUserName]
    @UsertName varchar(max)
AS
BEGIN 
    SELECT *
    FROM Users
    WHERE userName = @UsertName;
END;




--Update User [done]


CREATE PROCEDURE [dbo].[UpdateUser]  
(  
   @UserId varchar(6),  
   @profilePhoto varchar(Max),  
   @FirstName varchar(Max),  
   @LastName varchar(Max),
   @videoCount int, 
   @address varchar(Max),
   @country varchar(Max),
   @city varchar(Max),
   @email varchar(Max),
   @contactNo varchar(10),
   @isActive bit,
   @creationDate datetime,
   @userName varchar(Max),
   @password varchar(Max) 
)  
AS  
BEGIN  
   UPDATE Users   
   SET profilePhoto = @profilePhoto, 
       FirstName = @FirstName,
       LastName = @LastName,
       videoCount = @videoCount,
       address = @address,
	   country = @country,
       city = @city,
       email = @email,
       contactNo = @contactNo,
       isActive = @isActive,
       creationDate = @creationDate,
       userName = @userName,
       [password] = @password 
   WHERE UserId = @UserId;
END



--Delete User [done]

CREATE PROCEDURE [dbo].[DeleteUser]
(
   @UserId varchar(6)
)
AS
BEGIN
   DELETE FROM Users WHERE UserId = @UserId;
END;



--Create Stored Procedure GetUserByUserName

CREATE PROCEDURE [dbo].[GetUserByUserName]
    @USERNAME varchar(max)
AS
BEGIN
    DECLARE @USER_NAME varchar(MAX) = @USERNAME; -- Declare and assign the value to the variable
    
    SELECT UserId,FirstName, LastName, videoCount, [address], city, country, email, contactNo, isActive, creationDate, [password]
    FROM Users
    WHERE UserName = @USER_NAME;
END;


EXEC GetUserByUserName @UserName = 'atul@gmail.com';


--Create procedure GetuserRoleSP

CREATE PROCEDURE [dbo].[GetUserRoleSP]
    @USERNAME varchar(max)
AS
BEGIN
    

    SELECT UserId,FirstName, LastName, videoCount, [address], city, country, email, contactNo, isActive, creationDate, [password]
    FROM Users
    WHERE UserName = @USERNAME;
END;


--ResetPassword:Stored procedure to reset password 

CREATE PROCEDURE SETPASSWORD
@USERNAME varchar(max),
@PASSWORD varchar(max)
AS
BEGIN
Update Users Set password=@PASSWORD where userName=@USERNAME;
END

CREATE PROCEDURE RESETPASSWORD
@USERNAME varchar(max),
@NEWPASSWORD varchar(max),
@OLDPASSWORD varchar(max)
AS
BEGIN
Update Users set password=@NEWPASSWORD where userName=@USERNAME and password=@NEWPASSWORD;
END







--Drop StoredProcedure

use FanEase
DROP PROCEDURE AddUser;
DROP PROCEDURE DeleteStudent,GetUserById,GetUserList,UpdateUser;
DROP PROCEDURE GenerateUserId;
