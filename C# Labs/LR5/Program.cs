using System;

namespace LAB5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(@"Choose 1 of 3 classes:
1) DrugsAbilities
2) Athletes
3) SchoolKids");
            string dependency;
            string sporttype, country;
            string teachname, schoolname;
            int expirience;
            int temp;
            bool math, science;
            int numclass;
            int Swicther = Convert.ToInt32(Console.ReadLine());

            switch(Swicther)
            {
                case 1:
                    Console.WriteLine("Enter your Dependecy time(years):");
                    dependency = Console.ReadLine();
                    DrugsAddicts First = new DrugsAddicts(dependency, "0");
                    Console.WriteLine("Enter the drug you started with and you use now 1) Opium, 2) Cannabis, 3) Amphetamine, 4) Ecstasy ");
                    Swicther = Convert.ToInt32(Console.ReadLine());
                    if (Swicther == 1) First.SetType(DrugsAddicts.Drugs.Opium, DrugsAddicts.Drugs.Opium);
                    if (Swicther == 2) First.SetType(DrugsAddicts.Drugs.Cannabis, DrugsAddicts.Drugs.Cannabis);
                    if (Swicther == 3) First.SetType(DrugsAddicts.Drugs.Amphetamine, DrugsAddicts.Drugs.Amphetamine);
                    if (Swicther == 4) First.SetType(DrugsAddicts.Drugs.Ecstasy, DrugsAddicts.Drugs.Ecstasy);
                    First.ShowInfo();
                    Console.WriteLine("Enter index(from 1 to 4) for indexator");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Your choice: {First[index]}");
                    break;
                case 2: 
                    Console.WriteLine("Enter country, sporttype end expirience(years)");
                    country = Console.ReadLine();
                    sporttype = Console.ReadLine();
                    expirience = Convert.ToInt32(Console.ReadLine());
                    Athletes Second = new Athletes(country, sporttype, expirience);
                    Console.WriteLine("Choose your temperament(1.Choleric 2.Sanguine 3.Phlegmatic 4. Melancholy) ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    if (temp == 1) Second.Set(Human.Temperament.Choleric);
                    if (temp == 2) Second.Set(Human.Temperament.Sanguine);
                    if (temp == 3) Second.Set(Human.Temperament.Phlegmatic);
                    if (temp == 4) Second.Set(Human.Temperament.Melancholy);
                    Second.ShowTemp();
                    Second.ShowInfo();
                    break;
                case 3:
                    Console.WriteLine("Enter your teacher name and your school name:");
                    teachname = Console.ReadLine();
                    schoolname = Console.ReadLine();
                    Schoolkids Third = new Schoolkids(teachname, schoolname);
                    Console.WriteLine("Enter number of class and say if u attend math or science class");
                    numclass = Convert.ToInt32(Console.ReadLine());
                    science = Convert.ToBoolean(Console.ReadLine());
                    math = Convert.ToBoolean(Console.ReadLine());
                    Third.SetClass(numclass, math, science);
                    Third.Show();
                    break;
                default: 
                    Console.WriteLine("Error choose, program will be closed"); 
                    break;
            }
        }
    }
}
