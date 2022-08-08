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

    public class RoleSelectModel : MetaModelDef
    {
        public RoleSelectModel()
        {
            SetName(RoleOwner)
                 .SetModuleName(M_Permissions)
                .AddProperty(Guid(Id))
                .AddProperty(String_Name())
                .AddProperty(Int(Limit))
                .AddProperty(Int(AvailableQuantity))
            ;
        }
    }
}
