using static SmartModel.Keyword;

namespace SmartModel
{
    public class ClassGen : GenBase
    {
        /// <summary>
        /// 获取基类和需要实现的接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string GetBaseClassAndInterface()
        {
            //if (Model == null)
            //{
            //    return "";
            //}

            var baseClass = "";

            List<string> modelInterface = new List<string>();
            // 添加基类
            if (!string.IsNullOrEmpty(Model.BaseClassName))
            {
                modelInterface.Add(Model.BaseClassName);
            }
            // 添加Clone接口
            if (Model.NeedGenClone)
            {
                modelInterface.Add($"ICloneable");
            }

            // 添加Clone接口
            if (Model.NeedGenDefaultIdEqual)
            {
                modelInterface.Add($"IEquatable<{Model.ModelName}>");
            }

            if (modelInterface.Any())
            {
                baseClass = $":{string.Join(",", modelInterface)}";
            }

            return baseClass;
        }

        
        public override void GenCode()
        {
            foreach (var model in ModelList)
            {
                Model = model;

                NamespaceContainter(() =>
                {
                    var baseClass = GetBaseClassAndInterface();

                    WriteLine($"public {partial} class {Model.ModelName} {baseClass}");
                    WriteLine("{");

                    GenProperty();
                    GenClone();
                    GenDefaultEqual();

                    WriteLine("}");
                });

                SaveToFile();
            }
            
        }

        /// <summary>
        /// 生成属性定义
        /// </summary>

        private void GenProperty()
        {
            if (Model == null)
            {
                return;
            }

            foreach (var prop in Model.GetCurrentClassProperty())
            {
                WriteSummary(prop.Comment);
                var defalutValue = string.IsNullOrEmpty(prop.DefaultValue) ? "" : $"={prop.DefaultValue};";
                WriteLine($"public {prop.CSharpType} {prop.PropertyName} {{ get; set; }} {defalutValue}");
            }
        }
        /// <summary>
        /// 生成Clone方法
        /// </summary>
        /// <param name="model"></param>
        private void GenClone()
        {
            if (Model == null)
            {
                return;
            }
            if (Model.NeedGenClone)
            {
                var virtualOrOverRide = "";
                // 没有基类
                if (string.IsNullOrEmpty(Model.BaseClassName))
                {
                    virtualOrOverRide = "virtual";
                }
                // 有基类
                else
                {
                    virtualOrOverRide = "override";
                }

                WriteLine($"public {virtualOrOverRide} object Clone()");
                WriteLine("{");
                WriteLine($"var m = new {Model.ModelName}();");
                foreach (var prop in Model.PropertyDefs)
                {
                    WriteLine($"m.{prop.PropertyName} = {prop.CloneFunc($"this.{prop.PropertyName}")};");
                }
                WriteLine(" return m;");

                WriteLine("}");
            }
        }

        /// <summary>
        /// 生成默认Id相等
        /// </summary>
        /// <param name="model"></param>
        private void GenDefaultEqual()
        {
            if (Model == null)
            {
                return;
            }
            if (Model.NeedGenDefaultIdEqual)
            {
                WriteLine($"public bool Equals({ModelName}? other)");
                WriteLine("{");
                WriteLine("return other == null ? false : other.Id == this.Id;");
                WriteLine("}");
            }
        }

        protected override void GenUsing()
        {
            //WriteLine("");
            //WriteLine("");
            //WriteLine("");
            //WriteLine("");
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.BackendDir, Config.ModelDirecotryName);
        }

        protected override string GetCodeFileName()
        {
            if (Model == null)
            {
                return "";
            }
            return Model.GetModelFileName();
        }

    }

    public class EnumGen : GenBase
    {
        public override void GenCode()
        {
            NamespaceContainter(() =>
            {
                foreach (var enumDef in EnumModels)
                {
                    WriteLine($"public enum {enumDef.EnumName}:{enumDef.BaseType}");
                    WriteLine("{");
                    foreach (var item in enumDef.ItemDefs)
                    {
                        WriteLine($"{item.Name}={item.Value},");
                    }
                    WriteLine("}");
                }
            });

            SaveToFile();
        }

        protected override void GenUsing()
        {
            WriteLine("");
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.BackendDir, Config.EnumDirecotryName);
        }

        protected override string GetCodeFileName()
        {
            return "EnumDef.cs";
        }
    }
}