using System.Collections.Generic;
using System.Linq;

namespace ThirdProject.Data
{
    public class RegistrationData :EntityData<Registration>
    {
        public Registration Get(int memberId)
        {
            MatZipEntities context = CreateContext();
            
            return context.Registrations.FirstOrDefault(x => x.MemberId == memberId); 
        }

    }
}
