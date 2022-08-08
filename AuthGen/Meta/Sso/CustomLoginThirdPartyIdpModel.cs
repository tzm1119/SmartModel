using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class CustomLoginThirdPartyIdpModel : MetaModelDef
    {
        public CustomLoginThirdPartyIdpModel()
        {
            SetName(CustomLoginThirdPartyIdp)
                .SetModuleName(Sso)
                .SetBaseClass_Entity_Int()
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(Guid(ThirdPartyIdpId).IsOnlyDomainModel())
                .AddProperty(NewProperty(ThirdPartyIdp, ThirdPartyIdp).SetNullable_NotNull().IsOnlyDomainModel())
                .AddProperty(Int(CustomLoginId).IsOnlyDomainModel())
                .AddProperty(Int(Sort))
            ;
        }
    }
}
