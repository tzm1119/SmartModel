namespace AuthGen
{
    public class TeamTypeModel : MetaModelDef
    {
        public TeamTypeModel()
        {
            SetName(TeamType)
                .SetModuleName(Subjects)
                .SetDoNotGenDomainModel()
                .AddProperty(Int(Id)
                   .ExistIn(Dto))
                .AddProperty(String(Name)
                   .ExistIn(Dto))
                ;
        }
    }
}
