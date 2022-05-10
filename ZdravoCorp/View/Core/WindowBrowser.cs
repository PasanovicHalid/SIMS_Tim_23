using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.Core
{
    public class WindowBrowser
    {
        private List<WindowInterface> _navigable;
        private int _position;

        public WindowBrowser()
        {
            Navigable = new List<WindowInterface>();
            Position = Navigable.Count;
        }

        public List<WindowInterface> Navigable { get => _navigable; set => _navigable = value; }
        public int Position { get => _position; set => _position = value; }

        public void AddWindow(WindowInterface window)
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

        public WindowInterface BackWindow()
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

        public WindowInterface ForwardWindow()
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

        public WindowInterface CurrentWindow()
        {
            return Navigable[Position - 1];
        }
    }
}
