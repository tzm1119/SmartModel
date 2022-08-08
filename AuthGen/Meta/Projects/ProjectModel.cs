using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static AuthGen.MASAAuthEnumTypeNameConst;

namespace AuthGen
{
    public class ProjectModel : MetaModelDef
    {
        public ProjectModel()
        {
            SetName(Project)
                 .SetModuleName(Projects)
                .AddProperty(Int(Id))
                .AddProperty(String_Name())
                .AddProperty(String(Identity))
                .AddProperty(List(App, Apps))
            ;
        }
    }
}
