using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{

    public class UserPermissionModel : MetaModelDef
    {
        public UserPermissionModel()
        {
            SetName(UserPermission)
               .SetModuleName(Subjects)
               .SetBaseClassName(SubjectPermissionRelation)
               .SetDoNotGenDto()
               .AddProperty(Guid(UserId))
               .AddProperty(NewProperty(User, User).SetNullable_NotNull())
               ;
               }
    }
}
