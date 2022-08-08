using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class TeamModel : MetaModelDef
    {
        public TeamModel()
        {
            SetName(Team)
                .SetModuleName(Subjects)
                .SetBaseClass_FullAggregateRoot_Guid_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(String_Name())
                .AddProperty(String(Avatar).IsOnlyDto())
                .AddProperty(NewProperty(AvatarValue, Avatar).IsOnlyDomainModel())
                .AddProperty(String_Description())
                .AddProperty(Int(MemberCount).IsOnlyDto())
                .AddProperty(ListString(AdminAvatar).IsOnlyDto())
                .AddProperty(String(Modifier).IsOnlyDto())
                .AddProperty(DateTime(ModificationTime).IsNullable().IsOnlyDto())
                .AddProperty(Enum(TeamTypes, TeamType).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(TeamStaff, TeamStaffs).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(TeamPermission, TeamPermissions).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(TeamRole, TeamRoles).IsOnlyDomainModel())
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(Name, true, "[IsDeleted] = 0"))
                .Property(new EFPropertyConfig(Name, true, 20))
                .Property(new EFPropertyConfig(Description, maxLen: 255))
                .Return();
            ;
        }
    }
}
