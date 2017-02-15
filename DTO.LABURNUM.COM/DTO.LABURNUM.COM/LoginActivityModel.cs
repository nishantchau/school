using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class LoginActivityModel
    {
        public LoginActivityModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long LoginActivityId { get; set; }
        public long StudentId { get; set; }
        public System.DateTime LoginAt { get; set; }
        public Nullable<System.DateTime> LogoutAt { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
    }
}
