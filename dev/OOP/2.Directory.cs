using System;

namespace Millionaire
{
    // File, Directory, Image, Document, word.doc, img.png

    class File
    {
        private string Type { get; set; }
        public string Name { get; set; }

        public File(string name)
        {
            Set(name);
        }

        private void Set(string str)
        {
            string[] words = str.Split(new char[] { '.' });

            Name = words[0];
            Type = words[1];
        }

        public virtual void Display()
        {
            Console.WriteLine($"Name: {Name} Type: {Type}");
        }
    }

    class Image : File
    {
        public string Extension { get; set; }

        public Image(string name, string extension) : base(name)
        {
            Extension = extension;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Extension: {Extension}");
        }
    }

    class Document : File
    {
        public string Encoding { get; set; }

        public Document(string name, string encoding) : base(name)
        {
            Encoding = encoding;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Encoding: {Encoding}");
        }
    }


    class Directory
    {
        File[] files;

        public Directory(File[] files)
        {
            this.files = files;
        }

        public void Display()
        {
            foreach (var item in files)
            {
                item.Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            File[] files = new File[] { new Image("img.png", "1280"), new Document("word.doc", "utf-8") };
            Directory directory = new Directory(files);

            directory.Display();
        }
    }
}
