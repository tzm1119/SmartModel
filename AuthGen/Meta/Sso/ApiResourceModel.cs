using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType;

namespace AuthGen
{
    public class ApiResourceModel : MetaModelDef
    {
        public ApiResourceModel()
        {
            SetName(ApiResource)
             .SetModuleName(Sso)
             .SetDoNotGenDomainModel()
             .SetTKey_Int()
             .AddProperty(Int(Id)
                .ExistIn(Dto,SelectDto,RemoveDto,UpdateDto))
             .AddProperty(Bool(Enabled, true)
                .ExistIn(DomainModel, Dto,AddDto))
             .AddProperty(String_Name()
                 .ExistIn(DomainModel, Dto, AddDto, SelectDto))
             .AddProperty(String(DisplayName)
                 .ExistIn(DomainModel, Dto, AddDto, SelectDto))
             .AddProperty(String_Description()
                 .ExistIn(DomainModel, Dto, AddDto, SelectDto))
             .AddProperty(String(AllowedAccessTokenSigningAlgorithms)
                 .ExistIn(DomainModel, Dto, AddDto))
             .AddProperty(Bool(ShowInDiscoveryDocument,true)
                 .ExistIn(DomainModel, Dto, AddDto))
             .AddProperty(DateTime(LastAccessed, true)
                .ExistIn(DomainModel, Dto, AddDto))
             .AddProperty(Bool(NonEditable)
                .ExistIn(DomainModel, Dto, AddDto))
             .AddProperty(ListString(Secrets)
                 .ExistIn(DomainModel, AddDto, DetailDto))
              .AddProperty(ListInt( ApiScopes)
                  .ExistIn(AddDto,DetailDto))
             .AddProperty(ListInt( UserClaims)
                  .ExistIn(AddDto, DetailDto))
             .AddProperty(Dictionary_String_String_Properties()
                  .ExistIn(AddDto, DetailDto))
             .AddProperty(String(Search)
                  .ExistIn(GetDto))
             .SupportAdd()
             .SupportUpdate()
             .Set_UpdateDtoInheritAddDto()
             .SupportDetail()
             .SetDetialDtoInheritDto()
             .SupportGet()
             .SupportSelect()
             .SupportRemove()
            ;
        }
    }
}
