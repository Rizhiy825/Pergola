using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pergola
{

    class Program
    {
        static void Main(string[] args)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            string path = @"C:\Users\User\source\repos\Pergola\Pergola\X.txt";
            StreamReader sr = new StreamReader(path);

            string allText = sr.ReadToEnd();
            string[] lines = allText.Split('\n');
            List<int> numbers = new List<int>();
            Random random = new Random();
            List<int> indexes = new List<int>();

            foreach (string word in lines)
            {
                string[] coord = word.Split(' ');
                List<double> coordInt = new List<double>();

                foreach (string cord in coord)
                {
                    double c = double.Parse(cord);
                    coordInt.Add(c);
                }

                x.Add(coordInt[0]);
                y.Add(coordInt[1]);
            }

            int listCount = x.Count;
            List<List<int>> comb = new List<List<int>>();

            for (int i = 0; i < listCount; i++)
            {
                for (int l = 0; l < listCount; l++)
                {
                    if (i == l)
                    {

                    }
                    else
                    {

                        List<int> combAdd = new List<int>();
                        combAdd.Add(i);
                        combAdd.Add(l);
                        comb.Add(combAdd);
                    }
                }
            }

            int combListCount = comb.Count;

            List<List<int>> resultCombinations = new List<List<int>>();
            List<int> deleteInd = new List<int>();

            while (comb.Count > 0)
            {
                List<int> check = new List<int>();
                check = comb[0];
                int firstScale = check[0];
                int secondScale = check[1];
                int counter = comb.Count;





                for (int l = 0; l < counter; l++)
                {
                    List<int> checker = new List<int>();
                    checker = comb[l];
                    int firstScaler = checker[0];
                    int secondScaler = checker[1];

                    if (
                        firstScale == firstScaler && secondScale == secondScaler ||
                        firstScale == secondScaler && secondScale == firstScaler
                        )
                    {
                        deleteInd.Add(l);
                    }
                }

                deleteInd.Reverse();

                foreach (int index in deleteInd)
                {
                    comb.RemoveAt(index);
                }
                resultCombinations.Add(check);
                deleteInd.Clear();
            }


            for (int i = 0; i < resultCombinations.Count; i++)
            {
                List<int> res = new List<int>();
                res = resultCombinations[i];

                    double firstX = x[res[0]];
                    double firstY = y[res[0]];
                    double secondX = x[res[1]];
                    double secondY = y[res[1]];

                    double xScale = Math.Abs(secondX - firstX);
                    double yScalae = Math.Abs(secondY - firstY);

                    double r = Math.Sqrt(Math.Pow(xScale, 2) + Math.Pow(yScalae, 2));
                    r = Math.Round(r);
                    Console.WriteLine(r);
              





            }
        }



    }
}
