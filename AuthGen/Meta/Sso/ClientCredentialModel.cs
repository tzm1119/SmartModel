namespace AuthGen
{
    public class ClientCredentialModel : MetaModelDef
    {
        public ClientCredentialModel()
        {
            SetName(ClientCredential)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(Bool(RequireClientSecret)
                    .ExistIn(Dto))
                  .AddProperty(List(ClientSecret, ClientSecrets)
                    .ExistIn(Dto))
                  .AddProperty(NewProperty(ClientSecret, ClientSecret, DefaultValue_CtorNew)
                    .ExistIn(Dto))
                  ;
        }
    }
}
