using System.ComponentModel.DataAnnotations.Schema;

namespace Domain_DataBase.Domain_Entity
{
    [Table("Person")]
    public class Person : Base_Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PersonImageURL { get; set; } = string.Empty;
    }
}
