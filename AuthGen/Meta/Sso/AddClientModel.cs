using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AddClientModel : MetaModelDef
    {
        public AddClientModel()
        {
            SetName(AddClient)
                  .SetModuleName(Sso)
                .AddProperty(Enum(ClientTypes, ClientType, "ClientTypes.Web"))
                .AddProperty(String(ClientId))
                .AddProperty(String(ClientName))
                .AddProperty(String_Description())
                .AddProperty(List(_string, AllowedGrantTypes))
                .AddProperty(Bool(RequirePkce))
                .AddProperty(List(_string, RedirectUris))
                .AddProperty(List(_string, PostLogoutRedirectUris))
                .AddProperty(String(ClientUri))
                .AddProperty(String(LogoUri))
                .AddProperty(Bool(RequireConsent))
                .AddProperty(Bool(RequireClientSecret))
                .AddProperty(List(_string, AllowedScopes))
            ;
        }
    }
}
