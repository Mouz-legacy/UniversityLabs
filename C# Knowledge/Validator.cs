using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validator_Test
{

    public class User
    {
        [Required]//Наличие значения у поля обязательно
        public string id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]//Максимальная и минимальная длинна строки
        public string Name { get; set; }
        [Required]
        [Range(1,100)]//Приемлимый диапазон
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите возраст:");
            int age = Int32.Parse(Console.ReadLine());

            User user = new User { Name = name, Age = age };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            Console.Read();
        }
    }
}
