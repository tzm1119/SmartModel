namespace AuthGen
{
    public class LdapIdpModel : MetaModelDef
    {
        public LdapIdpModel()
        {
            SetName(LdapIdp)
                .SetModuleName(Subjects)
                .SetBaseClassName(IdentityProvider)
                .SetIRepository_Entity_Guid()
                .SetDoNotGenDto()
                .AddProperty(String(ServerAddress)
                    .ExistIn(DomainModel))
                .AddProperty(Int(ServerPort)
                     .ExistIn(DomainModel))
                .AddProperty(String(BaseDn)
                     .ExistIn(DomainModel))
                .AddProperty(Bool(IsSSL)
                     .ExistIn(DomainModel))
                .AddProperty(String(UserSearchBaseDn)
                     .ExistIn(DomainModel))
                .AddProperty(String(GroupSearchBaseDn)
                     .ExistIn(DomainModel))
                .AddProperty(String(RootUserDn)
                     .ExistIn(DomainModel))
                .AddProperty(String(RootUserPassword)
                     .ExistIn(DomainModel))
                .EntityTypeConfiguration
                .Property(new EFPropertyConfig(BaseDn,maxLen:255))
                .Property(new EFPropertyConfig(UserSearchBaseDn, maxLen:255))
                .Property(new EFPropertyConfig(GroupSearchBaseDn, maxLen:255))
                .Property(new EFPropertyConfig(RootUserDn, maxLen: 255))
                .Property(new EFPropertyConfig(RootUserPassword, maxLen: 255))
                .Return();
            ;
        }
    }
}
