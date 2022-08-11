namespace SmartModel
{
    /// <summary>
    /// 生成客户端Caller
    /// </summary>
    public class CallerGen : MASAAuthGenBase
    {
        protected string GetBaseUri()
        {
            return $"\"api/{Model.ModuleName}/{ModelName}/\"";
        }
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                // 目前认为，如果不支持 Get,则一定不支持 CUD操作
                if (!Model.AtLeastSupportOne())
                {
                    continue;
                }

                NamespaceContainter(() =>
            {
                var serviceName = $"{ModelName}Service";
                WriteLine($"public {partial} class {serviceName} : ServiceBase");
                WriteLine("{");
                WriteLine("protected override string BaseUrl { get; set; }");
                WriteLine($"internal {serviceName}(ICallerProvider callerProvider) : base(callerProvider)");
                WriteLine("{");
                WriteLine($" BaseUrl = {GetBaseUri()};");
                WriteLine("}"); // 构造结束







                if (Model.IsSupportGet)
                {
                    WriteLine($"public async Task<PaginationDto<{Model.GetDtoClassName()}>> GetListAsync({Model.GetDtoName} request)");
                    WriteLine("{");
                    WriteLine($" return await SendAsync<{Model.GetDtoName}, PaginationDto<{Model.GetDtoClassName()}>>(nameof(GetListAsync), request);");
                    WriteLine("}");
                }

                if (Model.IsSupportAdd)
                {
                    WriteLine($"public async Task AddAsync({Model.AddDtoName} request)");
                    WriteLine("{");
                    WriteLine($"await SendAsync(nameof(AddAsync), request);");
                    WriteLine("}");
                }

                if (Model.IsSupportDetail)
                {
                    WriteLine($"public async Task<{Model.DetailDtoName}> GetDetailAsync({Model.DetailQueryDtoName} dto)");
                    WriteLine("{");
                
                    WriteLine($"return await SendAsync<object, {Model.DetailDtoName}>(nameof(GetDetailAsync), dto);");
                    WriteLine("}");
                    WriteLine($"");
                }

                if (Model.IsSupportUpdate)
                {
                    WriteLine($"public async Task UpdateAsync({Model.UpdateDtoName} request)");
                    WriteLine("{");
                    WriteLine($" await SendAsync(nameof(UpdateAsync), request);");
                    WriteLine("}");
                }

                if (Model.IsSupportUpsert)
                {
                    WriteLine($"public async Task UpsertAsync({Model.UpsertDtoName} request)");
                    WriteLine("{");
                    WriteLine($" await PostAsync(nameof(UpsertAsync), request);");
                    WriteLine("}");
                }

                if (Model.IsSupportRemove)
                {
                    WriteLine($"public async Task RemoveAsync({Model.TKey} id)");
                    WriteLine("{");
                    WriteLine($" await SendAsync(nameof(RemoveAsync), new {Model.RemoveDtoName}(id));");
                    WriteLine("}");
                }

                if (Model.IsSupportSelect)
                {
                    WriteLine($"public async Task<List<{Model.SelectDtoName}>> GetSelectAsync({Model.SelectQueryDtoName} dto)");
                    WriteLine("{");
                    WriteLine($" return await SendAsync<object, List<{Model.SelectDtoName}>>(nameof(GetSelectAsync),dto);");
                    WriteLine("}");
                }

                if (Model.IsSupportCopy)
                {
                    var paramName = "copyDto";
                    WriteLine($"public async Task CopyAsync({Model.CopyDtoName} {paramName})");
                    WriteLine("{");
                    WriteLine($" await PostAsync(nameof(CopyAsync), {paramName});");
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

                var methodName = $"Update{updateModelName}Async";
                WriteLine($"public async Task {methodName}({item.UpdateDtoName} dto)");
                WriteLine("{");
                WriteLine($" await SendAsync(nameof({methodName}), dto);");
                WriteLine("}");
            }
        }
        protected override void GenUsing()
        {

        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.CallerDir, "Services", Model.ModuleName);
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}Service.cs";
        }
    }
}
