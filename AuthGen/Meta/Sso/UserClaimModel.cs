namespace AuthGen
{
    public class UserClaimModel : MetaModelDef
    {
        public UserClaimModel()
        {
            SetName(UserClaim)
                 .SetModuleName(Sso)
                 .SetTKey_Int()
                 .AddProperty(Int(Id)
                    .ExistIn(Dto, SelectDto,UpdateDto,RemoveDto))
                 .AddProperty(String_Name()
                    .ExistIn(Dto, SelectDto, AddDto))
                 .AddProperty(String_Description()
                    .ExistIn(Dto, SelectDto, AddDto))
                 .AddProperty(Enum(UserClaimType, UserClaimType)
                    .ExistIn(Dto, SelectDto, AddDto))
                 .AddProperty(String(Search)
                    .ExistIn(GetDto))
                 .SupportAdd()
                 .SupportDetail()
                 .SetDetialDtoInheritDto()
                 .SupportUpdate()
                 .Set_UpdateDtoInheritAddDto()
                 .SupportGet()
                 .SupportRemove()
                 .SupportSelect()
            ;
        }
    }
}
