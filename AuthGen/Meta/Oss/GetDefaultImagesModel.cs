namespace AuthGen
{
    public class DefaultImagesModel : MetaModelDef
    {
        public DefaultImagesModel()
        {
            SetName(DefaultImages)
                .SetDoNotGenDomainModel()
                .SetModuleName(Oss)
                .AddProperty(Enum(GenderTypes, Gender)
                      .ExistIn(GetDto))
                .AddProperty(String(Url)
                      .ExistIn(GetDto))
                .SupportGet()
            ;
        }
    }
}
