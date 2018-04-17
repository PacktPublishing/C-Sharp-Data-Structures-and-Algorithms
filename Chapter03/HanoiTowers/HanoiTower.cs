/* Exemplary file for Chapter 3 - Stacks and Queues. */

using System;
using System.Collections.Generic;

namespace HanoiTowers
{
    public class HanoiTower
    {
        public int DiscsCount { get; private set; }
        public int MovesCount { get; private set; }
        public Stack<int> From { get; private set; }
        public Stack<int> To { get; private set; }
        public Stack<int> Auxiliary { get; private set; }
        public event EventHandler<EventArgs> MoveCompleted;

        public HanoiTower(int discs)
        {
            DiscsCount = discs;
            From = new Stack<int>();
            To = new Stack<int>();
            Auxiliary = new Stack<int>();
            for (int i = 1; i <= discs; i++)
            {
                int size = discs - i + 1;
                From.Push(size);
            }
        }

        public void Start()
        {
            Move(DiscsCount, From, To, Auxiliary);
        }

        public void Move(int discs, Stack<int> from, Stack<int> to, Stack<int> auxiliary)
        {
            if (discs > 0)
            {
                Move(discs - 1, from, auxiliary, to);

                to.Push(from.Pop());
                MovesCount++;
                MoveCompleted?.Invoke(this, EventArgs.Empty);

                Move(discs - 1, auxiliary, to, from);
            }
        }
    }
}
