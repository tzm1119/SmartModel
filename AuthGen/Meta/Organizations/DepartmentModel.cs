using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType;
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
                .AddProperty(Guid(Id)
                     .ExistIn(Dto, DetailDto, DetailQueryDto, SelectDto, RemoveDto))
                .AddProperty(Guid(ParentId)
                     .ExistIn(DomainModel, DetailDto, UpsertDto))
                .AddProperty(String_Name()
                     .ExistIn(DomainModel, Dto, DetailDto, SelectDto, UpsertDto))
                .AddProperty(Bool(IsRoot)
                      .ExistIn(Dto))
                .AddProperty(Bool(Enabled, true)
                    .ExistIn(DomainModel, DetailDto, UpsertDto))
                .AddProperty(Int(Level, 1)
                    .ExistIn(DomainModel))
                .AddProperty(Int(Sort, 0)
                    .ExistIn(DomainModel))
                .AddProperty(String_Description()
                    .ExistIn(DomainModel, DetailDto, UpsertDto))
                .AddProperty(List(Department, Children)
                     .ExistIn(Dto))
                .AddProperty(IReadOnlyCollection(DepartmentStaff, DepartmentStaffs)
                     .ExistIn(DomainModel))
                .AddProperty(List(Staff, StaffList)
                     .ExistIn(DetailDto, CopyDto))
                 .AddProperty(ListGuid(StaffIds)
                     .ExistIn(UpsertDto))
                .AddProperty(Bool(MigrateStaff)
                     .ExistIn(CopyDto))
                 .AddProperty(Guid(SourceId)
                     .ExistIn(CopyDto))
                .SupportDetail()
                .SupportUpsert()
                .SupportSelect()
                .SupportRemove()
                .SupportCopy()
                .Set_CopyDtoInheritUpsertDto()
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(Name, true, "[IsDeleted] = 0"))
                .HasIndex(new EFIndexConfig(Level, true, "Level = 1"))
                .Property(new EFPropertyConfig(Name, true, 20))
                .Property(new EFPropertyConfig(Description, maxLen: 255))
                .Property(new EFPropertyConfig(Level, hasDefaultValue: "1"))
                .Return();

            ;
        }
    }
}
