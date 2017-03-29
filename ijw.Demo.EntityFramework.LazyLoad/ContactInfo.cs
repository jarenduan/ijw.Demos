using System.ComponentModel.DataAnnotations;
using System;

namespace ijw.Demo.EntityFramework.LazyLoad {
    public class ContactInfo {
        [Key]
        public string ContactInfoID { get; private set; }
        public string Mail { get; set; }

        public string PostCode { get; set; }

        public ContactInfo() {
            this.ContactInfoID = Guid.NewGuid().ToString();
        }
    }
}