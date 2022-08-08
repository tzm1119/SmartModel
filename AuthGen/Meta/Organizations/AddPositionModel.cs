
namespace AuthGen
{
 
    public class AddPositionModel : MetaModelDef
    {
        public AddPositionModel()
        {
            SetName(AddPosition)
                .SetModuleName(Organizations)
                .AddProperty(String_Name().IsRequired().SetMaxLength(20))
            ;
        }
    }
}
