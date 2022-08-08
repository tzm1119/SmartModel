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
    public class DepartmentSelectModel : MetaModelDef
    {
        public DepartmentSelectModel()
        {
            SetName(DepartmentSelect)
                 .SetModuleName(Organizations)
                .AddProperty(Guid(Id))
                .AddProperty(String_Name())
            ;
        }
    }
}
