using BBBusiness_Layer;
using DDModels;
using CCData_Access_Layer;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        //Data dependency injection 
        IPodFeedService podFeedService = new PodFeedService(new PodFeedRepository());

        public Form1()
        {
            InitializeComponent();
        }
    }
}
