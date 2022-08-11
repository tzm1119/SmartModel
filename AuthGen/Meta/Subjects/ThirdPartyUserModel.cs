namespace AuthGen
{
    public class ThirdPartyUserModel : MetaModelDef
    {
        public ThirdPartyUserModel()
        {
            SetName(ThirdPartyUser)
                .SetModuleName(Subjects)
                .SetBaseClass_FullAggregateRoot_Guid_Guid()
                .SetDtoBaseClassName("")
                .AddProperty(Guid(Id)
                    .ExistIn(Dto))
                .AddProperty(NewProperty(User, User,DefaultValue_CtorNew).IsVirtual()
                     .ExistIn(Dto))
                .AddProperty(NewProperty(UserDetail, User, DefaultValue_CtorNew).IsNew()
                     .ExistIn(DetailDto))
                // 临时先添加可为null，感觉源码中的LazyLoader用的有问题
                .AddProperty(NewProperty(IdentityProvider, IdentityProvider).IsNullable()
                     .ExistIn(DomainModel))
                .AddProperty(Guid(ThirdPartyIdpId)
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(User,CreateUser).IsNullable()
                     .ExistIn(DomainModel))
                .AddProperty(NewProperty(User, ModifyUser).IsNullable()
                     .ExistIn(DomainModel))
                .AddProperty(Guid(UserId)
                    .ExistIn(DomainModel,GetDto))
                .AddProperty(NewProperty(IdentityProviderDetail, IdpDetailDto,DefaultValue_CtorNew)
                     .ExistIn(Dto,DetailDto))
                .AddProperty(Bool(Enabled)
                     .ExistIn(DomainModel,Dto))
                .AddProperty(Bool(Enabled).IsNullable()
                     .ExistIn(GetDto))
                .AddProperty(String(ThridPartyIdentity)
                     .ExistIn(DomainModel))
                .AddProperty(String(ExtendedData)
                    .ExistIn(DomainModel))
                .AddProperty(Enum(AuthenticationTypes, VerifyType)
                    .ExistIn(DomainModel))
                .AddProperty(DateTime(CreationTime)
                    .ExistIn(Dto))
                .AddProperty(DateTime(ModificationTime).IsNullable()
                    .ExistIn(Dto))
                 .AddProperty(DateTime(StartTime).IsNullable()
                    .ExistIn(GetDto))
                  .AddProperty(DateTime(EndTime).IsNullable()
                    .ExistIn(GetDto))
                .AddProperty(String(Creator)
                    .ExistIn(Dto))
                .AddProperty(String(Modifier)
                    .ExistIn(Dto))
                .SupportDetail()
                .SupportAdd()
                .SupportGet()
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            
            ;
        }
    }
}
