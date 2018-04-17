/* Exemplary file for Chapter 3 - Stacks and Queues. */

using Priority_Queue;
using System;

namespace CallCenterPriority
{
    public class CallCenter
    {
        private int _counter = 0;
        public SimplePriorityQueue<IncomingCall> Calls { get; private set; }

        public CallCenter()
        {
            Calls = new SimplePriorityQueue<IncomingCall>();
        }

        public void Call(int clientId, bool isPriority = false)
        {
            IncomingCall call = new IncomingCall()
            {
                Id = ++_counter,
                ClientId = clientId,
                CallTime = DateTime.Now,
                IsPriority = isPriority
            };
            Calls.Enqueue(call, isPriority ? 0 : 1);
        }

        public IncomingCall Answer(string consultant)
        {
            if (Calls.Count > 0)
            {
                IncomingCall call = Calls.Dequeue();
                call.Consultant = consultant;
                call.StartTime = DateTime.Now;
                return call;
            }
            return null;
        }

        public void End(IncomingCall call)
        {
            call.EndTime = DateTime.Now;
        }

        public bool AreWaitingCalls()
        {
            return Calls.Count > 0;
        }
    }
}
