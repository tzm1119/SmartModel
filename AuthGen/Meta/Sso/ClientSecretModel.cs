

namespace AuthGen
{
    public class ClientSecretModel : MetaModelDef
    {
        public ClientSecretModel()
        {
            SetName(ClientSecret)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(Int(Id)
                    .ExistIn(Dto))
                .AddProperty(String(Description)
                    .ExistIn(Dto))
                .AddProperty(String(Value)
                    .ExistIn(Dto))
                 .AddProperty(String(_Type, "SharedSecret")
                    .ExistIn(Dto))
                  .AddProperty(DateOnly(Expiration).IsNullable()
                    .ExistIn(Dto))
                ;
        }
    }
}
