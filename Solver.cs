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
            string[] chislaIznaci = new string[] { };
            string minProblem = problem.Substring(otvarqshta[index] + 1, zatvarqshta[index]-otvarqshta[index] - 1);
            string minproblemzasplit = "";
            tempCharArr = minProblem.ToCharArray();
            int tempI = 0;
            minproblemzasplit.Replace('+', ' ');
            minproblemzasplit.Replace('-', ' ');
            minproblemzasplit.Replace('*', ' ');
            minproblemzasplit.Replace('/', ' ');
            chislaIznaci = minproblemzasplit.Split(' ');
            for (int i = 0; i < tempCharArr.Length; i++)
            {
                
                  if(tempCharArr[i] == '+' || tempCharArr[i] == '-' || tempCharArr[i] == '*' || tempCharArr[i] == '/')
                {
                    
                    //chislaIznaci.Add(minProblem.Substring(tempI, i ));
                    //tempI = i + 1;
                    //chislaIznaci.Add(tempCharArr[i].ToString());
                }
                
            }
            //chislaIznaci.Add(minProblem.Substring(tempI));
        }
    }
}
