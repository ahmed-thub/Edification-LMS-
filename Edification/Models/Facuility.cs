using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class Facuility
    {
        public Facuility()
        {
            CoursesToFacuilities = new HashSet<CoursesToFacuility>();
        }

        public int FacuilityId { get; set; }
        public string? FacuilityName { get; set; }
        public string? FacuilityEmail { get; set; }

        public virtual ICollection<CoursesToFacuility> CoursesToFacuilities { get; set; }
    }
}
