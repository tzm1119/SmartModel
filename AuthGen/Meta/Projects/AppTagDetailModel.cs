using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AppTagDetailModel : MetaModelDef
    {
        public AppTagDetailModel()
        {
            SetName(AppTagDetail)
                 .SetModuleName(Projects)
                .AddProperty(String(AppIdentity))
                .AddProperty(String(Tag))
            ;
        }
    }
}
