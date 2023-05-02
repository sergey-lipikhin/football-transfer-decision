using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace TransferMarketApp.ViewModels.Validation
{
    public class UserLoginValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string userLogin)
            {
                if (string.IsNullOrEmpty(userLogin))
                {
                    ErrorMessage = "Login is required"; return false;
                }
                if (userLogin.Length < 3 || userLogin.Length > 50)
                {
                    ErrorMessage = "Login should be between 3 and 50"; return false;
                }
                if (!Regex.IsMatch(userLogin, @"^[a-zA-Z0-9@_]+$"))
                {
                    ErrorMessage = "Wrong character. Allowed alpha, numeric, underscore and @ symbol"; return false;
                }
                return true;
            }
            return false;
        }
    }
    public class UserPasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string userPassword)
            {
                if (string.IsNullOrEmpty(userPassword))
                {
                    ErrorMessage = "Password is required"; return false;
                }
                if (userPassword.Length < 3 || userPassword.Length > 50)
                {
                    ErrorMessage = "Password should be between 3 and 50"; return false;
                }
                if (userPassword.Where(char.IsLetter).ToList().Count < 1 || userPassword.Where(char.IsDigit).ToList().Count < 1)
                {
                    ErrorMessage = "Password should contain minimum 1 alphabetic and 1 digit"; return false;
                }
                if (!Regex.IsMatch(userPassword, @"^[a-zA-Z0-9]+$"))
                {
                    ErrorMessage = "Wrong character. Allowed only alpha and numeric"; return false;
                }
                return true;
            }
            return false;
        }
    }
}
