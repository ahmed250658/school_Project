﻿using System.Security.Claims;

namespace school_Project.Data.Helper
{
    public static class ClaimStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Create Student","false"),
            new Claim("Edit Student","false"),
            new Claim("Delete Student","false"),
        };
    }
}
