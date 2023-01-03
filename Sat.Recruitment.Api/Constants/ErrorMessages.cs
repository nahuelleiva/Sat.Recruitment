namespace Sat.Recruitment.Api.Constants
{
    public static class ErrorMessages
    {
        // Users data file doesn't exist
        public const string FILE_MISSING = "The file you are attempting to load doesn't exist. Check the path is correct and reload the application";
        public const string NO_DATA = "No data. The file is empty.";

        // Errors related to the Users management
        public const string DUPLICATED_USER = "User is duplicated";
        public const string DUPLICATED_USER_BY_EMAIL = "Email already exists";
        public const string DUPLICATED_USER_BY_PHONE = "Phone already exists";
        public const string DUPLICATED_USER_BY_NAME_AND_ADDRESS = "Name and address already exist";
        public const string INVALID_EMAIL_ADDRESS = "The email provided has an invalid format";
        public const string EMAIL_REQUIRED = "The email address is required";
        public const string ADDRESS_REQUIRED = "The address information is required";
        public const string PHONE_REQUIRED = "The phone number is required";
        public const string NAME_REQUIRED = "The name is required";
        public const string ERROR_CREATING_USER = "There was an error while creating a new user";

        // We could still add custom messages to handle other kinds of errors like server errors (HTTP responses)
        // or business logic related error messages.
    }
}
