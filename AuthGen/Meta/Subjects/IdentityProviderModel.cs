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
            SetName(IdentityProvider )
              .SetModuleName(Subjects)
              .SetDoNotGenDto()
              .SetBaseClass_FullAggregateRoot_Guid_Guid()
              .AddProperty(String(DisplayName))
              .AddProperty(String_Name())
              .AddProperty(String(Icon))
              .AddProperty(Bool(Enabled, true))
              .AddProperty(NewProperty(IdentificationTypes, IdentificationType))
              .AddProperty(IReadOnlyCollection(ThirdPartyUser, ThirdPartyUsers))
              .EntityTypeConfiguration
              .HasKey(Id)
              .HasIndex(new EFIndexConfig(Name,hasFilter: "[IsDeleted] = 0"))
              .Property(new EFPropertyConfig(Name,maxLen:20))
              .Property(new EFPropertyConfig(DisplayName, maxLen:20))
              .Return();
            ;
        }
    }
}
