using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class DepartmentModel : MetaModelDef
    {
        public DepartmentModel()
        {
            SetName(Department)
                .SetModuleName(Organizations)
                .SetBaseClass_FullAggregateRoot_Guid_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(Guid(ParentId).IsOnlyDomainModel())
                .AddProperty(String_Name())
                .AddProperty(Bool(IsRoot).IsOnlyDto())
                .AddProperty(Bool(Enabled,true).IsOnlyDomainModel())
                .AddProperty(Int(Level,1).IsOnlyDomainModel())
                .AddProperty(Int(Sort, 0).IsOnlyDomainModel())
                .AddProperty(String_Description().IsOnlyDomainModel())
                .AddProperty(List(Department, Children).IsOnlyDto())
                .AddProperty(IReadOnlyCollection(DepartmentStaff, DepartmentStaffs).IsOnlyDomainModel())
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(Name,true, "[IsDeleted] = 0"))
                .HasIndex(new EFIndexConfig(Level,true, "Level = 1"))
                .Property(new EFPropertyConfig(Name,true,20))
                .Property(new EFPropertyConfig(Description, maxLen:255))
                .Property(new EFPropertyConfig(Level, hasDefaultValue:"1"))
                .Return();

            ;
        }
    }
}
