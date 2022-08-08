using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{

    public class TeamPermissionModel : MetaModelDef
    {
        public TeamPermissionModel()
        {
            SetName(TeamPermission)
                .SetModuleName(Subjects)
                .SetBaseClassName(SubjectPermissionRelation)
                .AddProperty(Enum(TeamMemberTypes, TeamMemberType))
                .AddProperty(Guid(TeamId))
                .AddProperty(NewProperty(Team, Team).SetNullable_NotNull())
                ;
        }
    }
}
