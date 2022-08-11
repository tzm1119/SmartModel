﻿using SmartModel;
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
                .AddProperty(Guid(Id)
                    .ExistIn(Dto, SelectDto, UpdateDto, RemoveDto))
                .AddProperty(NewProperty(User, User).Set_GetSetType(GetSetType.Get).IsVirtual().IsNullable()
                    .ExistIn(DomainModel))
                .AddProperty(NewProperty(Position, Position).Set_GetSetType(GetSetType.Get).IsVirtual().IsNullable()
                    .ExistIn(DomainModel))
                .AddProperty(IReadOnlyList(DepartmentStaff, DepartmentStaffs)
                    .ExistIn(DomainModel))
                .AddProperty(IReadOnlyList(TeamStaff, TeamStaffs)
                    .ExistIn(DomainModel))
                .AddProperty(NewProperty(User, CreateUser).IsNullable()
                    .ExistIn(DomainModel))
                .AddProperty(NewProperty(User, ModifyUser).IsNullable()
                    .ExistIn(DomainModel))
                .AddProperty(Guid(UserId)
                    .ExistIn(DomainModel,Dto, AddDto))
                .AddProperty(String(Department)
                    .ExistIn(Dto, AddDto))
                .AddProperty(Guid(DepartmentId)
                    .ExistIn(DetailDto, UpdateDto))
                 .AddProperty(String(Position)
                    .ExistIn(Dto, AddDto, UpdateDto))
                  .AddProperty(Guid(PositionId)
                    .ExistIn(DetailDto, AddDto, UpdateDto))
                    .AddProperty(ListGuid(TeamIds)
                    .ExistIn(DetailDto, AddDto, UpdateDto))
                .AddProperty(String_Name()
                    .ExistIn(DomainModel,Dto, SelectDto, AddDto, UpdateDto))
                .AddProperty(String(DisplayName)
                    .ExistIn(DomainModel, Dto, SelectDto, AddDto, UpdateDto))
                .AddProperty(String(Avatar)
                    .ExistIn(DomainModel, Dto, SelectDto, AddDto, UpdateDto))
                .AddProperty(String(IdCard)
                    .ExistIn(DomainModel, Dto, AddDto, UpdateDto))
                .AddProperty(String(Account)
                    .ExistIn(DomainModel, Dto, SelectDto, AddDto))
                .AddProperty(String(Password)
                  .ExistIn(DomainModel, DetailDto, AddDto))
                  .AddProperty(ListString(ThirdPartyIdpAvatars)
                  .ExistIn(DetailDto))
                   .AddProperty(String(Creator)
                  .ExistIn(DetailDto))
                    .AddProperty(String(Modifier)
                  .ExistIn(DetailDto))
                      .AddProperty(DateTime(ModificationTime).IsNullable()
                  .ExistIn(DetailDto))
                           .AddProperty(ListGuid(RoleIds)
                  .ExistIn(DetailDto))
                            .AddProperty(List(SubjectPermissionRelation, Permissions)
                  .ExistIn(DetailDto))
                .AddProperty(String(CompanyName)
                     .ExistIn(DomainModel,Dto, UpdateDto))
                 .AddProperty(String(Landline)
                     .ExistIn(UpdateDto))
                .AddProperty(Enum(GenderTypes, Gender)
                     .ExistIn(DomainModel,Dto, AddDto ,UpdateDto))
                .AddProperty(String(PhoneNumber)
                     .ExistIn(DomainModel,Dto, UpdateDto))
                .AddProperty(String(Email)
                     .ExistIn(DomainModel,Dto, UpdateDto))
                .AddProperty(NewProperty(AddressValue, Address, DefaultValue_CtorNew)
                     .ExistIn(DomainModel,Dto, UpdateDto))
                 .AddProperty(NewProperty(UpdateUserAuthorization, User, DefaultValue_CtorNew)
                     .ExistIn(UpdateDto))
                .AddProperty(String(JobNumber)
                     .ExistIn(DomainModel,Dto, SelectDto, AddDto, UpdateDto))
                .AddProperty(Guid(PositionId).IsNullable()
                     .ExistIn(DomainModel))
                .AddProperty(Enum(StaffTypes, StaffType)
                     .ExistIn(DomainModel,Dto, AddDto, UpdateDto))
                .AddProperty(Bool(Enabled)
                     .ExistIn(DomainModel,Dto, AddDto, UpdateDto))
                .AddProperty(DateTime(CreationTime)
                     .ExistIn(Dto))
                 // Get
                 .AddProperty(String(Search)
                     .ExistIn(GetDto))
                 .AddProperty(Bool(Enabled).IsNullable()
                     .ExistIn(GetDto))
                 .AddProperty(Guid(DepartmentId)
                     .ExistIn(GetDto, AddDto))
                .SupportGet()
                .SupportAdd(true)
                .SupportUpdate(true)
                .SupportDetail()
                .SetDetialDtoInheritDto()
                .SupportRemove()
                .SupportSelect()
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(JobNumber, true, "[IsDeleted] = 0"))
                .Property(new EFPropertyConfig(JobNumber, maxLen: 20))
                .Relation(p => p.HasOne(User).WithOne("").HasForeignKey(UserId))
                .Return();
            ;
        }
    }
}
