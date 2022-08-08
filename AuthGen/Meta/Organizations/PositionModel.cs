using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

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
                .AddProperty(Guid(Id).IsOnlyDto())
                .AddProperty(String_Name())
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(Name,true, "[IsDeleted] = 0"))
                .Property(new EFPropertyConfig(Name,maxLen:20))
                .Return();
            ;
        }
    }
}
