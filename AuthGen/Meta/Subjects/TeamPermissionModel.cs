namespace AuthGen
{

    public class TeamPermissionModel : MetaModelDef
    {
        public TeamPermissionModel()
        {
            SetName(TeamPermission)
                .SetModuleName(Subjects)
                .SetBaseClassName(SubjectPermissionRelation)
                .AddProperty(Enum(TeamMemberTypes, TeamMemberType)
                    .ExistIn(DomainModel, Dto))
                .AddProperty(Guid(TeamId)
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(Team, Team).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                ;
        }
    }
}
