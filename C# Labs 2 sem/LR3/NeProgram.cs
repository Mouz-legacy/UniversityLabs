using System;

namespace SharpLab3
{
    class Human
    {
        public static string DayOfBirth = "01:03:2002";
        public int Weight { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Temperament { get; set; } = "Choleric";//Темперамент
        public string Physique { get; set; } = "Mesomorph";//Телосложение
        public string LeatherColor { get; set; }// Цвет кожи
        public string EyeColor { get; set; }
        public string IntelligentDevelopment { get; set; }
        public int Age { get; set; }


        public Human(string Name, string SurName)
        {
            this.Name = Name;
            this.SurName = SurName;
        }

        public Human()
        {
            Age = 18;
            Name = "Adolf";
            SurName = "Hitler";
            Aryan();
        }
        public void Aryan()
        {
            LeatherColor = "White";
            EyeColor = "Blue";
            Weight = 180;
            IntelligentDevelopment = "Higher than medium";
        }
        
        public void BodyBuilder()
        {
            Physique = "Endomorph";
            Temperament = "Phlegmatic";
            Age = 25;
            Weight = 190;
            LeatherColor = "Brown";
            IntelligentDevelopment = "Low";
        }

        public void BodyBuilder(int Age, int Weight, string Temperament)
        {
            Physique = "Endomorph";
            this.Temperament = Temperament;
            this.Age = Age;
            this.Weight = Weight;
            LeatherColor = "Brown";
            IntelligentDevelopment = "Low";
        }

        public void BirthDay()
        {
            Console.WriteLine($"Day of Birth: {DayOfBirth}");
        }


        public string this[string index]
        {
            get
            {
                switch (index)
                {
                    case "n": return Name;
                    case "s": return SurName;
                    default: return null;
                }

            }
            set
            {
                switch(index)
                {

                    case "n": Name = value; break;
                    case "s": SurName = value; break;
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int MyAge, MyWeight;
            string MyTemp;
            char ForCase;
            Human First = new Human("Alexey","Strelets");
            Human Second = new Human();
            bool ForCycle = true;
            while (ForCycle)
            {
                Console.WriteLine(@"Enter the number of function:
1- First Constructor
2 - Second Constructor
3 - First BodyBuilder
4 - OverLoaded BodyBuilder
5 - Using of Indexator
7 - exit");
                ForCase = Console.ReadKey().KeyChar;
                switch (ForCase)
                {
                    case '1': Console.WriteLine($" Name: {First.Name}, SurName: {First.SurName}, Temperament: {First.Temperament}, Physique: {First.Physique}"); First.BirthDay(); Console.ReadKey(); 
                        break; 
                    case '2': Console.WriteLine($" Name: {Second.Name}, SurName: {Second.SurName}, Age: {Second.Age}, " +
                        $"Leather Color: {Second.LeatherColor}, Eye Color: {Second.EyeColor}, " +
                        $"IntelligentDevelopment: {Second.IntelligentDevelopment}, Weight: {Second.Weight} "); 
                        Console.ReadKey(); 
                        break;
                    case '3': First.BodyBuilder(); Console.WriteLine($" Physique: {First.Physique}, Temperament: {First.Temperament}, " +
                        $"Age: {First.Age}, Weight: {First.Weight}, Leather Color: {First.LeatherColor}, IntelligentDevelopment: {First.IntelligentDevelopment} ");
                        Console.ReadKey(); 
                        break;
                    case '4':
                        Console.WriteLine(" Enter your parametres(age,temperament,weight)");
                        MyAge = Convert.ToInt32(Console.ReadLine());
                        MyTemp = Console.ReadLine();
                        MyWeight = Convert.ToInt32(Console.ReadLine());
                        Second.BodyBuilder(MyAge,MyWeight, MyTemp); Console.WriteLine($" Physique: {Second.Physique}, Temperament: {Second.Temperament}, " +
                     $"Age: {Second.Age}, Weight: {Second.Weight}, Leather Color: {Second.LeatherColor}, IntelligentDevelopment: {Second.IntelligentDevelopment} ");
                        Console.ReadKey(); 
                        break;
                    case '5':
                        Console.Clear();
                        Console.Write(First["n"] + " " + First["s"]);
                        Console.ReadKey();
                        break;
                    case '7': ForCycle = false; break;
                    default: Console.WriteLine(" Choose Normal"); Console.ReadKey(); 
                        break;
                }
                Console.Clear();
            }
        }
    }
}
