using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vijuge.Data.Models.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int? QuestionId { get; set; }
        public QuestionDTO? Question { get; set; }

        public AnswerGroupDTO AnswerGroup { get;set;}
    }
}
