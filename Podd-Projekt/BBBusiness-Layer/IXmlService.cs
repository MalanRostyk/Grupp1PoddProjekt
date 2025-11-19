using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;


namespace DDModels
{
<<<<<<<< HEAD:Podd-Projekt/DDModels/Category.cs
    public class Category
    {

        public string Name { get; set; }

========
    public interface IXmlService
    {
        Task SavePodFeedToXml(PodFeed pf);
        Task<PodFeed> LoadPodFeedFromXml();
>>>>>>>> R2:Podd-Projekt/BBBusiness-Layer/IXmlService.cs
    }
}
