using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LinkedListvsArray
{

    class Program
    {
        static int iTotal = 17000000;
        static string small = "small";
        static string mid = "mid";
        static string large = "large";

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("                         LinkedList       List<T>       Array");
            Console.WriteLine("=============================================================");

            int iLaps = 0;
            Console.WriteLine("Creating --");
            
            while (iLaps < 3)
            {
                iLaps++;
                CreationTest(iLaps);
            }

            Console.WriteLine("");
            Console.WriteLine("Finding " + small + " --");

            iLaps = 0;

            while (iLaps < 3)
            {
                iLaps++;
                FindTest(small, iLaps);
            }

            Console.WriteLine("");
            Console.WriteLine("Finding " + mid + " --");

            iLaps = 0;

            while (iLaps < 3)
            {
                iLaps++;
                FindTest(mid, iLaps);
            }

            Console.WriteLine("");
            Console.WriteLine("Finding " + large + " --");

            iLaps = 0;

            while (iLaps < 3)
            {
                iLaps++;
                FindTest(large, iLaps);
            }

            Console.WriteLine("");
            Console.WriteLine("Inserting " + small + " --");

            iLaps = 0;

            while (iLaps < 3)
            {
                iLaps++;
                InsertTest(small, iLaps);
            }

            Console.WriteLine("");
            Console.WriteLine("Inserting " + mid + " --");

            iLaps = 0;

            while (iLaps < 3)
            {
                iLaps++;
                InsertTest(mid, iLaps);
            }

            Console.WriteLine("");
            Console.WriteLine("Inserting " + large + " --");

            iLaps = 0;

            while (iLaps < 3)
            {
                iLaps++;
                InsertTest(large, iLaps);
            }

            
            Console.Read();

        }

        static void CreationTest(int iLap)
        {
            Stopwatch timer = new Stopwatch();
            long time1, time2, time3;

            // Doing this inside the loop to get a fresh list each run. -- Keith Murphy / murfbard.com (3/12/2013)
            LinkedList<string> llData = new LinkedList<string>();
            List<string> lstData = new List<string>();
            string[] arData = new string[iTotal];

            timer.Reset();
            timer.Start();

            llData = CreateLinkedList();

            time1 = timer.ElapsedMilliseconds;
            timer.Stop();
            timer.Reset();
            timer.Start();

            lstData = CreateList();

            time2 = timer.ElapsedMilliseconds;
            timer.Stop();
            timer.Reset();
            timer.Start();

            arData = CreateArray();

            time3 = timer.ElapsedMilliseconds;
            timer.Stop();
            
            Console.WriteLine("Creating! Lap " + iLap + ":         " + time1.ToString() + "             " + time2.ToString() + "           " + time3.ToString());
        }

        static void InsertTest(string sFind, int iLap)
        {
            Stopwatch timer = new Stopwatch();
            long time1, time2, time3;

            LinkedList<string> llDataIns = new LinkedList<string>();
            List<string> lstDataIns = new List<string>();
            string[] arDataIns = new string[iTotal];

            llDataIns = CreateLinkedList();
            lstDataIns = CreateList();
            arDataIns = CreateArray();

            LinkedListNode<string> node = llDataIns.Find(sFind);

            timer.Reset();
            timer.Start();
            
            llDataIns.AddAfter(node, "new!");

            time1 = timer.ElapsedMilliseconds;
            timer.Stop();
            timer.Reset();
            timer.Start();

            lstDataIns.Insert(lstDataIns.IndexOf(sFind), "new!");

            time2 = timer.ElapsedMilliseconds;
            timer.Stop();
            timer.Reset();
            timer.Start();

            string[] newArray = new string[arDataIns.Length + 1];
            bool Found = false;

            for (int i = 0; arDataIns.Length > i; i++)
            {
                if(Found)
                {
                    newArray[i+1] = arDataIns[i];
                }
                else
                {
                    newArray[i] = arDataIns[i];

                    if(arDataIns[i] == sFind)
                    {
                        Found = true;
                        newArray[i+1] = "new!";
                    }
                }
            }

            time3 = timer.ElapsedMilliseconds;
            timer.Stop();

            Console.WriteLine("Inserting! Lap " + iLap + ":        " + time1.ToString() + "                " + time2.ToString() + "             " + time3.ToString());
        }

        static void FindTest(string sFind, int iLap)
        {
            Stopwatch timer = new Stopwatch();
            long time1, time2, time3;

            LinkedList<string> llDataFind = new LinkedList<string>();
            List<string> lstDataFind = new List<string>();
            string[] arDataFind = new string[iTotal];

            llDataFind = CreateLinkedList();
            lstDataFind = CreateList();
            arDataFind = CreateArray();

            timer.Reset();
            timer.Start();

            LinkedListNode<string> node = llDataFind.Find(sFind);

            time1 = timer.ElapsedMilliseconds;
            timer.Stop();
            timer.Reset();
            timer.Start();

            lstDataFind.Single(s => s == sFind);

            time2 = timer.ElapsedMilliseconds;
            timer.Stop();
            timer.Reset();
            timer.Start();

            arDataFind.Single(s => s == sFind);

            time3 = timer.ElapsedMilliseconds;
            timer.Stop();

            Console.WriteLine("Finding! Lap " + iLap + ":          " + time1.ToString() + "               " + time2.ToString() + "           " + time3.ToString());
        }

        #region Helper Functions

        static LinkedList<string> CreateLinkedList()
        {
            LinkedList<string> ListToReturn = new LinkedList<string>();

            for (int i = 0; i < iTotal; i++)
            {
                if (i == 50)
                {
                    ListToReturn.AddLast("small");
                }
                else if (i == iTotal/2)
                {
                    ListToReturn.AddLast("mid");
                }
                else if (i == iTotal - 50)
                {
                    ListToReturn.AddLast("large");
                }
                else
                {
                    ListToReturn.AddLast("FILLER !TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT");
                }
            }

            return ListToReturn;
        }

        static List<string> CreateList()
        {
            List<string> ListToReturn = new List<string>();

            for (int i = 0; i < iTotal; i++)
            {
                if (i == 50)
                {
                    ListToReturn.Add("small");
                }
                else if (i == iTotal/2)
                {
                    ListToReturn.Add("mid");
                }
                else if (i == iTotal - 50)
                {
                    ListToReturn.Add("large");
                }
                else
                {
                    ListToReturn.Add("FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT");
                }
            }

            return ListToReturn;
        }

        static string[] CreateArray()
        {
            string[] ListToReturn = new string[iTotal];

            for (int i = 0; i < iTotal; i++)
            {
                if (i == 50)
                {
                    ListToReturn[i] = "small"; 
                }
                else if (i == iTotal/2)
                {
                    ListToReturn[i] = "mid"; 
                }
                else if (i == iTotal - 50)
                {
                    ListToReturn[i] = "large"; 
                }
                else
                {
                    ListToReturn[i] = "FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT"; 
                }
            }

            return ListToReturn;
        }

        static Queue<string> CreateQueue()
        {
            Queue<string> ListToReturn = new Queue<string>();

            for (int i = 0; i < iTotal; i++)
            {
                if (i == 50)
                {
                    ListToReturn.Enqueue("small");
                }
                else if (i == iTotal/2)
                {
                    ListToReturn.Enqueue("mid");
                }
                else if (i == iTotal - 50)
                {
                    ListToReturn.Enqueue("large");
                }
                else
                {
                    ListToReturn.Enqueue("FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT FILLER TEXT");
                } 
            }

            return ListToReturn;
        }

        #endregion
    }
}
