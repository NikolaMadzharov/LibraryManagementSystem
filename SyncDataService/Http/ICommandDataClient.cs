using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.SyncDataService.Http
{
    public interface ICommandDataClient
    {
        Task SendBookToCommand(BookReadDto book);
    }
}
