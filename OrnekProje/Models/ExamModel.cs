using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrnekProje.Models;


namespace OrnekProje.Models
{
    public class ExamModel
    {
        public IEnumerable<InformationQuestion> Sinav { get; set; }
        public IEnumerable<Question> Soru { get; set; }
        public IEnumerable<Answer> Cevap { get; set; }
        public Guid TestID { get; set; }
    }
}