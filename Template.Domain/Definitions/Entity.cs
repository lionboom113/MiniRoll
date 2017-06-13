using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Definitions
{
    public enum CreateResult
    {
        Success = 0,
        ValidError = 1,
        Failed = 2,
    }

    public enum UpdateResult
    {
        Success = 0,
        NotExist = 1,
        ValidError = 2,
        Failed = 3,
    }

    public enum DeleteResult
    {
        Success = 0,
        NotExist = 1,
        Failed = 2,
    }
}
