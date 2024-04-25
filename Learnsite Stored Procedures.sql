--use Learnsite;

--User Table

CREATE PROCEDURE spGetAllUsers
AS
BEGIN
	SELECT UserID, FirstName, LastName, Email, Role
	FROM tblUser
	WHERE Status = 'Active';
END
Go;

CREATE PROCEDURE spGetUserById
	@UserID int
AS
BEGIN
	SELECT FirstName, LastName, Email, Role
	FROM tblUser
	WHERE UserID = @UserID;
END
Go;

CREATE PROCEDURE spInsertUser
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(255),
	@Password NVARCHAR(255),
	@Role NVARCHAR(10),
	@Status NVARCHAR(11)
AS
BEGIN
	INSERT INTO tblUser(FirstName, LastName, Email, Password, Role, Status)
	VALUES(@FirstName, @LastName, @Email, @Password, @Role, @Status);
END
Go;

EXEC spInsertUser 'Tshiamo', 'Mothokho', 'admin@learnsite.ac.za', 'admin1234', 'Admin', 'Active'

CREATE PROCEDURE spUpdateUser
	@UserID INT, 
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Password NVARCHAR(255)
AS
BEGIN
	UPDATE tblUser
	SET FirstName = @FirstName, LastName = @LastName, Password = @Password
	WHERE UserID = @UserID;
END
Go;

CREATE PROCEDURE spDeleteUser
	@UserID int
AS
BEGIN
	UPDATE tblUser
	SET Status = 'Not Active'
	WHERE UserID = @UserID;
END
Go;