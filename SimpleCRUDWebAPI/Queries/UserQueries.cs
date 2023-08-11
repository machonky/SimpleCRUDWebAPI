namespace SimpleCRUDWebAPI.Queries;

internal static class UserQueries
{
    public const string QueryAll = @"
SELECT 
    id,
    first_name, 
    last_name, 
    email_address, 
    date_of_birth 
FROM ""WebAPI"".user
";
    public const string QueryById = @"
SELECT 
    id,
    first_name, 
    last_name, 
    email_address, 
    date_of_birth 
FROM ""WebAPI"".user
WHERE id = @UserId
";
    public const string Insert = @"
INSERT INTO ""WebAPI"".user 
(
    first_name, 
    last_name, 
    email_address, 
    date_of_birth
)
VALUES
(
    @FirstName, 
    @LastName, 
    @EmailAddress, 
    @DateOfBirth
)
";
    public const string Update = @"
 UPDATE ""WebAPI"".user
SET
    first_name = @FirstName, 
    last_name = @LastName, 
    email_address = @EmailAddress, 
    date_of_birth = @DateOfBirth
WHERE id = @Id";

    public const string Delete = @"DELETE FROM ""WebAPI"".user WHERE id = @UserId";
}
