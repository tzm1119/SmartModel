using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartModel
{
    public partial class ListViewContent<TModel>
    {
        public IEnumerable<TModel> Items { get; set; }
    }
}
