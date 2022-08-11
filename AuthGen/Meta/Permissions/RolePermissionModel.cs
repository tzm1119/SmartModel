namespace AuthGen
{
    public class RolePermissionModel : MetaModelDef
    {
        public RolePermissionModel()
        {
            SetName(RolePermission)
                .SetModuleName(M_Permissions)
                .SetDoNotGenDto()
                .SetBaseClassName(SubjectPermissionRelation)
                .AddProperty(Guid(RoleId)
                    .ExistIn(DomainModel))
                .AddProperty(NewProperty(Role, Role).SetNullable_NotNull()
                     .ExistIn(DomainModel))
            ;
        }
    }

   
    
}
