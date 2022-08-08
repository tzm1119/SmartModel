using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthGen
{
    public class SubjectPermissionRelationModel : MetaModelDef
    {
        public SubjectPermissionRelationModel()
        {
            SetName(SubjectPermissionRelation)
                .SetBaseClass_FullEntity_Guid_Guid()
                .SetModuleName(M_Permissions)
                .AddProperty(Guid(PermissionId).Set_Get_ProtectedSet())
                .AddProperty(Bool(Effect).Set_Get_ProtectedSet())
                .AddProperty(NewProperty(Permission, Permission).Set_Get_ProtectedSet().SetNullable_NotNull().IsOnlyDomainModel())
                .EntityTypeConfiguration
                .HasKey(Id)
                .Return();
            ;
        }
    }
}
