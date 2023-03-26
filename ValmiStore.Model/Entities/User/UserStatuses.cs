namespace Webmall.Model.Entities.User
{
    public enum UserStatuses : long
    {
        Active = 0, // Обычное состояние
        WaitConfirmation = 1, // Ожидание подтверждения
        Blocked = 2, // Блокирован
        NoClients = 3, // Нет клиентов
    }
}
