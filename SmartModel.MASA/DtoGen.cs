
namespace SmartModel
{
    public class DtoGen : AggregateGen
    {


        private string GetDtoBaseClassName()
        {
            if (string.IsNullOrEmpty(Model.DtoBaseClassName))
            {
                return "";
            }
            else
            {
                return $": {Model.DtoBaseClassName}";
            }
        }

        /// <summary>
        /// 根据参数的顺序，优先使用靠前的 不为空的数据
        /// </summary>
        /// <returns></returns>
        private string UseDefault(params string[] values)
        {
            foreach (var item in values)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    return item;
                }
            }
            return "";
        }

        protected string AppendNullable(string oldType, bool appendNull)
        {
            if (appendNull)
            {
                return $"{oldType}?";
            }
            else
            {
                return oldType;
            }
        }
        private string GetDtoPropType(PropertyDef def)
        {
            var type = AppendNullable(UseDefault(def.DtoCsharpType, def.CSharpType), def.Nullable);
            return type;
        }
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                if (item.DoNotGenDto)
                {
                    continue;
                }

                Model = item;

                NamespaceContainter(() =>
                {
                    WriteLine($"public {partial} class {Model.GetDtoClassName()} {GetDtoBaseClassName()}");
                    WriteLine("{");

                    foreach (var prop in GetDtoProperty())
                    {
                        WriteLine($"public {GetDtoPropType(prop)} {prop.PropertyName} {{ get; set; }} {Property_DefaultValue(prop)}");
                    }

                    WriteEmptyCtor();
                    WriteAllParamCtor();

                    WriteLine("}");
                });

                SaveToFile();
            }
        }

        /// <summary>
        /// 无参数构造函数
        /// </summary>
        private void WriteEmptyCtor()
        {
            WriteLine($" public {Model.GetDtoClassName()}() {{ }}");
        }


        /// <summary>
        /// 所有参数的构造函数
        /// </summary>
        private void WriteAllParamCtor()
        {
            var props = GetDtoProperty().Select(p => $"{GetDtoPropType(p)} {p.GetPrivateParamName()}");
            var param = string.Join($",{Environment.NewLine}", props);
            WriteLine($" public {Model.GetDtoClassName()}({param})");
            WriteLine("{");

            foreach (var prop in GetDtoProperty())
            {
                WriteLine($"this.{prop.PropertyName} = {prop.GetPrivateParamName()};");
            }
            WriteLine("}");
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ContractsDir, Model.ModuleName);
        }

        protected override string GetCodeFileName()
        {
            return $"{Model.GetDtoClassName()}.cs";
        }
    }
}