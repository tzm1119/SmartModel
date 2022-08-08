using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen
{
    public class Enum_IdentificationTypes : EnumDef
    {
        public Enum_IdentificationTypes()
        {
            SetName(IdentificationTypes)
                .AddItem(NewEnumItem("PhoneNumber", 1))
                .AddItem(NewEnumItem("Email", 2));
        }
    }
}
