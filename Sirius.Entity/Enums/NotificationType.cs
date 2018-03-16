using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Enums
{
    public enum NotificationType
    {
        NewTask = 1,
        NewTaskEvaluation = 2,
        Nomination = 3,
        NewTaskComment = 4,
        TaskAccepted = 5,
        TaskDeclined = 6,
        SupervisorRequest = 7,
        SupervisorAccepted = 8,
        SupervisorDeclined = 9,
        SupervisorAppraisalApproval = 10,
        HodAppraisalApproval = 11,
        NewCompetencyEvaluation = 12,
        NewCompetencyComment = 13,
        NewPrivilegeRequest = 14,
        ApprovedPrivilegeRequest = 15,
        DeniedPrivilegeRequest = 16,
        AppraisalContest = 17
    }
}
