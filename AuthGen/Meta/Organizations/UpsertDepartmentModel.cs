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
    public class UpsertDepartmentModel : MetaModelDef
    {
        public UpsertDepartmentModel()
        {
            SetName(UpsertDepartment)
                 .SetModuleName(Organizations)
                .SetBaseClassName(BaseUpsertDto_Guid)
                .AddProperty(String_Name())
                .AddProperty(Guid(ParentId))
                .AddProperty(String_Description())
                .AddProperty(Bool(Enabled))
                .AddProperty(List(_Guid, StaffIds).IsVirtual())
            ;
        }
    }
}
