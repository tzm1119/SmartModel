using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    public abstract class MASAAuthGenBase: GenBase
    {
        public MASAAuthGenBase()
        {
            this.Namespace = "Masa.Auth";
        }

        public IEnumerable<PropertyDef> GetDomainModelProperty()
        {
            return Model.PropertyDefs.Where(p => 
            p.PropertyExistType == PropertyExistType.DomainModel || 
            p.PropertyExistType== PropertyExistType.BothDto_DomainModel);
        }

        public IEnumerable<PropertyDef> GetDtoProperty()
        {
            return Model.PropertyDefs.Where(p =>
            p.PropertyExistType == PropertyExistType.Dto ||
            p.PropertyExistType == PropertyExistType.BothDto_DomainModel);
        }
    }
}
