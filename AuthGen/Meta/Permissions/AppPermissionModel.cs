namespace AuthGen
{
    public class AppPermissionModel : MetaModelDef
    {
        public AppPermissionModel()
        {
            SetName(AppPermission)
               .SetModuleName(M_Permissions)
               .AddProperty(String(AppId)
                   .ExistIn(Dto))
               .AddProperty(Enum(PermissionTypes,_Type)
                 .ExistIn(Dto))
               .AddProperty(Guid(PermissionId)
                 .ExistIn(Dto))
               .AddProperty(String(PermissionName)
                 .ExistIn(Dto))
               .AddProperty(List(AppPermission, Children)
                 .ExistIn(Dto))
            ;
        }
    }
}
