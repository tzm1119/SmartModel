using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class PermissionModel : MetaModelDef
    {
        public PermissionModel()
        {
            SetName(Permission)
                 .SetModuleName(M_Permissions)
                .SetBaseClass_FullAggregateRoot_Guid_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(Enum(PermissionTypes, _Type))
                .AddProperty(String_Name())
                .AddProperty(String(SystemId).IsOnlyDomainModel())
                .AddProperty(String(AppId).IsOnlyDomainModel().IsRequired())
                .AddProperty(String(Code).IsOnlyDomainModel())
                .AddProperty(Guid(ParentId).IsOnlyDomainModel())
                .AddProperty(String(Url).IsOnlyDomainModel())
                .AddProperty(String(Icon).IsOnlyDomainModel())
                .AddProperty(Int(Order).IsOnlyDomainModel())
                .AddProperty(String_Description().IsOnlyDomainModel())
                .AddProperty(Bool(Enabled).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(Permission, ChildPermissions).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(Permission, ParentPermissions).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(PermissionRelation, ChildPermissionRelations).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(PermissionRelation, ParentPermissionRelations).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(UserPermission, UserPermissions).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(RolePermission, RolePermissions).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(TeamPermission, TeamPermissions).IsOnlyDomainModel())
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig("p => new { p.SystemId, p.AppId, p.Code }", true, "[IsDeleted] = 0", EFIndexType.CombinePropIndex))
                .Property(new EFPropertyConfig(Name,true,40))
                .Property(new EFPropertyConfig(Code, true,255))
                .Property(new EFPropertyConfig(Url, true,250))
                .Property(new EFPropertyConfig(Description, false,255))
                .Property(new EFPropertyConfig(_Type, PermissionTypes))
                .Return(); ;
            ;
        }
    }
}
