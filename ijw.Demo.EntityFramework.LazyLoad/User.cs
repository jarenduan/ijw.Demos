using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ijw.Demo.EntityFramework.LazyLoad {
    public class User {
        [Key]
        public string ID { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ContactInfo Contact { get; set; }

        public User() {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
