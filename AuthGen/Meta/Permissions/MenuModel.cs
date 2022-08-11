using SmartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;


namespace AuthGen
{

    public class MenuModel : MetaModelDef
    {
        public MenuModel()
        {
            SetName(Menu)
               .SetModuleName(M_Permissions)
               .AddProperty(Guid(Id)
                .ExistIn(Dto))
               .AddProperty(String_Name()
                 .ExistIn(Dto))
               .AddProperty(String(Code)
                 .ExistIn(Dto))
               .AddProperty(String(Icon)
                 .ExistIn(Dto))
               .AddProperty(String(Url)
                 .ExistIn(Dto))
               .AddProperty(List(Menu, Children)
                 .ExistIn(Dto))
            ;
        }
    }
}
