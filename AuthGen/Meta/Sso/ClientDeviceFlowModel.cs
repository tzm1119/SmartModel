namespace AuthGen
{
    public class ClientDeviceFlowModel : MetaModelDef
    {
        public ClientDeviceFlowModel()
        {
            SetName(ClientCredential)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(String(UserCodeType)
                    .ExistIn(Dto))
                .AddProperty(Int(DeviceCodeLifetime)
                    .ExistIn(Dto))
                  ;
        }
    }
}
