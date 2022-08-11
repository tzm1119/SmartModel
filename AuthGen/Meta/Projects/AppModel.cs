namespace AuthGen
{
    public class AppModel : MetaModelDef
    {
        public AppModel()
        {
            SetName(App)
                .SetModuleName(Projects)
                .AddProperty(Int(Id)
                    .ExistIn(Dto))
                .AddProperty(String_Name()
                     .ExistIn(Dto))
                .AddProperty(String(Identity)
                     .ExistIn(Dto))
                .AddProperty(String(Tag)
                      .ExistIn(Dto))
                .AddProperty(Int(ProjectId)
                      .ExistIn(Dto))
                .AddProperty(String(Url)
                      .ExistIn(Dto))
                .AddProperty(List(PermissionNav, Navs)
                      .ExistIn(Dto))
            ;
        }
    }
}
