using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegGen : CmdGen 
    {
        //public class ServiceReg
        //{
        //    public static void RegistService(IServiceCollection services)
        //    {
        //        services.AddSingleton<IDepartmentService, DepartmentService>();
        //    }
        //}
        public override void GenCode()
        {
            NamespaceContainter(() =>
            {
                WriteLine("public class ServiceReg");
                WriteLine("{");
                WriteLine("public static void RegistService(IServiceCollection services)");
                WriteLine("{");
                foreach (var item in ModelList)
                {
                    WriteLine($" services.AddSingleton<{GetServiceInterfaceName(item.ModelName)}, {GetServiceName(item.ModelName)}>();");
                }
                WriteLine("}");
                WriteLine("}");
            });

            SaveToFile();
        }

        protected override void GenUsing()
        {
            WriteLine("using Microsoft.Extensions.DependencyInjection;");
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.BackendDir, Config.Batch);
        }

        protected override string GetCodeFileName()
        {
            return "ServiceReg.cs";
        }
    }
}
