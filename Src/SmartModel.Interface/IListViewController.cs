using Microsoft.AspNetCore.Components;

namespace SmartModel
{
    /// <summary>
    /// 作为一个列表页面的统一暴露接口
    /// </summary>
    public interface IListViewController
    {
        IListViewContext Context { get; }
        IListViewToolBar ToolBar { get; }
        IListViewContent Content { get; }
    }

    /// <summary>
    /// 页面数据上下文
    /// </summary>
    public interface IListViewContext
    {

    }

    /// <summary>
    /// 列表页面的工具栏
    /// </summary>
    public interface IListViewToolBar
    {
        RenderFragment GetTemplate(IListViewContext context);
    }

    /// <summary>
    /// 列表内容
    /// </summary>
    public interface IListViewContent
    {
        RenderFragment GetTemplate(IListViewContext context);
    }

    public interface ICloneable<T>
    {
        T Clone();
    }
}