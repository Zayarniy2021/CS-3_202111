using System;
using System.Xml.Serialization;
using System.IO;

namespace ReflextionExample
{
    
    public class MyClass
    {
        [Obsolete]
        public int Data { get; set; }
        public DateTime Date { get; set; }

        public void SaveXML(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyClass));
            StreamWriter stream = new StreamWriter(filename);
            xmlSerializer.Serialize(stream, this);
            stream.Close();            
        }

        static public MyClass LoadXML(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyClass));
            StreamReader stream = new StreamReader(filename);
            MyClass myClass= (MyClass)xmlSerializer.Deserialize(stream);
            stream.Close();
            return myClass;

        }
    }



    class Program
    {
        public Program()
        {

        }

        public Program(int a)
        {

        }

        public Program(int a,int b)
        {

        }

        static void Main(string[] args)
        {
            MyClass myClass2 = new MyClass { Data = 10, Date = new DateTime(2021,12,3) };
            //myClass.SaveXML("1.xml");
            
            MyClass myClass = MyClass.LoadXML("1.xml");

            Random random = new Random();

            Type type = random.GetType();
            Type type1 = typeof(Type);
            Type type2 = typeof(Program);
            foreach(var constructor in type2.GetConstructors())
                Console.WriteLine(constructor.Name);

            Console.WriteLine("Hello World!");
        }
    }
}
