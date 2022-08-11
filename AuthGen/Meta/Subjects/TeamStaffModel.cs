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
                .AddProperty(Enum(TeamMemberTypes, TeamMemberType)
                    .ExistIn(DomainModel))
                .AddProperty(Guid(TeamId)
                     .ExistIn(DomainModel))
                .AddProperty(Guid(StaffId)
                     .ExistIn(DomainModel))
                .AddProperty(Guid(UserId)
                     .ExistIn(DomainModel))
                //.AddProperty(NewProperty(Team, Team).SetNullable_NotNull())
                .AddProperty(NewProperty(Staff, Staff).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                 .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
