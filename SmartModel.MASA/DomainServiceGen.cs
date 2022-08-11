namespace SmartModel
{
    /// <summary>
    /// 领域服务
    /// </summary>
    public class DomainServiceGen : MASAAuthGenBase
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                if (!Model.AtLeastOneDomainEvent())
                {
                    continue;
                }

                NamespaceContainter(() =>
                {
                    var serviceName = $"{ModelName}DomainService";


                    WriteLine($"public {partial} class {serviceName} : DomainService ");
                    WriteLine("{");

                    WriteLine($" public {serviceName}(IDomainEventBus eventBus) : base(eventBus)");
                    WriteLine("{");
                    WriteLine("}"); // 构造结束



                    if (Model.AddIsDomainEvent)
                    {
                        WriteLine($"public async Task Add{ModelName}Async({Model.AddDtoName} dto)");
                        WriteLine("{");
                        WriteLine($" await EventBus.PublishAsync(new {Model.AddDomainEvent}(dto));");
                        WriteLine("}");
                      
                    }


                    if (Model.RemoveIsDomainEvent)
                    {
                        WriteLine($"public async Task Remove{ModelName}Async({Model.RemoveDtoName} dto)");
                        WriteLine("{");
                        WriteLine($" await EventBus.PublishAsync(new {Model.RemoveDomainEvent}(dto));");
                        WriteLine("}");
                    }


                    if (Model.UpdateIsDomainEvent)
                    {
                        WriteLine($"public async Task Update{ModelName}Async({Model.UpdateDtoName} dto)");
                        WriteLine("{");
                        WriteLine($" await EventBus.PublishAsync(new {Model.UpdateDomainEvent}(dto));");
                        WriteLine("}");
                    }

                    WriteLine("}");// 类结束
                });

                SaveToFile();
            }
        }

        protected override void GenUsing()
        {
            
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Domain, Model.ModuleName, "Services");
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}DomainService.cs";
        }
    }

    public class DomainEvnetGen : MASAAuthGenBase
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                if (!Model.AtLeastOneDomainEvent())
                {
                    continue;
                }

                NamespaceContainter(() =>
                {
                   
                    if (Model.AddIsDomainEvent)
                    {
                        WriteLine($"public record {Model.AddDomainEvent}({Model.AddDtoName} {ModelName}) : Event;");
                    }


                    if (Model.RemoveIsDomainEvent)
                    {
                        WriteLine($"public record {Model.RemoveDomainEvent}({Model.RemoveDtoName} {ModelName}) : Event;");
                    }


                    if (Model.UpdateIsDomainEvent)
                    {
                        WriteLine($"public record {Model.UpdateDomainEvent}({Model.UpdateDtoName} {ModelName}) : Event;");
                    }
                });

                SaveToFile();
            }
        }

        protected override void GenUsing()
        {

        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Domain, Model.ModuleName, "Events");
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}.DomainEvent.cs";
        }
    }
}
