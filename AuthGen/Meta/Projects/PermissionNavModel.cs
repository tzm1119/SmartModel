using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static AuthGen.MASAAuthEnumTypeNameConst;

namespace AuthGen
{
    public class PermissionNavModel : MetaModelDef
    {
        public PermissionNavModel()
        {
            SetName(PermissionNav)
                 .SetModuleName(Projects)
                .AddProperty(String(Code))
                .AddProperty(String_Name())
                .AddProperty(String(Icon))
                .AddProperty(String(Url))
                .AddProperty(Enum(PermissionTypes, PermissionType))
                .AddProperty(List(PermissionNav, Children))
            ;
        }
    }
}
