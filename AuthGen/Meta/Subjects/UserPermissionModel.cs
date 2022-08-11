namespace AuthGen
{

    public class UserPermissionModel : MetaModelDef
    {
        public UserPermissionModel()
        {
            SetName(UserPermission)
               .SetModuleName(Subjects)
               .SetBaseClassName(SubjectPermissionRelation)
               .SetDoNotGenDto()
               .AddProperty(Guid(UserId)
                .ExistIn(DomainModel))
               .AddProperty(NewProperty(User, User).SetNullable_NotNull()
                 .ExistIn(DomainModel))
               ;
        }
    }
}
