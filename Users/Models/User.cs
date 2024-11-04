// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace MVCUsers.Models
{
    public class User
    {
        public int Id { get; set; } // Dodajemy Id, aby móc identyfikować użytkowników

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [Range(1, 120, ErrorMessage = "Please enter a valid age (1-120).")]
        public int Age { get; set; }
    }
}
