using static SmartModel.Keyword;

namespace SmartModel
{
    /// <summary>
    /// 生成聚合
    /// </summary>
    public class AggregateGen : MASAAuthGenBase
    {
        /// <summary>
        /// 无参数构造函数
        /// </summary>
        protected void WriteEmptyCtor(string modelName)
        {
            WriteLine($" public {modelName}() {{ }}");
        }
        protected string Property_Get_Set(PropertyDef def)
        {
            switch (def.GetSetType)
            {
                case GetSetType.Get:
                    return "{ get; }";
                case GetSetType.GetSet:
                    return "{ get; set; }";
                case GetSetType.Get_PrivateSet:
                    return "{ get; private set; }";
                case GetSetType.Get_ProtectedSet:
                    return "{ get; protected set; }";
                default:
                    return "{ get; set; }";
            }
        }

        protected virtual string Property_DefaultValue(PropertyDef def)
        {
            if (string.IsNullOrEmpty(def.DefaultValue))
            {
                return "";
            }
            else
            {
                return $"= {def.DefaultValue};";
            }
        }

        protected virtual void WritePropertyAttribute(PropertyDef def)
        {
            foreach (var item in def.Attributes)
            {
                WriteLine(item);
            }
        }


        private string GetPropertyType(PropertyDef def)
        {
            // 可空
            if (def.Nullable)
            {
                return $"{def.CSharpType}?";
            }
            else
            {
                return def.CSharpType;
            }
        }

        private string GetFieldType(PropertyDef def)
        {
            // 可空
            if (def.Nullable)
            {
                return $"{def.FieldType}?";
            }
            else
            {
                return def.FieldType;
            }
        }

        private string GetFieldDefaultValue(PropertyDef def)
        {
            // 可空
            if (string.IsNullOrEmpty(def.FieldDefaultValue))
            {
                return $";";
            }
            else
            {
                return $"={def.FieldDefaultValue};";
            }
        }

        private string GetBaseClass()
        {
            if (string.IsNullOrEmpty(Model.BaseClassName))
            {
                return "";
            }
            else
            {
                return $":{Model.BaseClassName}";
            }
        }

        /// <summary>
        ///  对于集成自 ValueObject的对象，需要实现GetEqualityValues方法
        /// </summary>
        private void WriteGetEqualityValues()
        {
            if (Model.BaseClassName!= "ValueObject")
            {
                return;
            }
          
            WriteLine("protected override IEnumerable<object> GetEqualityValues()");
            WriteLine("{");
            foreach (var prop in  GetDomainModelProperty())
            {
                WriteLine($"yield return {prop.PropertyName};");
            }
            WriteLine("}");
    }
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                if (Model.DoNotGenDomainModel)
                {
                    continue;
                }

                NamespaceContainter(() =>
                {
                    WriteLine($"public {partial} class {ModelName}  {GetBaseClass()}");
                    WriteLine("{");
                    foreach (var prop in GetDomainModelProperty())
                    {
                        // 只读属性，需要生成对应的字段
                        if (prop.GetSetType == GetSetType.Get)
                        {
                            WriteLine($"private {GetFieldType(prop)} {prop.GetPrivateParamName()} {GetFieldDefaultValue(prop)}");
                        }

                        if (prop.NotNullAttribute)
                        {
                            WriteLine("[NotNull]");
                        }

                        WritePropertyAttribute(prop);
                        // 只读属性，
                        if (prop.GetSetType == GetSetType.Get)
                        {
                            WriteLine($"public {GetPropertyType(prop)} {prop.PropertyName} => {prop.GetPrivateParamName()};");
                        }
                        else
                        {
                            WriteLine($"public {GetPropertyType(prop)} {prop.PropertyName} {Property_Get_Set(prop)} {Property_DefaultValue(prop)}");
                        }
                    }

                    WriteGetEqualityValues();

                    if (Model.IsSupportAdd)
                    {
                        WriteDtoCtor();
                    }
                  

                    if (Model.IsSupportUpdate)
                    {
                        WriteDtoUpdate();
                    }

                    // 局部更新
                    WritePartialUpdate();

                    WriteEmptyCtor(ModelName);

                    WriteLine("}");
                });

