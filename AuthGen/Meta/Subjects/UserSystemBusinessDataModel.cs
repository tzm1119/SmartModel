using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class UserSystemBusinessDataModel : MetaModelDef
    {
        public UserSystemBusinessDataModel()
        {
            SetName(UserSystemBusinessData)
               .SetModuleName(Subjects)
               .SetBaseClass_FullAggregateRoot_Guid_Guid()
               .SetIRepository_Entity()
               .SetDoNotGenDto()
               .AddProperty(Guid(UserId))
               .AddProperty(String(Data))
               .AddProperty(String(SystemId))
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig("u => new { u.UserId, u.SystemId }",true, "[IsDeleted] = 0"))
                .Return(); ;
        }
    }
}
