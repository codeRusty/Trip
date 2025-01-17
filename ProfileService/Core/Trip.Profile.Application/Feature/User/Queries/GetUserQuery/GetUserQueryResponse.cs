﻿using System;

namespace Trip.Profile.Application.Feature.User.Queries.GetUserQuery
{
    public class GetUserQueryResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
