using System;
using System.Collections.Generic;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //first
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //second
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //third
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }



            //fourth
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);


            //fifth
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);


            //sixth
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);





        }

        //first answer
        private static void printTriangle(int n)
        {
            try
            {
                for (int i = 1; i <= n; i++)  // for no fo lines in triangle
                {
                    for (int j = i; j <= i; j++)  // for elements in each line
                    {

                        String str = new String(' ', n - j);  //spaces before printing * in each line
                        Console.WriteLine(str + new String('*', (2 * i) - 1)); // printing * in each line

                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //second answer
        private static void printPellSeries(int n2)
        {
            try
            {
                int temp1 = 1;   //second term which is 1 is taken 
                int temp2 = 0;  //first term which is 0 is taken 
                Console.WriteLine(temp2);
                Console.WriteLine(temp1);
                for (int i = 3; i <= n2; i++)  // this takes each term starting from third as first and second are already 0, 1
                {

                    int z = (2 * temp1) + temp2;  //formula of each pell series term


                    Console.WriteLine(z);
                    temp2 = temp1;  //saving the before term of pell term to an earlier term
                    temp1 = z;     //saving the pell term as this becomes term before current pell term for the next one 
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //third answer
        private static bool squareSums(int n3)
        {
            try
            {
                int temp = 0;
                for (int a = 0; a <= n3; a++) // iterating a to check for a*a  format
                {
                    for (int b = 0; b <= n3; b++)  //iterating b to check for b*b format
                    {
                        int t = a * a + b * b;  //formula of required answer
                        if (t == n3)  //checking if lhs=rhs
                        {
                            temp = 1;  //taking temp 1 for true case

                        }


                    }
                }
                if (temp == 1)  // checking if the temp has 1 then returning true or else false
                {

                    return true;
                }
                else             
                {

                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        //fourth answer
        private static int diffPairs(int[] arr, int k)
        {
            try
            {
                
                Array.Sort(arr);  // arranging array in ascending order to avoid negative nos after difference
                int i;
              
                int count = 0;
                for (i = 0; i < 5; i++)     // iterating from 0 to 5 elements in string
                {

                    for (int j = i + 1; j < 5; j++)   //iterating from 0 to 5 elements in the same string but to perform difference
                    {

                        if (k != 0)  // using this condition the duplicates are taken into account for k=0 case
                        {
                            bool isDuplicate = false; // isDuplicate is used to ignore same numbers in array
                            if (arr[i] == arr[j])
                            {
                                isDuplicate = true;
                                break;
                            }
                            if ((arr[j] - arr[i] == k) && isDuplicate == false) // checking for difference along with duplicates
                            {

                                count++;   //incrementing count if any such pair exists
                            }
                        }
                        else
                        {
                            if ((arr[j] - arr[i] == k))  // this case is for array with same nos and k=0 will return corresponding no of pairs
                            {

                                count++;
                            }
                        }
                    }
                }
                



                return count;  // returns the count of pairs



            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }


        //fifth answer
        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                ISet<string> temp = new HashSet<string>();   //using HastSet to get unique emails
                foreach (var element in emails)              //iterating the whole string of email
                {

                    var substr = element.Split(new char[] { '@' });  //spliting string based on @ for loacl names and domain names
                    int another = substr[0].IndexOf('+');            //taking index of '+' 
                    if (another >= 0)
                    {
                        substr[0] = substr[0].Substring(0, another);  // based on '+' the string after that is taen into another string
                    }

                    substr[0] = substr[0].Replace(".", "");   //removing the '.' from string
                    temp.Add($"@{substr[1]}");                //adding the emails to HashSet to get unique ones

                }
                return temp.Count;                            //returning unique emails count
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        //sixth answer
        private static string DestCity(string[,] paths)
        {
            try
            {
                int x = 0;                                  //initializing x=0
                List<string> src = new List<string>();      //taking all sources into one list
                List<string> dstn = new List<string>();     //taking all destinations into one list
                foreach (string res in paths)               
                {
                    if ((x % 2) != 0)                       //cheking for detination items in the given string
                    {
                        dstn.Add(res);
                        x++;
                    }
                    else if (x % 2 == 0)                    //cheking for source items in the given string
                    {
                        src.Add(res);
                        x++;
                    }
                }
                
                foreach (string s in dstn)             //iterating on all items in destination list
                {
                    if (src.Contains(s) == false)      //last destination cannot be source again hence checking with that logic
                    {
                        string temp = s;
                        return temp;
                    }
                }

                return "destination does not exist";


            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
