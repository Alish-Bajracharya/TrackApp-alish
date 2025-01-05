using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackApp_alish.Models
{
    public class DebtModels
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public List<string> Tags { get; set; }
    }

}
