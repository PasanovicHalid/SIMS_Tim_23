using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.Core
{
    public class WindowBrowser
    {
        private List<object> _navigable;
        private int _position;

        public WindowBrowser()
        {
            Navigable = new List<object>();
            Position = Navigable.Count;
        }

        public List<object> Navigable { get => _navigable; set => _navigable = value; }
        public int Position { get => _position; set => _position = value; }

        public void AddWindow(object window)
        {
            if(window == null)
            {
                return;
            }
            else
            {
                if(Position == Navigable.Count)
                {
                    Navigable.Add(window);
                    Position = Navigable.Count;
                }
                else
                {
                    Navigable.RemoveRange(Position, Navigable.Count - Position);
                    Navigable.Add(window);
                    Position = Navigable.Count;
                }
            }
        }

        public object BackWindow()
        {
            if(Position == 1)
            {
                return Navigable[0];
            }
            else
            {
                Position--;
                return Navigable[Position - 1];
            }
        }

        public object ForwardWindow()
        {
            if (Position == Navigable.Count)
            {
                return Navigable[Position - 1];
            }
            else
            {
                Position++;
                return Navigable[Position - 1];
            }
        }

        public object CurrentWindow()
        {
            return Navigable[Position - 1];
        }
    }
}
