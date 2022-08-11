using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    /// <summary>
    /// RestService 生成
    /// </summary>
    public class RestServiceGen : CallerGen
    {
        private string eventBus_FromService = "";
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                if (!Model.AtLeastSupportOne())
                {
                    continue;
                }

                NamespaceContainter(() =>
                {
                    var serviceName = $"{ModelName}Service";
                    eventBus_FromService = "[FromServices] IEventBus eventBus";
                    WriteLine($"public {partial} class {serviceName} : RestServiceBase");
                    WriteLine("{");
               
                    WriteLine($"public {serviceName}(IServiceCollection services) : base(services, {GetBaseUri()})");
                    WriteLine("{");
                    WriteLine("}"); // 构造结束



                  

                    //WriteLine("{");
                    //WriteLine("}");



                    //WriteLine($"");
                    //WriteLine($"");
                    //WriteLine($"");


                    if (Model.IsSupportGet)
                    {
                        WriteLine($"private async Task<PaginationDto<{Model.GetDtoClassName()}>> GetListAsync({eventBus_FromService} ,{Model.GetDtoName} dto)");
                        WriteLine("{");
                        WriteLine($"var query = new {Model.ModelQueryName}(dto);");
                        WriteLine("await eventBus.PublishAsync(query);");
                        WriteLine("return query.Result;");
                        WriteLine("}");
                    }

                    if (Model.IsSupportAdd)
                    {
                        WriteLine($"private async Task AddAsync({eventBus_FromService}, [FromBody]{Model.AddDtoName} dto)");
                        WriteLine("{");
                        WriteLine($"await eventBus.PublishAsync(new {Model.AddCommandName}(dto));");
                        WriteLine("}");
                    }

                    if (Model.IsSupportDetail)
                    {
                        WriteLine($"private async Task<{Model.DetailDtoName}> GetDetailAsync({eventBus_FromService} ,[FromBody]{Model.DetailQueryDtoName} dto)");
                        WriteLine("{");
                        WriteLine($" var query = new {Model.ModelDetailQueryName}(dto);");
                        WriteLine(" await eventBus.PublishAsync(query);");
                        WriteLine(" return query.Result;");
                        WriteLine("}");
                        WriteLine($"");
                    }

                    if (Model.IsSupportUpdate)
                    {
                        WriteLine($"private async Task UpdateAsync({eventBus_FromService} ,[FromBody]{ Model.UpdateDtoName} dto)");
                        WriteLine("{");
                        WriteLine($" await eventBus.PublishAsync(new {Model.UpdateCommandName}(dto));");
                        WriteLine("}");
                    }

                    if (Model.IsSupportUpsert)
                    {
                        WriteLine($"private async Task UpsertAsync({eventBus_FromService} ,{Model.UpsertDtoName} dto)");
                        WriteLine("{");
                        WriteLine($" await eventBus.PublishAsync(new {Model.UpserCommandName}(dto));");
                        WriteLine("}");
                    }

                    if (Model.IsSupportRemove)
                    {
                        WriteLine($"private async Task RemoveAsync({eventBus_FromService} ,[FromBody]{Model.RemoveDtoName} dto)");
                        WriteLine("{");
                        WriteLine($" await eventBus.PublishAsync(new {Model.RemoveCommandName}(dto));");
                        WriteLine("}");
                    }

                    if (Model.IsSupportSelect)
                    {
                        WriteLine($"private async Task<List<{Model.SelectDtoName}>> GetSelectAsync({eventBus_FromService},[FromBody]{Model.SelectQueryDtoName} dto)");
                        WriteLine("{");
                        // TODO ApiResourceSelectQuery没改类型
                        WriteLine($"var query = new {Model.ModelSelectQueryName}(dto);");
                        WriteLine($"await eventBus.PublishAsync(query);");
                        WriteLine($" return query.Result;");
                        WriteLine("}");
                    }

                    if (Model.IsSupportCopy)
                    {
                        var paramName = "copyDto";
                        WriteLine($"public async Task CopyAsync({eventBus_FromService}, {Model.CopyDtoName} {paramName})");
                        WriteLine("{");
                        WriteLine($" await eventBus.PublishAsync(new {Model.CopyCommandName}({paramName}));");
                        WriteLine("}");
                    }

                    WritePartialUpdate();

                    WriteLine("}");// 类结束
                });

                SaveToFile();
            }
        }

        private void WritePartialUpdate()
        {
            var partialModels = PartailUpdateCenter.GetPartialUpdateModels(Model);
            foreach (var item in partialModels)
            {
                var updateModelName = item.ModelName;

                WriteLine($"public async Task Update{updateModelName}Async({eventBus_FromService},[FromBody]{item.UpdateDtoName} dto)");
                WriteLine("{");
                WriteLine($"  await eventBus.PublishAsync(new {item.UpdateCommandName}(dto));");
                WriteLine("}");
            }
        }

        protected override void GenUsing()
        {
            WriteLine("using Masa.Auth.Service.Admin.Services;");
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, "Services");
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}Service.cs";
        }
    }
}
