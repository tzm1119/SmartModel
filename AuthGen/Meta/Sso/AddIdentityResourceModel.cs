using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AddIdentityResourceModel : MetaModelDef
    {
        public AddIdentityResourceModel()
        {
            SetName(AddIdentityResource)
                  .SetModuleName(Sso)
             .AddProperty(String_Name())
             .AddProperty(String(DisplayName))
             .AddProperty(String_Description())
             .AddProperty(Bool(Enabled, true))
             .AddProperty(Bool(Required))
             .AddProperty(Bool(Emphasize))
             .AddProperty(Bool(ShowInDiscoveryDocument,true))
             .AddProperty(Bool(NonEditable))
             .AddProperty(List(_int, UserClaims))
             .AddProperty(Dictionary_String_String_Properties())
            ;
        }
    }
}
