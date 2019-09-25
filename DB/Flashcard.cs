using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tcc_lang_backend.DB
{
    public class Flashcard

    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
    }
}