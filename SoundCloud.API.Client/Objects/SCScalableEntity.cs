using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects
{
    public class SCScalableEntity<TEnum> where TEnum : struct
    {
        private readonly string format;

        private SCScalableEntity(string format)
        {
            this.format = format.Replace("large", "{0}");
        }

        public string Url(TEnum value = default (TEnum))
        {
            return string.Format(format, value.GetParameterName());
        }

        internal static SCScalableEntity<TEnum> Create(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return null;
            }

            return new SCScalableEntity<TEnum>(format);
        }
    }
}