using static SmartModel.LanguageDef;


namespace SmartModel
{
    /// <summary>
    /// 
    /// </summary>
    public enum GetSetType
    {
        Get,
        GetSet,
        Get_PrivateSet,
        Get_ProtectedSet
    }

    /// <summary>
    /// 属性否是出现在dto 或 domain model中
    /// </summary>
    public enum PropertyExistType
    {
        None,
        /// <summary>
        /// 此属性仅出现在Dto中
        /// </summary>
        Dto = 1,
        DetailDto = 2,
        SelectDto = 4,
        AddDto = 8,
        GetDto = 16,
        RemoveDto = 32,
        UpdateDto = 64,
        DomainModel = 128,
        UpsertDto = 256,
        CopyDto=512,
        SelectQueryDto=1024,
        DetailQueryDto=2048,
    }

    public static class StringExt
    {
        public static string ToCameCase(this string s)
        {
            return char.ToLower(s[0]) + s.Substring(1);
        }

        public static string AppendIf(this string s, bool condition, string lastString)
        {
            if (condition)
            {
                return $"{s}{lastString}";
            }
            else
            {
                return s;
            }
        }

        public static string Append(this string s, string lastString)
        {
            return $"{s}{lastString}";
        }

        public static string NotEmptyAppend(this string s, string lastString)
        {
            if (!string.IsNullOrEmpty(lastString))
            {
                return $"{s}{lastString}";
            }
            else
            {
                return s;
            }
        }
    }
    /// <summary>
    /// 属性定义
    /// </summary>
    public class PropertyDef
    {
        #region 静态属性构造函数
        public static PropertyDef String_Description()
        {
            return String(PropertyNameConst.Description)
                .WithLangs(ChineseLang("描述")
                , EnglishLang("Description"))
                .WithComment("描述信息");
        }

        public static PropertyDef String_Name()
        {
            return String(PropertyNameConst.Name)
                .WithLangs(ChineseLang("名称")
                , EnglishLang("Name"))
                .WithComment("名称");
        }
        public static PropertyDef String_ParentId()
        {
            return String(PropertyNameConst.ParentId)
                .WithLangs(ChineseLang("父节点Id")
                , EnglishLang("Parent Id"))
                .WithComment("父节点Id")
                .SetDoNotShowInEditForm()
                .SetDoNotShowInTable();
        }

        public static PropertyDef StringId()
        {
            return new PropertyDef
            {
                PropertyName = "Id",
                CSharpType = "string",
                DefaultValue = "\"\"",
                Comment = "Id唯一标识"
            }.SetEditor(PropertyEditorType.TextInput)
            .SetDoNotShowInEditForm()
            .SetDoNotShowInTable();
        }

