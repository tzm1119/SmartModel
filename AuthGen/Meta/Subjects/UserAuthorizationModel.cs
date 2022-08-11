namespace AuthGen
{
    public class UserAuthorizationModel : MetaModelDef
    {
        public UserAuthorizationModel()
        {
            SetName(UserAuthorization)
                .SetModuleName(Subjects)
                .SetDoNotGenDomainModel()
                .AddProperty(Guid(Id)
                    .ExistIn(UpdateDto))
                .AddProperty(ListGuid(Roles)
                    .ExistIn(UpdateDto))
                .AddProperty(List(SubjectPermissionRelation, Permissions)
                    .ExistIn(UpdateDto))
                .SupportUpdate()
                ;
        }
    }
}
