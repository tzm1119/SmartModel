namespace AuthGen
{
    public class TeamBasicInfoModel : MetaModelDef
    {
        public TeamBasicInfoModel()
        {
            SetName(TeamBasicInfo)
                .SetModuleName(Subjects)
                .SetDoNotGenDomainModel()
                .AddProperty(Guid(Id)
                    .ExistIn(UpdateDto))
                .AddProperty(String_Name()
                    .ExistIn(Dto, UpdateDto))
                .AddProperty(NewProperty(AvatarValue, Avatar)
                    .ExistIn(DomainModel, UpdateDto))
                .AddProperty(String_Description()
                    .ExistIn(Dto, UpdateDto))
               .AddProperty(Enum(TeamTypes, _Type)
                    .ExistIn(Dto, UpdateDto))
            ;
        }
    }
}
