using CORE.Entities.Abstarct;

namespace CORE.Entities.Concrete
{
    public class DtoEntity : IDto
    {
        public string CreatedUserFullName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedUserFullName { get; set; }
        public string ModifiedDate { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }
    }
}