using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_And_UnitOfWork.Utils
{
    public class IdentityErrorCustom: IdentityErrorDescriber
    {
        public override IdentityError DuplicateRoleName(string role)
        {
            var error = base.DuplicateRoleName(role);
            return new IdentityError
            {
                Code = error.Code,
                Description = $"Role có tên {role} đã tồn tại"
            };
        }
    }
}
