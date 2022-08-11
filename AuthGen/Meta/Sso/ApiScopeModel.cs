using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType;

namespace AuthGen
{

    public class ApiScopeModel : MetaModelDef
    {
        public ApiScopeModel()
        {
            SetName(ApiScope)
              .SetModuleName(Sso)
              .SetDoNotGenDomainModel()
              .SetTKey_Int()
              .AddProperty(Int(Id)
                   .ExistIn(Dto,SelectDto,RemoveDto,UpdateDto))
              .AddProperty(Bool(Enabled, true)
                   .ExistIn(Dto,AddDto))
               .AddProperty(String_Name()
                   .ExistIn(Dto, AddDto, SelectDto))
                  .AddProperty(String(DisplayName)
                   .ExistIn(Dto, AddDto, SelectDto))
                     .AddProperty(String_Description()
                   .ExistIn(Dto, AddDto, SelectDto))
                        .AddProperty(Bool(Required)
                   .ExistIn(Dto, AddDto))
                         .AddProperty(Bool(Emphasize)
                           .ExistIn(Dto, AddDto))
              .AddProperty(Bool(ShowInDiscoveryDocument, true)
                           .ExistIn(Dto, AddDto))
                .AddProperty(ListInt(UserClaims)
                           .ExistIn(DetailDto, AddDto))
              .AddProperty(Dictionary_String_String_Properties()
                  .ExistIn(DetailDto, AddDto))
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
