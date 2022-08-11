namespace AuthGen
{
    public class PermissionNavModel : MetaModelDef
    {
        public PermissionNavModel()
        {
            SetName(PermissionNav)
                .SetModuleName(Projects)
                .AddProperty(String(Code)
                    .ExistIn(Dto))
                .AddProperty(String_Name()
                     .ExistIn(Dto))
                .AddProperty(String(Icon)
                     .ExistIn(Dto))
                .AddProperty(String(Url)
                     .ExistIn(Dto))
                .AddProperty(Enum(PermissionTypes, PermissionType)
                     .ExistIn(Dto))
                .AddProperty(List(PermissionNav, Children)
                     .ExistIn(Dto))
            ;
        }
    }
}
