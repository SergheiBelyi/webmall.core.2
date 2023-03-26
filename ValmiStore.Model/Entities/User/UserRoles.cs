namespace Webmall.Model.Entities.User
{
    public enum UserRoles : long
    {
        Admin = 0x0001, // Администратор системы безопасности
        VINRequestManager = 0x0002, // Менеджер по запросам
        //CatalogManager = 4, // Менеджер каталогу
        RepresentativeManager = 0x0008, // Менеджер по сотрудникам
        //CallManager = 0x0010,   // Менеджер по общим вопросам
        ContentManager = 0x0020,   // Менеджер по CMS
        Statistic = 0x0040, // Статистика
        EventManager = 0x0080, // Менеджер мероприятий
        LoyaltyUser = 0x0100, // Доступ к программе лояльности
    }
}
