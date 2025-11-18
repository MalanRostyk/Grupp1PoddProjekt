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
        CICategoryService catService;
        private delegate void UpdateCategoryDelegate();
        private event UpdateCategoryDelegate updateCategoryDelegate;
        public Form1(IService service, IPodFeedService pFs, CICategoryService catService)
        {
            this.catService = catService;
            this.service = service;
            pfService = pFs;
            InitializeComponent();
            DisplayCategories();
            //updateCategoryDelegate += DisplayCategories;
            //updateCategoryDelegate += CategoryList.Refresh;
            //updateCategoryDelegate?.Invoke();
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
            if (tbNewFeedName.Text != string.Empty)
            {
                pf.Name = tbNewFeedName.Text;
                pfService.AddPodFeedAsync(pf);
            }
            else { tbeEmptyName.Text = "Fyll Namn för RSS Feed"; }

        }

        private void rrr(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)//tbcreate category
        {

        }
        private void button4_Click(object sender, EventArgs e)//skapa categori knapp
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//tbUpdateCategory
        {

        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)//uppdatera categori knapp
        {

        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)//ta bort categori knapp
        {

        }

        private void CategoryList_SelectedIndexChanged(object sender, EventArgs e)//listbox category
        {

        }

        private async void DisplayCategories()
        {
            List<Category> categories = await catService.GetAllCategoriesAsync();
            CategoryList.DataSource = categories;
            CategoryList.DisplayMember = "Name";
            

        }
    }
}
