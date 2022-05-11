using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Manager.Model.Equipment;
using ZdravoCorp.View.Manager.Model.Room;

namespace Controller
{
    public class ActionController
    {
        public ActionService actionService = new ActionService();
        public Boolean CreateAction(Model.Action newAction)
        {
            return actionService.CreateAction(newAction);
        }

        public Boolean UpdateRenovationAction(RenovationActionModel action)
        {
            return actionService.UpdateRenovationAction(action);
        }

        public Boolean DeleteRenovationAction(RenovationActionModel action)
        {
            return actionService.DeleteRenovationAction(action);
        }

        public Boolean DeleteChangeAction(ChangeActionModel action)
        {
            return actionService.DeleteChangeAction(action);
        }

        public Boolean UpdateChangeAction(ChangeActionModel action, int count)
        {
            return actionService.UpdateChangeAction(action, count);
        }

        public Boolean DeleteAction(int identificator)
        {
            return actionService.DeleteAction(identificator);
        }

        public Model.Action ReadAction(int identificator)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<RenovationActionModel> GetAllRenovationActions()
        {
            return actionService.GetAllRenovationActions();
        }

        public ObservableCollection<ChangeActionModel> GetAllChangeRoomActions()
        {
            return actionService.GetAllChangeRoomActions();
        }

    }
}
