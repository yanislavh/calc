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
            for (int i = 0; i < chislaIznaci.Count / 2; i++)
            {
                if (chislaIznaci.IndexOf("") != -1)
                {
                    chislaIznaci.RemoveAt(chislaIznaci.IndexOf(""));
                }
                else break;
            }
            double reshenieT = 0;
            if (chislaIznaci.Count != 2)
            {
                for (int i = 0; i < chislaIznaci.Count; i++)
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
                for (int i = 0; i < chislaIznaci.Count / 2; i++)
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
                for (int i = 0; i < chislaIznaci.Count / 2; i++)
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
                for (int i = 0; i < chislaIznaci.Count / 2; i++)
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

                for (int i = 0; i < chislaIznaci.Count / 2; i++)
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
            else
            {
                string temp = "-" + chislaIznaci[1];
                chislaIznaci.RemoveRange(0, 2);
                chislaIznaci.Insert(0, temp);
            }
            reshenieT = int.Parse(chislaIznaci[0]);
            //problem = problem.Substring(0, otvarqshta[index]) + reshenieT.ToString() + problem.Substring(zatvarqshta[index]);
            charArr.RemoveRange(otvarqshta[index], zatvarqshta[index] - otvarqshta[index] + 1);
            charArr.InsertRange(otvarqshta[index], reshenieT.ToString().ToCharArray());
            problem = new string(charArr.ToArray());
            otvarqshta.Clear();
            zatvarqshta.Clear();
            chislaIznaci.Clear();
            Array.Clear(tempCharArr, 0, tempCharArr.Length);
            Otvarqshta();
            //imame problemi sys otricatelnite chisla
            //tozi metod ne baca kogato imam otricatelno pyrwo chislo
        }
    }

}
