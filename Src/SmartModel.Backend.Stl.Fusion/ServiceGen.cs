using static SmartModel.Keyword;

namespace SmartModel
{
    public class ServiceGen : CmdGen
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;
                NamespaceContainter(() =>
                {
                    InitName();

                    WriteInterfaceDef();

                    WriteServiceImpl();
                });

                SaveToFile();
            }
        }

        private void WriteInterfaceDef()
        {
            //    public interface IDepartmentService
            //: IHasCreate<Department>,
            // IHasUpdate<Department>,
            // IHasDelete<Department>,
            // IHasCompose<Department>
            //{

            //}
            WriteLine($"public {partial} interface {GetServiceInterfaceName(ModelName)} : IHasCreate<{AddCmdName}>,");
            WriteLine($"IHasUpdate<{UpdateCmdName}>,");
            WriteLine($"IHasDelete<{DeleteCmdName}>,");
            WriteLine($"IHasCompose<{DefalutComposeModelName}>");
            WriteLine("{}");
        }

        private void WriteServiceImpl()
        {
            WriteComposeModel();

            WriteLine($"public partial class {GetServiceName(ModelName)} : {GetServiceInterfaceName(ModelName)}");
            WriteLine("{");
            WriteLine($"List<{ModelName}> store = new ();");
            WriteLine("");
      

            #region Add

            WriteLine($"public Task Add({AddCmdName} command, CancellationToken cancellationToken = default)");
            WriteLine("{");
            WriteLine($" store.AddRange(command.Models);");
            WriteLine($" return Task.CompletedTask;");
            WriteLine($"");
            WriteLine("}");

            #endregion

            #region Delete



            WriteLine($" public Task Delete({DeleteCmdName} command, CancellationToken cancellationToken = default)");
            WriteLine("{");
            WriteLine($" foreach (var item in command.Models)");
            WriteLine("{");
            WriteLine($" store.Remove(item);");
            WriteLine($"");
            WriteLine("}");//foreach结束
            WriteLine($" return Task.CompletedTask;");
            WriteLine("}");

            #endregion

            #region GetCompose

            WriteLine($"public Task<{DefalutComposeModelName}> GetCompose(CancellationToken cancellationToken = default)");
            WriteLine("{");
            WriteLine($"return Task.FromResult(new {DefalutComposeModelName} {{ All{ModelName} = store }});");
            WriteLine("}");

            #endregion

            #region Update

            WriteLine($"public Task Update({UpdateCmdName} command, CancellationToken cancellationToken = default)");
            WriteLine("{");

            WriteLine($"foreach (var item in command.Models)");
            WriteLine("{");

            WriteLine($" var idx = store.IndexOf(item);");
            WriteLine($"if (idx != -1)");
            WriteLine("{");
            WriteLine($" store[idx] = item;");
            WriteLine("}");//if结束

            WriteLine("}");//foreach结束
            WriteLine(" return Task.CompletedTask;");
            WriteLine("}");
            #endregion

            WriteLine("}");// Service 类结束

            //WriteLine($"");
            //WriteLine($"");
            //WriteLine($"");
        }

        //public partial class DepartmentService : IDepartmentService
        //{
        //    List<Department> store = new List<Department>();

        //    public Task Add(AddDepartmentCommand command, CancellationToken cancellationToken = default)
        //    {
        //        store.AddRange(command.Models);
        //        return Task.CompletedTask;
        //    }

        //    public Task Delete(DeleteDepartmentCommand command, CancellationToken cancellationToken = default)
        //    {
        //        foreach (var item in command.Models)
        //        {
        //            store.Remove(item);
        //        }
        //        return Task.CompletedTask;
        //    }

        //    public Task<DepartmentCompose> GetCompose(CancellationToken cancellationToken = default)
        //    {
        //        return Task.FromResult(new DepartmentCompose { AllDepartment = store });
        //    }

        //    public Task Update(UpdateDepartmentCommand command, CancellationToken cancellationToken = default)
        //    {
        //        foreach (var item in command.Models)
        //        {
        //            var idx = store.IndexOf(item);
        //            if (idx != -1)
        //            {
        //                store[idx] = item;
        //            }
        //        }
        //        return Task.CompletedTask;
        //    }
        //}

        private void WriteComposeModel()
        {
            WriteLine($"public partial class {DefalutComposeModelName}");
            WriteLine("{");
            WriteLine($"public IReadOnlyList<{ModelName}> All{ModelName} {{ get; set; }} = new {ModelName}[0];");
            WriteLine("");
            WriteLine("}");
            WriteLine($"");
            WriteLine($"");
      
    }
        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.BackendDir, Config.ServiceDirecotryName);
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}.Svc.cs";
        }
    }
}
