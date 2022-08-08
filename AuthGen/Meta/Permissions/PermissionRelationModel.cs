using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class PermissionRelationModel : MetaModelDef
    {
        public PermissionRelationModel()
        {
            SetName(PermissionRelation)
                .SetModuleName(M_Permissions)
                .SetBaseClass_FullEntity_Guid_Guid()
                .SetDoNotGenDto()
                .AddProperty(Guid(ChildPermissionId))
                .AddProperty(Guid(ParentPermissionId))
                .AddProperty(NewProperty(Permission, ChildPermission).SetNullable_NotNull())
                .AddProperty(NewProperty(Permission, ParentPermission).SetNullable_NotNull())
            ;
        }
    }
}
