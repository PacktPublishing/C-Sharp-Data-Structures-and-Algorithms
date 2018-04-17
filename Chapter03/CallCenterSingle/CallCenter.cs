/* Exemplary file for Chapter 3 - Stacks and Queues. */

using System;
using System.Collections.Generic;

namespace CallCenterSingle
{
    public class CallCenter
    {
        private int _counter = 0;
        public Queue<IncomingCall> Calls { get; private set; }

        public CallCenter()
        {
            Calls = new Queue<IncomingCall>();
        }

        public void Call(int clientId)
        {
            IncomingCall call = new IncomingCall()
            {
                Id = ++_counter,
                ClientId = clientId,
                CallTime = DateTime.Now
            };
            Calls.Enqueue(call);
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
