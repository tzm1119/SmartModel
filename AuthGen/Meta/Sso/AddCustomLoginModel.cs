using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;


namespace AuthGen
{
    public class AddCustomLoginModel : MetaModelDef
    {
        public AddCustomLoginModel()
        {
            SetName(AddCustomLogin)
                  .SetModuleName(Sso)
             .AddProperty(String_Name())
             .AddProperty(String(Title))
             .AddProperty(String(ClientId))
             .AddProperty(Bool(Enabled,true))
             .AddProperty(List(CustomLoginThirdPartyIdp, ThirdPartyIdps))
             .AddProperty(List(RegisterField, RegisterFields))
            ;
        }
    }
}
