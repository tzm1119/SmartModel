using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    public class CommandGen : DtoGen
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                NamespaceContainter(() =>
                {
                    if (Model.IsSupportAdd)
                    {
                        WriteAddCommand();
                    }

                    if (Model.IsSupportRemove)
                    {
                        WriteRemoveCommand();
                    }

                    if (Model.IsSupportUpdate || Model.IsPartialUpdate)
                    {
                        WriteUpdateCommand();
                    }

                    if (Model.IsSupportUpsert)
                    {
                        WriteUpsertCommand();
                    }

                    if (Model.IsSupportCopy)
                    {
                        WriteCopyCommand();
                    }
                });

                SaveToFile();
            }
        }

        private void WriteCopyCommand()
        {
            WriteLine($"public {partial} record {Model.CopyCommandName}({Model.CopyDtoName} {ModelName}) : Command");
            WriteLine("{");
            WriteLine("}");
        }
        private void WriteAddCommand()
        {
            WriteLine($"public {partial} record {Model.AddCommandName}({Model.AddDtoName} {ModelName}) : Command");
            WriteLine("{");
            WriteLine("}");
        }

        private void WriteRemoveCommand()
        {
            WriteLine($"public {partial} record {Model.RemoveCommandName}({Model.RemoveDtoName} {ModelName}) : Command");
            WriteLine("{");
            WriteLine("}");
        }

        private void WriteUpdateCommand()
        {
            WriteLine($"public {partial} record {Model.UpdateCommandName}({Model.UpdateDtoName} {ModelName}) : Command");
            WriteLine("{");
            WriteLine("}");
        }

        private void WriteUpsertCommand()
        {
            //public class UpsertDepartmentDto : BaseUpsertDto<Guid>
            WriteLine($"public {partial} record {Model.UpserCommandName}({Model.UpsertDtoName} {ModelName}) : Command");
            WriteLine("{");
            WriteLine("}");
        }


        protected override void GenUsing()
        {

        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Application, Model.ModuleName, "Commands");
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}.Command.cs";
        }
    }
}
