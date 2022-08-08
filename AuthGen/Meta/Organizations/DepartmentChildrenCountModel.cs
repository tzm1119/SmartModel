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
   
    public class DepartmentChildrenCountModel : MetaModelDef
    {
        public DepartmentChildrenCountModel()
        {
            SetName(DepartmentChildrenCount)
                 .SetModuleName(Organizations)
                .AddProperty(Int(SecondLevel))
                .AddProperty(Int(ThirdLevel))
                .AddProperty(Int(FourthLevel))
            ;
        }
    }
}
