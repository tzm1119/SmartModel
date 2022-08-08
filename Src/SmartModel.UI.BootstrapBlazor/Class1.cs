using Microsoft.AspNetCore.Components;

namespace SmartModel
{
    public class TableViewController : IListViewController
    {
        public IListViewContext Context => throw new NotImplementedException();

        public IListViewToolBar ToolBar => throw new NotImplementedException();

        public IListViewContent Content => throw new NotImplementedException();
    }

    public class TableContext: IListViewContext
    {

    }
}