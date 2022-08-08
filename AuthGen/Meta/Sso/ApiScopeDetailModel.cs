using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
   
    public class ApiScopeDetailModel : MetaModelDef
    {
        public ApiScopeDetailModel()
        {
            SetName(ApiScopeDetail)
                  .SetModuleName(Sso)
             .SetBaseClassName(ApiScope)
             .AddProperty(List(_int, UserClaims))
             .AddProperty(Dictionary_String_String_Properties())
            ;
        }
    }
}
