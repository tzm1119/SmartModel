using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class AppNavigationTagModel : MetaModelDef
    {
        public AppNavigationTagModel()
        {
            SetName(AppNavigationTag)
                 .SetModuleName(Projects)
                .SetBaseClass_AggregateRoot_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(String(AppIdentity))
                .AddProperty(String(Tag))
                .EntityTypeConfiguration
                .HasKey(Id)
                .Property(new EFPropertyConfig(AppIdentity,true,255))
                .Property(new EFPropertyConfig(Tag,maxLen:255))
                .Return();
            ;
        }
    }
}
