﻿namespace WebApi.EndPoints.Models.Identity.Authorization;

public class RegisterModel
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

}
