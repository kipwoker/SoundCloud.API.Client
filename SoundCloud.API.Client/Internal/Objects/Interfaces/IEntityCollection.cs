namespace SoundCloud.API.Client.Internal.Objects.Interfaces
{
    internal interface IEntityCollection<TEntity>
    {
        TEntity[] Collection { get; set; }
    }
}