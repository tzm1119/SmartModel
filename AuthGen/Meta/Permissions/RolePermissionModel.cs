using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class RolePermissionModel : MetaModelDef
    {
        public RolePermissionModel()
        {
            SetName(RolePermission)
                .SetModuleName(M_Permissions)
                .SetDoNotGenDto()
                .SetBaseClassName(SubjectPermissionRelation)
                .AddProperty(Guid(RoleId))
                .AddProperty(NewProperty(Role, Role).SetNullable_NotNull())
            ;
        }
    }

   
    
}
