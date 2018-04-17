/* Exemplary file for Chapter 3 - Stacks and Queues. */

using System;
using System.Collections.Concurrent;

namespace CallCenterMany
{
    public class CallCenter
    {
        private int _counter = 0;
        public ConcurrentQueue<IncomingCall> Calls { get; private set; }

        public CallCenter()
        {
            Calls = new ConcurrentQueue<IncomingCall>();
        }

        public int Call(int clientId)
        {
            IncomingCall call = new IncomingCall()
            {
                Id = ++_counter,
                ClientId = clientId,
                CallTime = DateTime.Now
            };
            Calls.Enqueue(call);
            return Calls.Count;
        }

        public IncomingCall Answer(string consultant)
        {
            if (Calls.Count > 0 && Calls.TryDequeue(out IncomingCall call))
            {
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
