using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class GroupConverter : IGroupConverter
    {
        internal static readonly IGroupConverter Default = new GroupConverter();

        public SCGroup Convert(Group @group)
        {
            if (@group == null)
            {
                return null;
            }

            return new SCGroup();
        }

        public Group Convert(SCGroup @group)
        {
            if (@group == null)
            {
                return null;
            }

            return new Group();
        }
    }
}