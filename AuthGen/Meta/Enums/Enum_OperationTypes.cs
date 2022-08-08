using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen
{

    public class Enum_OperationTypes : EnumDef
    {
        public Enum_OperationTypes()
        {
            SetName(OperationTypes)
                .AddItem(NewEnumItem("AddUser", 1))
                .AddItem(NewEnumItem("UpdateUser", 2))
                .AddItem(NewEnumItem("UpdateUserAuthorization", 3))
                .AddItem(NewEnumItem("RemoveUser", 4));
        }
    }
}
