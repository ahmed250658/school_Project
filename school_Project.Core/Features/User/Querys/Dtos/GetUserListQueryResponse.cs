namespace school_Project.Core.Features.User.Querys.Dtos
{
    public class GetUserListQueryResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
