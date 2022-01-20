using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThridAssigment.FunctionModel
{
    public class Function
    {
        private static Function function;
        public static Function GetFunctionInstance(){
            if(function is null) function = new Function();
            return function;
        }

        private async Task isPrimeAsync(int checkedNumber, List<int> outResultList)
        {
            // Tách cái này thành 1 thread khác không chạy với luồng chính.
            // This await will help this for each run seperately from main thread.
            // Each time the function isPrimeAsync is called, it will run on another thread
            // So we will have (to - from) threads.
            await Task.Run
            ( 
                () => {
                    var possibleFactor = (int)Math.Sqrt(checkedNumber);
                    for (int fac = 2; fac <= possibleFactor; fac++)
                        if (checkedNumber % fac == 0) return ;
                    outResultList.Add(checkedNumber > 1 ? checkedNumber : -1);
                    // Console.WriteLine(checkedNumber);
                }
            );
        }
        
        // private int isPrime(int checkedNumber, int factor){
        //     if (checkedNumber % factor == 0) return -1;
        //     return checkedNumber;
        // }

        //Create a faster loop to have a list of funcInLastOfLoop;
        private async Task<List<int>> SeperateLoop(int from, int to)  {
            List<int> outResultList = new List<int>();
            await Task.Run(async () => 
            {
                int totalElemets = (to - from) / 2;
                if(to - from == 1) {
                    // Console.WriteLine($" Range {from} {to}");
                    isPrimeAsync(from, outResultList);
                    isPrimeAsync(to, outResultList);
                    return;
                }

                if(to - from == 0)
                {
                    // Console.WriteLine($" Range {from} {to}");
                    isPrimeAsync(from, outResultList);
                    return;
                }
                      
                SeperateLoop(from, from + totalElemets);
                SeperateLoop(from + totalElemets + 1, to);                 
            });
            return outResultList;
        }

        public async Task FindPrimeNumber(int from, int to){
            Console.Write($"List prime number from {from} to {to} is : ");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // List<int>[] outResultList = new List<int> [] ();
            var outResultList = await Task.WhenAll(SeperateLoop(from, to));
            // Task.WhenAll(new Task[] { isPrimeAsync(3, outResultList), isPrimeAsync(10, outResultList)});
            sw.Stop();
            //List khong phai la kieu reference???
            Console.WriteLine($"Total number : {outResultList.Sum(x=> x.Where(x => x != -1).Count())}");
            Console.WriteLine();
            Console.WriteLine($"Total Elapsed time: {sw.ElapsedMilliseconds} ms");
        }

        private event Action PrintOutTimer = delegate {};
        private Action PrintTime(CancellationTokenSource cancellationToken){
            while(true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                if(cancellationToken.IsCancellationRequested)
                    throw new TaskCanceledException("Stop watch");
            }
        }

        public void ClockProgram(){
            Stopwatch sw = new Stopwatch();
            sw.Start();
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            // PrintOutTimer = await PrintTime(cancellationToken);
            Task printTime = new Task(PrintOutTimer);
            printTime.Start();
            
            Console.ReadLine();
            cancellationToken.Cancel();
            // if(choice == "0") PrintOutTimer -= PrintTime;
            // PrintOutTimer.Dis;

            sw.Stop();
            Console.WriteLine($"Total timer {sw.ElapsedMilliseconds/1000} seconds");
        }
    }
}