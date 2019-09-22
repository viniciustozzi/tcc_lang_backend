using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tcc_lang_backend.DB
{
    public class Text
    {
        [Key] public int Id { get; set; }
        public String Title { get; set; }
        public ICollection<WordSection> WordSections { get; set; }
    }
}