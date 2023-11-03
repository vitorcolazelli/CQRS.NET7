using CQRS.Core.Commands;

namespace Post.CMD.Api.Commands
{
    public class EditPostCommand : BaseCommand
    {
        public string Message { get; set; }
    }
}
