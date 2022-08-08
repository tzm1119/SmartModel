using static SmartModel.TypeNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyNameConst;
using static SmartModel.ValidationRule;
using System.Text;

namespace SmartModel
{
    public abstract class GenBase
    {
        //public string ModelName => Model?.ModelName ?? "";
        //public MetaModelDef? Model { get; set; }

        [NotNull]
        public List<EnumDef>? EnumModels { get; set; }

        public void SetEnumModels(List<EnumDef> models)
        {
            this.EnumModels = models;
        }

        /// <summary>
        /// 此属性仅用于内部遍历时使用
        /// </summary>
        /// 
        [NotNull]
        protected MetaModelDef? Model { get; set; }

        protected string ModelName => Model?.ModelName ?? "";
        [NotNull]
        public List<MetaModelDef>? ModelList { get; set; }

        public void SetModelList(List<MetaModelDef> models)
        {
            ModelList = models;
        }
        public GenBase()
        {
            this.Namespace = "SmartModel";
        }

        #region Cmd和服务
        protected string AddBaseCmd = "AddCommand";
        protected string UpdateBaseCmd = "UpdateCommand";
        protected string DeleteBaseCmd = "DeleteCommand";
        protected string CmdSuffix = "Command";
        protected string ValidatorSuffix = "Validator";
        public string AddCmdName { get; set; } = "";
        public string UpdateCmdName { get; set; } = "";
        public string DeleteCmdName { get; set; } = "";
        public string ServiceName { get; set; } = "";
        public string ServiceInterfaceName { get; set; } = "";
        protected string DefalutComposeModelName { get; set; } = "";
        protected string GetDeleteCmdName(string modelName)
        {
            var strPrefix = "Delete";
            return $"{strPrefix}{modelName}{CmdSuffix}";
        }
        protected virtual void InitName()
        {
            var strPrefix = "Add";
            AddCmdName = $"{strPrefix}{ModelName}{CmdSuffix}";
            strPrefix = "Update";
            UpdateCmdName = $"{strPrefix}{ModelName}{CmdSuffix}";
            DeleteCmdName = GetDeleteCmdName(ModelName);
            ServiceName = GetServiceName(ModelName);
            ServiceInterfaceName = GetServiceInterfaceName(ModelName);

            //StateMachineCompose
            DefalutComposeModelName = $"{ModelName}Compose";
            //UserComposeModelName = $"User_{DefalutComposeModelName}";
            //User_Project_ComposeModelName = $"User_Project_{DefalutComposeModelName}";
            //ProjectComposeModelName = $"Project_{DefalutComposeModelName}";
            //DocComposeModelName = $"Doc_{DefalutComposeModelName}";
            //PartComposeModelName = $"Part_{DefalutComposeModelName}";

            //string defaultFindoModelName = $"Find{ModelName}";
            //ProjectFindModelName = $"Project_{defaultFindoModelName}";
            //UserFindModelName = $"User_{defaultFindoModelName}";
        }
        public string GetServiceName(string modelName)
        {
            return $"{modelName}Service";
        }
        public string GetServiceInterfaceName(string modelName)
        {
            return $"I{modelName}Service";
        }
        #endregion

        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace { get; set; } = "";

        protected StringBuilder CodeCache { get; set; } = new();

        /// <summary>
        /// 输出注释
        /// </summary>
        protected virtual void WriteSummary(string summary)
        {
            WriteLine("/// <summary>");
            WriteLine($"/// {summary}");
            WriteLine("/// </summary>");
        }

        protected void WriteInjectService(string type, string propName)
        {
            WriteLine("[Inject]");
            WriteLine("[NotNull]");
            WriteLine($"public {type}? {propName} {{get; set;}}");
        }
        protected void WriteParameter(bool isNotNull, string type, string propName)
        {
            //    [Parameter]
            //    [NotNull]
            //    public Department? Model { get; set; }
            WriteLine("[Parameter]");
            if (isNotNull)
            {
                WriteLine("[NotNull]");
            }

            var notNull = isNotNull ? "?" : "";

            WriteLine($"public {type}{notNull} {propName} {{get; set;}}");
        }

