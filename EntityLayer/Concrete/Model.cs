using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Model
    {
        [Key]
        public int modelId { get; set; }
        public string modelName { get; set; }
        ICollection<Car> Cars { get; set; }

    }
}
