using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class UserModel : MetaModelDef
    {
        public UserModel()
        {
            SetName(User)
               .SetModuleName(Subjects)
               .SetBaseClass_FullAggregateRoot_Guid_Guid()
               .SetIRepository_Entity()
               .AddProperty(Guid(Id).IsOnlyDto())
               .AddProperty(String_Name())
               .AddProperty(String(DisplayName))
               .AddProperty(String(Avatar))
               .AddProperty(String(IdCard))
               .AddProperty(String(Account))
               .AddProperty(String(Password).IsOnlyDomainModel())
               .AddProperty(String(CompanyName))
               .AddProperty(String(Department).IsOnlyDomainModel())
               .AddProperty(String(Position).IsOnlyDomainModel())
               .AddProperty(Bool(Enabled))
               .AddProperty(DateTime(CreationTime).IsOnlyDto())
               .AddProperty(Enum(GenderTypes, GenderType))
               .AddProperty(String(PhoneNumber))
               .AddProperty(String(Landline).IsOnlyDomainModel())
               .AddProperty(String(Email))
               .AddProperty(NewProperty(AddressValue, Address,DefaultValue_CtorNew))
               .AddProperty(IReadOnlyCollection(UserRole, Roles).IsOnlyDomainModel())
               .AddProperty(IReadOnlyCollection(UserPermission, Permissions).IsOnlyDomainModel())
               .AddProperty(IReadOnlyCollection(ThirdPartyUser, ThirdPartyUsers).IsOnlyDomainModel())
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(Name))
                .HasIndex(new EFIndexConfig(IdCard,true, "[IsDeleted] = 0 and IdCard!=''"))
                .HasIndex(new EFIndexConfig(PhoneNumber,true, "[IsDeleted] = 0 and PhoneNumber!=''"))
                .HasIndex(new EFIndexConfig(Email,true, "[IsDeleted] = 0 and Email!=''"))
                .Property(new EFPropertyConfig(IdCard,maxLen:18))
                .Property(new EFPropertyConfig(PhoneNumber, maxLen:11))
                .Return();
        }
    }
}
