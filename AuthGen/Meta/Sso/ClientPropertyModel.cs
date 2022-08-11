namespace AuthGen
{
    public class ClientPropertyModel : MetaModelDef
    {
        public ClientPropertyModel()
        {
            SetName(ClientProperty)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(String(Key)
                    .ExistIn(Dto))
                .AddProperty(String(Value)
                    .ExistIn(Dto))
                ;
        }
    }
}
