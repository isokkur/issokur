using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginValidator loginValidator = new LoginValidator();
            PasswordValidator passwordValidator = new PasswordValidator();

            // Тестирование с использованием атрибута DataRow
            TestWithDataRow(loginValidator, passwordValidator);

            // Тестирование с использованием атрибута DynamicData
            TestWithDynamicData(loginValidator, passwordValidator);
        }

        [DataRow("User123", true)]
        [DataRow("us123", false)]
        static void TestWithDataRow(LoginValidator loginValidator, PasswordValidator passwordValidator)
        {
            object[] testParams = {
                typeof(Program).GetMethod("TestWithDataRow").GetCustomAttributes(typeof(DataRowAttribute), false)[0],
                new object[] { loginValidator, passwordValidator },
            };

            foreach (object testParam in testParams)
            {
                dynamic dataRow = testParam;
                string validateObject = (string)dataRow.Data[0];
                bool expectedResult = (bool)dataRow.Data[1];
                bool result = loginValidator.Validate(validateObject);

                Console.WriteLine($"Login Validation for '{validateObject}': Expected - {expectedResult}, Actual - {result}");
            }
        }

        [DynamicData("User123", true)]
        [DynamicData("us123", false)]
        static void TestWithDynamicData(LoginValidator loginValidator, PasswordValidator passwordValidator)
        {
            object[] testParams = {
                typeof(Program).GetMethod("TestWithDynamicData").GetCustomAttributes(typeof(DynamicDataAttribute), false)[0],
                new object[] { loginValidator, passwordValidator },
            };

            foreach (object testParam in testParams)
            {
                dynamic dynamicData = testParam;
                string validateObject = (string)dynamicData.Data[0];
                bool expectedResult = (bool)dynamicData.Data[1];
                bool result = loginValidator.Validate(validateObject);

                Console.WriteLine($"Login Validation for '{validateObject}': Expected - {expectedResult}, Actual - {result}");
            }
        }

    }
}