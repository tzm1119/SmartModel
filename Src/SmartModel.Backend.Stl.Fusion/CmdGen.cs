using static SmartModel.Keyword;

namespace SmartModel
{
    /// <summary>
    /// 生成命令对象,包含命令和对应的验证器
    /// </summary>
    public class CmdGen : GenBase
    {
     
        

        private void WriteAdd()
        {
            WriteCmd(AddCmdName, AddBaseCmd);
        }

        private void WriteUpdate()
        {
            WriteCmd(UpdateCmdName, UpdateBaseCmd);
        }

        private void WriteDelete()
        {
            WriteCmd(DeleteCmdName, DeleteBaseCmd);


        }

      

        private void WriteValidator(string cmdName)
        {
            var validatorName = $"{cmdName}{ValidatorSuffix}";
            WriteLine($"public {partial} class {validatorName} : AbstractValidator<{cmdName}>");
            WriteLine("{");
            WriteLine("partial void RuleCore();");
            WriteLine($"public {validatorName}()");
            WriteLine("{");
            WriteLine("RuleCore();");
            WriteLine("RuleFor(x => x.Models).NotEmpty();");
            WriteLine("RuleForEach(x => x.Models).InjectValidator();");
            WriteLine("}");
            WriteLine("}");
        }

        private void WriteCmd(string cmdName, string cmdBaseName)
        {
            if (Model == null)
            {
                return;
            }

            WriteLine($"public record {cmdName} : {cmdBaseName}<{ModelName}>");
            WriteLine("{");

            // 考虑树形结构级联删除问题,级联删除统一在Repo中处理，无需前端处理
            //var models = Model.IsTreeModel ? "TreeToList(models)" : "models";
            var models = "models";
            WriteLine($"public {cmdName}(string opDesc,IReadOnlyList<{ModelName}> models) : base(opDesc,{models})");
            WriteLine("{");
            WriteLine("}");
            WriteLine("}");

            WriteValidator(cmdName);
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.BackendDir, Config.CmdDirecotryName);
        }

        protected override void GenUsing()
        {
            WriteLine("using FluentValidation;");
            //WriteLine("using static FuSa.Domain.FHelper;");
        }

        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;
                NamespaceContainter(() =>
                {
                    InitName();
                    WriteAdd();
                    WriteDelete();
                    WriteUpdate();
                });

                SaveToFile();
            }
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}.Cmd.cs";
        }
    }
}
