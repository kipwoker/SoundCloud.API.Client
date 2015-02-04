namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal interface IActivity<out T>
    {
         T Origin { get; }
    }
}