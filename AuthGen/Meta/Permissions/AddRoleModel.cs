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
    public class AddRoleModel : MetaModelDef
    {
        public AddRoleModel()
        {
            SetName(AddRole)
                 .SetModuleName(M_Permissions)
                .AddProperty(String_Name().IsRequired().SetMaxLength(20,true))
                .AddProperty(String_Description().SetMaxLength(50))
                .AddProperty(Bool(Enabled))
                .AddProperty(Int(Limit).SetGreaterThanOrEqualTo(0))
                .AddProperty(List(SubjectPermissionRelation, Permissions))
                .AddProperty(List(_Guid, ChildrenRoles))
            ;
        }
    }

    public class RemoveRoleModel : MetaModelDef
    {
        public RemoveRoleModel()
        {
            SetName(RemoveRole)
                .SetModuleName(M_Permissions)
                .AddProperty(Guid(Id))
            ;
        }
    }

    
}