        protected void WriteBindingParameter(string type, string name)
        {
            //    [Parameter]
            //    public bool Visible { get; set; }

            //    [Parameter]
            //    public EventCallback<bool> VisibleChanged { get; set; }
            WriteLine("[Parameter]");
            WriteLine($"public {type} {name} {{ get; set; }}");
            WriteLine("[Parameter]");
            WriteLine($"public EventCallback<{type}> {name}Changed {{ get; set; }}");
        }
        protected abstract string GetCodeDirectoryPath();
        /// <summary>
        /// 向缓存中输出一行代码
        /// </summary>
        /// <param name="s"></param>
        protected virtual void WriteLine(string s)
        {
            CodeCache.AppendLine(s);
        }

        /// <summary>
        /// 在命名空间外，生成using
        /// </summary>
        protected abstract void GenUsing();

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="models"></param>
        public abstract void GenCode();

        protected void NamespaceContainter(Action action)
        {
            GenUsing();

            WriteLine($"namespace {Namespace}");

            WriteLine("{");

            action();

            WriteLine("}");
        }

        protected virtual void SaveToFile()
        {
            var dir = GetCodeDirectoryPath();
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(
                Path.Combine(dir, GetCodeFileName())
                , CodeCache.ToString());

            CodeCache.Clear();
        }

        protected abstract string GetCodeFileName();
    }


    public class TypeNameConst
    {
        public const string SysProject = "SysProject";
        public const string SysUser = "SysUser";
        public const string ProjectTask = "ProjectTask";
        public const string IdNameModel = "IdNameModel";
        public const string HeroInfo = "HeroInfo";
        public const string Department = "Department";
        public const string HeroSkillType = "HeroSkillType";
        public const string ScoringDimension = "ScoringDimension";
        public const string ScoreItem = "ScoreItem";
        public const string SkillType_ScoringDimension_Map = "SkillType_ScoringDimension_Map";
        public const string HeroSuccessType = "HeroSuccessType";
    }

    public class EnumTypeNameConst
    {
        public const string FormEditType = "FormEditType";

    }

    public class MetaModelDefExtInfo
    {
        public MetaModelDefExtInfo(MetaModelDef host)
        {
            Host = host;
        }

        public MetaModelDef Host { get; }

        public MetaModelDef Return()
        {
            return this.Host;
        }
    }

    public class EntityTypeConfigurationDef : MetaModelDefExtInfo
    {
        public EntityTypeConfigurationDef(MetaModelDef host) : base(host)
        {

        }
        public string KeyPropName { get; set; } = "";
        public HashSet<EFIndexConfig> IndexConfig { get; set; } = new();
        public HashSet<EFPropertyConfig> PropertyConfig { get; set; } = new();
        public EntityTypeConfigurationDef HasKey(string propName)
        {
            KeyPropName = propName;
            return this;
        }

        public EntityTypeConfigurationDef HasIndex(EFIndexConfig config)
        {
            IndexConfig.Add(config);
            return this;
        }

        public EntityTypeConfigurationDef Property(EFPropertyConfig propConfig)
        {
            PropertyConfig.Add(propConfig);
            return this;
        }

        public HashSet<string> IgnorePropNames { get; set; } = new();
        public EntityTypeConfigurationDef Ignore(string propConfig)
        {
            IgnorePropNames.Add(propConfig);
            return this;
        }

        public HashSet<EFRelationConfig> RelationConfigs { get; set; } = new();

        public EntityTypeConfigurationDef Relation(Action<EFRelationConfig> act)
        {
            EFRelationConfig config = new EFRelationConfig();
            act(config);
            RelationConfigs.Add(config);
            return this;
        }


    }

    public class EFIndexConfig
    {
        public EFIndexConfig(string name, bool isUnique = false, string hasFilter = "", EFIndexType fIndexType = EFIndexType.SinglePropIndex)
        {
            this.Name = name;
            this.IsUnique = isUnique;
            if (!string.IsNullOrEmpty(hasFilter))
            {
                this.HasFilter = $".HasFilter(\"{hasFilter}\")" ;
            }
            
            this.EFIndexType = fIndexType;
        }
        /// <summary>
        /// 如果是单属性索引，则Name表示属性名，如 UserId
        /// 如果是多属性联合索引，则Name表示联合索引对应的 表达式，如 u => new { u.UserId, u.SystemId }
        /// </summary>
        public string Name { get; set; } = "";
        public bool IsUnique { get; set; }
        public string HasFilter { get; set; } = "";

