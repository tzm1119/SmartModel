using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{

    public class ApiResourceDetailModel : MetaModelDef
    {
        public ApiResourceDetailModel()
        {
            SetName(ApiResourceDetail)
                  .SetModuleName(Sso)
             .SetBaseClassName(ApiResource)
             .AddProperty(List(_int, ApiScopes))
             .AddProperty(List(_int, UserClaims))
             .AddProperty(Dictionary_String_String_Properties())
             .AddProperty(List(_string, Secrets))

            ;
        }
    }
}
