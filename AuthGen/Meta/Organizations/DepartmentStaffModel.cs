using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType;

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
                .AddProperty(Guid(DepartmentId)
                    .ExistIn(DomainModel))
                .AddProperty(Guid(StaffId)
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(Department, Department).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(Staff, Staff).SetNullable_NotNull()
                     .ExistIn(DomainModel))
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
