using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AddUserClaimModel : MetaModelDef
    {
        public AddUserClaimModel()
        {
            SetName(AddUserClaim)
                  .SetModuleName(Sso)
             .AddProperty(String_Name())
             .AddProperty(String_Description())
             .AddProperty(Enum(UserClaimType, UserClaimType))
         
            ;
        }
    }
}
