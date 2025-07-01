namespace school_Project.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string perfix = Rule + "Student";
            public const string list = perfix + "/list";
            public const string GetById = perfix + "/{id}";
            public const string Create = perfix + "/Create";
            public const string Edit = perfix + "/Edit";
            public const string Delete = perfix + "/Delete/{id}";
            public const string Paginated = perfix + "/Pagianted";
        }
        public static class DepartmetnRouting
        {
            public const string perfix = Rule + "Department";
            public const string GetById = perfix + "/Id";
            public const string GetViewDepartment = perfix + "/View-Department";
            public const string GetDepartmentStudentCountById = perfix + "/Procedure-Department/{id}";

        }
        public static class AppUserRouting
        {
            public const string perfix = Rule + "User";
            public const string Create = perfix + "/Create";
            public const string Paginated = perfix + "/Paginated";
            public const string GetById = perfix + "/{id}";
            public const string Edit = perfix + "/Edit";
            public const string Delete = perfix + "/Delete/{id}";
            public const string ChangePassword = perfix + "/Change-Password";
        }
        public static class Authentication
        {
            public const string perfix = Rule + "Authentication";
            public const string SignIn = perfix + "/SignIn";
            public const string RefreshToken = perfix + "/Refresh-Token";
            public const string VaildateToken = perfix + "/Vaildate-Token";
            public const string SendResetPassword = perfix + "/SendResetPassword";
            public const string ConfirmResetPassword = perfix + "/ConfirmResetPassword";
            public const string ResetPassword = perfix + "/ResetPassword";
            public const string ConfirmEmail = perfix + "/Api/Authentication/Confirm-Email";
        }
        public static class Authorization
        {
            public const string Prefix = Rule + "AuthorizationRouting";
            public const string Roles = Prefix + "/Roles";
            public const string Claims = Prefix + "/Claims";
            public const string Create = Roles + "/Create";
            public const string Edit = Roles + "/Edit";
            public const string Delete = Roles + "/Delete/{id}";
            public const string RoleList = Roles + "/Role-List";
            public const string GetRoleById = Roles + "/Role-By-Id/{id}";
            public const string ManageUserRoles = Roles + "/Manage-User-Roles/{userId}";
            public const string ManageUserClaims = Claims + "/Manage-User-Claims/{userId}";
            public const string UpdateUserRoles = Roles + "/Update-User-Roles";
            public const string UpdateUserClaims = Claims + "/Update-User-Claims";
        }
        public static class Email
        {
            public const string Prefix = Rule + "Email";
            public const string SendEmail = Prefix + "/SendEmail";
        }
        public static class Instructor
        {
            public const string Prefix = Rule + "Instructor";
            public const string GetSalarySummationOfInstructor = Prefix + "/Salary-Summation-Of-Instructor";
            public const string Create = Prefix + "/Create";
        }
    }

}
