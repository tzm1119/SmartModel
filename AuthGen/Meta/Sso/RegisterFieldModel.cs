using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class RegisterFieldModel : MetaModelDef
    {
        public RegisterFieldModel()
        {
            SetName(RegisterField)
                .SetModuleName(Sso)
                .SetBaseClass_Entity_Int()
                .AddProperty(Enum(RegisterFieldTypes, RegisterFieldType))
                .AddProperty(Bool(Required))
                .AddProperty(Int(CustomLoginId).IsOnlyDomainModel())
                .AddProperty(Int(Sort))
                .AddProperty(Bool(CannotUpdate).IsOnlyDto())
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
