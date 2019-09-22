using System;
using System.ComponentModel.DataAnnotations;

namespace tcc_lang_backend.DB
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Fullname { get; set; }
        
        [Required] public byte[] PasswordHash { get; set; }

        [Required] public byte[] PasswordSalt { get; set; }
    }
}