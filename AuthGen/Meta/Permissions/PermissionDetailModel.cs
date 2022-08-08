using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{
    public class PermissionDetailModel : MetaModelDef
    {
        public PermissionDetailModel()
        {
            SetName(PermissionDetail)
                 .SetModuleName(M_Permissions)
                .SetBaseClassName(BaseUpsertDto_Guid)
                .AddProperty(String_Name().IsRequired())
                .AddProperty(String(Code).IsRequired())
                .AddProperty(Enum(PermissionTypes, _Type, "PermissionTypes.Api"))
                .AddProperty(String_Description().SetMaxLength(255,true))
                .AddProperty(String(SystemId))
                .AddProperty(String(AppId).IsRequired())
                .AddProperty(String(Url))
                .AddProperty(String(Icon))
                .AddProperty(Int(Order).SetCustomMustValidator("order => order >= BusinessConsts.PERMISSION_ORDER_MIN_VALUE && order <= BusinessConsts.PERMISSION_ORDER_MAX_VALUE"))
            ;
        }
    }

    public class ApiPermissionDetailModel : MetaModelDef
    {
        public ApiPermissionDetailModel()
        {
            SetName(ApiPermissionDetail)
                 .SetModuleName(M_Permissions)
                .SetBaseClassName(PermissionDetail)
            ;
        }
    }

    
}
