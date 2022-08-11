namespace AuthGen
{
    public class IdentityResourceModel : MetaModelDef
    {
        public IdentityResourceModel()
        {
            SetName(IdentityResource)
                 .SetModuleName(Sso)
                 .SetTKey_Int()
                 .AddProperty(Int(Id)
                    .ExistIn(Dto,SelectDto,UpdateDto,RemoveDto))
                 .AddProperty(String_Name()
                     .ExistIn(Dto, SelectDto , AddDto,UpdateDto))
                 .AddProperty(String(DisplayName)
                     .ExistIn(Dto, SelectDto, AddDto, UpdateDto))
                 .AddProperty(String_Description()
                     .ExistIn(Dto, SelectDto, AddDto, UpdateDto))
                 .AddProperty(Bool(Enabled, true)
                     .ExistIn(Dto, AddDto, UpdateDto))
                 .AddProperty(Bool(Required)
                     .ExistIn(Dto, AddDto, UpdateDto))
                 .AddProperty(Bool(Emphasize)
                     .ExistIn(Dto, AddDto, UpdateDto))
                 .AddProperty(Bool(ShowInDiscoveryDocument, true)
                     .ExistIn(Dto, AddDto, UpdateDto))
                 .AddProperty(Bool(NonEditable)
                     .ExistIn(Dto, AddDto, UpdateDto))
                 .AddProperty(ListInt(UserClaims)
                     .ExistIn(DetailDto,AddDto, UpdateDto))
                 .AddProperty(Dictionary_String_String_Properties()
                      .ExistIn(DetailDto,AddDto, UpdateDto))
                 .AddProperty(String(Search)
                    .ExistIn(GetDto))
                    .SupportAdd()
                    .SupportUpdate()
                    .SupportDetail()
                    .SetDetialDtoInheritDto()
                    .SupportGet()
                    .SupportSelect()
                    .SupportRemove()
            ;
        }
    }
}