        public EFIndexType EFIndexType { get; set; } = EFIndexType.SinglePropIndex;

        public override string ToString()
        {
            var idx = "";
            if (EFIndexType == EFIndexType.SinglePropIndex)
            {
                idx = $"builder.HasIndex(s => s.{Name})";
            }
            else
            {
                idx = $"builder.HasIndex({Name})";
            }

            idx = StringExt.AppendIf(idx, IsUnique, ".IsUnique()");
            idx = StringExt.NotEmptyAppend(idx, HasFilter);
            idx = StringExt.Append(idx, ";");
            return idx;
        }

    }

    /// <summary>
    /// 是单属性索引还是多属性索引
    /// </summary>
    public enum EFIndexType
    {
        SinglePropIndex,
        CombinePropIndex
    }

    public class EFRelationConfig
    {
        private List<(string, string)> cmds = new();
        public EFRelationConfig HasMany(string propName)
        {
            cmds.Add(("HasMany", propName));
            return this;
        }

        public EFRelationConfig WithOne(string propName)
        {
            cmds.Add(("WithOne", propName));
            return this;
        }

        public EFRelationConfig HasForeignKey(string propName)
        {
            cmds.Add(("HasForeignKey", propName));
            return this;
        }

        public EFRelationConfig HasOne(string propName)
        {
            cmds.Add(("HasOne", propName));
            return this;
        }

        public EFRelationConfig WithMany(string propName = "")
        {
            cmds.Add(("WithMany", propName));
            return this;
        }

        public EFRelationConfig IsRequiredFalse()
        {
            cmds.Add(("IsRequired", "false"));
            return this;
        }

        public EFRelationConfig OnDelete_ClientSetNull()
        {
            cmds.Add(("OnDelete", "DeleteBehavior.ClientSetNull"));
            return this;
        }
    }



    public class EFPropertyConfig
    {
        public EFPropertyConfig(string name, string enumType)
        {
            this.Name = name;
            this.EnumType = enumType;
        }
        public EFPropertyConfig(string name, bool isrequired = false, int maxLen = 100, string hasDefaultValue = "")
        {
            this.Name = name;
            this.IsRequired = isrequired;
            this.HasMaxLength = maxLen;
            this.HasDefaultValue = hasDefaultValue;
        }
        public string Name { get; set; } = "";
        public bool IsRequired { get; set; }

        /// <summary>
        /// 枚举的自定义转换逻辑
        /// </summary>
        public string EnumType { get; set; } = "";
        public int HasMaxLength { get; set; }
        public string HasDefaultValue { get; set; } = "";

        public override string ToString()
        {
            var prop = $"builder.Property(s => s.{Name})";
            prop = StringExt.AppendIf(prop, IsRequired, ".IsRequired()");
            prop = StringExt.AppendIf(prop, HasMaxLength != 0, $".HasMaxLength({HasMaxLength})");
            prop = StringExt.AppendIf(prop, !string.IsNullOrEmpty(HasDefaultValue), $".HasDefaultValue({HasDefaultValue})");

            // 枚举转换
            if (!string.IsNullOrEmpty(EnumType))
            {
                prop = prop.Append($".HasConversion( v => v.ToString(), v => ({EnumType})Enum.Parse(typeof({EnumType}), v));");
            }
            prop = prop.Append(";");
            return prop;
        }
    }

    /// <summary>
    /// 元模型定义
    /// </summary>
    public abstract class MetaModelDef
    {
        public string GetPaginationBaseClass()
        {
            return $"Pagination<{this.ModelName}>";
        }

        public string GetDtoClassName()
        {
            return $"{ModelName}Dto";
        }

        #region 快捷方法
        public MetaModelDef SetName(string name)
        {
            ModelName = name;
            return this;
        }

