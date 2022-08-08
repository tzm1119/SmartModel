
namespace AuthGen
{
    public class RoleRelationModel : MetaModelDef
    {
        public RoleRelationModel()
        {
            SetName(RoleRelation)
                .SetModuleName(M_Permissions)
                .SetDoNotGenDto()
                .SetBaseClass_FullEntity_Guid_Guid()
                .AddProperty(Guid(ParentId))
                .AddProperty(Guid(RoleId))
                .AddProperty(NewProperty(Role, ParentRole).SetNullable_NotNull())
                .AddProperty(NewProperty(Role, Role).SetNullable_NotNull())
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
