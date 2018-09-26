using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace String_Program
{
    class Program
    {   
        

        static void Main(string[] args)
        {
            List<string> para = new List<string>();
            string sentence;
            Console.WriteLine("String Program");
            Console.WriteLine("_______________");
            Console.WriteLine("Enter the text for input. Enter  1 for exit");
            //Reading input
            do
            {
                sentence = Console.ReadLine();
                if (sentence.Contains("1") == true)
                {
                    break;
                }
                para.Add(sentence);
                sentence = "";
            } while (sentence != "1");
            //Convert paragrah into lowercase and remove special characters
           para= Convert(para);
            //Processing input
            Process(para);

            Console.WriteLine("Press any key to exit:");

            Console.ReadKey();
        }
        static List<string> Convert(List<string> para)
        {
            int index = 0;
            string str;
            index = para.Count();
            List<string> output = new List<string>(index);
            Regex regex = new Regex("[^a-zA-Z0-9]");
            index = 0;
            foreach (string sentence in para)
            {
                str = regex.Replace(sentence, " ");
                str = str.ToUpper();
                output.Add(str);
                index++;
            }

            return output;
            
        }
        static void Process(List<string> para)
        {
            string firstword;
            int lenght, index;
            int i ;
            int strt = 0;
            int cnt = 0;
            int idx = 0;
            int j = -1;
            bool flag;
            List<string> output = new List<string>();
            index = 0;
            lenght = para.Count;
            string str;
            //take each sentence in paragrah
            foreach (string sentence in para)
            {
                str = sentence.Trim();//Remove whitespaces
                //put each words in sentence to array
                var Wordsarray = str.Split();
                idx = Wordsarray.Count();//count of word array
                //Looping words in each words array
                for (i = 0; i <= idx - 2; i++)
                {
                    firstword = Wordsarray[i] + " " + Wordsarray[i + 1];//substring for checking

                    strt = 0;
                    //Check if searching words repeadily.
                    flag = false;
                    foreach (string check in output)
                    {
                        strt = check.IndexOf(firstword);
                        if (strt != -1)
                        {
                            flag = true;
                            break;//already checked words
                        }
                    }
                    if (flag == true)
                        continue;//no need to check proceed the loop.

                    foreach (string strt1 in para)
                    {
                        j++;
                        if (j >= index)
                        {
                            strt = strt1.IndexOf(firstword);
                            if (strt != -1)
                            {
                                cnt += 1;
                            }
                        }

                    }
                    if (cnt > 1)
                    { 
                    Console.Write("The string '{0}' occurs " + cnt + " times.\n", firstword);
                }
                output.Add(firstword);
                    cnt = 0;
                }
                //input first word into output array and check.

                index++;// index of sentence in paragragh 
            } 
            }

        }
   
    }


