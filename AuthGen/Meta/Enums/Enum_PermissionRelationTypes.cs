using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen
{
    public class Enum_PermissionRelationTypes : EnumDef
    {
        public Enum_PermissionRelationTypes()
        {
            SetName(PermissionRelationTypes)
                .AddItem(NewEnumItem("UserPermission", 1))
                .AddItem(NewEnumItem("RolePermission", 2))
                .AddItem(NewEnumItem("TeamPermission", 3));
              
        }
    }
}
