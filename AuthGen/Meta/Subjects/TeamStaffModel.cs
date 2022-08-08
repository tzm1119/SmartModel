using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class TeamStaffModel : MetaModelDef
    {
        public TeamStaffModel()
        {
            SetName(TeamStaff)
                .SetModuleName(Subjects)
                .SetBaseClass_FullEntity_Guid_Guid()
                .SetDoNotGenDto()
                .AddProperty(Enum(TeamMemberTypes, TeamMemberType))
                .AddProperty(Guid(TeamId))
                .AddProperty(Guid(StaffId))
                .AddProperty(Guid(UserId))
                //.AddProperty(NewProperty(Team, Team).SetNullable_NotNull())
                .AddProperty(NewProperty(Staff, Staff).SetNullable_NotNull())
                 .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