        public MetaModelDef SetBaseClass_AggregateRoot_Guid()
        {
            this.BaseClassName = "AggregateRoot<Guid>";
            TKey = "Guid";
            return this;
        }

        public MetaModelDef SetBaseClass_FullAggregateRoot_Guid_Guid()
        {
            this.BaseClassName = "FullAggregateRoot<Guid,Guid>";
            TKey = "Guid";
            return this;
        }

        public MetaModelDef SetBaseClass_FullAggregateRoot_Int_Guid()
        {
            this.BaseClassName = "FullAggregateRoot<int, Guid>";
            TKey = "int";
            return this;
        }



        public MetaModelDef SetBaseClass_FullEntity_Guid_Guid()
        {
            this.BaseClassName = "FullEntity<Guid,Guid>";
            return this;
        }

        public MetaModelDef SetBaseClass_Entity_Int()
        {
            this.BaseClassName = "Entity<int>";
            return this;
        }

        public MetaModelDef SetBaseClass_ValueObject()
        {
            this.BaseClassName = "ValueObject";
            return this;
        }

        //ValueObject

        public MetaModelDef SetBaseClassName(string name)
        {
            BaseClassName = name;
            DtoBaseClassName = $"{name}Dto";
            return this;
        }

        /// <summary>
        /// 设置当前类的基类为 Pagination<T>
        /// </summary>
        /// <returns></returns>
        public MetaModelDef SetPaginationBaseClassName()
        {
            BaseClassName = GetPaginationBaseClass();
            return this;
        }

        public MetaModelDef SetScope(ModelScope scope)
        {
            Scope = scope;
            return this;
        }

        public MetaModelDef AddProperty(PropertyDef def)
        {
            PropertyDefs.Add(def);
            return this;
        }


        #endregion

        #region Repository接口

        public string RepositoryName => $"{ModelName}Repository";
        public string RepositoryInterfaceName => $"I{ModelName}Repository";
        /// <summary>
        /// 当前对象的Repository接口，需要实现的基接口
        /// </summary>
        public string RepositoryBaseInterface { get; set; } = "";

        public MetaModelDef SetIRepository_Entity_Guid()
        {
            this.RepositoryBaseInterface = $"IRepository<{ModelName}, Guid>";
            TKey = "Guid";
            return this;
        }

        public MetaModelDef SetIRepository_Entity_Int()
        {
            this.RepositoryBaseInterface = $"IRepository<{ModelName}, int>";
            TKey = "int";
            return this;
        }

        /// <summary>
        /// 当前对象 对应的MASA中的TKey
        /// </summary>
        public string TKey { get; set; } = "";

        public MetaModelDef SetIRepository_Entity()
        {
            this.RepositoryBaseInterface = $"IRepository<{ModelName}>";
            return this;
        }

        #endregion

        #region CRUD功能支持

        public bool SupportGet { get; set; }
        public bool SupportDetail { get; set; }
        public bool SupportAdd { get; set; }
        public bool SupportRemove { get; set; }
        public bool SupportUpdate { get; set; }
        public bool SupportUpsert { get; set; }

        /// <summary>
        ///  需要生成对应的SelectDto，如 DepartmentSelectDto
        /// </summary>
        public bool SupportSelectDto { get; set; }
        #endregion

        #region EF

        public bool NeedGenEntityTypeConfiguration()
        {
            return _EntityTypeConfiguration != null;
        }
        private EntityTypeConfigurationDef? _EntityTypeConfiguration;
        public EntityTypeConfigurationDef EntityTypeConfiguration
        {
            get
            {
                if (_EntityTypeConfiguration == null)
                {
                    _EntityTypeConfiguration = new EntityTypeConfigurationDef(this);
                }
                return _EntityTypeConfiguration;
            }
        }
        #endregion

        #region 文件名


        public virtual string GetModelFileName()
        {
            return $"{this.ModelName}.cs";
        }

        public virtual string GetRazorEditFormFileName()
        {
            return $"{this.ModelName}Form.razor";
        }

        public virtual string GetRazorTableFileName()
        {
            return $"{this.ModelName}Table.razor";
        }

