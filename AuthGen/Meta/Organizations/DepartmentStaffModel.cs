using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class DepartmentStaffModel : MetaModelDef
    {
        public DepartmentStaffModel()
        {
            SetName(DepartmentStaff)
                .SetModuleName(Organizations)
                .SetDoNotGenDto()// 不生成Dto
                .SetBaseClass_FullEntity_Guid_Guid()
                .AddProperty(Guid(DepartmentId))
                .AddProperty(Guid(StaffId))
                .AddProperty(NewProperty(Department, Department).SetNullable_NotNull())
                .AddProperty(NewProperty(Staff, Staff).SetNullable_NotNull())
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
