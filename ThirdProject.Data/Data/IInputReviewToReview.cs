using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public interface IInputReviewToReview
    {
        void SetData(string comment, string filePath, int grade);
    }
}
