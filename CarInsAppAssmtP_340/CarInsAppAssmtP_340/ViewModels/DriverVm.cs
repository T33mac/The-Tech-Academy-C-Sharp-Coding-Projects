using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsAppAssmtP_340.ViewModels
{
    public class DriverVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int? Quote { get; internal set; }
    }
}