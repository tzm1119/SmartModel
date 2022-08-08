using SmartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class MenuPermissionDetailModel : MetaModelDef
    {
        public MenuPermissionDetailModel()
        {
            SetName(MenuPermissionDetail)
                 .SetModuleName(M_Permissions)
                .SetBaseClassName(PermissionDetail)
               .AddProperty(Bool(Enabled,true))
               .AddProperty(Guid(ParentId))
               .AddProperty(List(RoleSelect, Roles))
               .AddProperty(List(UserSelect, Users))
               .AddProperty(List(TeamSelect, Teams))
               .AddProperty(List(_Guid, ApiPermissions))
            ;
        }
    }
}
