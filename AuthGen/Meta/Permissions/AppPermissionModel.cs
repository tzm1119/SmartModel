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
    public class AppPermissionModel : MetaModelDef
    {
        public AppPermissionModel()
        {
            SetName(AppPermission)
               .SetModuleName(M_Permissions)
               .AddProperty(String(AppId))
               .AddProperty(Enum(PermissionTypes,_Type))
               .AddProperty(Guid(PermissionId))
               .AddProperty(String(PermissionName))
               .AddProperty(List(AppPermission, Children))
            ;
        }
    }
}
