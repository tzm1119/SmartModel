namespace AuthGen
{
    public class SecurityTokenModel : MetaModelDef
    {
        public SecurityTokenModel()
        {
            SetName(SecurityToken)
                .SetDoNotGenDomainModel()
                .SetModuleName(Oss)
                .AddProperty(String(Region)
                    .ExistIn(GetDto))
                .AddProperty(String(AccessKeyId)
                    .ExistIn(GetDto))
                .AddProperty(String(AccessKeySecret)
                    .ExistIn(GetDto))
                .AddProperty(String(StsToken)
                    .ExistIn(GetDto))
                .AddProperty(String(Bucket)
                    .ExistIn(GetDto))
                .SupportGet()
            ;
        }
    }
}
