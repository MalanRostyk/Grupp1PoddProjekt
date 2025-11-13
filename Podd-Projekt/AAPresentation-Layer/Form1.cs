using InterfacesLayer;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        private readonly IPodFeedService service;
        public Form1(IPodFeedService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private async void btnAddFeeds(object sender, EventArgs e)
        {
            string rssUrl = txtUrl.Text;
            string category = cmbCategory.Text;
            await service.AddFeedFromUrlAsync(rssUrl, category);
            await LoadFeedsAsync();
        }

        private async Task LoadFeedsAsync()
        {
            var feeds = await service.GetAllFeedsAsync();
            lstFeeds.DataSource = feeds;
            lstFeeds.DisplayMember = "Title";
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadFeedsAsync();
        }
    }
}
