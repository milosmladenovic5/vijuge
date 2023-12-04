using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vijuge.Data.Models.DTOs
{
    public class AnswerGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AnswerDTO> Answers { get; set; }
    }
}
