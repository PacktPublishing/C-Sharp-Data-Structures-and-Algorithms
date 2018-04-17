/* Exemplary file for Chapter 2 - Arrays and Lists. */

using System;

namespace JaggedArrays
{
    public static class TransportEnumExtensions
    {
        public static char GetChar(this TransportEnum transport)
        {
            switch (transport)
            {
                case TransportEnum.BIKE: return 'B';
                case TransportEnum.BUS: return 'U';
                case TransportEnum.CAR: return 'C';
                case TransportEnum.SUBWAY: return 'S';
                case TransportEnum.WALK: return 'W';
                default: throw new Exception("Unknown transport");
            }
        }

        public static ConsoleColor GetColor(this TransportEnum transport)
        {
            switch (transport)
            {
                case TransportEnum.BIKE: return ConsoleColor.Blue;
                case TransportEnum.BUS: return ConsoleColor.DarkGreen;
                case TransportEnum.CAR: return ConsoleColor.Red;
                case TransportEnum.SUBWAY: return ConsoleColor.DarkMagenta;
                case TransportEnum.WALK: return ConsoleColor.DarkYellow;
                default: throw new Exception("Unknown transport");
            }
        }
    }
}
