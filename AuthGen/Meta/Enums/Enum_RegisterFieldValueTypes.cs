using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.EnumItemDef;

namespace AuthGen
{
  
    public class Enum_RegisterFieldValueTypes : EnumDef
    {
        public Enum_RegisterFieldValueTypes()
        {
            SetName(RegisterFieldValueTypes)
                .AddItem(NewEnumItem("String", 1))
                .AddItem(NewEnumItem("Number", 2))
                .AddItem(NewEnumItem("Password", 3))
                ;
        }
    }
}
