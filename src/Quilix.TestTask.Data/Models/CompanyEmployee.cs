namespace Quilix.TestTask.Data.Models
{
    // UNDONE: Заложен функционал для связи многие ко многим
    // Для того, чтобы сотрудник мог работать сразу в нескольких организациях

    public class CompanyEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
    }
}
