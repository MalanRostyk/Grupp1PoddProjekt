using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using CCData_Access_Layer;

namespace BBBusiness_Layer
{
    public static class FeedValidator
    {
        public static ValidationResult ValidateName(string newName)
        {
            var result = new ValidationResult();
            if (string.IsNullOrWhiteSpace(newName))
            {
                result.Errors.Add("Name cannot be empty.");
            }
            return result;
        }

    }
}
