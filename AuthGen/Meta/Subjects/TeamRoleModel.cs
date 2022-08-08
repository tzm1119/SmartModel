using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;


namespace AuthGen
{
    public class TeamRoleModel : MetaModelDef
    {
        public TeamRoleModel()
        {
            SetName(TeamRole)
                .SetModuleName(Subjects)
                .SetBaseClass_FullEntity_Guid_Guid()
                .SetDoNotGenDto()
                .AddProperty(Enum(TeamMemberTypes, TeamMemberType))
                .AddProperty(Guid(TeamId))
                .AddProperty(Guid(RoleId))
                .AddProperty(NewProperty(Team, Team).SetNullable_NotNull())
                .AddProperty(NewProperty(Role, Role).SetNullable_NotNull())
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
