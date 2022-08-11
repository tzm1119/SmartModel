using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    /// <summary>
    /// 生成Repository 接口定义
    /// </summary>
    public class RepositoryInterfaceGen : AggregateGen
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                // 没有指定基类，说明不需要生成
                if (string.IsNullOrEmpty(item.RepositoryBaseInterface))
                {
                    continue;
                }

                Model = item;

                NamespaceContainter(() =>
                {
                    WriteLine($"public {partial} interface {Model.RepositoryInterfaceName} :{Model.RepositoryBaseInterface}");
                    WriteLine("{");

                    WriteLine("}");
                });

                SaveToFile();
            }
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Domain, Model.ModuleName, Config.Repositories);
        }
        protected override string GetCodeFileName()
        {
            return $"{Model.RepositoryInterfaceName}.cs";
        }
    }

    /// <summary>
    /// 生成 Repository的实现
    /// </summary>
    public class RepositoryImplGen : AggregateGen
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                // 没有指定基类，说明不需要生成
                if (string.IsNullOrEmpty(item.RepositoryBaseInterface))
                {
                    continue;
                }

                Model = item;

                NamespaceContainter(() =>
                {
                    var repoName = Model.RepositoryName;
                    var tKey = "";
                    if (!string.IsNullOrEmpty(Model.TKey))
                    {
                        tKey = $",{Model.TKey}";
                    }

                    WriteLine($"public {partial} class {repoName} : Repository<AuthDbContext, {ModelName} {tKey}>, {Model.RepositoryInterfaceName}");
                    WriteLine("{");
                    WriteLine($"public {repoName}(AuthDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)");
                    WriteLine("{");
                    WriteLine("}");// 构造结束
                    WriteLine("}");// 类结束
                });

                SaveToFile();
            }
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Infrastructure, Config.Repositories);
        }

        protected override string GetCodeFileName()
        {
            return $"{Model.RepositoryName}.cs";
        }
    }
}
