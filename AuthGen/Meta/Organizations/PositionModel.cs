using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType;

namespace AuthGen
{
    public class PositionModel : MetaModelDef
    {
        public PositionModel()
        {
            SetName(Position)
                 .SetModuleName(Organizations)
                .SetBaseClass_FullAggregateRoot_Guid_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(Guid(Id)
                    .ExistIn(Dto,  SelectDto, UpdateDto, RemoveDto))
                .AddProperty(String_Name()
                    .ExistIn(DomainModel, Dto,  SelectDto, AddDto, UpdateDto))
                .AddProperty(String(Search)
                  .ExistIn(GetDto))
                .SupportAdd()
                .SupportGet()
                .SupportRemove()
                .SupportUpdate()
                .SupportDetail()
                .SetDetialDtoInheritDto()
                .SupportSelect()
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(Name, true, "[IsDeleted] = 0"))
                .Property(new EFPropertyConfig(Name, maxLen: 20))
                .Return();
            ;
        }
    }
}
