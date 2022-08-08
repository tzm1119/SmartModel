using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen
{
    public class Enum_PermissionTypes : EnumDef
    {
        public Enum_PermissionTypes()
        {
            SetName(PermissionTypes)
                .AddItem(NewEnumItem("Menu", 1))
                .AddItem(NewEnumItem("Element", 2))
                .AddItem(NewEnumItem("Api", 3))
                .AddItem(NewEnumItem("Data", 4))
                ;
        }
    }
}
