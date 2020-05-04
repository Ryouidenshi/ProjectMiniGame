using System;
using System.Collections.Generic;

namespace Family_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var vitya = new Man("Vitya", "21.03.2000", "Chelyabinsk", "Male", "photo");
            var mom = new UpTreeMan("Natasha", "05.05.1965", "Chelyabinsk", "Female", "photo", "Mom");
            var father = new UpTreeMan("Volodya", "03.03.1941", "Moscow", "Male", "photo", "Father");
            var sister = new DownTreeMan("Tonya", "02.01.2000", "Chelybinsk", "Female", "photo", "Sister");
            var brother = new DownTreeMan("Alexandr", "01.01.10001", "World", "Yes", "Hello", "Brother");
            Console.WriteLine("Вся информация о человеке: ");
            GetInformationAboutMan(vitya);
            vitya.AddParent(mom.Name, mom.DateBorn, mom.PlaceBorn, mom.Gender, mom.Photo, mom.TypeInTree);
            vitya.AddParent(father.Name, father.DateBorn, father.PlaceBorn, father.Gender, father.Photo, father.TypeInTree);
            vitya.AddRelatives(sister.Name, sister.DateBorn, sister.PlaceBorn, sister.Gender, sister.Photo, sister.TypeInTree);
            vitya.AddRelatives(brother.Name, brother.DateBorn, brother.PlaceBorn, brother.Gender, brother.Photo, brother.TypeInTree);
            PrintAllInformationAboutParentsAndRelatives(vitya.FamilyUpTree, vitya.FamilyDownTree);
            PrintOnlyNamesParentsAndRelatives(vitya.FamilyUpTree, vitya.FamilyDownTree);
            Console.WriteLine();
            mom.AddParent("Anna", "03.02.1914", "Chelybinsk", "Female", "Photo", "Mom");
            GetInformationAboutMan(mom);
            PrintAllInformationAboutParentsAndRelatives(mom.FamilyUpTree, mom.FamilyDownTree);
        }

        public static void PrintAllInformationAboutParentsAndRelatives(List<UpTreeMan> familyUpTree, List<DownTreeMan> familyDownTree)
        {
            Console.WriteLine("Вся информация про людей сверху по дереву: ");

            foreach (var manInUpTree in familyUpTree)
            {
                Console.WriteLine("Name - {0} \nDateBorn - {1} \nPlaseBorn - {2} \nPhoto - {3} \nGender - {4} \nTypeInTree - {5}",
                    manInUpTree.Name, manInUpTree.DateBorn, manInUpTree.PlaceBorn,
                    manInUpTree.Photo, manInUpTree.Gender, manInUpTree.TypeInTree);
                Console.WriteLine();
            }

            Console.WriteLine("Вся информация про людей снизу по дереву: ");

            foreach (var manInDownTree in familyDownTree)
            {
                Console.WriteLine("Name - {0} \nDateBorn - {1} \nPlaseBorn - {2} \nPhoto - {3} \nGender - {4} \nTypeInTree - {5}",
                    manInDownTree.Name, manInDownTree.DateBorn, manInDownTree.PlaceBorn,
                    manInDownTree.Photo, manInDownTree.Gender, manInDownTree.TypeInTree);
                Console.WriteLine();
            }
        }

        public static void PrintOnlyNamesParentsAndRelatives(List<UpTreeMan> familyUpTree, List<DownTreeMan> familyDownTree)
        {
            Console.WriteLine();

            Console.Write("Все люди, находящиеся сверху по дереву: ");
            foreach (var manInUpTree in familyUpTree)
                Console.Write(manInUpTree.Name + ' ');
            Console.WriteLine();

            Console.Write("Все люди, находящиеся снизу по дереву: ");
            foreach (var manInDownTree in familyDownTree)
                Console.Write(manInDownTree.Name + ' ');
            Console.WriteLine();
        }
        public static void GetInformationAboutMan(Man man)
        {
            Console.WriteLine("Name - {0} \nDateBorn - {1} \nPlaseBorn - {2} \nPhoto - {3} \nGender - {4} \n",
                man.Name, man.DateBorn, man.PlaceBorn, man.Photo, man.Gender);            
        }
    }

    public class Man
    {
        private string name;
        private string dateBorn;
        private string placeBorn;
        private string gender;
        private string photo;
        private List<DownTreeMan> familyDownTree = new List<DownTreeMan>();
        private List<UpTreeMan> familyUpTree = new List<UpTreeMan>();

        public Man(string name, string dateBorn, string placeBorn,
            string gender, string photo)
        {
            this.Name = name;
            this.DateBorn = dateBorn;
            this.placeBorn = placeBorn;
            this.Gender = gender;
            this.Photo = photo;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string DateBorn
        {
            get { return dateBorn; }
            set { dateBorn = value; }
        }
        public string PlaceBorn
        {
            get { return placeBorn; }
            set { placeBorn = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public List<UpTreeMan> FamilyUpTree
        {
            get { return familyUpTree; }
            set { familyUpTree = value; }
        }
        public List<DownTreeMan> FamilyDownTree
        {
            get { return familyDownTree; }
            set { familyDownTree = value; }
        }

        public void AddParent(string name, string dateBorn, string placeBorn,
            string gender, string photo, string typeInTree)
        {
            familyUpTree.Add(new UpTreeMan(name, dateBorn, placeBorn, gender, photo, typeInTree));
        }

        public void AddRelatives(string name, string dateBorn, string placeBorn,
            string gender, string photo, string typeInTree)
        {
            familyDownTree.Add(new DownTreeMan(name, dateBorn, placeBorn, gender, photo, typeInTree));
        }

    }

    public class UpTreeMan : Man
    {
        string typeInTree;
        public UpTreeMan(string name, string dateBorn, string placeBorn,
            string gender, string photo, string typeInTree)
            : base(name, dateBorn, placeBorn, gender, photo)
        {
            this.TypeInTree = typeInTree;
        }

        public string TypeInTree
        {
            get
            {
                if (typeInTree == "Mom" || typeInTree == "Father" || typeInTree == "GrandMother" || typeInTree == "GrandFather")
                    return typeInTree;
                else throw new Exception();
            }
            set { typeInTree = value; }
        }
    }


    //Можно объединить в один класс, но захотелось иерархичности

    public class DownTreeMan : Man
    {
        string typeInTree;
        public DownTreeMan(string name, string dateBorn, string placeBorn,
            string gender, string photo, string typeInTree)
            : base(name, dateBorn, placeBorn, gender, photo)
        {
            this.TypeInTree = typeInTree;
        }

        public string TypeInTree
        {
            get
            {
                if (typeInTree != "Mom" && typeInTree != "Father" && typeInTree != "GrandMother" && typeInTree != "GrandFather")
                    return typeInTree;
                else throw new Exception();
            }
            set { typeInTree = value; }
        }
    }
}
