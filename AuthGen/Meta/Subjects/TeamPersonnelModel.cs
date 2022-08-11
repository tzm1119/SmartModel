namespace AuthGen
{
    public class TeamPersonnelModel : MetaModelDef
    {
        public TeamPersonnelModel()
        {
            SetName(TeamPersonnel)
                .SetModuleName(Subjects)
                .SetDoNotGenDomainModel()
                 .AddProperty(Guid(Id)
                    .ExistIn(UpdateDto))
                .AddProperty(ListGuid(Staffs)
                    .ExistIn(Dto, UpdateDto))
                .AddProperty(ListGuid(SubjectPermissionRelation)
                    .ExistIn(Dto, UpdateDto))
                  .AddProperty(ListGuid(Roles)
                    .ExistIn(Dto, UpdateDto))
               .SupportUpdate()
            ;
        }
    }
}
