using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TransferMarketApp.Service;
using System.Linq;
using System.Globalization;
using System.Windows;

namespace TransferMarketApp.ViewModels.Validation
{
    public class PlayerNameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string playerName)
            {
                if (string.IsNullOrEmpty(playerName))
                {
                    ErrorMessage = "Name is required"; return false;
                }
                if (!Regex.IsMatch(playerName, @"^[a-zA-Z]"))
                {
                    ErrorMessage = "First symbol should be alphabetic"; return false;
                }
                if (playerName.Where(char.IsLetter).ToList().Count < 2)
                {
                    ErrorMessage = "Name should contain minimum 2 alphabetic"; return false;
                }
                if (!Regex.IsMatch(playerName, @"^[a-zA-Z .'-]+$"))
                {
                    ErrorMessage = "Wrong character"; return false;
                }
                return true;
            }
            return false;
        }
    }
    public class PlayerNationalityValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string playerNationality)
            {
                if (string.IsNullOrEmpty(playerNationality))
                {
                    ErrorMessage = "Nationality is required"; return false;
                }
                if (!ApplicationUserManager.getInstance().nationalityConverter.Contains(playerNationality))
                {
                    ErrorMessage = "Such nationality does not exist"; return false;
                }
                return true;
            }
            return false;
        }
    }
    public class PlayerAgeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            if (value is int playerAge)
            {
                if (playerAge > 45 || playerAge < 15)
                {
                    ErrorMessage = "Age should be between 15 and 45"; return false;
                }
                return true;
            };
            return false;
        }
    }
}
