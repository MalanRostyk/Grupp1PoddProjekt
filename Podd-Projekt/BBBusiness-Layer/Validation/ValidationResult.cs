using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
    public class ValidationResult
    {
        public List<string> Errors { get; } = new();
        public bool IsValid => Errors.Count == 0;
        public string GetErrorString()
        {
            string errorString = "";
            foreach (string e in Errors)
                errorString += $" {e}";
            return errorString;
        }
    }
}