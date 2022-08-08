using static SmartModel.TypeNameConst;
using static SmartModel.PropertyDef;
using static SmartModel.PropertyNameConst;
using static SmartModel.LanguageDef;
using static SmartModel.ValidationRule;
using static SmartModel.EnumItemDef;
using static SmartModel.EnumTypeNameConst;


namespace SmartModel
{
    /// <summary>
    ///  Table表格cs代码
    /// </summary>
    public class TableCSGen : GenBase
    {
        protected override string GetCodeFileName()
        {
            if (Model == null)
            {
                return "";
            }
            return Model.GetRazorTableCSFileName();
        }

        public string GetPageRoute()
        {
            return $"app/{ModelName}";
        }

        private string ServicePropName = "Service";
        private void WriteCodeCore()
        {
            WriteLine($"[Route(\"{GetPageRoute()}\")]");
            WriteLine($"public partial class {ModelName}Table");
            WriteLine("{");

            WriteInjectService(GetServiceInterfaceName(ModelName), ServicePropName);

            WriteLine($"private readonly List<DataTableHeader<{ModelName}>> _headers = new()");
            WriteLine("{");

            // 表格中显示的属性
            foreach (var prop in Model.GetTableDisplayProperty())
            {
                WriteLine($"new() {{ Text = \"{prop.PropertyName}\", Value = nameof({ModelName}.{prop.PropertyName}) }},");
            }


            WriteLine($" new() {{ Text = \"操作\", Value = \"Action\", Sortable = false }},");
            WriteLine("};");//_headers结束

            WriteLine("private bool editFormVisible;");
            WriteLine($"private List<{ModelName}> Items {{ get; set; }} = new();");
            WriteLine($"public {ModelName} SelectModel {{ get; set; }}  = new();");

            WriteLine("protected override async Task OnInitializedAsync()");
            WriteLine("{");
            WriteLine(" var compose = await Service.GetCompose();");
            WriteLine($"Items = compose.All{ModelName}.ToList();");
            WriteLine("await base.OnInitializedAsync();");
            WriteLine("}");

            WriteLine("//点击创建按钮");
            WriteLine("private  Task OnClickAdd()");
            WriteLine("{");
            WriteLine("EditType = FormEditType.Add;");
            WriteLine($"SelectModel = new {ModelName}");
            WriteLine("{");
            WriteLine("Id = Guid.NewGuid().ToString(),");

            WriteLine("};");
            WriteLine("editFormVisible = true;");

            WriteLine("return Task.CompletedTask;");
            WriteLine("}");//OnClickAdd结束



            WriteLine("private FormEditType EditType { get; set; }");
            WriteLine("//点击编辑");
            WriteLine($"private Task OnClickEdit(ItemColProps<{ModelName}> context)");
            WriteLine("{");
            WriteLine("EditType = FormEditType.Edit;");
            WriteLine($"this.SelectModel = ({ModelName})context.Item.Clone();");
            WriteLine("editFormVisible = true;");
            //WriteLine("_= InvokeAsync(StateHasChanged);");
            WriteLine("return Task.CompletedTask;");

            WriteLine("}");//OnClickEdit结束

            WriteLine("//点击删除");
            WriteLine($"private async Task OnClickDelete(ItemColProps<{ModelName}> context)");
            WriteLine("{");
            WriteLine(" var model = context.Item;");
            WriteLine($"await Service.Delete(new {DeleteCmdName}(string.Empty, new {ModelName}[] {{ model }}));");

            WriteLine("}");//OnClickDelete结束
            WriteLine("// 保存");
            WriteLine($"private async Task OnSubmit({ModelName} model)");
            WriteLine("{");
            WriteLine(" if (EditType == FormEditType.Add)");
            WriteLine("{");
            WriteLine($"  await Service.Add(new {AddCmdName}(string.Empty, new {ModelName}[] {{ model }}));");
            WriteLine("}");
            WriteLine("else");
            WriteLine("{");
            WriteLine($" await Service.Update(new {UpdateCmdName}(string.Empty, new {ModelName}[] {{ model }}));");
            WriteLine("}");

            WriteLine("_= InvokeAsync(StateHasChanged);");
            WriteLine("}");//OnSubmit结束

            WriteLine("}");// 类结束
        }
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                if (Model.DoNotGenFrontTableAndEditForm)
                {
                    continue;
                }

