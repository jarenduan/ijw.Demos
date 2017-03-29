using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ijw.Demo.DataContractSerialization {
    [DataContract(IsReference = true)]
    public class Person {
        public Person() {
        }
        public Person(string nickname) {
            this._nickname = nickname;
        }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public Person Dad { get; set; }

        //without [datamemeber], skip
        public Person X_men { get; }

        //without [datamemeber], skip
        public Person Y_men { get; set; }

        //without [datamemeber], skip
        public int AgeBak { get { return this.Age; } }

        [DataMember]
        public Animal Pet { get; set; }

        [DataMember]
        public IEnumerable<Person> Friends { get; set; }

        //[DataMember]
        public string Nickname { get { return this._nickname; } }

        [DataMember]
        protected string _nickname = "none";
    }
}
