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
    public class GetDefaultImagesModel : MetaModelDef
    {
        public GetDefaultImagesModel()
        {
            SetName(AddPosition)
                .AddProperty(Enum(GenderTypes, Gender))
                .AddProperty(String(Url))
            ;
        }
    }
}
