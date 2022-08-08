using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

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
                .AddProperty(String(ServerAddress))
                .AddProperty(Int(ServerPort))
                .AddProperty(String(BaseDn))
                .AddProperty(Bool(IsSSL))
                .AddProperty(String(UserSearchBaseDn))
                .AddProperty(String(GroupSearchBaseDn))
                .AddProperty(String(RootUserDn))
                .AddProperty(String(RootUserPassword))
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
