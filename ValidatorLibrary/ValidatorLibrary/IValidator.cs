using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLibrary
{
    public interface IValidator
    {
        bool Validate(string? validateObject);
    }

    public class LoginValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            return validateObject.Length >= 6 && validateObject.Length <= 16 && System.Text.RegularExpressions.Regex.IsMatch(validateObject, @"^[a-zA-Z]+$");
        }
    }

    public class PasswordValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            return validateObject.Length >= 8 && validateObject.Length <= 20 &&
                   System.Text.RegularExpressions.Regex.IsMatch(validateObject, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*-_])[A-Za-z\d!@#$%^&*-_]+$");
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DataRowAttribute : Attribute
    {
        public object[] Data { get; }

        public DataRowAttribute(params object[] data)
        {
            Data = data;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DynamicDataAttribute : Attribute
    {
        public object[] Data { get; }

        public DynamicDataAttribute(params object[] data)
        {
            Data = data;
        }
    }

}