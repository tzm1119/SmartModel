using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    public class CommandGen : MASAAuthGenBase
    {
        public override void GenCode()
        {
            foreach (var item in ModelList)
            {
                if (item.DoNotGenDto)
                {
                    continue;
                }

                Model = item;

                NamespaceContainter(() =>
                {
                    WriteLine("{");
                    WriteLine("}");
                });

                SaveToFile();
            }
        }

        protected override void GenUsing()
        {
            throw new NotImplementedException();
        }

        protected override string GetCodeDirectoryPath()
        {
            throw new NotImplementedException();
        }

        protected override string GetCodeFileName()
        {
            throw new NotImplementedException();
        }
    }
}
