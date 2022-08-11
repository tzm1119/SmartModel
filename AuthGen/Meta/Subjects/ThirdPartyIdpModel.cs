namespace AuthGen
{
    public class ThirdPartyIdpModel : MetaModelDef
    {
        public ThirdPartyIdpModel()
        {
            SetName(ThirdPartyIdp)
                .SetModuleName(Subjects)
                .SetBaseClassName(IdentityProvider)
                .SetIRepository_Entity()
                .SetDtoBaseClassName("")
                .SetTKey_Guid()
                .AddProperty(Guid(Id)
                    .ExistIn(Dto,SelectDto, UpdateDto,RemoveDto))
                .AddProperty(String_Name()
                    .ExistIn(Dto, SelectDto,AddDto))
                .AddProperty(String(DisplayName)
                    .ExistIn(Dto, SelectDto,AddDto, UpdateDto))
                .AddProperty(String(ClientId)
                    .ExistIn(DomainModel,Dto, SelectDto,AddDto, UpdateDto))
                .AddProperty(String(ClientSecret)
                    .ExistIn(DomainModel,Dto, SelectDto, AddDto, UpdateDto))
                .AddProperty(String(Url)
                    .ExistIn(DomainModel,Dto, SelectDto,AddDto, UpdateDto))
                .AddProperty(String(Icon)
                    .ExistIn(Dto, SelectDto, AddDto, UpdateDto))
                .AddProperty(String(VerifyFile)
                     .ExistIn(DomainModel,Dto, AddDto, UpdateDto))
                .AddProperty(Bool(Enabled)
                    .ExistIn(Dto, AddDto, UpdateDto))
                .AddProperty(Enum(AuthenticationTypes, VerifyType)
                    .ExistIn(DomainModel,Dto, SelectDto, AddDto, UpdateDto))
                .AddProperty(Enum(IdentificationTypes, IdentificationType)
                    .ExistIn(Dto, AddDto, UpdateDto))
                .AddProperty(DateTime(CreationTime)
                    .ExistIn(Dto))
                .AddProperty(DateTime(ModificationTime).IsNullable()
                    .ExistIn(Dto))
                  .AddProperty(String(Search)
                    .ExistIn(GetDto))
                .SupportAdd()
                .SupportDetail()
                .SetDetialDtoInheritDto()
                .SupportGet()
                .SupportRemove()
                .SupportSelect()
                .SupportUpdate()
                 .EntityTypeConfiguration
                .Property(new EFPropertyConfig(ClientId, maxLen: 255))
                .Property(new EFPropertyConfig(ClientSecret, maxLen: 255))
                .Return();
            ;
        }
    }
}
