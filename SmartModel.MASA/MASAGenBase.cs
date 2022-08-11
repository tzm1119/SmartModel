using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    public abstract class MASAAuthGenBase : GenBase
    {
        public MASAAuthGenBase()
        {
            this.Namespace = "Masa.AuthGen";
        }

        public IEnumerable<PropertyDef> GetDomainModelProperty()
        {
            return Model.PropertyDefs.Where(p =>
            p.CheckExistIn(PropertyExistType.DomainModel));
        }

        public IEnumerable<PropertyDef> GetDtoProperty()
        {
            return Model.PropertyDefs.Where(p =>
            p.CheckExistIn(PropertyExistType.Dto));
        }

        /// <summary>
        /// 获取指定的属性，并使用逗号进行 连接
        /// </summary>
        /// <param name="existType"></param>
        /// <returns></returns>
        public string GetJoinPropNames(PropertyExistType existType)
        {
            var props = Model.GetPropertyDefs(existType);
            var otherProps = "";
            if (props.Any())
            {
                var joinProps = string.Join(",", props.Select(p => $"{p.CSharpType} {p.PropertyName}"));
                otherProps = $",{joinProps}";
            }
            return otherProps;
        }
    }
}
