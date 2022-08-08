using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class RoleModel : MetaModelDef
    {
        public RoleModel()
        {
            SetName(Role)
                .SetModuleName(M_Permissions)
                .SetBaseClass_FullAggregateRoot_Guid_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(String_Name())
                .AddProperty(Int(Limit))
                .AddProperty(String_Description())
                .AddProperty(Bool(Enabled).IsOnlyDomainModel())
                .AddProperty(Int(AvailableQuantity).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(RolePermission, Permissions).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(RoleRelation, ChildrenRoles).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(RoleRelation, ParentRoles).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(UserRole, Users).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(TeamRole, Teams).IsOnlyDomainModel())
                .AddProperty(NewProperty(User, CreateUser).Set_GetSetType(GetSetType.Get).IsOnlyDomainModel().IsNullable())
                .AddProperty(NewProperty(User, ModifyUser).Set_GetSetType(GetSetType.Get).IsOnlyDomainModel().IsNullable())
                .AddProperty(DateTime(CreationTime).IsOnlyDto())
                .AddProperty(DateTime(ModificationTime).IsOnlyDto().IsNullable())
                .AddProperty(String(Creator).IsOnlyDto())
                .AddProperty(String(Modifier).IsOnlyDto())
            ;
        }
    }
}
