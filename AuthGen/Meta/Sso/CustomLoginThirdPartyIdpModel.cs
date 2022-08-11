using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType;

namespace AuthGen
{
    public class CustomLoginThirdPartyIdpModel : MetaModelDef
    {
        public CustomLoginThirdPartyIdpModel()
        {
            SetName(CustomLoginThirdPartyIdp)
                .SetModuleName(Sso)
                .SetBaseClass_Entity_Int()
                .AddProperty(Guid(Id)
                    .ExistIn(Dto))
                .AddProperty(Guid(ThirdPartyIdpId)
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(ThirdPartyIdp, ThirdPartyIdp).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                .AddProperty(Int(CustomLoginId)
                     .ExistIn(DomainModel))
                .AddProperty(Int(Sort)
                    .ExistIn(DomainModel,Dto))
            ;
        }
    }
}
