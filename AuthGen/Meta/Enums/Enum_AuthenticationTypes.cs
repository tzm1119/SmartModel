using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen
{
    public class Enum_AuthenticationTypes : EnumDef
    {
        public Enum_AuthenticationTypes()
        {
            SetName(AuthenticationTypes)
                .AddItem(NewEnumItem("OAuth", 0));
        }
    }
}
