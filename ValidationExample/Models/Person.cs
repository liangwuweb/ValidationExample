using System.ComponentModel.DataAnnotations;

namespace ValidationExample.Models
{
    public class Person
    {
        [Required(ErrorMessage ="Person name cannot be empty!")]
        public string? PersonName { get; set; }

        public string? Email { get; set; }


        public string? Phone { get; set; }


        public string? Password { get; set; }


        public string? ConfirmPassword { get; set; }


        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person object\n " +
                $"name: {PersonName}" +
                $"Email: {Email}" +
                $"Phone: {Phone}" +
                $"Password: {Password}" +
                $"ConfirmPassword: {ConfirmPassword}" +
                $"Price: {Price}" 
                ;
        }
    }
}
