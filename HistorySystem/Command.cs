using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistorySystem
{
    public class Command
    {
        public CommandType CommandType { get; set; }
        public CommandType UndoCommandType { get; set; }
        public ICollection<object> Arguments { get; set; }

        public Command() : this(CommandType.Unknown, CommandType.Unknown, new List<object>())
        {   
        }

        public Command(CommandType commandType, CommandType undoCommandType, ICollection<object> arguments)
        {
            CommandType = commandType;
            UndoCommandType = undoCommandType;
            Arguments = arguments;
        }
    }
}