                SaveToFile();
            }
        }

        /// <summary>
        /// 生成局部更新方法
        /// </summary>
        private void WritePartialUpdate()
        {
            var partialModels= PartailUpdateCenter.GetPartialUpdateModels(Model);
            foreach (var item in partialModels)
            {
                var updateModelName = item.ModelName;
                var preUpdateMethodName = $"Pre{updateModelName}Update";
                var postUpdateMethodName = $"Post{updateModelName}Update";
                // Id属性不更新
                var props = item.PropertyDefs.Where(p=>p.PropertyName!="Id");
                WriteLine($"public void {updateModelName}Update({item.UpdateDtoName} {dtoParamName})");
                WriteLine("{");
                WriteLine($"{preUpdateMethodName}();");
                WritePropertyCopy(props);
                WriteLine($"{postUpdateMethodName}();");
                WriteLine("}");

                WritePartialDef(preUpdateMethodName);
                WritePartialDef(postUpdateMethodName);
            }
        }

        /// <summary>
        /// 使用Dto构造 DomainModel
        /// </summary>
        private void WriteDtoCtor()
        {
            var preCtorMethodName = "PreCtor";
            var postCtorMethodName = "PostCtor";
            var props = GetIntersectionProperty(PropertyExistType.DomainModel, PropertyExistType.AddDto);
            WriteLine($"public {ModelName}({Model.AddDtoName} {dtoParamName})");
            WriteLine("{");
            WriteLine($"{preCtorMethodName}();");
            WritePropertyCopy(props);
            WriteLine($"{postCtorMethodName}();");
            WriteLine("}");

            WritePartialDef(preCtorMethodName);
            WritePartialDef(postCtorMethodName);
        }

        /// <summary>
        /// 获取两个对象上 都有的属性
        /// </summary>
        /// <param name="ext1"></param>
        /// <param name="ext2"></param>
        /// <returns></returns>
        private IEnumerable<PropertyDef> GetIntersectionProperty(PropertyExistType ext1, PropertyExistType ext2)
        {
            foreach (var item in Model.PropertyDefs)
            {
                if (item.CheckExistIn(ext1) && item.CheckExistIn(ext2))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// 属性复制
        /// </summary>
        /// <param name="def"></param>
        private void WritePropertyCopy(IEnumerable<PropertyDef> def)
        {
            foreach (var item in def)
            {
                WriteLine($"this.{item.PropertyName} = {dtoParamName}.{item.PropertyName};");
            }
        }

        private string dtoParamName = "dto";
        /// <summary>
        /// 使用UpdateDto更新 Domain Model
        /// </summary>
        private void WriteDtoUpdate()
        {
            var preUpdateMethodName = "PreUpdate";
            var postUpdateMethodName = "PostUpdate";
            var props = GetIntersectionProperty(PropertyExistType.DomainModel, PropertyExistType.UpdateDto);
            WriteLine($"public void Update({Model.UpdateDtoName} {dtoParamName})");
            WriteLine("{");
            WriteLine($"{preUpdateMethodName}();");
            WritePropertyCopy(props);
            WriteLine($"{postUpdateMethodName}();");
            WriteLine("}");

            WritePartialDef(preUpdateMethodName);
            WritePartialDef(postUpdateMethodName);
        }

        /// <summary>
        /// 分部方法定义
        /// </summary>
        private void WritePartialDef(string methodName)
        {
            WriteLine($"partial void {methodName}();");
        }
        

        protected override void GenUsing()
        {

        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Domain, Model.ModuleName, "Aggregates");
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}.cs";
        }
    }
}
