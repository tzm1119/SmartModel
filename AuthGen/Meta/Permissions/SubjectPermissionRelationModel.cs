
namespace AuthGen
{
    public class SubjectPermissionRelationModel : MetaModelDef
    {
        public SubjectPermissionRelationModel()
        {
            SetName(SubjectPermissionRelation)
                .SetBaseClass_FullEntity_Guid_Guid()
                .SetModuleName(M_Permissions)
                .AddProperty(Guid(PermissionId).Set_Get_ProtectedSet()
                    .ExistIn(DomainModel,Dto))
                .AddProperty(Bool(Effect).Set_Get_ProtectedSet()
                     .ExistIn(DomainModel, Dto))
                .AddProperty(NewProperty(Permission, Permission).Set_Get_ProtectedSet().SetNullable_NotNull()
                      .ExistIn(DomainModel))
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
