namespace AuthGen
{
    public class AddressValueModel : MetaModelDef
    {
        public AddressValueModel()
        {
            SetName(AddressValue)
                .SetModuleName(Subjects)
                .SetBaseClass_ValueObject()
                .AddProperty(String(Address)
                    .ExistIn(DomainModel, Dto))
                .AddProperty(String(ProvinceCode)
                     .ExistIn(DomainModel, Dto))
                .AddProperty(String(CityCode)
                     .ExistIn(DomainModel, Dto))
                .AddProperty(String(DistrictCode)
                     .ExistIn(DomainModel, Dto))
                ;
        }
    }
}
