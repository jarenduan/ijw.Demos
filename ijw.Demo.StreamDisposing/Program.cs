using System.IO;

namespace ijw.Demo.StreamDisposing {
    class Program {
        
        static void Main(string[] args) {
            MemoryStream stream = new MemoryStream();
            string jstring = "demo";

            //WithUsing(stream, jstring);
            WithoutUsing(stream, jstring);

            //with or without using, 下面这句都会抛出异常
            stream.WriteByte(new byte());
            //close streamreader的同时, 就会释放stream
            //所以只好尽量不要传递stream作为参数.
        }


        static void WithUsing(Stream stream, string str) {
            //using will close the stream as well as the StreamWriter
            using (StreamWriter w = new StreamWriter(stream)) {
                w.Write(str);
            }
            //stream already disposed
        }

        static void WithoutUsing(Stream stream, string str) {
            StreamWriter w = new StreamWriter(stream);
            w.Write(str);
            w.Close(); //stream disposed as well.
        }
    }
}
