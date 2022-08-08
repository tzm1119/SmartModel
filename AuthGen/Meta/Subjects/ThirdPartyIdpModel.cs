using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class ThirdPartyIdpModel : MetaModelDef
    {
        public ThirdPartyIdpModel()
        {
            SetName(ThirdPartyIdp)
                .SetModuleName(Subjects)
                .SetBaseClassName(IdentityProvider)
                .SetIRepository_Entity()
                .SetDtoBaseClassName("")
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(String_Name() .IsOnlyDto())
                .AddProperty(String(DisplayName) .IsOnlyDto())
                .AddProperty(String(ClientId))
                .AddProperty(String(ClientSecret))
                .AddProperty(String(Url))
                .AddProperty(String(Icon).IsOnlyDto())
                .AddProperty(String(VerifyFile))
                .AddProperty(Bool(Enabled).IsOnlyDto())
                .AddProperty(Enum(AuthenticationTypes, VerifyType))
                .AddProperty(Enum(IdentificationTypes, IdentificationType).IsOnlyDto())
                .AddProperty(DateTime(CreationTime).IsOnlyDto())
                .AddProperty(DateTime(ModificationTime).IsNullable().IsOnlyDto())
                 .EntityTypeConfiguration
                .Property(new EFPropertyConfig(ClientId, maxLen: 255))
                .Property(new EFPropertyConfig(ClientSecret, maxLen: 255))
                .Return();
            ;
        }
    }
}
