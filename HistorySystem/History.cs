using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistorySystem
{
    public class History<T>
    {
        // Fields/Properties
        protected Stack<T> undo = new Stack<T>();
        protected Stack<T> redo = new Stack<T>();

        /// <summary>
        /// This is the item that will be returned when nothing exists in the history.  Typically this would be null but could be something like -1.
        /// </summary>
        public T EmptyItem { get; set; }

        // Constructors
        public History()
        {
        }

        public History(T emptyItem)
        {
            EmptyItem = emptyItem;
        }

        // Methods
        public virtual void AddItemToHistory(T input)
        {
            undo.Push(input);
            redo = new Stack<T>();
        }

        /// <summary>
        /// Undo the last item from history.
        /// </summary>
        /// <returns></returns>
        public virtual T Undo()
        {
            if (undo.Count > 0)
            {
                // Take the last item off the top of the undo stack and place it on top of the redo stack.
                T output = undo.Pop();
                redo.Push(output);
                
                return output;
            }
            else
            {
                return EmptyItem;
            }
        }

        /// <summary>
        /// Redo the last item that was undone from history.
        /// </summary>
        /// <returns></returns>
        public virtual T Redo()
        {
            if (redo.Count > 0)
            {
                // Take the last item off the top of the redo stack and place it on top of the undo stack.
                T output = redo.Pop();
                undo.Push(output);
                
                return output;
            }
            else
            {
                return EmptyItem;
            }
        }

        /// <summary>
        /// Reset the history contents.
        /// </summary>
        public virtual void Clear()
        {
            undo = new Stack<T>();
            redo = new Stack<T>();
        }
    }
}
