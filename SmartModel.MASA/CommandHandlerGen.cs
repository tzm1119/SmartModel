namespace SmartModel
{
    /// <summary>
    /// CommandHandler 生成
    /// </summary>
    public class CommandHandlerGen : MASAAuthGenBase
    {
        private void WriteEventHandlerAttribute()
        {
            WriteLine(" [EventHandler]");
        }

        private string repoInterfaceFieldName = "";
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                // 目前认为，如果不支持 Get,则一定不支持 CUD操作
                if (!Model.AtLeastCommandHandler())
                {
                    continue;
                }

                NamespaceContainter(() =>
                {
                    var handlerName = $"{ModelName}CommandHandler";

               
                    WriteLine($"public {partial} class {handlerName} ");
                    WriteLine("{");
                    repoInterfaceFieldName = $"_{Model.RepositoryInterfaceName.Substring(1).ToCameCase()}";
                    WriteLine($"readonly {Model.RepositoryInterfaceName} {repoInterfaceFieldName};");
                    // 构造函数，注入Repo接口
                    WriteLine($" public {handlerName}({Model.RepositoryInterfaceName} {repoInterfaceFieldName})");
                    WriteLine("{");
                    WriteLine($"this.{repoInterfaceFieldName}={repoInterfaceFieldName};");
                    WriteLine("}"); // 构造结束



                    if (Model.IsSupportAdd)
                    {
                        var findParam = "findModel";
                        var keyProp = Model.KeyProperty;
                        WriteEventHandlerAttribute();
                        WriteLine($"public async Task Add{ModelName}Async({Model.AddCommandName} command)");
                        WriteLine("{");

                        WriteLine($"{ModelName}? {findParam}=default;");
                        // 设置了KeyProperty
                        if (!string.IsNullOrEmpty(keyProp))
                        {
                            // 判断是否已存在
                            WriteLine($"{findParam} = await {repoInterfaceFieldName}.FindAsync(p => p.Name == command.Position.Name);");
                            WriteLine($"if ({findParam} is not null)");
                            // 如果已存在，直接抛异常
                            WriteLine($"throw new UserFriendlyException($\"{ModelName} with {keyProp} {{ command.{ModelName}.{keyProp}}}  already exists\");");
                        }
                       
                       
                        // 使用Command构造 Domain Model
                        WriteLine($"{findParam} = new(command.{ModelName});");
                        // 执行保存
                        WriteLine($" await {repoInterfaceFieldName}.AddAsync({findParam});");

                        // TODO,这个Command的Result需要手动指定
                        //WriteLine($" command.Result = {findParam}.Id;");

                        WriteLine("}");
                    }

                    if (Model.IsSupportUpdate)
                    {
                        WriteEventHandlerAttribute();
                        WriteLine($"public async Task Update{ModelName}Async({Model.UpdateCommandName} command)");
                        WriteLine("{");
                        var dtoFieldParam = "dto";
                        var findParam = "findModel";
                        WriteLine($" var {dtoFieldParam} = command.{ModelName};");
                        // 先查找已有的值
                        WriteLine($"var {findParam} = await {repoInterfaceFieldName}.FindAsync(p => p.Id == {dtoFieldParam}.Id);");
                        // 不存在 无法更新，直接抛异常
                        WriteLine($" if ({findParam} is null) throw new UserFriendlyException($\"Current {ModelName} not found\");");
                        // 已存在，执行更新
                        WriteLine($"{findParam}.Update({dtoFieldParam});");
                        // 保存
                        WriteLine($"await {repoInterfaceFieldName}.UpdateAsync({findParam});");
                        WriteLine("}");
                    }

                    // 暂时没定下来 怎么写
                    if (Model.IsSupportUpsert)
                    {
                       
                    }

                    if (Model.IsSupportRemove)
                    {
                        var findParam = "findModel";
                        WriteEventHandlerAttribute();
                        WriteLine($"public async Task Remove{ModelName}Async({Model.RemoveCommandName} command)");
                        WriteLine("{");
                        // 查找对象
                      
                        WriteLine($"  var {findParam} = await {repoInterfaceFieldName}.FindAsync(p => p.Id == command.{ModelName}.Id);");
                        // 不存在 抛异常
                        WriteLine($" if ({findParam} == null) throw new UserFriendlyException(\"The current {ModelName} does not exist\");");
                        WriteLine($" await {repoInterfaceFieldName}.RemoveAsync({findParam});");
                        WriteLine("}");
                    }


                    //if (Model.IsSupportCopy)
                    //{
                    //    var paramName = "copyDto";
                    //    WriteLine($"public async Task CopyAsync({Model.CopyDtoName} {paramName})");
                    //    WriteLine("{");
                    //    WriteLine($" await PostAsync(nameof(CopyAsync), {paramName});");
                    //    WriteLine("}");
                    //}

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

                // Id属性不更新
                var props = item.PropertyDefs.Where(p => p.PropertyName != "Id");
                WriteEventHandlerAttribute();
                WriteLine($"public async Task Update{updateModelName}Async({item.UpdateCommandName} command)");
                WriteLine("{");

                var dtoParamName = "dto";
                var findModelName = "findModel";
                WriteLine($" var {dtoParamName} = command.{updateModelName};");
                WriteLine($" var {findModelName} = await {repoInterfaceFieldName}.FindAsync(u => u.Id == {dtoParamName}.Id);");
                WriteLine($" if ({findModelName} is null)  throw new UserFriendlyException(\"The current {ModelName} does not exist\");");
                WriteLine($" {findModelName}.{updateModelName}Update({dtoParamName});");
                WriteLine($" await {repoInterfaceFieldName}.UpdateAsync({findModelName});");
           
                WriteLine("}");


            }
        }

        protected override void GenUsing()
        {
          
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Application, Model.ModuleName);
        }

        protected override string GetCodeFileName()
        {
            var handlerName = $"{ModelName}CommandHandler";
            return $"{handlerName}.cs";
        }
    }
}
