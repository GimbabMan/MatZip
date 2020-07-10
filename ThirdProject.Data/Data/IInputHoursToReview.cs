using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public interface IInputHoursToReview
    {
        void SetHours(string startTime, string finishTime);
    }
}
