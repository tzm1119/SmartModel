

namespace AuthGen
{

    public class ClientBasicModel : MetaModelDef
    {
        public ClientBasicModel()
        {
            SetName(ClientBasic)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(Int(Id)
                    .ExistIn(Dto))
                .AddProperty(String(ClientId)
                    .ExistIn(Dto, AddDto))
                .AddProperty(String(ClientName)
                    .ExistIn(Dto, AddDto))
               .AddProperty(String(Description)
                    .ExistIn(Dto, AddDto))
               .AddProperty(ListString(GrantTypes)
                    .ExistIn(Dto, AddDto))
                 .AddProperty(String(ClientUri)
                    .ExistIn(AddDto))
                .AddProperty(String(LogoUri)
                    .ExistIn(AddDto))
               .AddProperty(Bool(RequireConsent)
                    .ExistIn(AddDto))
               .AddProperty(String(RedirectUri)
                    .ExistIn(AddDto))
                .AddProperty(ListString(RedirectUris)
                    .ExistIn(AddDto))
              .AddProperty(String(PostLogoutRedirectUri)
                    .ExistIn(AddDto))
                .AddProperty(ListString(PostLogoutRedirectUris)
                    .ExistIn(AddDto))
               .AddProperty(Bool(RequirePkce, true)
                    .ExistIn(Dto))
               .AddProperty(Bool(Enabled)
                    .ExistIn(Dto))
              .AddProperty(Bool(RequireRequestObject)
                    .ExistIn(Dto))
                .AddProperty(String(AllowedCorsOrigin)
                    .ExistIn(Dto))
               .AddProperty(ListString(AllowedCorsOrigins)
                    .ExistIn(Dto))
                 .AddProperty(List(ClientProperty, Properties)
                    .ExistIn(Dto))
                   .AddProperty(NewProperty(ClientProperty, Property,DefaultValue_CtorNew)
                    .ExistIn(Dto))
                   //.SupportAdd()
                ;
        }
    }
}
