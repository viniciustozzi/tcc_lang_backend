using System;
using System.ComponentModel.DataAnnotations;

namespace tcc_lang_backend.DB
{
    public class WordSection
    {
        [Key] public int Id { get; set; }
        public string Word { get; set; }
        public bool IsPressed { get; set; }
        public Text Text { get; set; }
    }
}