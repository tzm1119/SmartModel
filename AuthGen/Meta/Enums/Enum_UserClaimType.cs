using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen
{
    public class Enum_UserClaimType : EnumDef
    {
        public Enum_UserClaimType()
        {
            SetName(UserClaimType)
                .AddItem(NewEnumItem("Standard", 1))
                .AddItem(NewEnumItem("Customize", 2))
                ;
        }
    }
}
