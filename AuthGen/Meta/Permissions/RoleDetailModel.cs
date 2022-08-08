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
    public class RoleDetailModel : MetaModelDef
    {
        public RoleDetailModel()
        {
            SetName(RoleDetail)
                 .SetModuleName(M_Permissions)
                .SetBaseClassName(Role)
                .AddProperty(List(SubjectPermissionRelation, Permissions))
                .AddProperty(List(_Guid, ParentRoles))
                .AddProperty(List(_Guid, ChildrenRoles))
                .AddProperty(List(UserSelect, Users))
                .AddProperty(List(_Guid, Teams))
                .AddProperty(Int(AvailableQuantity))
            ;
        }
    }
}
