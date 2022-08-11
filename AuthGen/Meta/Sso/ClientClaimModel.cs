namespace AuthGen
{
    public class ClientClaimModel : MetaModelDef
    {
        public ClientClaimModel()
        {
            SetName(ClientClaim)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(String(_Type)
                    .ExistIn(Dto))
                .AddProperty(String(Value)
                    .ExistIn(Dto))
                ;
        }
    }
}
