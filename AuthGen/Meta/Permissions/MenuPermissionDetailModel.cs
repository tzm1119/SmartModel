namespace AuthGen
{
    public class MenuPermissionModel : MetaModelDef
    {
        public MenuPermissionModel()
        {
            SetName(MenuPermission)
                .SetModuleName(M_Permissions)
                .SetBaseClassName(PermissionDetail)
                .SetDoNotGenDomainModel()
                .SetDoNotGenDto()
                .AddProperty(Bool(Enabled,true)
                    .ExistIn(DetailDto))
                .AddProperty(Guid(ParentId)
                     .ExistIn(DetailDto))
                .AddProperty(List(RoleSelect, Roles)
                     .ExistIn(DetailDto))
                .AddProperty(List(UserSelect, Users)
                     .ExistIn(DetailDto))
                .AddProperty(List(TeamSelect, Teams)
                     .ExistIn(DetailDto))
                .AddProperty(ListGuid(ApiPermissions)
                     .ExistIn(DetailDto))
                .SupportDetail()
            ;
        }
    }
}
