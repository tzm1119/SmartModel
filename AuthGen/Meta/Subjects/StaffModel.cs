using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{

    public class StaffModel : MetaModelDef
    {
        public StaffModel()
        {
            SetName(Staff)
                .SetModuleName(Subjects)
                .SetBaseClass_FullAggregateRoot_Guid_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(NewProperty(User, User).Set_GetSetType(GetSetType.Get).IsVirtual().IsOnlyDomainModel())
                .AddProperty(NewProperty(Position, Position).Set_GetSetType(GetSetType.Get).IsVirtual().IsOnlyDomainModel())
                .AddProperty(IReadOnlyList(DepartmentStaff, DepartmentStaffs).IsOnlyDomainModel())
                .AddProperty(IReadOnlyList(TeamStaff, TeamStaffs).IsOnlyDomainModel())
                .AddProperty(NewProperty(User, CreateUser).IsNullable().IsOnlyDomainModel())
                .AddProperty(NewProperty(User, ModifyUser).IsNullable().IsOnlyDomainModel())
                .AddProperty(Guid(UserId))
                .AddProperty(Guid(Id))
                .AddProperty(String(Department).IsOnlyDto())
                .AddProperty(String(Position).IsOnlyDto())
                .AddProperty(String_Name())
                .AddProperty(String(DisplayName))
                .AddProperty(String(Avatar))
                .AddProperty(String(IdCard))
                .AddProperty(String(Account))
                .AddProperty(String(Password))
                .AddProperty(String(CompanyName))
                .AddProperty(Enum(GenderTypes, Gender))
                .AddProperty(String(PhoneNumber))
                .AddProperty(String(Email))
                .AddProperty(NewProperty(AddressValue, Address,DefaultValue_CtorNew))
                .AddProperty(String(JobNumber))
                .AddProperty(Guid(PositionId).IsNullable().IsOnlyDomainModel())
                .AddProperty(Enum(StaffTypes, StaffType))
                .AddProperty(Bool(Enabled))
                .AddProperty(DateTime(CreationTime).IsOnlyDto())
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(JobNumber,true, "[IsDeleted] = 0"))
                .Property(new EFPropertyConfig(JobNumber, maxLen: 20))
                .Relation(p=>p.HasOne(User).WithOne("").HasForeignKey(UserId))
                .Return();
            ;
        }
    }
}
