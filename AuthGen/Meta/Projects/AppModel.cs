using SmartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AppModel : MetaModelDef
    {
        public AppModel()
        {
            SetName(App)
                 .SetModuleName(Projects)
                .AddProperty(Int(Id))
                .AddProperty(String_Name())
                .AddProperty(String(Identity))
                .AddProperty(String(Tag))
                .AddProperty(Int(ProjectId))
                .AddProperty(String(Url))
                .AddProperty(List(PermissionNav, Navs))
            ;
        }
    }
}
