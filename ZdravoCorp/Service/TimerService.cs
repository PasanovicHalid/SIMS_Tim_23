using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZdravoCorp.Service
{
    public class TimerService
    {
        private int interval = 1000;
        private AutoResetEvent autoEvent;
        private ActionService actionService;

        public TimerService(AutoResetEvent autoEvent)
        {
            actionService =new ActionService();
            this.autoEvent = autoEvent;
        }

        public AutoResetEvent AutoEvent { get => autoEvent; }

        public void initiate()
        {
            Timer timer = new Timer(actionService.CheckActions, autoEvent, 1000, interval);

            autoEvent.WaitOne();
            Console.WriteLine("\n Closing Timer");
        }
    }
}
