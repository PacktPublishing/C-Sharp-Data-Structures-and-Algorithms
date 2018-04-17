/* Exemplary file for Chapter 3 - Stacks and Queues. */

using System;
using System.Threading;

namespace CallCenterSingle
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            CallCenter center = new CallCenter();
            center.Call(1234);
            center.Call(5678);
            center.Call(1468);
            center.Call(9641);

            while (center.AreWaitingCalls())
            {
                IncomingCall call = center.Answer("Marcin");
                Log($"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}.");
                Thread.Sleep(random.Next(1000, 10000));
                center.End(call);
                Log($"Call #{call.Id} from {call.ClientId} is ended by {call.Consultant}.");
            }
        }

        private static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
        }
    }
}
