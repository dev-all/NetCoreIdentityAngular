using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace allshop.Toold

{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        /// <summary>
        /// ejemplo de implementacion
        ///   [ValidEmailDomain(allowedDomain: "gna.gob.ar",
        // ErrorMessage = "Email domain must be gna.gob.ar")]
        /// </summary>



        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            string[] strings = value.ToString().Split('@');
            return strings[1].ToUpper() == allowedDomain.ToUpper();
        }
    }
}
