using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public class CodeData:EntityData<Code>
    {
        public Code Get(int codeId)
        {
            MatZipEntities context = CreateContext();          

            return context.Codes.FirstOrDefault(x => x.CodeId == codeId);
        }
    }
}
