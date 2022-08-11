using SmartModel;
using System;
namespace AuthGen
{
    public class RoleOwnerModel : MetaModelDef
    {
        public RoleOwnerModel()
        {
            SetName(RoleOwner)
                .SetModuleName(M_Permissions)
                .SetDoNotGenDomainModel()
                .AddProperty(Guid(RoleId)
                    .ExistIn(GetDto))
                .AddProperty(List(UserSelect, Users)
                    .ExistIn(Dto))
                .AddProperty(List(TeamSelect, Teams)
                     .ExistIn(Dto))
                .SupportGet()
            ;
        }
    }
}
