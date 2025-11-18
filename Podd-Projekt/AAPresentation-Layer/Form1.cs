using BBBusiness_Layer;
using DDModels;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        public delegate void RefreshDelegate();
        public event RefreshDelegate refreshEvent;
        private IService service;//Dependcy injection måste, ej gjort
        private IPodFeedService pfService;
        private ICategoryService catService;
        private PodFeed pf;
        //private Category c;
        public Form1(IService service, IPodFeedService pFs, ICategoryService catService)
        {
            refreshEvent += ClearListBox2;
            refreshEvent += DisplayAllCategoryData;

            this.service = service;
            this.catService = catService;
            pfService = pFs;
            InitializeComponent();
            DisplayAllCategoryData();
        }


        //private void ClearListBox2() => listBox2.Items.Clear();
        private void ClearListBox2() => listBox2.DataSource = null;
        private async void DisplayAllCategoryData()
        {
            List<Category> catList = await catService.GetAllCategoriesAsync();
            listBox2.DataSource = catList;
            listBox2.DisplayMember = "Name";
        }
        private async void DisplayAllCategory()
        {
            List<Category> catList = await catService.GetAllCategoriesAsync();
            foreach (Category c in catList)
            {
                listBox2.Items.Add(c);
            }

            listBox2.DisplayMember = "Name";
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

        private void Form1_Load(object sender, EventArgs e)//Dont touch
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

        private async void button4_Click(object sender, EventArgs e)//Category tab, add category
        {
            Category cat = new();
            cat.Name = tbCreateCategoryName.Text;
            await catService.AddCategoryAsync(cat);
            refreshEvent?.Invoke();
        }
        private async void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)//Category tab
        {

            //try
            //{

            //    //c = (Category)listBox2.SelectedItem;
            //}
            //catch (Exception ec) { Debug.WriteLine("Engine e kaput"); }
        }

        private async void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    c.Name = tbCategoryUpdate.Text;
            //    Category updCat = new();
            //    updCat.Id = c.Id;
            //    updCat.Name = c.Name;
            //    await catService.UpdateCategoryAsync(updCat);
            //    refreshEvent?.Invoke();
            //}catch(Exception ec) { Debug.WriteLine("Engine e kaput"); }


            try
            {

                if(listBox2.SelectedItem is not Category selectedCat)
                {
                    return;
                }
                
                selectedCat.Name = tbCategoryUpdate.Text;
                await catService.UpdateCategoryAsync(selectedCat);
            }
            catch (Exception ec) { Debug.WriteLine("Engine e kaput"); }
            refreshEvent?.Invoke();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if(listBox2.SelectedItem is not Category selectedCat)
                {
                    Debug.WriteLine("Knappen klickades innan Category var vald");
                    return;
                }
                await catService.DeleteCategoryAsync(selectedCat.Id);
                
            }
            catch (Exception ec) { Debug.WriteLine(ec.Message); }
            refreshEvent?.Invoke();
        }
    }
}
