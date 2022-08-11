namespace SmartModel
{
    /// <summary>
    /// Application Query 生成
    /// </summary>
    public class QueryGen : MASAAuthGenBase
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                NamespaceContainter(() =>
                {
                    if (Model.IsSupportGet)
                    {
                        WriteGetQuery();
                    }

                    if (Model.IsSupportDetail)
                    {
                        WriteDetailQuery();
                    }

                    if (Model.IsSupportSelect)
                    {
                        WriteSelectQuery();
                    }
                });

                SaveToFile();
            }
        }
        private void WriteDetailQuery()
        {
            WriteLine($"public {partial} record {Model.ModelDetailQueryName}({Model.DetailQueryDtoName} QueryDto) : Query<{Model.DetailDtoName}>");
            WriteLine("{");
            WriteLine($" public override {Model.DetailDtoName} Result {{ get; set; }} = new();");
            WriteLine("}");
        }
        private void WriteSelectQuery()
        {
            // TODO 目前还不支持Select 查询参数
            //var otherProps = GetJoinPropNames(PropertyExistType.GetDto);

            WriteLine($"public {partial} record {Model.ModelSelectQueryName}({Model.SelectQueryDtoName} QueryDto) : Query<List<{Model.SelectDtoName}>>");
            WriteLine("{");
            WriteLine($"public override List<{Model.SelectDtoName}> Result {{ get; set; }} = new();");
            WriteLine("}");
        }

       
       
        private void WriteGetQuery()
        {
            WriteLine($"public {partial} record {Model.ModelQueryName}({Model.GetDtoName} QueryDto) : Query<PaginationDto<{Model.GetDtoClassName()}>>");
            WriteLine("{");
            WriteLine($"public override PaginationDto<{Model.GetDtoClassName()}> Result {{ get; set; }} = new();");
            WriteLine("}");
        }

        protected override void GenUsing()
        {
           
        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.ServicesDir, Config.Application, Model.ModuleName, "Queries");
        }

        protected override string GetCodeFileName()
        {
            return $"{ModelName}.Query.cs";
        }
    }
}
