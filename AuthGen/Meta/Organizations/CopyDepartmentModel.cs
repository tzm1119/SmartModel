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
    public class CopyDepartmentModel : MetaModelDef
    {
        public CopyDepartmentModel()
        {
            SetName(AddPosition)
                .SetModuleName(Organizations)
                .SetBaseClassName(UpsertDepartment)
                .AddProperty(List(Staff,Staffs))
                .AddProperty(List(_Guid, StaffIds).IsOverride("=> Staffs.Select(s => s.Id).ToList();"))
                .AddProperty(Bool(MigrateStaff))
                .AddProperty(Guid(SourceId).IsRequired())
            ;
        }
    }
}
