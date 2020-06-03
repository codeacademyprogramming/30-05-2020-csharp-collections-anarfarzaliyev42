using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Net.Cache;
using System.Runtime.InteropServices;

namespace Test
{


    class Program
    {

        static void Main(string[] args)
        {
            List<Debtor> debtors = new List<Debtor> {
                new Debtor("Shirley T. Qualls", DateTime.Parse("March 30, 1932"), "530-662-7732", "ShirleyTQualls@teleworm.us", "3565 Eagles Nest Drive Woodland, CA 95695", 2414),
                new Debtor("Danielle W. Grier", DateTime.Parse("October 18, 1953"), "321-473-4178", "DanielleWGrier@rhyta.com", "1973 Stoneybrook Road Maitland, FL 32751", 3599),
                new Debtor("Connie W. Lemire", DateTime.Parse("June 18, 1963"), "828-321-3751", "ConnieWLemire@rhyta.com", "2432 Hannah Street Andrews, NC 28901", 1219),
                new Debtor("Coy K. Adams", DateTime.Parse("March 1, 1976"), "410-347-1307", "CoyKAdams@dayrep.com", "2411 Blue Spruce Lane Baltimore, MD 21202", 3784),
                new Debtor("Bernice J. Miles", DateTime.Parse("June 1, 1988"), "912-307-6797", "BerniceJMiles@armyspy.com", "4971 Austin Avenue Savannah, GA 31401", 4060),
                new Debtor("Bob L. Zambrano", DateTime.Parse("February 28, 1990"), "706-446-1649", "BobLZambrano@armyspy.com", "2031 Limer Street Augusta, GA 30901", 6628),
                new Debtor("Adam D. Bartlett", DateTime.Parse("May 6, 1950"), "650-693-1758", "AdamDBartlett@rhyta.com", "2737 Rardin Drive San Jose, CA 95110", 5412),
                new Debtor("Pablo M. Skinner", DateTime.Parse("August 26, 1936"), "630-391-2034", "PabloMSkinner@armyspy.com", "16 Fraggle Drive Hickory Hills, IL 60457", 11097),
                new Debtor("Dorothy J. Brown", DateTime.Parse("July 9, 1971"), "270-456-3288", "DorothyJBrown@rhyta.com", "699 Harper Street Louisville, KY 40202", 7956),
                new Debtor("Larry A. Miracle", DateTime.Parse("May 22, 1998"), "301-621-3318", "LarryAMiracle@jourrapide.com", "2940 Adams Avenue Columbia, MD 21044", 7150),
                new Debtor("Donna B. Maynard", DateTime.Parse("January 26, 1944"), "520-297-0575", "DonnaBMaynard@teleworm.us", "4821 Elk Rd Little Tucson, AZ 85704", 2910),
                new Debtor("Jessica J. Stoops", DateTime.Parse("April 22, 1989"), "360-366-8101", "JessicaJStoops@dayrep.com", "2527 Terra Street Custer, WA 98240", 11805),
                new Debtor("Audry M. Styles", DateTime.Parse("February 7, 1937"), "978-773-4802", "AudryMStyles@jourrapide.com", "151 Christie Way Marlboro, MA 01752", 1001),
                new Debtor("Violet R. Anguiano", DateTime.Parse("November 4, 1958"), "585-340-7888", "VioletRAnguiano@dayrep.com", "1460 Walt Nuzum Farm Road Rochester, NY 14620", 9128),
                new Debtor("Charles P. Segundo", DateTime.Parse("October 21, 1970"), "415-367-3341", "CharlesPSegundo@dayrep.com", "1824 Roosevelt Street Fremont, CA 94539", 5648),
                new Debtor("Paul H. Sturtz", DateTime.Parse("September 15, 1944"), "336-376-1732", "PaulHSturtz@dayrep.com", "759 Havanna Street Saxapahaw, NC 27340", 10437),
                new Debtor("Doris B. King", DateTime.Parse("October 10, 1978"), "205-231-8973", "DorisBKing@rhyta.com", "3172 Bedford Street Birmingham, AL 35203", 7230),
                new Debtor("Deanna J. Donofrio", DateTime.Parse("April 16, 1983"), "952-842-7576", "DeannaJDonofrio@rhyta.com", "1972 Orchard Street Bloomington, MN 55437", 515),
                new Debtor("Martin S. Malinowski", DateTime.Parse("January 17, 1992"), "765-599-3523", "MartinSMalinowski@dayrep.com", "3749 Capitol Avenue New Castle, IN 47362", 1816),
                new Debtor("Melissa R. Arner", DateTime.Parse("May 24, 1974"), "530-508-7328", "MelissaRArner@armyspy.com", "922 Hill Croft Farm Road Sacramento, CA 95814", 5037),
                new Debtor("Kelly G. Hoffman", DateTime.Parse("September 22, 1969"), "505-876-8935", "KellyGHoffman@armyspy.com", "4738 Chapmans Lane Grants, NM 87020", 7755),
                new Debtor("Doyle B. Short", DateTime.Parse("June 15, 1986"), "989-221-4363", "DoyleBShort@teleworm.us", "124 Wood Street Saginaw, MI 48607", 11657),
                new Debtor("Lorrie R. Gilmore", DateTime.Parse("December 23, 1960"), "724-306-7138", "LorrieRGilmore@teleworm.us", "74 Pine Street Pittsburgh, PA 15222", 9693),
                new Debtor("Lionel A. Cook", DateTime.Parse("April 16, 1972"), "201-627-5962", "LionelACook@jourrapide.com", "29 Goldleaf Lane Red Bank, NJ 07701", 2712),
                new Debtor("Charlene C. Burke", DateTime.Parse("January 18, 1990"), "484-334-9729", "CharleneCBurke@armyspy.com", "4686 Renwick Drive Philadelphia, PA 19108", 4016),
                new Debtor("Tommy M. Patton", DateTime.Parse("June 30, 1981"), "774-571-6481", "TommyMPatton@rhyta.com", "748 Rockford Road Westborough, MA 01581", 349),
                new Debtor("Kristin S. Bloomer", DateTime.Parse("June 16, 1944"), "443-652-0734", "KristinSBloomer@dayrep.com", "15 Hewes Avenue Towson, MD 21204", 9824),
                new Debtor("Daniel K. James", DateTime.Parse("November 10, 1997"), "801-407-4693", "DanielKJames@rhyta.com", "3052 Walton Street Salt Lake City, UT 84104", 8215),
                new Debtor("Paula D. Henry", DateTime.Parse("September 6, 1976"), "618-378-5307", "PaulaDHenry@rhyta.com", "3575 Eagle Street Norris City, IL 62869", 5766),
                new Debtor("Donna C. Sandoval", DateTime.Parse("December 13, 1947"), "540-482-5463", "DonnaCSandoval@rhyta.com", "675 Jehovah Drive Martinsville, VA 24112", 8363),
                new Debtor("Robert T. Taylor", DateTime.Parse("August 17, 1932"), "270-596-6442", "RobertTTaylor@armyspy.com", "2812 Rowes Lane Paducah, KY 42001", 7785),
                new Debtor("Donna W. Alamo", DateTime.Parse("December 9, 1948"), "978-778-2533", "DonnaWAlamo@teleworm.us", "4367 Christie Way Marlboro, MA 01752", 10030),
                new Debtor("Amy R. Parmer", DateTime.Parse("May 19, 1995"), "480-883-4934", "AmyRParmer@armyspy.com", "85 Elmwood Avenue Chandler, AZ 85249", 5347),
                new Debtor("Newton K. Evans", DateTime.Parse("October 8, 1986"), "303-207-9084", "NewtonKEvans@rhyta.com", "3552 Columbia Road Greenwood Village, CO 80111", 9838),
                new Debtor("Kathleen C. Chaney", DateTime.Parse("January 5, 1949"), "605-245-3513", "KathleenCChaney@rhyta.com", "316 Elsie Drive Fort Thompson, SD 57339", 1672),
                new Debtor("Manuel C. Johnson", DateTime.Parse("February 23, 1957"), "606-247-2659", "ManuelCJohnson@jourrapide.com", "4146 May Street Sharpsburg, KY 40374", 9195),
                new Debtor("Carla A. Creagh", DateTime.Parse("November 21, 1988"), "615-302-8974", "CarlaACreagh@dayrep.com", "3106 Bates Brothers Road Columbus, OH 43215", 11271),
                new Debtor("Norma M. New", DateTime.Parse("May 18, 1988"), "857-492-8703", "NormaMNew@jourrapide.com", "965 Metz Lane Woburn, MA 01801", 9761),
                new Debtor("Roy D. Green", DateTime.Parse("January 27, 1983"), "308-340-5981", "RoyDGreen@jourrapide.com", "401 Romrog Way Grand Island, NE 68801", 10771),
                new Debtor("Cristy J. Jensen", DateTime.Parse("November 2, 1935"), "440-626-9550", "NormaMNew@jourrapide.com", "2177 Harley Vincent Drive Cleveland, OH 44113", 5205),
                new Debtor("Nancy J. Fergerson", DateTime.Parse("June 10, 1993"), "219-987-8498", "NancyJFergerson@dayrep.com", "3584 Jadewood Drive Demotte, IN 46310", 1276),
                new Debtor("Dave N. Rodriguez", DateTime.Parse("January 21, 1938"), "214-540-2499", "DaveNRodriguez@rhyta.com", "1890 Poco Mas Drive Dallas, TX 75247", 9132),
                new Debtor("James E. Denning", DateTime.Parse("May 4, 1988"), "504-289-8640", "JamesEDenning@jourrapide.com", "1444 Rose Avenue Metairie, LA 70001", 8176),
                new Debtor("Richard M. Thomas", DateTime.Parse("February 13, 1972"), "510-735-3359", "RichardMThomas@jourrapide.com", "4454 Green Avenue Oakland, CA 94609", 7875),
                new Debtor("Lakisha R. Forrest", DateTime.Parse("December 1, 1973"), "334-830-1181", "LakishaRForrest@armyspy.com", "3121 Quarry Drive Montgomery, AL 36117", 3088),
                new Debtor("Pamela H. Beauchamp", DateTime.Parse("November 20, 1959"), "801-529-6347", "PamelaHBeauchamp@jourrapide.com", "3239 Tori Lane Salt Lake City, UT 84104", 6588)
            };
            Console.WriteLine("\n---------------------Debtors selected by domain names:\n");
            List<Debtor> domainDebtors = GetDebtorByDomain(debtors, "NormaMNew@jourrapide.com");
            domainDebtors.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\n---------------------Debtors selected by ages :\n");
            List<Debtor> ageDebtors = GetDebtorByAge(debtors, 26, 36);
            ageDebtors.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\n---------------------Debtors selected by specific amount of debt :\n");
            List<Debtor> debtDebtors = GetDebtorByAmountOfDebt(debtors, 5000);
            debtDebtors.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\n---------------------Debtors selected by symbol size and phone number :\n");
            GetDebtorsBySymbolAndPhoneNumber(debtors);
            Console.WriteLine("\n---------------------Debtors born in winter :\n");
            List<Debtor> debtorsBornInWinter = GetDebtorsBornInWinter(debtors);
            debtorsBornInWinter.ForEach(x => Console.WriteLine(x.ToString()));

            DebtorTask8(debtors);
            Console.WriteLine("\n--------------------Name, Age and Debt of Debtors who doesnt have 8 in their phone number :\n");
            DebtorTask9(debtors);
            Console.WriteLine("\n--------------------Debtors who has at least 3 same letter in the name listed by alphabetic order  :\n");
            DebtorTask11(debtors);
            Console.WriteLine("\n--------------------Most debtors born in\n");
            DebtorTask13(debtors);
            Console.WriteLine("\n--------------------Max salary 5 debtor\n");
            DebtorTask14(debtors);
            Console.WriteLine("\n--------------------Sum of debts\n");
            DebtorTask15(debtors);
            Console.WriteLine("\n--------------------Debtors who saw second World War\n");
            DebtorTask16(debtors);
            Console.WriteLine("\n--------------------Debtors whose phone number consist of unique numbers\n");
            DebtorTask18(debtors);
            Console.WriteLine("\n--------------------Debtors can pay till birthday\n");
            DebtorTask19(debtors);
            Console.WriteLine("\n--------------------'Smile' can be created from name of this debtors\n");
            DebtorTask20(debtors);

            Console.ReadKey();
        }
        static void DebtorTask20(List<Debtor> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                int indexOfSpace = list[i].FullName.IndexOf(" ");
                string firstName = list[i].FullName.Substring(0, indexOfSpace);
                string lastName = list[i].FullName.Substring(indexOfSpace + 4);
                string fullName = String.Concat(firstName, lastName);
                char[] wantedWord = new char[] { 's', 'm', 'i', 'l', 'e' };
                List<char> nameChars = fullName.ToLower().ToCharArray().ToList();
                int oldLength = nameChars.Count;

                foreach (var item in wantedWord)
                {
                    nameChars.Remove(item);
                }

                int newLength = nameChars.Count;

                if ((oldLength - newLength) == wantedWord.Length)
                {

                    Console.WriteLine(list[i].ToString());
                }

            }
        }
        static void DebtorTask19(List<Debtor> list)
        {
            DateTime today = DateTime.Today;


            for (int i = 0; i < list.Count; i++)
            {
                int debt = list[i].Debt;
                int monthlyAmount = 500;
                DateTime next = new DateTime(today.Year, list[i].BirthDay.Month, list[i].BirthDay.Day);

                if (next < today)
                {
                    next = next.AddYears(1);
                }

                double numDays = (next - today).Days;

                int months = (int)Math.Ceiling(numDays / 31);
                int debtEndInMonths = debt / monthlyAmount;
                if (debtEndInMonths <= months)
                {
                    Console.WriteLine(list[i].ToString());
                }
            }
        }

