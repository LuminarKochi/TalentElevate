//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TalentElevate
{
    using System;
    using System.Collections.Generic;
    
    public partial class jobs_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public jobs_tb()
        {
            this.apply_tb = new HashSet<apply_tb>();
        }
    
        public int job_id { get; set; }
        public int company_id { get; set; }
        public string job_title { get; set; }
        public string job_description { get; set; }
        public string job_type { get; set; }
        public int vacancy { get; set; }
        public int salary { get; set; }
        public string skillset { get; set; }
        public int experiance { get; set; }
        public string location { get; set; }
        public string status { get; set; }
        public System.DateTime last_date { get; set; }
    
        public virtual company_reg_tb company_reg_tb { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<apply_tb> apply_tb { get; set; }
    }
}
