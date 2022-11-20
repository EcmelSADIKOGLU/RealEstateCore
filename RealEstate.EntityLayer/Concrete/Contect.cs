using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.EntityLayer.Concrete
{
    public class Contect
    {
        [Key]
        public int ContectID { get; set; }
        public string ContectMail { get; set; }
        public string ContectNameSurname { get; set; }
        public string ContectSubject { get; set; }
        public string ContectMessage { get; set; }
        public DateTime ContectDate { get; set; }
    }
}
