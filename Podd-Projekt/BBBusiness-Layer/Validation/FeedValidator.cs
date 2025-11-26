using CCData_Access_Layer;
using DDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BBBusiness_Layer.Validation
{
    public static class FeedValidator
    {
        public static ValidationResult ValidateTextBox(string aString)
        {
            var result = new ValidationResult();
            if (string.IsNullOrWhiteSpace(aString))
            {
                result.Errors.Add("Field cannot be empty.");
            }
            return result;
        }
        public static ValidationResult ValidateRssLink(string rssLink)
        {
            var result = new ValidationResult();
            if (string.IsNullOrWhiteSpace(rssLink))
            {
                result.Errors.Add("Link cannot be empty.");
            }
            return result;
        }


        public static ValidationResult ValidateList(List<Pod> rssFeed)
        {
            var result = new ValidationResult();
            if(rssFeed.Count == 0 || rssFeed == null)
            {
                result.Errors.Add("This link returned no results");
            }
            return result;
        }

        public static ValidationResult ValidateDuplicateNames(List<PodFeed> pfLista, string name)
        {
            var result = new ValidationResult();
            var query = from pf in pfLista
                        where pf.Name == name
                        select pf;
            if (query.Any())
            {
                result.Errors.Add($"There is already a document with the property Name = {name}");
            }
            return result;

        }

        public static ValidationResult ValidateLink(string link)
        {
            
            var result = new ValidationResult();
            string reg = @"^https?:\/\/[A-ZÅÄÖa-zåäö0-9.-]+\.[A-ZÅÄÖa-zåäö]{2,}.*$";
            Regex regex = new Regex(reg);
            //Regex regex = new Regex("^https?:\\/\\/[A-ZÅÄÖa-zåäö0-9\\-]+\\.[A-ZÅÄÖa-zåäö]{2,}(\\/\\S*)?$");
            if (!regex.IsMatch(link)) 
            {
                result.Errors.Add($"This link is not a valid RSS link");
            }
            return result;
        }
    }
}