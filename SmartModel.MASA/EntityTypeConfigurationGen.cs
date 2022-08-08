using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    /// <summary>
    /// 生成EF配置代码，EntityTypeConfiguration
    /// </summary>
    public class EntityTypeConfigurationGen : MASAAuthGenBase
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                if (!item.NeedGenEntityTypeConfiguration())
                {
                    continue;
                }

                Model = item;

                NamespaceContainter(() =>
                {
                    WriteLine($"public class {ModelName}EntityTypeConfiguration : IEntityTypeConfiguration<{ModelName}>");
                    WriteLine("{");
                    WriteLine($" public void Configure(EntityTypeBuilder<{ModelName}> builder)");
                    WriteLine("{");


                    if (!string.IsNullOrEmpty(Model.EntityTypeConfiguration.KeyPropName))
                    {
                        WriteLine($"builder.HasKey(s => s.{Model.EntityTypeConfiguration.KeyPropName});");

                    }
                    foreach (var item in Model.EntityTypeConfiguration.IndexConfig)
                    {
                        WriteLine(item.ToString());
                    }

                    foreach (var item in Model.EntityTypeConfiguration.IgnorePropNames)
                    {
                        WriteLine($"builder.Ignore(x => x.{item});");
                    }

                    foreach (var item in Model.EntityTypeConfiguration.PropertyConfig)
                    {
                        WriteLine(item.ToString());
                    }

                    //foreach (var item in Model.EntityTypeConfiguration.RelationConfigs)
                    //{

                    //}
                    WriteLine("}"); // Configure接胡搜
                    WriteLine("}");// 类结束

                    WriteLine($"");
                    WriteLine($"");
                });

                SaveToFile();
            }
        }

        protected override void GenUsing()
        {

        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Infrastructure, Config.EntityConfigurations, Model.ModuleName);
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}EntityTypeConfiguration.cs";
        }
    }
}