                NamespaceContainter(() =>
                {
                    WriteCodeCore();
                });

                SaveToFile();
            }
        }
        protected override void GenUsing()
        {

        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.FrontendDir, ModelName);
        }
    }

    /// <summary>
    /// TableRazor页面代码
    /// </summary>
    public class TableRazorGen : GenBase
    {
        protected override string GetCodeFileName()
        {
            if (Model == null)
            {
                return "";
            }
            return Model.GetRazorTableFileName();
        }

        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                Model = item;

                if (Model.DoNotGenFrontTableAndEditForm)
                {
                    continue;
                }

                WriteCodeCore();

                SaveToFile();
            }
        }

        private void WriteCodeCore()
        {
            WriteLine("@using static SmartModel.FHepler");
            WriteLine("@namespace SmartModel");

            // 工具栏
            WriteLine("<MCard>");
            WriteLine(" <MToolbar Dense Elevation=\"0\" Class=\"rounded-2\" Height=\"60\">");
            WriteLine("<MButton Color=\"primary\" MinWidth=80 Height=32 Class=\"ml-6 rounded-pill\" OnClick=\"OnClickAdd\">创建</MButton>");
            WriteLine(" </MToolbar>");
            WriteLine("</MCard>");

            // 表格
            WriteLine(" <MCard Class=\"mt-6\">");
            WriteLine($" <MDataTable Headers=\"_headers\" Items=\"Items\" TItem=\"{ModelName}\" HideDefaultFooter Class=\"ml-2 table-border-none\">");
            WriteLine(" <HeaderColContent Context=\"header\">");
            WriteLine(" <span class=\"text-subtitle\">@header.Text</span>");
            WriteLine("</HeaderColContent>");
            WriteLine("<ItemColContent>");
            WriteLine("@switch (context.Header.Value)");
            WriteLine("{");
            foreach (var prop in Model.GetTableDisplayProperty())
            {
                WriteLine($"case nameof({ModelName}.{prop.PropertyName}):");
                WriteLine($"<span>@context.Item.{prop.PropertyName}</span>");
                WriteLine(" break;");
            }
            WriteLine("case \"Action\":");
            WriteLine("<TableActionMenu OnClickDelete=@(()=>OnClickDelete(context)) OnClickEdit=@(()=>OnClickEdit(context)) ></TableActionMenu>");
            WriteLine(" break;");
            WriteLine("default:");
            WriteLine("@context.Value");
            WriteLine("break;");
            WriteLine("}");//switch结束

            WriteLine("</ItemColContent>");
            WriteLine("</MDataTable>");
            WriteLine("</MCard>");

            var formName = $"{ModelName}Form";
            WriteLine($"<{formName} EditType=@EditType Model=SelectModel @bind-Visible=editFormVisible Submit=\"OnSubmit\"></{formName}>");
            WriteLine("");
            WriteLine("");
            WriteLine("");
            WriteLine("");
            WriteLine("");
            WriteLine("");
            WriteLine("");
            WriteLine("");
            WriteLine("");
        }

        protected override void GenUsing()
        {

        }

        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.FrontendDir, ModelName);
        }
    }

    public class FormEditTypeEnumDef : EnumDef
    {
        public FormEditTypeEnumDef()
        {
            this.EnumName = FormEditType;
            this.AddItem(NewEnumItem("None", 0));
            this.AddItem(NewEnumItem("Add", 1));
            this.AddItem(NewEnumItem("Edit", 2));
        }
    }
}
