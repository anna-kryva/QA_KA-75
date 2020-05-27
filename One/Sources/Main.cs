using System;

namespace Tasks
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\nUsing Queue: \n\n");
            UseUQueue();
            Console.WriteLine("\n\nUsing CompareVersions: \n\n");
            UseCompareVersions();
        }

        private static void UseUQueue()
        {
            var que = new UQueue();

            try { que.Peek(); }
            catch (InvalidOperationException)
            { Console.WriteLine("Invalid operation | OK"); }

            try { que.Dequeue(); }
            catch (InvalidOperationException)
            { Console.WriteLine("Invalid operation | OK"); }

            que.Enqueue("el");
            Console.WriteLine(que);
            que.Enqueue(2);
            Console.WriteLine(que);
            Console.WriteLine(que.Peek());
            Console.WriteLine(que.Dequeue());
            Console.WriteLine(que);
        }

        private static void UseCompareVersions() {
            PrintVersioningResult("1.2.3", "4.5.6");
            PrintVersioningResult("1", "1.0");
            PrintVersioningResult("1.1.0", "1.0.1");
        }

        private static void PrintVersioningResult(string v1, string v2)
        {
            var res = UVersion.CompareVersions(v1, v2);

            char sign;
            if (res > 0) sign = '>';
            else if (res < 0) sign = '<';
            else sign = '=';

            Console.WriteLine("{0} {1} {2}", v1, sign, v2);
        }

    }
}

