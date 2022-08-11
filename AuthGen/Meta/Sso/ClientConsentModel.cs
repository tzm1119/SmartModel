namespace AuthGen
{

    public class ClientConsentModel : MetaModelDef
    {
        public ClientConsentModel()
        {
            SetName(ClientConsent)
              .SetModuleName(Sso)
              .SetDoNotGenDomainModel()
              .AddProperty(Int(Id)
                   .ExistIn(Dto))
              .AddProperty(String(ClientUri)
                   .ExistIn(Dto))
               .AddProperty(String(LogoUri)
                   .ExistIn(Dto))
                .AddProperty(Bool(RequireConsent)
                   .ExistIn(Dto))
                 .AddProperty(Bool(AllowRememberConsent)
                   .ExistIn(Dto))
                  .AddProperty(Int(ConsentLifetime)
                   .ExistIn(Dto))
              ;
        }
    }
}