        public virtual string GetRazorTableCSFileName()
        {
            return $"{this.ModelName}Table.razor.cs";
        }
        #endregion

        #region 属性过滤查询


        /// <summary>
        /// 仅获取当前类型的属性，而不获取任何父类上的属性
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PropertyDef> GetCurrentClassProperty()
        {
            return this.PropertyDefs.Where(p => !p.IsBaseClaseProperty);
        }

        /// <summary>
        /// 获取在表格中显示的属性
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PropertyDef> GetTableDisplayProperty()
        {
            return this.PropertyDefs.Where(p => p.ShowInTable);
        }
        /// <summary>
        /// 获取在表单中显示的属性
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PropertyDef> GetFormDisplayProperty()
        {
            return this.PropertyDefs.Where(p => p.ShowInEditForm);
        }
        #endregion

        #region 基础属性

        public MetaModelDef SetModuleName(string name)
        {
            this.ModuleName = name;
            return this;
        }


        public bool DoNotGenDomainModel { get; set; }
        /// <summary>
        /// 不生成对应的Domain Model，如ApiResource，只生成Dto
        /// </summary>
        public MetaModelDef SetDoNotGenDomainModel()
        {
            DoNotGenDomainModel = true;
            return this;
        }

        public bool DoNotGenDto { get; set; }
        /// <summary>
        /// 不生成对应的Dto
        /// </summary>
        public MetaModelDef SetDoNotGenDto()
        {
            DoNotGenDto = true;
            return this;
        }

        /// <summary>
        /// 当前对象所属的模块
        /// </summary>
        public string ModuleName { get; set; } = "Default";
        /// <summary>
        /// 基类名称,聚合根基类
        /// </summary>
        public string BaseClassName { get; set; } = "";

        /// <summary>
        /// Dto的基类名
        /// </summary>
        public string DtoBaseClassName { get; set; } = "";

        public MetaModelDef SetDtoBaseClassName(string name)
        {
            DtoBaseClassName = name;
            return this;
        }
        /// <summary>
        /// 当前对象名
        /// </summary>
        public string ModelName { get; set; } = "";

        public List<PropertyDef> PropertyDefs { get; set; } = new();

        public ModelScope Scope { get; set; }

        #endregion

        #region 扩展功能属性
        /// <summary>
        /// 是否需要生成Clone方法
        /// </summary>
        public bool NeedGenClone { get; set; }

        /// <summary>
        /// 是否需要生成默认的使用Id判断相等的逻辑
        /// </summary>
        public bool NeedGenDefaultIdEqual { get; set; }

        /// <summary>
        /// 不生成前端的表格和Form代码，如IIdNameModel基类，就不需要
        /// </summary>
        public bool DoNotGenFrontTableAndEditForm { get; set; }
        #endregion

    }

    /// <summary>
    /// 对象的生效范围
    /// </summary>
    public enum ModelScope
    {
        Tenant,
        Project,
        User,
        Document
    }

    /// <summary>
    /// 属性引用类型
    /// </summary>
    public enum PropertyRefType
    {
        None,
        SingleRef,
        MultiRef,
        SingleDep,
        MultiDep
    }

    public class EnumDef
    {
        public EnumDef SetName(string name)
        {
            this.EnumName = name;
            return this;
        }

        public string EnumName { get; set; } = "";

        public string BaseType { get; set; } = "int";

        public List<EnumItemDef> ItemDefs { get; set; } = new();

        public EnumDef AddItem(EnumItemDef item)
        {
            this.ItemDefs.Add(item);
            return this;
        }
    }

    public class EnumItemDef
    {
        public static EnumItemDef NewEnumItem(string name, int value)
        {
            return new EnumItemDef
            {
                LanguageDefList = Array.Empty<LanguageDef>(),
                Name = name,
                Value = value
            };
        }
        public static EnumItemDef NewEnumItem(string name, int value, params LanguageDef[] lang)
        {
            return new EnumItemDef
            {
                LanguageDefList = lang,
                Name = name,
                Value = value
            };
        }
        public int Value { get; set; }

        public string Name { get; set; } = "";

        public LanguageDef[] LanguageDefList { get; set; } = Array.Empty<LanguageDef>();
    }
}