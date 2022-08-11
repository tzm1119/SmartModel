namespace AuthGen
{
    public class ProjectModel : MetaModelDef
    {
        public ProjectModel()
        {
            SetName(Project)
                .SetModuleName(Projects)
                .AddProperty(Int(Id)
                    .ExistIn(Dto))
                .AddProperty(String_Name()
                      .ExistIn(Dto))
                .AddProperty(String(Identity)
                      .ExistIn(Dto))
                .AddProperty(List(App, Apps)
                      .ExistIn(Dto))
            ;
        }
    }
}
