namespace school_Project.Data.Requests
{
    public class ManagerUserClaimsResponse
    {
        public int UserId { get; set; }
        public List<UserClaims> userClaims { get; set; }

    }
    public class UserClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
