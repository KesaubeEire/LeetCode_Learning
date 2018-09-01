using System;
using System.Diagnostics;
using System.Threading;

namespace TestInBook
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            StopTimeTest();
//            DateTimeTest();
            Thread thread1 = new Thread(DateTimeTest); //线程1管DT
            Thread thread2 = new Thread(StopTimeTest); //线程1管SW
            Thread thread3 = new Thread(Cal2MethodDiff); //线程3管DT-SW
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }


        private static int _perTimeSw; //循环次数
        private static float _timeSw; //总时长
        private static float _aveTimeSw; //平均时长

        private static int _perTimeDt; //循环次数
        private static float _timeDt; //总时长
        private static float _aveTimeDt; //平均时长

        //StopWatch方法计时
        static void StopTimeTest()
        {
            while (true)
            {
                _perTimeSw++;
                Stopwatch sw = new Stopwatch();
                //开始计时
                sw.Start();
                //100ms
                Thread.Sleep(100);
                //计时结束
                sw.Stop();
                _timeSw += sw.ElapsedMilliseconds;
                _aveTimeSw = _timeSw / _perTimeSw;
//                Console.WriteLine($"SW平均计量时间:{_aveTimeSw}");
//                Console.WriteLine("elpase time {0}, elapse ticks {1}", sw.ElapsedMilliseconds, sw.ElapsedTicks);
            }

            // ReSharper disable once FunctionNeverReturns
        }

        //DateTime方法计时
        static void DateTimeTest()
        {
            while (true)
            {
                _perTimeDt++;
                //打印时的时间格式
//                string dateFormat = "yyyy-MM-dd HH:mm:ss.ffff";

                //开始的utc time
                DateTime startTime = DateTime.UtcNow;
                Thread.Sleep(100);

                //结束的utc time
                DateTime endTime = DateTime.UtcNow;
//                Console.WriteLine("interval:{2},  start time:{0}, end time:{1}",
//                    startTime.ToString(dateFormat, CultureInfo.InvariantCulture),
//                    endTime.ToString(dateFormat, CultureInfo.InvariantCulture), (endTime - startTime).Milliseconds);
                _timeDt += (endTime - startTime).Milliseconds;
                _aveTimeDt = _timeDt / _perTimeDt;
//                Console.WriteLine($"DT平均计量时间:{_aveTimeDt}");
            }

            // ReSharper disable once FunctionNeverReturns
        }

        //比较二者平均时间
        private static void Cal2MethodDiff()
        {
            while (true)
            {
                Console.WriteLine($"Dt比Sw快{_aveTimeDt - _aveTimeSw}");
            }
        }
    }
}