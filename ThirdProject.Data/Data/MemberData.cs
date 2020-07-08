using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public class MemberData:EntityData<Member>
    {
        public List<Member> Get(int memberId)
        {
            MatZipEntities context = CreateContext();
            var query = from x in context.Members
                        where x.MemberId == memberId
                        select x;

            return query.ToList();
        }

        public Member GetOneMember(int memberId)
        {
            MatZipEntities context = CreateContext();

            return context.Members.FirstOrDefault(x => x.MemberId == memberId);
        }

    }
}
