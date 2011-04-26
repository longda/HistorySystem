using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistorySystem
{
    public enum CommandType
    {
        Unknown = 0,
        TypeCharacter = 1,
        DeleteCharacter = 2
    }

    public static class CommandTypeHelper
    {
        public static string ToString(CommandType input)
        {
            string output = string.Empty;

            switch (input)
            {
                case CommandType.DeleteCharacter:
                    output = "Delete";
                    break;

                case CommandType.TypeCharacter:
                    output = "Type";
                    break;

                case CommandType.Unknown:
                default:
                    output = "Unknown";
                    break;
            }

            return output;
        }
    }
}
