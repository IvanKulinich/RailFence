using System;
using System.Collections.Generic;
using System.Linq;

namespace RailFenceCipher
{
    class Program
    {
        private static string Encode(string text, int railCount)
        {
            if (text == null)
            {
                throw new NullReferenceException("Text can not be null");
            }

            if (railCount < 2)
            {
                throw new ArgumentException("Wrong railCount argument: " + railCount);
            }

            if (text == String.Empty)
            {
                return "";
            }

            string[] arrRail = new string[railCount];
            int railIndex = 0;
            int way = 1;
            int wayCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                arrRail[railIndex] += text[i];
                railIndex += way;
                wayCount++;

                if (wayCount == railCount - 1)
                {
                    way *= -1;
                    wayCount = 0;
                }
            }

            return arrRail.Aggregate("", (a, b) => a + b);
        }


        private static string Decode(string text, int railCount)
        {
            if (text == null)
            {
                throw new NullReferenceException("Text can not be null");
            }

            if (railCount < 2)
            {
                throw new ArgumentException("Wrong railCount argument: " + railCount);
            }

            if (text == String.Empty)
            {
                return "";
            }

            string[] arrRail = new string[railCount];
            int railIndex = 0;
            int way = 1;
            int wayCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                arrRail[railIndex] += text[i];
                railIndex += way;
                wayCount++;

                if (wayCount == railCount - 1)
                {
                    way *= -1;
                    wayCount = 0;
                }
            }

            int[] arrayRailsLength = arrRail.Select(r => r.Length).ToArray();

            List<string> listOfRails = new List<string>();
            int cur = 0;

            for (int i = 0; i < railCount; i++)
            {
                string railStr = text.Substring(cur, arrayRailsLength[i]);
                listOfRails.Add(railStr);
                cur += arrayRailsLength[i];
            }

            railIndex = 0;
            way = 1;
            wayCount = 0;

            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                result += char.ToString(listOfRails[railIndex].First());
                listOfRails[railIndex] = listOfRails[railIndex].Remove(0, 1);
                railIndex += way;
                wayCount++;

                if (wayCount == railCount - 1)
                {
                    way *= -1;
                    wayCount = 0;
                }
            }

            return result;
        }


        static void Main(string[] args)
        {
            try
            {
                string testText1 = "WEAREDISCOVEREDFLEEATONCE";
                string resultEncode1 = Encode(testText1, 3);
                Console.WriteLine(resultEncode1);

                string testText2 = "";
                string resultEncode2 = Encode(testText2, 3);
                Console.WriteLine(resultEncode2);


                string testText3 = "WECRLTEERDSOEEFEAOCAIVDEN";
                string resultDecode1 = Decode(testText3, 3);
                Console.WriteLine(resultDecode1);

                string testText4 = "";
                string resultDecode2 = Decode(testText4, 3);
                Console.WriteLine(resultDecode2);
            }
            catch (NullReferenceException nullEx)
            {
                Console.WriteLine(nullEx.Message);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }     
    }
}