        static void DebtorTask18(List<Debtor> list)
        {


            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
                foreach (var item in list[i].Phone)
                {
                    if (item != '-')
                    {
                        if (keyValuePairs.ContainsKey(item))
                        {
                            keyValuePairs[item]++;
                        }
                        else
                        {
                            keyValuePairs.Add(item, 1);
                        }
                    }

                }
                List<int> counts = keyValuePairs.Values.ToList();
                bool isAllUnique = counts.TrueForAll(x => x == 1);
                if (isAllUnique)
                {
                    Console.WriteLine(list[i].ToString());
                }
            }


        }

        static void DebtorTask16(List<Debtor> list)
        {
            DateTime now = DateTime.Now;
            DateTime endOfSecondWW = new DateTime(1945, 9, 2);
            TimeSpan daysFromWWSEnded = now - endOfSecondWW;

            for (int i = 0; i < list.Count; i++)
            {
                TimeSpan daysFromDebtorBorn = now - list[i].BirthDay;

                if (daysFromWWSEnded < daysFromDebtorBorn)
                {
                    Console.WriteLine(list[i].ToString());
                }
            }
        }
        static void DebtorTask15(List<Debtor> list)
        {
            int totalDebtSum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                totalDebtSum += list[i].Debt;
            }
            Console.WriteLine($"\nTotal debt is {totalDebtSum}\n");
        }
        static void DebtorTask14(List<Debtor> list)
        {
            List<Debtor> debtors = list.OrderBy(x => x.Debt).ToList();
            int count = 5;
            for (int i = debtors.Count - 1; i >= 0; i--)
            {
                if (count > 0)
                {
                    Console.WriteLine(debtors[i].ToString());
                    count--;
                }

            }

        }
        static void DebtorTask13(List<Debtor> list)
        {

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {


                int year = list[i].BirthDay.Year;
                if (keyValuePairs.ContainsKey(year))
                {
                    keyValuePairs[year]++;
                }
                else
                {
                    keyValuePairs.Add(year, 1);
                }

            }
            List<int> countYears = keyValuePairs.Values.ToList();
            int maxCountYear = countYears.Max();

            foreach (var item in keyValuePairs)
            {

                if (item.Value == maxCountYear)
                {
                    Console.WriteLine($"\n {item.Value} debtors born in {item.Key}\n");
                }
            }


        }
        static void DebtorTask11(List<Debtor> list)
        {

            List<Debtor> debtors = new List<Debtor>();
            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

                foreach (var item in list[i].FullName)
                {
                    if (keyValuePairs.ContainsKey(item))
                    {
                        keyValuePairs[item]++;

                    }
                    else
                    {
                        keyValuePairs.Add(item, 1);
                    }
                    if (keyValuePairs[item] == 3)
                    {
                        debtors.Add(list[i]);
                        break;
                    }
                }

            }

            List<Debtor> sortedByAlpha = debtors.OrderBy(x => x.FullName).ToList();
            sortedByAlpha.ForEach(x => Console.WriteLine(x.ToString()));

        }
        static void DebtorTask9(List<Debtor> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                int count = 0;
                string phoneNumber = list[i].Phone;
                foreach (var item in phoneNumber)
                {
                    if (item == '8')
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    int age = CalculateAge(list[i].BirthDay);
                    Console.WriteLine($"FullName:{list[i].FullName} Age:{age} Debt:{list[i].Debt}");
                }
            }
        }
        static void DebtorTask8(List<Debtor> list)
        {
            int totalDebt = 0;
            list.ForEach(x => totalDebt += x.Debt);
            int averageDebt = totalDebt / list.Count;
            List<Debtor> debtors = list.FindAll(x => x.Debt > averageDebt);
            Console.WriteLine($"\n---------------------Debtors that debt is more than average ( Average is:{averageDebt} ) :\n");

            debtors.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\n---------------------Above list Sorted by name\n");

            List<Debtor> sortedByName = debtors.OrderBy(x => x.FullName).ToList();
            sortedByName.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\n---------------------Above list Sorted by debt in descending order\n");
            List<Debtor> sortedByDebt = debtors.OrderBy(x => x.Debt).ToList();
            sortedByDebt.Reverse();
            sortedByDebt.ForEach(x => Console.WriteLine(x.ToString()));

        }
        static List<Debtor> GetDebtorsBornInWinter(List<Debtor> list)
        {

            List<Debtor> debtors = list.FindAll(x => x.BirthDay.Month == 12 || x.BirthDay.Month == 1 || x.BirthDay.Month == 2);
            return debtors;
        }
        static void GetDebtorsBySymbolAndPhoneNumber(List<Debtor> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string fullName = list[i].FullName;
                string phoneNumber = list[i].Phone;
                int count = 0;
                foreach (var item in phoneNumber)
                {
                    if (item == '7')
                    {
                        count++;
                    }
                }
                if (fullName.Length >= 18 && count >= 2)
                {
                    Console.WriteLine(list[i]);
                }
            }
        }
        static List<Debtor> GetDebtorByDomain(List<Debtor> list, string email)
        {
            List<Debtor> debtors = list.FindAll(x => x.Email == email);

            return debtors;
        }
        static List<Debtor> GetDebtorByAge(List<Debtor> list, int minAge, int maxAge)
        {
            List<Debtor> debtors = new List<Debtor>();
            for (int i = 0; i < list.Count; i++)
            {
                int age = CalculateAge(list[i].BirthDay);

                if (age >= minAge && age <= maxAge)
                {
                    debtors.Add(list[i]);
                }
            }

            return debtors;

        }
        static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
        static List<Debtor> GetDebtorByAmountOfDebt(List<Debtor> list, int debt)
        {
            List<Debtor> debtors = list.FindAll(x => x.Debt < debt);

            return debtors;
        }

    }
    class Debtor
    {
        public Debtor(string fullname, DateTime birthDay, string phone, string email, string address, int debt)
        {
            this.FullName = fullname;
            this.BirthDay = birthDay;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.Debt = debt;
        }

        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Debt { get; set; }
        public override string ToString()
        {
            return $"{this.FullName} {this.BirthDay.ToShortDateString()} {this.Phone} {this.Email} {this.Address} {this.Debt}";
        }
    }


}

