using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistorySystem
{
    public class CommandHistory : History<Command>
    {
        public override void AddItemToHistory(Command input)
        {
            base.AddItemToHistory(input);
        }

        public override void Clear()
        {
            base.Clear();
        }

        public override Command Redo()
        {
            return base.Redo();
        }

        public override Command Undo()
        {
            if (undo.Count > 0)
            {
                Command output = undo.Pop();
                Command commandClone = new Command();
                commandClone.Arguments = output.Arguments;
                commandClone.CommandType = output.UndoCommandType;
                commandClone.UndoCommandType = output.CommandType;
                this.redo.Push(output);

                return output;
            }
            else
            {
                return EmptyItem;
            }
        }
    }
}
