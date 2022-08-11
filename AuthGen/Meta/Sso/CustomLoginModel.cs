namespace AuthGen
{
    public class CustomLoginModel : MetaModelDef
    {
        public CustomLoginModel()
        {
            SetName(CustomLogin)
                .SetModuleName(Sso)
                .SetBaseClass_FullAggregateRoot_Int_Guid()
                .SetIRepository_Entity_Int()
                .AddProperty(Int(Id)
                    .ExistIn(Dto, RemoveDto, UpdateDto))
                .AddProperty(String_Name()
                    .ExistIn(DomainModel,Dto, AddDto, UpdateDto))
                .AddProperty(String(Title)
                    .ExistIn(DomainModel,Dto, AddDto, UpdateDto))
                .AddProperty(String(ClientId)
                     .ExistIn(DomainModel, AddDto))
                .AddProperty(Bool(Enabled)
                     .ExistIn(DomainModel,Dto, AddDto, UpdateDto))
                .AddProperty(DateTime(CreationTime)
                    .ExistIn(Dto))
                .AddProperty(DateTime(ModificationTime).IsNullable()
                    .ExistIn(Dto))
                .AddProperty(String(Creator)
                    .ExistIn(Dto))
                .AddProperty(String(Modifier)
                    .ExistIn(Dto))
                .AddProperty(NewProperty(Client, Client,DefaultValue_CtorNew)
                    .ExistIn(Dto))
                    .AddProperty(NewProperty(Client, Client).IsNullable()
                    .ExistIn(DomainModel))
                .AddProperty(IReadOnlyCollection(CustomLoginThirdPartyIdp, ThirdPartyIdps)
                    .ExistIn(DomainModel,DetailDto, AddDto, UpdateDto))
                .AddProperty(IReadOnlyCollection(RegisterField, RegisterFields)
                    .ExistIn(DomainModel, DetailDto, AddDto, UpdateDto))
                .AddProperty(NewProperty(User, CreateUser).IsNullable()
                    .ExistIn(DomainModel))
                .AddProperty(NewProperty(User, ModifyUser).IsNullable()
                    .ExistIn(DomainModel))
                .AddProperty(String(Search)
                     .ExistIn(GetDto))
                 .SupportAdd()
                 .SupportUpdate()
                 .SupportDetail()
                 .SetDetialDtoInheritDto()
                 .SupportGet()
                 .SupportRemove()
                .EntityTypeConfiguration
                .Ignore(Client)
                .Property(new EFPropertyConfig(Name, true, 200))
                .HasIndex(new EFIndexConfig(Name, true, "[IsDeleted] = 0"))
                .Return();

            ;
        }
    }
}
