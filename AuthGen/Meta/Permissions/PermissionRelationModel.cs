using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType;

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
                .AddProperty(Guid(ChildPermissionId)
                    .ExistIn(DomainModel))
                .AddProperty(Guid(ParentPermissionId)
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(Permission, ChildPermission).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(Permission, ParentPermission).SetNullable_NotNull()
                     .ExistIn(DomainModel))
            ;
        }
    }
}
