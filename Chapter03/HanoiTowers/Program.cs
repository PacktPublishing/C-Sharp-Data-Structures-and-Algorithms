/* Exemplary file for Chapter 3 - Stacks and Queues. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HanoiTowers
{
    class Program
    {
        private const int DISCS_COUNT = 10;
        private const int DELAY_MS = 250;
        private static int _columnSize = 30;

        static void Main(string[] args)
        {
            _columnSize = Math.Max(6, GetDiscWidth(DISCS_COUNT) + 2);
            HanoiTower algorithm = new HanoiTower(DISCS_COUNT);
            algorithm.MoveCompleted += Algorithm_Visualize;
            Algorithm_Visualize(algorithm, EventArgs.Empty);
            algorithm.Start();
        }

        private static void Algorithm_Visualize(object sender, EventArgs e)
        {
            Console.Clear();

            HanoiTower algorithm = (HanoiTower)sender;
            if (algorithm.DiscsCount <= 0) { return; }

            char[][] visualization = InitializeVisualization(algorithm);
            PrepareColumn(visualization, 1, algorithm.DiscsCount, algorithm.From);
            PrepareColumn(visualization, 2, algorithm.DiscsCount, algorithm.To);
            PrepareColumn(visualization, 3, algorithm.DiscsCount, algorithm.Auxiliary);

            Console.WriteLine(Center("FROM") + Center("TO") + Center("AUXILIARY"));
            DrawVisualization(visualization);
            Console.WriteLine();
            Console.WriteLine($"Number of moves: {algorithm.MovesCount}");
            Console.WriteLine($"Number of discs: {algorithm.DiscsCount}");

            Thread.Sleep(DELAY_MS);
        }

        private static char[][] InitializeVisualization(HanoiTower algorithm)
        {
            char[][] visualization = new char[algorithm.DiscsCount][];

            for (int y = 0; y < visualization.Length; y++)
            {
                visualization[y] = new char[_columnSize * 3];
                for (int x = 0; x < _columnSize * 3; x++)
                {
                    visualization[y][x] = ' ';
                }
            }

            return visualization;
        }

        private static void PrepareColumn(char[][] visualization, int column, int discsCount, Stack<int> stack)
        {
            int margin = _columnSize * (column - 1);

            for (int y = 0; y < stack.Count; y++)
            {
                int size = stack.ElementAt(y);
                int row = discsCount - (stack.Count - y);
                int columnStart = margin + discsCount - size;
                int columnEnd = columnStart + GetDiscWidth(size);

                for (int x = columnStart; x <= columnEnd; x++)
                {
                    visualization[row][x] = '=';
                }
            }
        }

        private static void DrawVisualization(char[][] visualization)
        {
            for (int y = 0; y < visualization.Length; y++)
            {
                Console.WriteLine(visualization[y]);
            }
        }

        private static string Center(string text)
        {
            int margin = (_columnSize - text.Length) / 2;
            return text.PadLeft(margin + text.Length).PadRight(_columnSize);
        }

        private static int GetDiscWidth(int size)
        {
            return 2 * size - 1;
        }
    }
}
