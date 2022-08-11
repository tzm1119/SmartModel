namespace AuthGen
{
    public class ClientTypeDetailModel : MetaModelDef
    {
        public ClientTypeDetailModel()
        {
            SetName(ClientTypeDetail)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                  .AddProperty(Enum(ClientTypes, ClientType)
                    .ExistIn(Dto))
              .AddProperty(String(Description)
                    .ExistIn(Dto))
             .AddProperty(String(Icon)
                    .ExistIn(Dto));
        }
    }
}
