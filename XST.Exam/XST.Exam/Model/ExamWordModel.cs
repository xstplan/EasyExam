using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Model
{
    public class ExamWordModel
    {
        public int Id { get; set; }
        public string? Term { get; set; }
        public string? Definition { get; set; }
        public string? Category { get; set; }
        public string? PartOfSpeech { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
