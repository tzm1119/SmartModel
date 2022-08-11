using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyExistType ;

namespace AuthGen
{
    public class RegisterFieldModel : MetaModelDef
    {
        public RegisterFieldModel()
        {
            SetName(RegisterField)
                .SetModuleName(Sso)
                .SetBaseClass_Entity_Int()
                .AddProperty(Enum(RegisterFieldTypes, RegisterFieldType)
                    .ExistIn(DomainModel,Dto))
                .AddProperty(Bool(Required)
                     .ExistIn(DomainModel,Dto))
                .AddProperty(Int(CustomLoginId)
                     .ExistIn(DomainModel))
                .AddProperty(Int(Sort)
                    .ExistIn(DomainModel,Dto))
                .AddProperty(Bool(CannotUpdate)
                    .ExistIn(Dto))
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
