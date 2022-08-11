namespace AuthGen
{
    public class UserRoleModel : MetaModelDef
    {
        public UserRoleModel()
        {
            SetName(UserRole)
               .SetModuleName(Subjects)
               .SetBaseClass_FullEntity_Guid_Guid()
               .SetDoNotGenDto()
               .AddProperty(Guid(UserId)
                .ExistIn(DomainModel))
               .AddProperty(Guid(RoleId)
                 .ExistIn(DomainModel))
               .AddProperty(NewProperty(User, User).SetNullable_NotNull()
                 .ExistIn(DomainModel))
               .AddProperty(NewProperty(Role, Role).SetNullable_NotNull()
                 .ExistIn(DomainModel))
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
