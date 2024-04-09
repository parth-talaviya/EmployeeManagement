﻿namespace UserManagement.ViewModel.Models.LoginUser;

public sealed class LoginUserViewModel
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Token { get; set; }

    public bool IsActive { get; set; }
}