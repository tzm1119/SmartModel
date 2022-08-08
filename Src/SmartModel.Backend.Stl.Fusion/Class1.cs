using Stl.CommandR;
using System.Reactive;

namespace SmartModel
{
    public record BaseCommand<TModel> : ICommand<Unit>
    {
        public BaseCommand(string opDesc, IReadOnlyList<TModel> models)
        {
            this.OpDesc = opDesc;
            this.Models = models;
        }

        public string OpDesc { get; set; }

        public IReadOnlyList<TModel> Models { get; set; }
    }

    public record AddCommand<TModel> : BaseCommand<TModel>
    {
        public AddCommand(string opDesc, IReadOnlyList<TModel> models) : base(opDesc, models)
        {

        }
    }

    public record DeleteCommand<TModel> : BaseCommand<TModel>
    {
        public DeleteCommand(string opDesc, IReadOnlyList<TModel> models) : base(opDesc, models)
        {

        }
    }

    public record UpdateCommand<TModel> : BaseCommand<TModel>
    {
        public UpdateCommand(string opDesc, IReadOnlyList<TModel> models) : base(opDesc, models)
        {

        }
    }
}