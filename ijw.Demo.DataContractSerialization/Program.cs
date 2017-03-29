using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using ijw.Serialization;

namespace ijw.Demo.DataContractSerialization {
    class Program {
        static void Main(string[] args) {
            Person jack = new Person("little jack");
            jack.Name = "jack";
            jack.Age = 20;

            Person jackDad = new Person();
            jackDad.Name = "jack dad";
            jackDad.Age = 40;

            jack.Dad = jackDad;

            Person tom = new Person();
            tom.Name = "tom";
            tom.Age = 21;

            Person jim = new Person();
            jim.Name = "jim";
            jim.Age = 22;
            jim.Dad = jackDad;

            jack.Friends = new Person[] { tom, jim, jack };

            Animal cat = new Animal();
            cat.Age = 1;
            cat.Name = "Kitty";
            cat.Master = jack;

            jack.Pet = cat;

            //using (FileStream fs = new FileStream("e:\\jack.xml", FileMode.Create)) {
            //    using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs)) {
            //        DataContractSerializer saver = new DataContractSerializer(typeof(Person), null, 1000, false, true, null);
            //        saver.WriteObject(writer, jack);
            //        Console.WriteLine("Finished writing object.");
            //    }
            //}

            JsonSerializer j = new JsonSerializer() {
                //NullValueHandling = NullValueHandling.Ignore,
                //MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };

            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            using (var jtw = new JsonTextWriter(sw))
                j.Serialize(jtw, jack);
            var result = sb.ToString();
            Console.WriteLine(result);

            Console.WriteLine(jack.ToJsonFormatString());

            deserialize(result);

            // j.Serialize(new StreamWriter("e:\\jack.json"), jack);
            Console.WriteLine("Json done.");
            Console.ReadLine();
        }

        private static void deserialize(string result) {
            Person p = SerializationHelper.LoadJsonObject<Person>(result);
        }
    }
}