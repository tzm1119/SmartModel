using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class ClientModel_Model : MetaModelDef
    {
        public ClientModel_Model()
        {
            SetName(ClientModel)
                .SetModuleName(Infrastructure)
                .AddProperty(Int(Id).IsOnlyDto())
                .AddProperty(String(LogoUri).IsOnlyDto())
                .AddProperty(String_Description().IsOnlyDto())
                .AddProperty(Bool(Enabled).IsOnlyDto())
                .AddProperty(Enum(ClientTypes, ClientType))
                .AddProperty(String(ClientId))
                .AddProperty(String(ClientName))
                .AddProperty(ListString(AllowedScopes).IsOnlyDomainModel())
                .AddProperty(ListString(RedirectUris).IsOnlyDomainModel())
                .AddProperty(ListString(PostLogoutRedirectUris).IsOnlyDomainModel())
            ;
        }
    }
}
