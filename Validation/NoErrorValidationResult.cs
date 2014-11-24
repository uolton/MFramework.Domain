using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFramework.Domain.Validation
{
    class NoErrorValidationResult:IValidateResult
    {
        private readonly IList<IValidateFailure> emptyErrorList = new List<IValidateFailure>();
        public IList<IValidateFailure> Errors
        {
            get { return emptyErrorList; }
        }

        public bool IsValid
        {
            get { return true; }
        }
    }
}
