using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AddressValueModel : MetaModelDef
    {
        public AddressValueModel()
        {
            SetName(AddressValue)
                .SetModuleName(Subjects)
                .SetBaseClass_ValueObject()
                .AddProperty(String(Address))
                .AddProperty(String(ProvinceCode))
                .AddProperty(String(CityCode))
                .AddProperty(String(DistrictCode));
        }
    }
}
