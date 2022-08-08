using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class UserRoleModel : MetaModelDef
    {
        public UserRoleModel()
        {
            SetName(UserRole)
               .SetModuleName(Subjects)
               .SetBaseClass_FullEntity_Guid_Guid()
               .SetDoNotGenDto()
               .AddProperty(Guid(UserId))
               .AddProperty(Guid(RoleId))
               .AddProperty(NewProperty(User, User).SetNullable_NotNull())
               .AddProperty(NewProperty(Role, Role).SetNullable_NotNull())
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
