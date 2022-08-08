using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen.Meta.Enums
{

    public class Enum_RegisterFieldTypes : EnumDef
    {
        public Enum_RegisterFieldTypes()
        {
            SetName(PermissionTypes)
                .AddItem(NewEnumItem("Account", 1))
                .AddItem(NewEnumItem("Password", 2))
                .AddItem(NewEnumItem("ConfirmPassword", 3))
                .AddItem(NewEnumItem("Name", 4))
                .AddItem(NewEnumItem("DisplayName", 5))
                .AddItem(NewEnumItem("IdCard", 6))
                .AddItem(NewEnumItem("PhoneNumber", 7))
                .AddItem(NewEnumItem("Email", 8))
                ;
        }
    }
}
