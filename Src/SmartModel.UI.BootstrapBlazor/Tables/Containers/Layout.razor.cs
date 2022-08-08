using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartModel
{
    public partial class Layout
    {
        public RenderFragment? Header { get; set; }
        public RenderFragment? Side { get; set; }
        public RenderFragment? Body { get; set; }
        public RenderFragment? Footer { get; set; }

    }
}
