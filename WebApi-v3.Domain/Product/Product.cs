using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_v3.Domain
{
    public class Product
    {
        public Product()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public int? Price { get; set; }

        public HashSet<Customer> Customers { get; }

        

       

        // public virtual ICollection<Customer> Customers { get; set; }

        // public virtual Employee CreatedBy { get; set; }


    }    
}
