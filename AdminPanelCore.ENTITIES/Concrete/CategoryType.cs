using CORE.Entities.Abstarct;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCore.ENTITIES.Concrete
{
    public class CategoryType : IBaseEntity
    {
        public CategoryType()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string CategoryTypeName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}