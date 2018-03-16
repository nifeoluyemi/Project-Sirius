using Sirius.Services.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager
{
    public interface IZeus
    {
        IEvaluationManager evaluationManager { get; }
        IMessageManager messageManager { get; }
        INotificationManager notificationManager { get; }
        IOrganizationManager organizationManager { get; }
        IStaffManager staffManager { get; }
    }
}
