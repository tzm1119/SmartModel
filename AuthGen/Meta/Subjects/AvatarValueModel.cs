using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AvatarValueModel : MetaModelDef
    {
        public AvatarValueModel()
        {
            SetName(AvatarValue)
              .SetModuleName(Subjects)
              .SetBaseClass_ValueObject()
              .AddProperty(String(Url))
              .AddProperty(String_Name())
              .AddProperty(String(Color));
        }
    }
}
