using System;

namespace LAB5
{

    class Program
    {
        static void Main()
        {
            bool cycle_check = true;
            int switcher, temp, age, type;
            string name = " ", surname = " ", time, country, teacher, school;
            Human Man = new Human(null, null);
            DrugsAddicts NNMan = new DrugsAddicts(null, null);
            Athletes Olympic = new Athletes(null, null, 1);
            Schoolkids Normpoc = new Schoolkids(null, null);
            Human[] Peoples = new Human[] { Man, NNMan, Normpoc, Olympic };
            do
            {
                Console.Clear();
                Console.WriteLine("MENU:" +
                    "\n1 - Create Human" +
                    "\n2 - Create Human with addicts from grugs" +
                    "\n3 - Create Athlet" +
                    "\n4 - Create School kid" +
                    "\n5 - Sort" +
                    "\n6 - Show Student Info" +
                    "\nAny other key - exit from program");//menu

                switcher = Convert.ToInt32(Console.ReadLine());
                if (switcher < 5 && switcher >= 1)
                {
                    Console.WriteLine("Enter your Full name");
                    name = Console.ReadLine();
                    surname = Console.ReadLine();
                }
                switch (switcher)
                {
                    case 1: Man = new Human(name,surname);
                        Console.WriteLine("Enter your temperament" +
                        " 1 - Choleric" +
                        " 2 - Sanguine" +
                        " 3 - Phlegmatic" +
                        " 4 - Melancholy");
                        temp = Convert.ToInt32(Console.ReadLine());
                        Man = new Human(temp, 20);
                        Man.ShowTemp();
                        Console.WriteLine("Enter your age");
                        age = Convert.ToInt32(Console.ReadLine());
                        Man._age = age;
                        Man._expir = age;
                        break;
                    case 2: Console.WriteLine("Enter for how long time you use drugs?");
                        time = Console.ReadLine();
                        NNMan = new DrugsAddicts(time, null);
                        NNMan._name = name;
                        NNMan._surName = surname;
                        Console.WriteLine("Enter type of drugs" +
                        " 1 - Opium" +
                        " 2 - Cannabis" +
                        " 3 - Amphetamine" +
                        " 4 - Ecstasy");
                        type = Convert.ToInt32(Console.ReadLine());
                        switch(type)
                        {
                            case 1: NNMan.SetType(DrugsAddicts.Drugs.Opium, DrugsAddicts.Drugs.Opium);  break;
                            case 2: NNMan.SetType(DrugsAddicts.Drugs.Cannabis, DrugsAddicts.Drugs.Cannabis); break;
                            case 3: NNMan.SetType(DrugsAddicts.Drugs.Amphetamine, DrugsAddicts.Drugs.Amphetamine); break;
                            case 4: NNMan.SetType(DrugsAddicts.Drugs.Ecstasy, DrugsAddicts.Drugs.Ecstasy); break;
                            default: Console.WriteLine("Error input"); break;
                        }
                        Console.WriteLine("Enter your age");
                        age = Convert.ToInt32(Console.ReadLine());
                        NNMan._age = age;
                        break;
                    case 3: Console.WriteLine("Enter your country, sport type and expirience");
                        country = Console.ReadLine();
                        time = Console.ReadLine();
                        type = Convert.ToInt32(Console.ReadLine());
                        Olympic = new Athletes(country, time, type);
                        break;
                    case 4: Console.WriteLine("Enter Name of your teacher and name of your school");
                        teacher = Console.ReadLine();
                        school = Console.ReadLine();
                        Normpoc = new Schoolkids(teacher, school);
                        Normpoc._name = name;
                        Normpoc._surName = surname;
                        Console.WriteLine("Enter the class your visiting(1 - A, 2 - B, 3 - C)");
                        type = Convert.ToInt32(Console.ReadLine());
                        Normpoc.SetClass(type, false, false);
                        Console.WriteLine("Enter what class you attend");
                        age = Convert.ToInt32(Console.ReadLine());
                        Normpoc._expir = age;
                        break;
                    case 5: Peoples = new Human[] {Man, NNMan, Normpoc, Olympic };
                        Array.Sort(Peoples); break;
                    case 6: for (int i = 0; i < 4; i++){
                            Peoples[i].Show();
                        }; break;
                    default: cycle_check = false; Console.WriteLine("Program ends"); Environment.Exit(0); break;
                } 
                Console.WriteLine("Do you want ot change some information? (1 = yes, any other symbol = no)");
                switcher = Convert.ToInt32(Console.ReadLine());
                switch(switcher)
                {
                    case 1: Console.WriteLine("Restart this program, a have no time to add this ability in this cycle"); break;
                    default: Console.WriteLine("OK"); break;
                }  
            }
            while (cycle_check);
        }
    }
}
