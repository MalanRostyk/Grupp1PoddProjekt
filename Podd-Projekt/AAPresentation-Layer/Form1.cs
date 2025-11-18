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

        private void btnSave_Click(object sender, EventArgs e)//I start tab, spara feed
        {
            if (tbNewFeedName.Text != string.Empty)
            {
                pf.Name = tbNewFeedName.Text;
                
                pf.CategoryId = GetCategoryName();

                pfService.AddPodFeedAsync(pf);
            }
            else { tbeEmptyName.Text = "Fyll Namn för RSS Feed"; }
        }

        private string GetCategoryName()
        {
            Category selectedCat = (Category)cbChooseCategory.SelectedItem;
            return selectedCat.Name; 
        }

        private void rrr(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)//tbcreate category
        {

        }
        private async void button4_Click(object sender, EventArgs e)//skapa categori knapp
        {
            try
            {
                var name = textBox2.Text;
                if (name != string.Empty)
                {
                    Category c = new Category() { Name = name };
                    await catService.AddCategoryAsync(c);
                    await DisplayCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//tbUpdateCategory
        {

        }

        private async void btnUpdateCategory_Click(object sender, EventArgs e)//uppdatera categori knapp
        {
            try
            {

                var name = textBox1.Text;
                if (!(CategoryList.SelectedItem is Category selectedCat))
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    return;
                }
                selectedCat.Name = name;
                await catService.UpdateCategoryAsync(selectedCat);
                await DisplayCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDeleteCategory_Click(object sender, EventArgs e)//ta bort categori knapp
        {
            try
            {
                if (CategoryList.SelectedItem is not Category selectedCat)
                {
                    return;
                }
                await catService.DeleteCategoryAsync(selectedCat.Id);
                await DisplayCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CategoryList_SelectedIndexChanged(object sender, EventArgs e)//listbox category
        {

        }

        private async Task DisplayCategories()
        {
            try
            {
                CategoryList.DataSource = null;
                cbChooseCategory.DataSource = null;
                List<Category> categories = await catService.GetAllCategoriesAsync();
                CategoryList.DataSource = categories;
                CategoryList.DisplayMember = "Name";
                cbChooseCategory.DataSource = categories;
                cbChooseCategory.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }



        private void tbNewFeedName_TextChanged(object sender, EventArgs e)//tbNewFeedName
        {

        }


        private void cbChooseCategory_SelectedIndexChanged(object sender, EventArgs e)//combobox choose category
        {

        }

        private async void btnAddCategoryToPodeFeed_Click(object sender, EventArgs e)//add category to podfeed knapp
        {
            //pf = new ();
            //if (cbChooseCategory.SelectedItem is not Category selectedCat)
            //{
            //    return;
            //}
            //pf.CategoryId = selectedCat.Name;
            
            //await pfService.AddPodFeedAsync(pf);
        }
    }
}
