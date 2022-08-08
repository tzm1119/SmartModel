using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class ApiResourceModel : MetaModelDef
    {
        public ApiResourceModel()
        {
            SetName(ApiResource)
             .SetModuleName(Sso)
             .SetDoNotGenDomainModel()
             .AddProperty(Int(Id))
             .AddProperty(Bool(Enabled, true))
             .AddProperty(String_Name())
             .AddProperty(String(DisplayName))
             .AddProperty(String_Description())
             .AddProperty(String(AllowedAccessTokenSigningAlgorithms))
             .AddProperty(Bool(ShowInDiscoveryDocument))
             .AddProperty(DateTime(LastAccessed,true))
             .AddProperty(Bool(NonEditable))
             .AddProperty(List(_string, Secrets))
            ;
        }
    }

    public class ApiResourceSelectModel : MetaModelDef
    {
        public ApiResourceSelectModel()
        {
            SetName(ApiResourceSelect)
             .AddProperty(Int(Id))
             .AddProperty(String_Name())
             .AddProperty(String(DisplayName))
             .AddProperty(String_Description())
            ;
        }
    }
}
