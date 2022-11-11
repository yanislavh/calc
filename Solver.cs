using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace calc
{
    /*
     * stepenuvane
     * korenuwane
     * log
     * tan
     * cos
     * sin
     * ln
     * pi
     * vid Rad Deg GDR
 
      */
    class Solver
    {
        string problem;
        List<char> charArr = new List<char>();
        List<int> otvarqshta = new List<int>();
        List<int> zatvarqshta = new List<int>();

        public Solver(string problem)
        {
            this.problem = problem;
            charArr.AddRange(problem);
            this.problem = "(" + problem + ")";
            charArr.Insert(0, '(');
            charArr.Add(')');
            Otvarqshta();
            CalculiraneNaIndex();
        }
        char Ch(string a)
        {
            return Convert.ToChar(a);
        }
        public void Otvarqshta()
        {
            for (int i = 0; i < charArr.Count; i++)
            {
                if (charArr[i] == '(')
                {
                    Zatvarqshta(i);
                    otvarqshta.Add(i);
                }
            }
        }
        void Zatvarqshta(int i)
        {
            int countOtv = 0;
            int countZatv = 0;
            for (int j = i; j < charArr.Count; j++)
            {
                if (charArr[j] == '(') countOtv++;
                else if (charArr[j] == ')') countZatv++;
                if (countOtv == countZatv)
                {
                    zatvarqshta.Add(j);
                    break;
                }
            }
        }
        void CalculiraneNaIndex()
        {
            int puti = otvarqshta.Count;
            for (int i = 0; i < puti; i++)
            {
                int tempNum = zatvarqshta.Min();
                int index = zatvarqshta.IndexOf(tempNum);
                SmqnaReshavane(index);
            }
            Console.WriteLine(problem);
        }
        void SmqnaReshavane(int index)
        {
            char[] tempCharArr = new char[] { }; //masiv ot simvolite v skobite
            List<string> chislaIznaci = new List<string>(); //list kojto shte sydyrja chislata i znacite
            string minProblem = problem.Substring(otvarqshta[index] + 1, zatvarqshta[index] - otvarqshta[index] - 1); //string kojto shte e v edni skobi
            tempCharArr = minProblem.ToCharArray();  //prevryshta go v char masiv
            int tempI = 0;
            for (int i = 0; i < tempCharArr.Length; i++) //razdelq gi na chisla i znaci kato zapomnq mqstoto na posledniq znak i vzima mejdu tqh
            {
                if (tempCharArr[i] == '+' || tempCharArr[i] == '/' || tempCharArr[i] == '*' || tempCharArr[i] == '-')
                {
                    chislaIznaci.Add(minProblem.Substring(tempI, i - tempI));
                    chislaIznaci.Add(tempCharArr[i].ToString());
                    tempI = i + 1;
                }
            }
            chislaIznaci.Add(minProblem.Substring(tempI)); //dobavq poslednoto chislo poneve to ne e mejdu dva znaka
            for (int i = 0; i < chislaIznaci.Count / 2; i++) // ako ima 2 znaka edin do drug dobavq element kojto e prazen string i zatova kato ima takiva gi trie
            {
                if (chislaIznaci.IndexOf("") != -1)
                {
                    chislaIznaci.RemoveAt(chislaIznaci.IndexOf(""));
                }
                else break;
            }
            double reshenieT = 0;
            if (chislaIznaci.Count != 2) // ako chisloto trqbwa da e otricatelno trqbwa da e skobi i tova e kogato ne e samo chislo v skobite
            {
                if (chislaIznaci[0] == "-") //ako pyrviq simvol e minus da go dobavi kym chisloto
                {
                    string temp = "-" + chislaIznaci[1];
                    chislaIznaci.RemoveRange(0, 2);
                    chislaIznaci.Insert(0, temp);
                }
                for (int i = 0; i < chislaIznaci.Count; i++) //proverqva ako ima 2 znaka kojto i da e znak i minus do nego i dobavq minusa v sledashtoto chislo
                {
                    int tempU = chislaIznaci.IndexOf("*");
                    int tempD = chislaIznaci.IndexOf("/");
                    int tempP = chislaIznaci.IndexOf("+");
                    int tempM = chislaIznaci.IndexOf("-");
                    if (chislaIznaci[tempU + 1] == "-")
                    {
                        string temp = "-" + chislaIznaci[tempU + 2];
                        chislaIznaci.RemoveRange(tempU + 1, 2);
                        chislaIznaci.Insert(tempU + 1, temp);
                    }
                    if (chislaIznaci[tempD + 1] == "-")
                    {
                        string temp = "-" + chislaIznaci[tempD + 2];
                        chislaIznaci.RemoveRange(tempD + 1, 2);
                        chislaIznaci.Insert(tempD + 1, temp);
                    }
                    if (chislaIznaci[tempP + 1] == "-")
                    {
                        string temp = "-" + chislaIznaci[tempP + 2];
                        chislaIznaci.RemoveRange(tempP + 1, 2);
                        chislaIznaci.Insert(tempP + 1, temp);
                    }
                    if (chislaIznaci[tempM + 1] == "-")
                    {
                        string temp = "-" + chislaIznaci[tempM + 2];
                        chislaIznaci.RemoveRange(tempM + 1, 2);
                        chislaIznaci.Insert(tempM + 1, temp);
                    }
                }
                for (int i = 0; i < chislaIznaci.Count / 2; i++) //pravi umnojavaneto kato vzima prednoto i sledvashtoto cislo i gi zamenq v chisla i znaci
                {
                    tempI = chislaIznaci.IndexOf("*");
                    if (tempI == -1) break;
                    else
                    {
                        reshenieT = double.Parse(chislaIznaci[tempI - 1]) * double.Parse(chislaIznaci[tempI + 1]);
                        chislaIznaci.RemoveRange(tempI - 1, 3);
                        chislaIznaci.Insert(tempI - 1, reshenieT.ToString());
                    }
                }
                for (int i = 0; i < chislaIznaci.Count / 2; i++) //pravi delenieto analogichno
                {
                    tempI = chislaIznaci.IndexOf("/");
                    if (tempI == -1) break;
                    else
                    {
                        reshenieT = double.Parse(chislaIznaci[tempI - 1]) / double.Parse(chislaIznaci[tempI + 1]);
                        chislaIznaci.RemoveRange(tempI - 1, 3);
                        chislaIznaci.Insert(tempI - 1, reshenieT.ToString());
                    }
                }
                for (int i = 0; i < chislaIznaci.Count / 2; i++) //pravi subiraneto analogichno
                {
                    tempI = chislaIznaci.IndexOf("+");
                    if (tempI == -1) break;
                    else
                    {
                        reshenieT = double.Parse(chislaIznaci[tempI - 1]) + double.Parse(chislaIznaci[tempI + 1]);
                        chislaIznaci.RemoveRange(tempI - 1, 3);
                        chislaIznaci.Insert(tempI - 1, reshenieT.ToString());
                    }
                }

                for (int i = 0; i < chislaIznaci.Count / 2; i++) //pravi izvajdaneto analogichno
                {
                    tempI = chislaIznaci.IndexOf("-");
                    if (tempI == -1) break;
                    else
                    {
                        reshenieT = double.Parse(chislaIznaci[tempI - 1]) - double.Parse(chislaIznaci[tempI + 1]);
                        chislaIznaci.RemoveRange(tempI - 1, 3);
                        chislaIznaci.Insert(tempI - 1, reshenieT.ToString());
                    }
                }
            }
            else //kat cqlo ne pravi nishto no predodvratqva greshka
            {
                string temp = "-" + chislaIznaci[1];
                chislaIznaci.RemoveRange(0, 2);
                chislaIznaci.Insert(0, temp);
            }
            reshenieT = int.Parse(chislaIznaci[0]);
            if (char.IsLetter(Convert.ToChar(problem.Substring(otvarqshta[index] - 1, 1)))) //proverqva dali simvola pred skobite e bukva
            {
                string funkciq = "";
                int indexZaRet = 0;
                char[] reversedProb = problem.Substring(otvarqshta[index] - 6, otvarqshta[index] - (otvarqshta[index] - 6)).ToCharArray();
                for (int i = 0; i < reversedProb.Length; i++)
                {
                    if (char.IsLetter(reversedProb[i])) //proverqva pogolovno 6 simvola predi skobite i gi dobavq v promenliva za proverka na red 230
                    {
                        funkciq += reversedProb[i];
                    }
                }
                for (int i = 0; i < reversedProb.Length; i++) //zapomnq nomera na purviq simvol za da vurne posle v glavniq string i array
                {
                    if (char.IsLetter(reversedProb[i]))
                    {
                        indexZaRet = otvarqshta[index] - (reversedProb.Length - i);
                        break;
                    }
                }
                if (funkciq == "sqrt")
                {
                    reshenieT = Math.Sqrt(reshenieT);
                }
                else if (funkciq == "sin")
                {
                    reshenieT = Math.Sin(Math.PI / 180 * reshenieT);
                }
                else if (funkciq == "cos")
                {
                    reshenieT = Math.Cos(Math.PI / 180 * reshenieT);
                }
                else if (funkciq == "tan")
                {
                    reshenieT = Math.Tan(Math.PI / 180 * reshenieT);
                }
                else if (funkciq == "cotg")
                {
                    reshenieT = 1 / Math.Tan(Math.PI / 180 * reshenieT);
                }
                charArr.RemoveRange(indexZaRet, zatvarqshta[index] - indexZaRet + 1);
                charArr.InsertRange(indexZaRet, reshenieT.ToString().ToCharArray());
            }
            else
            {
                charArr.RemoveRange(otvarqshta[index], zatvarqshta[index] - otvarqshta[index] + 1);
                charArr.InsertRange(otvarqshta[index], reshenieT.ToString().ToCharArray());
            }
            problem = new string(charArr.ToArray());
            otvarqshta.Clear();
            zatvarqshta.Clear();
            chislaIznaci.Clear();
            Array.Clear(tempCharArr, 0, tempCharArr.Length);
            Otvarqshta();
        }
    }
}