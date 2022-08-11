namespace AuthGen
{

    public class ClientScopesModel : MetaModelDef
    {
        public ClientScopesModel()
        {
            SetName(ClientScopes)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(ListString(_AllowedScopes)
                    .ExistIn(Dto))
                .AddProperty(ListCheckItem_String(IdentityScopes)
                    .ExistIn(Dto))
                  .AddProperty(ListCheckItem_String(ApiScopes)
                    .ExistIn(Dto))
                  ;
        }
    }
}
