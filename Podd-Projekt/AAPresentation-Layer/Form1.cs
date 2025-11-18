using BBBusiness_Layer;
using System.ComponentModel;
using System.Threading.Tasks;
using DDModels;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        private IService service;//Dependcy injection måste, ej gjort
        private IPodFeedService pfService;
        private PodFeed pf;
        public Form1(IService service, IPodFeedService pFs)
        {
            this.service = service;
            pfService = pFs;
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e) //I Start tab, Search knapp
        {
            pf = new(); //En feed att använda
            pf.Link = tbLink.Text; //Rss feed i form av länk användaren vill se
            pf.podList = await service.ReadAllPodAsync(pf); //Fyll listan med Pod objekt från länken

            foreach (Pod p in pf.podList)
            {
                lbSearchedResults.Items.Add(p);
                p.LinkRef = pf.Link;
            }

            lbSearchedResults.DisplayMember = "Titel"; //Det som visas i listBox samma som p.Titel i loopen
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//I Start Tabben
        {
            Pod p = pf.podList[lbSearchedResults.SelectedIndex];//Välj motsvarande index i listBox från podList
            rtbSearchedPodInfo.Text = $"{p.Link}"; //Det som visas i richTextBox när vi valt en pod i listBox
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) //I Start tabben
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)//I start tab, 
        {
            if(tbNewFeedName.Text != string.Empty)
            {
                pf.Name = tbNewFeedName.Text;
                pfService.AddPodFeedAsync(pf);
            }
            else { tbeEmptyName.Text = "Fyll Namn för RSS Feed"; }

        }
    }
}