        public static PropertyDef Guid(string name)
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = "Guid",
                DefaultValue = "",
            }.SetEditor(PropertyEditorType.TextInput);
        }

        public static PropertyDef String(string name,string defalutValue="")
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = "string",
                DefaultValue = $"\"{defalutValue}\"",
            }.SetEditor(PropertyEditorType.TextInput);
        }

        public static PropertyDef Bool(string name, bool defaultValue = false)
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = "bool",
                DefaultValue = defaultValue.ToString().ToLower(),
            }.SetEditor(PropertyEditorType.Switch);
        }

        public string GetPrivateParamName()
        {
            return GetPropertyFieldName(PropertyName);
            //return $"_{PropertyName.ToCameCase()}";
        }

        /// <summary>
        /// List中的 泛型类型为自定义类型时，使用此方法。如果泛型为c#基础类型
        /// 比如List<int>,List<string>时，请直接使用ListString或ListInt，
        /// 而不要使此方法，因为此方法 会设置 DtoCsharpType = List<{innerType}Dto>
        /// 
        /// </summary>
        /// <param name="innerType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyDef List(string innerType, string name)
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = $"List<{innerType}>",
                DefaultValue = DefaultValue_CtorNew,
                DtoCsharpType = $"List<{innerType}Dto>",
                ListInnerType = innerType,
                FieldDefaultValue = DefaultValue_CtorNew,
            }.SetEditor(PropertyEditorType.Switch);
        }

        /// <summary>
        /// List<CheckItemDto<string>>
        /// </summary>
        /// <param name="innerType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyDef ListCheckItem_String(string name)
        {
            var p = List("CheckItemDto<string>", name);
            p.DtoCsharpType = "List<CheckItemDto<string>>";
            return p;
        }

        /// <summary>
        /// List<SelectItemDto<string>>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyDef ListSelectItem_String(string name)
        {
            var p = List("SelectItemDto<string>", name);
            p.DtoCsharpType = "List<SelectItemDto<string>>";
            return p;
        }

        public static PropertyDef ListString(string name)
        {
            var p = List("string", name);
            p.DtoCsharpType = "List<string>";
            return p;
        }

        public static PropertyDef ListInt(string name)
        {
            var p = List("int", name);
            p.DtoCsharpType = "List<int>";
            return p;
        }

        public static PropertyDef ListGuid(string name)
        {
            var p = List("Guid", name);
            p.DtoCsharpType = "List<Guid>";
            return p;
        }

        public static PropertyDef IReadOnlyCollection(string innerType, string name)
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = $"IReadOnlyCollection<{innerType}>",
                DefaultValue = GetPropertyFieldName(name),
                GetSetType = GetSetType.Get,
                FieldType = $"List<{innerType}>",
                DtoCsharpType = $"List<{innerType}Dto>",
                ListInnerType = innerType,
                DtoDefaultValue = DefaultValue_CtorNew,
                FieldDefaultValue = DefaultValue_CtorNew,
            }.SetEditor(PropertyEditorType.Switch);
        }

        public static PropertyDef IReadOnlyList(string innerType, string name)
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = $"IReadOnlyList<{innerType}>",
                DefaultValue = GetPropertyFieldName(name),
                GetSetType = GetSetType.Get,
                FieldType = $"List<{innerType}>",
                DtoCsharpType = $"List<{innerType}Dto>",
                ListInnerType = innerType,
                DtoDefaultValue= DefaultValue_CtorNew,
                FieldDefaultValue = DefaultValue_CtorNew,
            }.SetEditor(PropertyEditorType.Switch);
        }

        public PropertyDef AddAttribute(string attr)
        {
            Attributes.Add(attr);
            return this;
        }
        /// <summary>
        /// 当前属性的 Attribute
        /// </summary>
        public HashSet<string> Attributes { get; set; } = new();
        /// <summary>
        /// 如果当前属性是List和IReadOnlyList集合类型，则此属性表示 集合中的泛型
        /// 对象的类型
        /// </summary>
        public string ListInnerType { get; private set; } = "";

        /// <summary>
        /// 当前属性对应的Dto属性类型，目前此属性只对于 List IReadOnlyList这种集合类型使用
        /// 
        /// 因为集合内部的 类型需要添加Dto后缀
        /// </summary>
        public string DtoCsharpType { get; private set; } = "";
        /// <summary>
        /// 根据属性名，获取对应的字段名
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static string GetPropertyFieldName(string propName)
        {
            return $"_{propName.ToCameCase()}";
        }

        /// <summary>
        /// 对于只有Get的属性，默认会生成对应的字段
        /// 
        /// FieldType表示属性对应的字段的类型，一般情况下，属性和字段是同一类型
        /// 
        /// 但对于一些只读属性，字段类型就与属性类型不一致，
        /// 
        /// 比如IReadOnlyCollection的属性，字段类型可能是List
        /// </summary>
        public string FieldType { get; set; } = "";
        public string FieldName { get; set; } = "";
        /// <summary>
        /// 字段默认值
        /// </summary>
        public string FieldDefaultValue { get; set; } = "";

        public static PropertyDef Dictionary_String_String_Properties()
        {
            var dicType = "Dictionary<string, string>";
            var p= NewProperty(dicType, "Properties", DefaultValue_CtorNew);
            p.DtoCsharpType = dicType;
            return p;
        }

        public static PropertyDef DateTime(string name, bool nullable = false)
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = "DateTime",
                Nullable = nullable
            }.SetEditor(PropertyEditorType.DateOnlyPicker);
        }

        public static PropertyDef DateOnly(string name)
        {
            var p= new PropertyDef
            {
                PropertyName = name,
                CSharpType = "DateOnly",
                DefaultValue = "DateOnly.FromDateTime(DateTime.Now)"
            }.SetEditor(PropertyEditorType.DateOnlyPicker);
            
            // 默认都加上这个特性
            p.AddAttribute("[JsonConverter(typeof(DateOnlyNullableJsonConverter))]");
            return p;
        }

        public static PropertyDef Enum(string enumType, string name, string defaultValue = "")
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = enumType,
                DefaultValue = defaultValue,
                IsCustomEnumType = true,
            }.SetEditor(PropertyEditorType.SingleSelect);
        }


        public static PropertyDef Int(string name, int defaultValue = 0)
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = "int",
                DefaultValue = defaultValue.ToString(),
            };
        }

        public static PropertyDef NewProperty(string type, string name, string defaultValue = "")
        {
            return new PropertyDef
            {
                PropertyName = name,
                CSharpType = type,
                DefaultValue = defaultValue,
                IsCustomType = true,
                FieldType = type,
                DtoCsharpType = $"{type}Dto"
            };
        }

        public static PropertyDef SingleRef(string refModelType, string propName)
        {
            var prop = String(GetSingleRefPropertyName(refModelType, propName));
            prop.RefType = PropertyRefType.SingleRef;
            prop.SetEditor(PropertyEditorType.SingleSelect);
            return prop;
        }

        public static PropertyDef MultiRef(string refModelType, string propName)
        {
            var prop = String(GetSingleRefPropertyName(refModelType, propName));
            prop.RefType = PropertyRefType.MultiRef;
            prop.SetEditor(PropertyEditorType.MultiSelect);
            return prop;
        }

        public static PropertyDef MultiDep(string refModelType, string propName)
        {
            var prop = String(GetSingleRefPropertyName(refModelType, propName));
            prop.RefType = PropertyRefType.MultiDep;
            prop.SetEditor(PropertyEditorType.MultiSelect);
            return prop;
        }


        public static PropertyDef SingleDep(string refModelType, string propName)
        {
            var prop = String(GetSingleRefPropertyName(refModelType, propName));
            prop.RefType = PropertyRefType.SingleDep;
            prop.SetEditor(PropertyEditorType.SingleSelect);
            return prop;
        }

        #endregion

        #region 链式方法
        /// <summary>
        /// 设置多语言
        /// </summary>
        /// <param name="langs"></param>
        /// <returns></returns>
        public PropertyDef WithLangs(params LanguageDef[] langs)
        {
            LanguageDefList.AddRange(langs);
            return this;
        }

        public PropertyDef WithRules(params ValidationRule[] rules)
        {
            ValidationRuleList.AddRange(rules);
            return this;
        }

        public PropertyDef WithComment(string comment)
        {
            this.Comment = comment;
            return this;
        }
        #endregion

        #region Clone和默认值
        public static string BasicClone(string k) => k;

        public static string CtorClone(string k) => $"new ({k})";

        public static string ListStringCtorClone(string k) => $"new List<string>({k})";

        public static string DefaultValue_CtorNew => "new ()";
        #endregion
        public static string GetRef_Dep_PropertyName(PropertyRefType refType, string refModelType, string propName)
        {
            return $"{refType}_{refModelType}_{propName}";
        }

        public string GetRefModelType()
        {
            return this.PropertyName.Split("_")[1];
        }

        public static string GetSingleRefPropertyName(string refModelType, string propName)
        {
            return GetRef_Dep_PropertyName(PropertyRefType.SingleRef, refModelType, propName);
        }

        public static string GetMultiRefPropertyName(string refModelType, string propName)
        {
            return GetRef_Dep_PropertyName(PropertyRefType.MultiRef, refModelType, propName);
        }

        public static string GetMultiDefPropertyName(string refModelType, string propName)
        {
            return GetRef_Dep_PropertyName(PropertyRefType.MultiDep, refModelType, propName);
        }

        public static string GetSingleDefPropertyName(string refModelType, string propName)
        {
            return GetRef_Dep_PropertyName(PropertyRefType.SingleDep, refModelType, propName);
        }

        public EditorInfo EditorType { get; set; }

        public PropertyDef SetEditorTextarea()
        {
            SetEditor(PropertyEditorType.Textarea);
            return this;
        }
        public PropertyDef SetEditor(PropertyEditorType editorType)
        {
            EditorType = new EditorInfo { Type = editorType };
            return this;
        }
        public PropertyDef SetEditor(EditorInfo info)
        {
            EditorType = info;
            return this;
        }

        /// <summary>
        /// 
        /// 根据现有的信息，更新指定的信息
        /// </summary>
        /// <param name="updateFunc"></param>
        /// <returns></returns>
        public PropertyDef UpdateEditor(Func<EditorInfo, EditorInfo> updateFunc)
        {
            EditorType = updateFunc(this.EditorType);
            return this;
        }

        /// <summary>
        /// 当前属性是否是基类的属性
        /// </summary>
        public bool IsBaseClaseProperty { get; set; }

        /// <summary>
        /// 设置当前属性为virtual属性
        /// </summary>
        /// <returns></returns>
        public PropertyDef IsVirtual()
        {
            this.Virtual = true;
            return this;
        }

        /// <summary>
        /// 当前属性需要 添加new 隐藏父类的属性
        /// </summary>
        public bool New { get; set; }
        public PropertyDef IsNew()
        {
            New = true;
            return this;
        }

        public GetSetType GetSetType { get; set; } = GetSetType.Get_PrivateSet;

        public PropertyDef Set_GetSetType(GetSetType getSetType)
        {
            GetSetType = getSetType;
            // 如果是只读，则初始化字段名称
            if (GetSetType == GetSetType.Get)
            {
                this.FieldName = GetPropertyFieldName(this.PropertyName);
            }
            return this;
        }

        public PropertyDef Set_Get_ProtectedSet()
        {
            this.GetSetType = GetSetType.Get_ProtectedSet;
            return this;
        }

        /// <summary>
        /// 此属性仅在Dto中出现，在Domin Model中没有此属性
        /// </summary>
        public PropertyExistType PropertyExistType { get; set; } = PropertyExistType.None;
        public PropertyDef IsOnlyDto()
        {
            PropertyExistType = PropertyExistType.Dto;
            return this;
        }

        public PropertyDef IsOnlyGetDto()
        {
            PropertyExistType = PropertyExistType.GetDto;
            return this;
        }

        /// <summary>
        /// 当前属性存在于多种Dto或Domain model中
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public PropertyDef ExistIn(params PropertyExistType[] types)
        {
            PropertyExistType = types.Aggregate((t, seed) => t | seed);
            return this;
        }

        /// <summary>
        /// 检查当前属性是否出现在 指定类型的对象上
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool CheckExistIn(PropertyExistType type)
        {
            return (PropertyExistType & type) != 0;

        }

        public PropertyDef IsOnlyDomainModel()
        {
            PropertyExistType = PropertyExistType.DomainModel;
            return this;
        }

        public PropertyDef IsOverride(string impl)
        {
            this.Override = true;
            CustomOverride = impl;
            return this;
        }
        /// <summary>
        /// 当前属性是否是 virtual属性
        /// </summary>
        public bool Virtual { get; set; }

        /// <summary>
        /// 当前属性是否是 override属性
        /// </summary>
        public bool Override { get; set; }

        #region 属性验证相关


        /// <summary>
        /// 属性是否必填
        /// </summary>
        public bool Required { get; set; }

        public PropertyDef IsRequired()
        {
            this.Required = true;
            return this;
        }

        public string CustomMustValidator { get; set; } = "";

        /// <summary>
        /// 设置自定义must验证，如
        /// order => order >= BusinessConsts.PERMISSION_ORDER_MIN_VALUE && order <= BusinessConsts.PERMISSION_ORDER_MAX_VALUE
        /// </summary>
        /// <param name="must"></param>
        /// <returns></returns>
        public PropertyDef SetCustomMustValidator(string must)
        {
            this.CustomMustValidator = must;
            return this;
        }

        public int MaxLength { get; set; }

        public bool ChineseLetterNumber { get; set; }
        public PropertyDef SetMaxLength(int maxLen, bool chineseLetterNumber = false)
        {
            this.MaxLength = maxLen;
            this.ChineseLetterNumber = chineseLetterNumber;
            return this;
        }

        public int GreaterThanOrEqualTo { get; set; }

        public PropertyDef SetGreaterThanOrEqualTo(int num)
        {
            this.GreaterThanOrEqualTo = num;
            return this;
        }
        #endregion
        /// <summary>
        /// 如果当前属性是Override，则使用此属性，表示如何实现
        /// </summary>
        public string CustomOverride { get; set; } = "";
        /// <summary>
        /// 当前属性是否可空，可空会在类型后面加 ?
        /// </summary>
        public bool Nullable { get; set; }
        public PropertyDef IsNullable()
        {
            Nullable = true;
            return this;
        }

        /// <summary>
        /// 是否在属性上方添加 [NotNull]
        /// </summary>
        public bool NotNullAttribute { get; set; }

        public PropertyDef SetNullable_NotNull()
        {
            Nullable = true;
            NotNullAttribute = true;
            return this;
        }

        /// <summary>
        /// 当前属性的类型 是否用户自定义类型，
        /// 如果是自定义类型，在生成Dto时，需要加Dto后缀
        /// </summary>
        public bool IsCustomType { get; set; }

        /// <summary>
        /// 当前属性是否是自定义枚举类型
        /// </summary>
        public bool IsCustomEnumType { get; set; }
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; } = "";

        /// <summary>
        /// 当前属性的注释
        /// </summary>
        public string Comment { get; set; } = "";
        /// <summary>
        /// 当前属性对应的C#类型，如int,string,也可以是自定义类型如User
        /// </summary>
        public string CSharpType { get; set; } = "";
        /// <summary>
        /// 默认值,领域对象的默认值
        /// </summary>
        public string DefaultValue { get; set; } = "";

        /// <summary>
        /// 默认值,Dto对象的默认值
        /// </summary>
        public string DtoDefaultValue { get; set; } = "";

        public Func<string, string> CloneFunc = BasicClone;

        public PropertyRefType RefType { get; set; }

        /// <summary>
        /// 验证规则
        /// </summary>
        public List<ValidationRule> ValidationRuleList { get; set; } = new();

        /// <summary>
        /// 多语言定义
        /// </summary>
        public List<LanguageDef> LanguageDefList { get; set; } = new();

        #region 控制属性是否显示
        /// <summary>
        /// 在表格中是否显示
        /// </summary>
        public PropertyDef SetDoNotShowInTable()
        {
            this.ShowInTable = false;
            return this;
        }
        /// <summary>
        /// 在编辑表单中是否显示
        /// </summary>
        public PropertyDef SetDoNotShowInEditForm()
        {
            this.ShowInEditForm = false;
            return this;
        }

        public bool ShowInTable { get; set; } = true;

        public bool ShowInEditForm { get; set; } = true;
        #endregion
    }

    public struct EditorInfo
    {
        public EditorInfo(PropertyEditorType editorType)
        {
            Type = editorType;
            CustomArrtibute = "";
            NeedBinding = true;
            DisplayContition = default;
        }
        public EditorInfo(PropertyEditorType editorType, string customArrt, bool needBingding, bool hasFormatter, bool selectNeedSetItems)
        {
            Type = editorType;
            CustomArrtibute = customArrt;
            NeedBinding = needBingding;
            DisplayContition = default;
        }
        public EditorInfo()
        {
            Type = PropertyEditorType.TextInput;
            CustomArrtibute = "";
            NeedBinding = true;
            DisplayContition = default;
        }
        public PropertyEditorType Type { get; set; }
        /// <summary>
        /// 自定义属性
        /// </summary>
        public string CustomArrtibute { get; set; }

        /// <summary>
        /// 是否需要使用默认的绑定语法，对于项目的模板选择，
        /// 由于是强类型多选，需要手动设置回调，因此不使用默认绑定
        /// 
        /// 其他一般情况都是用默认绑定即可
        /// </summary>
        public bool NeedBinding { get; set; }

        /// <summary>
        /// 此控件的显示条件，如Blog只有在Admin视图，才显示是否发布属性
        /// </summary>
        public DisplayContition DisplayContition { get; set; }
    }

    public struct DisplayContition
    {
        public DisplayContition(bool hasCondition, string paramName)
        {
            HasCondition = hasCondition;
            DisplayConditionParamName = paramName;
        }
        /// <summary>
        /// 是否有条件显示
        /// </summary>
        public bool HasCondition { get; set; } = false;
        /// <summary>
        /// 此编辑器是否在指定条件下才显示
        /// </summary>
        public string DisplayConditionParamName { get; set; } = "";
    }

    public enum PropertyEditorType
    {
        TextInput,
        Textarea,
        RichText,
        SingleSelect,
        MultiSelect,
        Switch,
        //DateTimePicker,
        DateOnlyPicker,
        CheckboxList,
    }
}