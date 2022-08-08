using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class CustomLoginModel : MetaModelDef
    {
        public CustomLoginModel()
        {
            SetName(CustomLogin)
                .SetModuleName(Sso)
                .SetBaseClass_FullAggregateRoot_Int_Guid()
                .SetIRepository_Entity_Int()
                .AddProperty(Int(Id).IsOnlyDto())
                .AddProperty(String_Name())
                .AddProperty(String(Title))
                .AddProperty(String(ClientId).IsOnlyDomainModel())
                .AddProperty(Bool(Enabled))
                .AddProperty(DateTime(CreationTime).IsOnlyDto())
                .AddProperty(DateTime(ModificationTime).IsNullable().IsOnlyDto())
                .AddProperty(String(Creator).IsOnlyDto())
                .AddProperty(String(Modifier).IsOnlyDto())
                .AddProperty(NewProperty(ClientModel, Client).IsNullable())
                .AddProperty(IReadOnlyCollection(CustomLoginThirdPartyIdp, ThirdPartyIdps).IsOnlyDomainModel())
                .AddProperty(IReadOnlyCollection(RegisterField, RegisterFields).IsOnlyDomainModel())
                .AddProperty(NewProperty(User, CreateUser).IsNullable().IsOnlyDomainModel())
                .AddProperty(NewProperty(User, ModifyUser).IsNullable().IsOnlyDomainModel())
                .EntityTypeConfiguration
                .Ignore(Client)
                .Property(new EFPropertyConfig(Name, true, 200))
                .HasIndex(new EFIndexConfig(Name, true, "[IsDeleted] = 0"))
                .Return();

            ;
        }
    }
}
