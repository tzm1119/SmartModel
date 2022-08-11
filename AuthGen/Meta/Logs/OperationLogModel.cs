using static SmartModel.PropertyExistType;

namespace AuthGen
{
    public class OperationLogModel : MetaModelDef
    {
        public OperationLogModel()
        {
            SetName(OperationLog)
                .SetModuleName(Logs)
                .SetBaseClass_AggregateRoot_Guid()
                .SetIRepository_Entity_Guid()
                .AddProperty(Guid(Id)
                    .ExistIn(Dto,RemoveDto))
                .AddProperty(Guid(Operator)
                    .ExistIn(DomainModel,Dto,AddDto))
                .AddProperty(String(OperatorName)
                    .ExistIn(DomainModel, Dto, AddDto))
                .AddProperty(Enum(OperationTypes, OperationType)
                     .ExistIn(DomainModel, Dto, AddDto))
                .AddProperty(DateTime(OperationTime)
                     .ExistIn(DomainModel, Dto, AddDto))
                .AddProperty(String(OperationDescription)
                     .ExistIn(DomainModel, Dto, AddDto))
                .SupportGet()
                .SupportDetail()
                .SetDetialDtoInheritDto()
                .SupportRemove()
                .SupportAdd()
                .EntityTypeConfiguration
                .HasKey(Id)
                .HasIndex(new EFIndexConfig(Operator))
                .HasIndex(new EFIndexConfig(OperationTime))
                .HasIndex(new EFIndexConfig(OperationType))
                .HasIndex(new EFIndexConfig(OperationDescription))
                .Return();
        }
    }

    public class GetOperationLogsModel : MetaModelDef
    {
        public GetOperationLogsModel()
        {
            SetName(GetOperationLogs)
                .SetPaginationBaseClassName()
                .AddProperty(Guid(Operator))
                .AddProperty(Enum(OperationTypes, OperationType))
                .AddProperty(DateTime(StartTime,true))
                .AddProperty(DateTime(EndTime,true))
                .AddProperty(String(Search));
        }
    }

    public class OperationLogDetailModel : MetaModelDef
    {
        public OperationLogDetailModel()
        {
            SetName(OperationLogDetail)
                .SetBaseClassName(OperationLog)
                .AddProperty(Guid(Id))
                .AddProperty(Guid(Operator))
                .AddProperty(String(OperatorName))
                .AddProperty(Enum(OperationTypes, OperationType))
                .AddProperty(DateTime(OperationTime))
                .AddProperty(String(OperationDescription));
        }
    }
}
