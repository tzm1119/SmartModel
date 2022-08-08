using static SmartModel.Keyword;

namespace SmartModel
{
    /// <summary>
    /// 生成聚合
    /// </summary>
    public class AggregateGen : MASAAuthGenBase
    {
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

        protected string Property_DefaultValue(PropertyDef def)
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
            //    protected override IEnumerable<object> GetEqualityValues()
            //{
            //    yield return Address;
            //    yield return ProvinceCode;
            //    yield return CityCode;
            //    yield return DistrictCode;
            //}
            WriteLine("protected override IEnumerable<object> GetEqualityValues()");
            WriteLine("{");
            foreach (var prop in GetDomainModelProperty())
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

                    WriteLine("}");
                });

                SaveToFile();
            }


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
