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
                 .AddProperty(Guid(Id)
                    .ExistIn(SelectDto))
                .AddProperty(Enum(TeamMemberTypes, TeamMemberType)
                     .ExistIn(DomainModel))
                .AddProperty(String_Name()
                      .ExistIn(SelectDto))
                 .AddProperty(String(Avatar)
                      .ExistIn(SelectDto))
                    .AddProperty(List(RoleSelect, Roles)
                      .ExistIn(SelectDto))
                .AddProperty(Guid(TeamId)
                      .ExistIn(DomainModel))
                .AddProperty(Guid(RoleId)
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(Team, Team).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(Role, Role).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                .SupportSelect()
                
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
