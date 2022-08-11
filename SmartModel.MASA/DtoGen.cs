
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

        protected override string Property_DefaultValue(PropertyDef def)
        {
            // 优先使用配置的 dto默认值
            var defaultValue = UseDefault(def.DtoDefaultValue, def.DefaultValue);
            if (string.IsNullOrEmpty(defaultValue))
            {
                return "";
            }
            else
            {
                return $"= {defaultValue};";
            }
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
        protected string GetDtoPropType(PropertyDef def)
        {
            var type = AppendNullable(UseDefault(def.DtoCsharpType, def.CSharpType), def.Nullable);
            return type;
        }
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                NamespaceContainter(() =>
                {
                    if (!item.DoNotGenDto)
                    {
                        WriteDto();
                    }
                  

                    if (Model.IsSupportGet)
                    {
                        WriteGetDto();
                    }

                    if (Model.IsSupportAdd)
                    {
                        WriteAddDto();
                    }

                    if (Model.IsSupportDetail)
                    {
                        WriteDetailDto();
                    }

                    if (Model.IsSupportUpdate || Model.IsPartialUpdate)
                    {
                        WriteUpdateDto();
                    }

                    if (Model.IsSupportUpsert)
                    {
                        WriteUpsertDto();
                    }

                    if (Model.IsSupportRemove)
                    {
                        WriteRemoveDto();
                    }

                    if (Model.IsSupportSelect)
                    {
                        WriteSelectDto();
                    }

                    if (Model.IsSupportCopy)
                    {
                        WriteCopyDto();
                    }
                });

                SaveToFile();
            }
        }


        private void WriteCopyDto()
        {
            var baseType = "";
            if (Model.IsCopyDtoInheritUpsertDto)
            {
                baseType = Model.UpsertDtoName;
            }
            WriteDtoCore(Model.CopyDtoName, baseType, Model.GetPropertyDefs(PropertyExistType.CopyDto));
        }
        private void WriteGetDto()
        {
            WriteDtoCore(Model.GetDtoName, $"Pagination<{Model.GetDtoName}>", Model.GetPropertyDefs(PropertyExistType.GetDto));
        }

        private void WriteDtoCore(string className, string baseClassName, IEnumerable<PropertyDef> props)
        {
            if (!string.IsNullOrEmpty(baseClassName))
            {
                baseClassName = $":{baseClassName}";
            }

            WriteLine($"public {partial} class {className} {baseClassName}");
            WriteLine("{");

            foreach (var prop in props)
            {
                WriteLine($"public {IsNew(prop)} {GetDtoPropType(prop)} {prop.PropertyName} {{ get; set; }} {Property_DefaultValue(prop)}");
            }

            WriteEmptyCtor(className);
            WriteAllParamCtor(className, props);

            WriteLine("}");
        }

        protected string IsNew(PropertyDef def)
        {
            if (def.New)
            {
                return "new";
            }
            else
            {
                return "";
            }
        }

        private void WriteSelectDto()
        {
            WriteDtoCore(Model.SelectQueryDtoName, "", Model.GetPropertyDefs(PropertyExistType.SelectQueryDto));

            WriteDtoCore(Model.SelectDtoName, Model.CustomSelectDtoBaseClass, Model.GetPropertyDefs(PropertyExistType.SelectDto));
        
            
        }
        private void WriteAddDto()
        {
            WriteDtoCore(Model.AddDtoName, "", Model.GetPropertyDefs(PropertyExistType.AddDto));
        }

        private void WriteDetailDto()
        {
            WriteDtoCore(Model.DetailQueryDtoName, "", Model.GetPropertyDefs(PropertyExistType.DetailQueryDto));

            var baseClass = Model.CustomDetailDtoBaseClass;
            if (Model.IsDetialDtoInheritDto)
            {
                baseClass = Model.GetDtoClassName();
            }
            WriteDtoCore(Model.DetailDtoName, baseClass, Model.GetPropertyDefs(PropertyExistType.DetailDto));
        }

        private void WriteUpdateDto()
        {
            var baseType = "";
            if (Model.IsUpdateDtoInheritAddDto)
            {
                baseType = Model.AddDtoName;
            }
            if (Model.IsUpdateDtoInheritDetailDto)
            {
                baseType = Model.DetailDtoName;
            }
            WriteDtoCore(Model.UpdateDtoName, baseType, Model.GetPropertyDefs(PropertyExistType.UpdateDto));
        }

        private void WriteUpsertDto()
        {
            WriteDtoCore(Model.UpsertDtoName, "", Model.GetPropertyDefs(PropertyExistType.UpsertDto));
        }

        private void WriteRemoveDto()
        {
            WriteDtoCore(Model.RemoveDtoName, "", Model.GetPropertyDefs(PropertyExistType.RemoveDto));
        }

        private void WriteDto()
        {
            WriteLine($"public {partial} class {Model.GetDtoClassName()} {GetDtoBaseClassName()}");
            WriteLine("{");

            foreach (var prop in GetDtoProperty())
            {
                WritePropertyAttribute(prop);
                WriteLine($"public {GetDtoPropType(prop)} {prop.PropertyName} {{ get; set; }} {Property_DefaultValue(prop)}");
            }

            WriteEmptyCtor(Model.GetDtoClassName());
            WriteAllParamCtor(Model.GetDtoClassName(), GetDtoProperty());

            WriteLine("}");
        }

       

      


        /// <summary>
        /// 所有参数的构造函数
        /// </summary>
        protected void WriteAllParamCtor(string modelName, IEnumerable<PropertyDef> defs)
        {
            var props = defs.Select(p => $"{GetDtoPropType(p)} {p.GetPrivateParamName()}");

            // 如果没有任何属性，则不需要生成有参数构造
            if (!props.Any())
            {
                return;
            }

            var param = string.Join($",{Environment.NewLine}", props);
            WriteLine($" public {modelName}({param})");
            WriteLine("{");

            foreach (var prop in defs)
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