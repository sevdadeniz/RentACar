using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Car
    {
        [Key]
        public int carId { get; set; }
        public string carName { get; set; }
        public string image { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public string details { get; set; }

        public int modelId { get; set; }
        public Model Model { get; set; }
        public int categoryId { get; set; }

        ICollection<Category> Categories { get; set; }

    }
}
