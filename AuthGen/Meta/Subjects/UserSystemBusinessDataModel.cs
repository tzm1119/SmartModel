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
               .AddProperty(Guid(UserId)
                    .ExistIn(DomainModel,UpsertDto))
               .AddProperty(String(Data)
                 .ExistIn(DomainModel, UpsertDto))
               .AddProperty(String(SystemId)
                 .ExistIn(DomainModel, UpsertDto))
               . SupportUpsert()
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig("u => new { u.UserId, u.SystemId }",true, "[IsDeleted] = 0", EFIndexType.CombinePropIndex))
                .Return(); ;
        }
    }
}
