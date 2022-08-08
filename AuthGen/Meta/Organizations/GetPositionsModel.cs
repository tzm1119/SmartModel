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
    public class GetPositionsModel : MetaModelDef
    {
        public GetPositionsModel()
        {
            SetName(DepartmentSelect)
                 .SetModuleName(Organizations)
                .SetPaginationBaseClassName()
                .AddProperty(String(Search))
            ;
        }
    }


    public class PositionDetailModel : MetaModelDef
    {
        public PositionDetailModel()
        {
            SetName(PositionDetail)
                 .SetModuleName(Organizations)
                .SetBaseClassName(Position)
                .AddProperty(Guid(Id))
                .AddProperty(String_Name())
            ;
        }
    }

    public class PositionSelectModel : MetaModelDef
    {
        public PositionSelectModel()
        {
            SetName(PositionSelect)
                 .SetModuleName(Organizations)
                .SetBaseClassName(Position)
            ;
        }
    }

    public class RemovePositionModel : MetaModelDef
    {
        public RemovePositionModel()
        {
            SetName(RemovePosition)
                 .SetModuleName(Organizations)
                .AddProperty(Guid(Id))
            ;
        }
    }

    public class UpdatePositionModel : MetaModelDef
    {
        public UpdatePositionModel()
        {
            SetName(UpdatePosition)
                 .SetModuleName(Organizations)
                .AddProperty(Guid(Id))
                .AddProperty(String_Name().IsRequired())
            ;
        }
    }

    public class UpsertPositionModel : MetaModelDef
    {
        public UpsertPositionModel()
        {
            SetName(UpsertPosition)
                 .SetModuleName(Organizations)
                .AddProperty(String_Name().IsRequired())
            ;
        }
    }
}
