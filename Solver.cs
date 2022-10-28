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
     * +
     * _
     * :
     * .
       
      */
    class Solver
    {
        string problem;
        char[] charArr = new char[] { };
        List<int> otvarqshta = new List<int>();
        List<int> zatvarqshta = new List<int>();
        
        public Solver(string problem)
        {
            this.problem = problem;
            charArr = problem.ToCharArray();
        }
        char Ch(string a)
        {
            return Convert.ToChar(a);
        }
        public void Otvarqshta()
        {
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == Ch("("))
                {
                    Zatvarqshta(i);
                    otvarqshta.Add(i);
                }
            }
            CalculiraneNaIndex();
        }
        void Zatvarqshta(int i)
        {
            int countOtv = 0;
            int countZatv = 0;
            for (int j = i; j < charArr.Length; j++)
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
            int tempNum = zatvarqshta.Min();
            int index = zatvarqshta.IndexOf(tempNum);
            SmqnaReshavane(index);
        }
        void SmqnaReshavane(int index)
        {
            char[] tempCharArr = new char[] { };
            List<string> chislaIznaci = new List<string>();
            string minProblem = problem.Substring(otvarqshta[index] + 1, zatvarqshta[index] - otvarqshta[index] - 1);
            tempCharArr = minProblem.ToCharArray();
            int tempI = 0;
            for (int i = 0; i < tempCharArr.Length; i++)
            {
                if (tempCharArr[i] == '+' || tempCharArr[i] == '/' || tempCharArr[i] == '*' || tempCharArr[i] == '-')
                {
                    chislaIznaci.Add(minProblem.Substring(tempI, i - tempI));
                    chislaIznaci.Add(tempCharArr[i].ToString());
                    tempI = i + 1;
                }
            }
            chislaIznaci.Add(minProblem.Substring(tempI));
            double reshenieT = 0;
            for (int i = 1; i <= chislaIznaci.Count; i++)
            {
                if (chislaIznaci[i-1] == "*")
                {
                    reshenieT = double.Parse(chislaIznaci[i - 1]) * double.Parse(chislaIznaci[i + 1]);
                    chislaIznaci.RemoveRange(i - 1, 3);
                    chislaIznaci.Insert(i - 1, reshenieT.ToString());

                }
                else if (chislaIznaci[i-1] == "/") //problem sveti tuka demek ot cikyla neshto
                {
                    reshenieT = double.Parse(chislaIznaci[i - 1]) / double.Parse(chislaIznaci[i + 1]);
                    chislaIznaci.RemoveRange(i - 1, 3);
                    chislaIznaci.Insert(i - 1, reshenieT.ToString());
                }
            }
            for (int i = 1; i <= chislaIznaci.Count; i++)
            {
                if (chislaIznaci[i-1] == "+")
                {
                    reshenieT = double.Parse(chislaIznaci[i - 1]) + double.Parse(chislaIznaci[i + 1]);
                    chislaIznaci.RemoveRange(i - 1, 3);
                    chislaIznaci.Insert(i - 1, reshenieT.ToString());
                }
                else if (chislaIznaci[i-1] == "-")
                {

                    reshenieT = double.Parse(chislaIznaci[i - 1]) - double.Parse(chislaIznaci[i + 1]);
                    chislaIznaci.RemoveRange(i - 1, 3);
                    chislaIznaci.Insert(i - 1, reshenieT.ToString()); // ima problem sus znacite i stava sled tova 2 i ne zachita minusa
                }
            }
        }
    }
}
