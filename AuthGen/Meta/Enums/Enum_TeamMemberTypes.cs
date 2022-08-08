using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen.Meta.Enums
{
    public class Enum_TeamMemberTypes : EnumDef
    {
        public Enum_TeamMemberTypes()
        {
            SetName(TeamMemberTypes)
                .AddItem(NewEnumItem("Member", 1))
                .AddItem(NewEnumItem("Admin", 2))
                ;
        }
    }
}
