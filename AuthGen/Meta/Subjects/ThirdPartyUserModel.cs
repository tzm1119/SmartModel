using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class ThirdPartyUserModel : MetaModelDef
    {
        public ThirdPartyUserModel()
        {
            SetName(ThirdPartyUser)
                .SetModuleName(Subjects)
                .SetBaseClassName(IdentityProvider)
                .SetIRepository_Entity()
                .SetDtoBaseClassName("")
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(NewProperty(User, User,DefaultValue_CtorNew).IsVirtual())
                .AddProperty(NewProperty(IdentityProvider, IdentityProvider))
                .AddProperty(Guid(ThirdPartyIdpId).IsOnlyDomainModel())
                .AddProperty(NewProperty(User,CreateUser).IsNullable().IsOnlyDomainModel())
                .AddProperty(NewProperty(User, ModifyUser).IsNullable().IsOnlyDomainModel())
                .AddProperty(Guid(UserId).IsOnlyDomainModel())
                .AddProperty(Bool(Enabled))
                .AddProperty(String(ThridPartyIdentity).IsOnlyDomainModel())
                .AddProperty(String(ExtendedData).IsOnlyDomainModel())
                .AddProperty(Enum(AuthenticationTypes, VerifyType).IsOnlyDomainModel())
                .AddProperty(DateTime(CreationTime).IsOnlyDto())
                .AddProperty(DateTime(ModificationTime).IsNullable().IsOnlyDto())
                .AddProperty(String(Creator).IsOnlyDto())
                .AddProperty(String(Modifier).IsOnlyDto())
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            
            ;
        }
    }
}
