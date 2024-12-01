using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.Sql(@" DECLARE @Base64String NVARCHAR(MAX) = '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';
DECLARE @DecodedBinaryData VARBINARY(MAX);

-- Using XML to decode base64 into varbinary
SET @DecodedBinaryData = CAST('' AS XML).value('xs:base64Binary(sql:variable(""@Base64String""))', 'VARBINARY(MAX)');

-- Insert the binary data into the table
INSERT INTO Cafes ([ID], [Name], [Description], [Location], [Logo], [ContentType], [CreatedAt], [UpdatedAt])
VALUES (NEWID(), 'Asokan Cafe', 'Veg/Non-Veg', 'Sengkang', @DecodedBinaryData, 'application/jpeg', GETDATE(), GETDATE());

-- Insert the binary data into the table
INSERT INTO Cafes ([ID], [Name], [Description], [Location], [Logo], [ContentType], [CreatedAt], [UpdatedAt])
VALUES (NEWID(), 'Padmavathi Cafe', 'Veg/Non-Veg', 'Punggol', @DecodedBinaryData, 'application/jpeg', GETDATE(), GETDATE());

-- Insert the binary data into the table
INSERT INTO Cafes ([ID], [Name], [Description], [Location], [Logo], [ContentType], [CreatedAt], [UpdatedAt])
VALUES (NEWID(), 'Vivek Cafe', 'Veg/Non-Veg', 'LittleIndia', @DecodedBinaryData, 'application/jpeg', GETDATE(), GETDATE());

-- Insert the binary data into the table
INSERT INTO Cafes ([ID], [Name], [Description], [Location], [Logo], [ContentType], [CreatedAt], [UpdatedAt])
VALUES (NEWID(), 'Simran Cafe', 'Veg/Non-Veg', 'CityHall', @DecodedBinaryData, 'application/jpeg', GETDATE(), GETDATE());

-- Insert the binary data into the table
INSERT INTO Cafes ([ID], [Name], [Description], [Location], [Logo], [ContentType], [CreatedAt], [UpdatedAt])
VALUES (NEWID(), 'Sadha Cafe', 'Veg/Non-Veg', 'MarinaBay', @DecodedBinaryData, 'application/jpeg', GETDATE(), GETDATE());


INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender],[CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI1111111', 'Velan', 'ashokan1984@gmail.com', '91111111',2,(select ID from Cafes where [Name] = 'Asokan Cafe'), GETDATE(), GETDATE());

INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender],[CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI2222222', 'Ramanathan', 'ramanathan@gmail.com', '99222222',2,(select ID from Cafes where [Name] = 'Asokan Cafe'), GETDATE(), GETDATE());

INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender],[CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI3333333', 'Rangan', 'Rangan@gmail.com', '93333333',2,(select ID from Cafes where [Name] = 'Padmavathi Cafe'), GETDATE(), GETDATE());

INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender],[CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI4444444', 'Rasu', 'rasu@gmail.com', '94444444',2,(select ID from Cafes where [Name] = 'Padmavathi Cafe'), GETDATE(), GETDATE());

INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender],[CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI5555555', 'Adhiyavani', 'Adhiyavani@gmail.com', '95111111',1,(select ID from Cafes where [Name] = 'Simran Cafe'), GETDATE(), GETDATE());

INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender],[CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI6666666', 'Ranjan', 'Ranjan@gmail.com', '96222222',2,(select ID from Cafes where [Name] = 'Vivek Cafe'), GETDATE(), GETDATE());

INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender],[CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI7777777', 'Ravi', 'Ravi@gmail.com', '98333333',2,(select ID from Cafes where [Name] = 'Sadha Cafe'), GETDATE(), GETDATE());

INSERT INTO Employees ([ID], [EmployeeId], [Name], [EmailAddress], [PhoneNumber], [gender], [CafeId], [CreatedAt], [UpdatedAt] )
VALUES (NEWID(), 'UI8888888', 'Ahaniniyal', 'Ahaniniyal@gmail.com', '99444444',1,(select ID from Cafes where [Name] = 'Padmavathi Cafe'), GETDATE(), GETDATE());


Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI1111111'),(SELECT ID from Employees where EmployeeId='UI1111111'),GETDATE()-100, GETDATE(), GETDATE())

Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI2222222'),(SELECT ID from Employees where EmployeeId='UI2222222'),GETDATE()-90, GETDATE(), GETDATE())

Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI3333333'),(SELECT ID from Employees where EmployeeId='UI3333333'),GETDATE()-80, GETDATE(), GETDATE())

Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI4444444'),(SELECT ID from Employees where EmployeeId='UI4444444'),GETDATE()-70, GETDATE(), GETDATE())

Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI5555555'),(SELECT ID from Employees where EmployeeId='UI5555555'),GETDATE()-60, GETDATE(), GETDATE())

Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI6666666'),(SELECT ID from Employees where EmployeeId='UI6666666'),GETDATE()-50, GETDATE(), GETDATE())

Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI7777777'),(SELECT ID from Employees where EmployeeId='UI7777777'),GETDATE()-40, GETDATE(), GETDATE())

Insert Into CafeEmployees ( [CafeId], [EmployeeID], [StartDate], [CreatedAt], [UpdatedAt] ) 
values ((SELECT CafeId from Employees where EmployeeId='UI8888888'),(SELECT ID from Employees where EmployeeId='UI8888888'),GETDATE()-30, GETDATE(), GETDATE())
 ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.Sql(@"
            DELETE FROM CafeEmployees

            DELETE FROM Employees

            DELETE FROM Cafes");
        }
    }
}
