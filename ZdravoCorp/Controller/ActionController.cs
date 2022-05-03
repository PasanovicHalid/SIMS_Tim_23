using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.ViewModel;

namespace Controller
{
    public class ActionController
    {
        public ActionService actionService = new ActionService();
        public Boolean CreateAction(Model.Action newAction)
        {
            return actionService.CreateAction(newAction);
        }

        public Boolean UpdateRenovationAction(RenovationActionVO action)
        {
            return actionService.UpdateRenovationAction(action);
        }

        public Boolean DeleteRenovationAction(RenovationActionVO action)
        {
            return actionService.DeleteRenovationAction(action);
        }

        public Boolean DeleteChangeAction(ChangeActionVO action)
        {
            return actionService.DeleteChangeAction(action);
        }

        public Boolean UpdateChangeAction(ChangeActionVO action, int count)
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

        public ObservableCollection<RenovationActionVO> GetAllRenovationActions()
        {
            return actionService.GetAllRenovationActions();
        }

        public ObservableCollection<ChangeActionVO> GetAllChangeRoomActions()
        {
            return actionService.GetAllChangeRoomActions();
        }

    }
}
