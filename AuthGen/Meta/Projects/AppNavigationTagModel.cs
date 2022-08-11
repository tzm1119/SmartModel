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
                .SetDoNotGenDto()
                .AddProperty(String(AppIdentity)
                    .ExistIn(DomainModel,DetailDto))
                .AddProperty(String(Tag)
                    .ExistIn(DomainModel, DetailDto))
                .SupportDetail()
                .EntityTypeConfiguration
                .HasKey(Id)
                .Property(new EFPropertyConfig(AppIdentity,true,255))
                .Property(new EFPropertyConfig(Tag,maxLen:255))
                .Return();
            ;
        }
    }
}
