namespace SoundCloud.API.Client.Internal.Validation
{
    internal interface IPaginationValidator
    {
        bool IsValid(int offset, int count, out string errorMessage);
    }
}