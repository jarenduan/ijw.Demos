using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ijw.Demo.LoopReferenceJsonSerialization {
    class Program {
        static void Main(string[] args) {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            ParentAndChild(jsSettings);
            TwoFriends(jsSettings);
            FriendChains(jsSettings);
            SelfFriend(jsSettings);

            Console.ReadLine();
        }

        private static void SelfFriend(JsonSerializerSettings jsSettings) {
            //self friend
            Bar anna = new Bar();
            anna.Name = "anna";
            anna.Age = 18;
            anna.Friend = anna;

            //below is a loop ref exception
            //string jimJson = JsonConvert.SerializeObject(jim);

            string annaJson = JsonConvert.SerializeObject(anna, jsSettings);
            Console.WriteLine(annaJson);
        }

        private static void FriendChains(JsonSerializerSettings jsSettings) {
            //friend chains
            Bar dave = new Bar();
            dave.Name = "dave";
            dave.Age = 22;

            Bar bob = new Bar();
            bob.Name = "bob";
            bob.Age = 23;

            Bar harry = new Bar();
            harry.Name = "harry";
            harry.Age = 24;

            dave.Friend = bob;
            bob.Friend = harry;
            harry.Friend = dave;

            //below is a loop ref exception
            //string jimJson = JsonConvert.SerializeObject(jim);

            string daveJson = JsonConvert.SerializeObject(dave, jsSettings);
            Console.WriteLine(daveJson);
        }

        private static void TwoFriends(JsonSerializerSettings jsSettings) {
            //two friends
            Bar jim = new Bar();
            jim.Name = "jim";
            jim.Age = 20;

            Bar lucy = new Bar();
            lucy.Name = "bob";
            lucy.Age = 21;

            jim.Friend = lucy;
            lucy.Friend = jim;

            //below is a loop ref exception
            //string jimJson = JsonConvert.SerializeObject(jim);

            string jimJson = JsonConvert.SerializeObject(jim, jsSettings);
            Console.WriteLine(jimJson);
        }

        private static void ParentAndChild(JsonSerializerSettings jsSettings) {
            //Parent and child
            Foo jack = new Foo();
            jack.Name = "jack";
            jack.Age = 40;

            Foo tom = new Foo();
            tom.Name = "tom";
            tom.Age = 18;

            jack.Child = tom;
            tom.Parent = jack;

            string jackJson = JsonConvert.SerializeObject(jack, jsSettings);

            Console.WriteLine(jackJson);
        }
    }
}
