using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    public class EditFormGen : GenBase
    {
        protected override string GetCodeFileName()
        {
            if (Model == null)
            {
                return "";
            }
            return Model.GetRazorEditFormFileName();
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

        private void WritePropertyEditor(PropertyDef def)
        {
            var pName = def.PropertyName;
            var bindValue = $"@bind-Value=Model.{pName}";
            var label = $"Label=\"{pName}\"";
            var Class = "Class=mb-6";
            var Outlined = "Outlined";
            var headDetails = "HideDetails=\"@(\"auto\")\"";
            switch (def.EditorType.Type)
            {
                case PropertyEditorType.TextInput:
                    WriteLine($"<MTextField {bindValue} {label} {Class} {Outlined} {headDetails} />");
                    break;
                case PropertyEditorType.Textarea:
                    WriteLine($"<MTextarea {bindValue} {label} {Class} {Outlined}  Rows=\"3\" RowHeight=\"15\"></MTextarea>");
                    break;
                case PropertyEditorType.RichText:
                    break;
                case PropertyEditorType.SingleSelect:
                case PropertyEditorType.MultiSelect:
                    // 是否多选
                    var Multiple = "";
                    if (def.EditorType.Type == PropertyEditorType.MultiSelect)
                    {
                        Multiple = "Multiple";
                    }

                    // 普通枚举类型下拉框
                    var itemsDef = "";
                    if (def.RefType == PropertyRefType.None)
                    {
                        itemsDef = $"Items=@(GetEnumItems<{def.CSharpType}>())";
                    }
                    // 引用类型下拉框
                    else
                    {
                        var refModelType = def.GetRefModelType();
                        itemsDef = $"Items=@All{refModelType}";
                    }
                    WriteLine($"<MSelect {Multiple} {bindValue} {itemsDef} ItemValue=@(x=> x.Id) ItemText=@(x=>x.Name) {Class} {label}  {Outlined} {headDetails}/>");
                    break;
                case PropertyEditorType.Switch:
                    WriteLine($"<MSwitch {bindValue} {label}></MSwitch>");
                    break;
                case PropertyEditorType.DateOnlyPicker:
                    WriteLine($"<MenuDateOnlyPicker {bindValue} {label}></MenuDateOnlyPicker>");
                    break;
                case PropertyEditorType.CheckboxList:
                    break;
                default:
                    break;
            }

        }
        private void WriteCodeCore()
        {
            WriteLine("@using static SmartModel.FHepler");
            WriteLine("@namespace SmartModel");
            WriteLine("<MNavigationDrawer Temporary Fixed Right Value=Visible ValueChanged=VisibleChanged Width=\"465\" Class=\"pa-6\">");
            WriteLine("<div class=\"block-between mb-12\">");
            WriteLine("<span class=\"text-h6\">@FormTitle()</span>");
            WriteLine("<MIcon Color=\"neutral-lighten-3\" Size=24 OnClick=\"()=>Visible = false\">mdi-close</MIcon>");
            WriteLine("</div>");
            WriteLine(" <MForm Model=Model EnableDataAnnotationsValidation>");
            foreach (var item in Model.GetFormDisplayProperty())
            {
                WritePropertyEditor(item);
            }

            WriteLine("<div style=\"bottom: 48px; right: 24px; position: absolute\">");
            WriteLine("<MButton MinWidth=80 Height=40 Outlined Class=\"text-btn rounded-pill\" OnClick=\"async () => await UpdateVisible(false)\"> 取消 </MButton>");
            WriteLine("<MButton MinWidth=80 Height=40 Color=\"primary\" Class=\"ml-6 rounded-pill\" OnClick=\"async () => await AddData(context)\"> 保存 </MButton>");
            WriteLine("</div>");
            WriteLine("</MForm>");
            WriteLine("</MNavigationDrawer>");

            WriteLine("@code {");
            WriteParameter(true, ModelName, "Model");
            WriteBindingParameter("bool", "Visible");
            WriteParameter(false, $"EventCallback<{ModelName}>", "Submit");
            WriteParameter(false, "FormEditType", "EditType");

            WriteLine("private string FormTitle()");
            WriteLine("{");
            WriteLine(" switch (EditType)");
            WriteLine("{");
            WriteLine("case FormEditType.Add:");
            WriteLine("return \"新建\";");
            WriteLine("case FormEditType.Edit:");
            WriteLine("return \"编辑\";");
            WriteLine("default:");
            WriteLine("return \"未定义\";");
            WriteLine("}");// switch结束
            WriteLine("}");// FormTitle方法结束

            WriteLine("private async Task UpdateVisible(bool visible)");
            WriteLine("{");

            WriteLine("if (VisibleChanged.HasDelegate)");
            WriteLine("{");
            WriteLine("await VisibleChanged.InvokeAsync(visible);");
            WriteLine("}");
            WriteLine("else");
            WriteLine("{");
            WriteLine("Visible = visible;");
            WriteLine("}");

            WriteLine("}");//UpdateVisible结束

            WriteLine("private async Task AddData(EditContext context)");
            WriteLine("{");
            WriteLine("if (context.Validate())");
            WriteLine("{");
            WriteLine("if (Submit.HasDelegate) await Submit.InvokeAsync(Model);");
            WriteLine(" await UpdateVisible(false);");
            WriteLine("}");
            WriteLine("}");//AddData结束
            WriteLine("");
            WriteLine("}");//code结束
        }

        protected override void GenUsing()
        {

        }


        protected override string GetCodeDirectoryPath()
        {
            return Path.Combine(Config.FrontendDir, ModelName);
        }
    }
}
