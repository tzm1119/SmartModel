using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class IdentityProviderModel : MetaModelDef
    {
        public IdentityProviderModel()
        {
            SetName(IdentityProvider)
              .SetModuleName(Subjects)
              .SetDoNotGenDto()
              .SetBaseClass_FullAggregateRoot_Guid_Guid()
               .AddProperty(Guid(Id)
                .ExistIn(DetailDto,DetailQueryDto))
              .AddProperty(String(DisplayName).Set_Get_ProtectedSet()
                  .ExistIn(DomainModel,DetailDto))
              .AddProperty(String_Name().Set_Get_ProtectedSet()
                  .ExistIn(DomainModel, DetailDto))
              .AddProperty(String(Icon).Set_Get_ProtectedSet()
                  .ExistIn(DomainModel, DetailDto))
              .AddProperty(Bool(Enabled, true).Set_Get_ProtectedSet()
                  .ExistIn(DomainModel, DetailDto))
              .AddProperty(Enum(IdentificationTypes, IdentificationType, "IdentificationTypes.PhoneNumber").Set_Get_ProtectedSet()
                  .ExistIn(DomainModel, DetailDto))
              .AddProperty(IReadOnlyCollection(ThirdPartyUser, ThirdPartyUsers)
                 .ExistIn(DomainModel))
              .SupportDetail()
              .EntityTypeConfiguration
              .HasKey(Id)
              .HasIndex(new EFIndexConfig(Name, hasFilter: "[IsDeleted] = 0"))
              .Property(new EFPropertyConfig(Name, maxLen: 20))
              .Property(new EFPropertyConfig(DisplayName, maxLen: 20))
              .Return();
            ;
        }
    }
}
