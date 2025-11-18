using BBBusiness_Layer;
using DDModels;
using System.Collections.Generic;
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
            refreshEvent += FillRegisterListBox;
            refreshEvent += ClearListBox2;
            refreshEvent += DisplayAllCategoryData;

            this.service = service;
            this.catService = catService;
            pfService = pFs;
            InitializeComponent();
            FillRegisterListBox();
            DisplayAllCategoryData();
        }



        private void ClearListBox2() => listBox2.DataSource = null;
        private async void DisplayAllCategoryData()
        {
            List<Category> catList = await catService.GetAllCategoriesAsync();
            listBox2.DataSource = catList;
            listBox2.DisplayMember = "Name";
            comboBox1.DataSource = catList;
            comboBox1.DisplayMember = "Name";
        }
        private async void FillRegisterListBox()
        {
            List<PodFeed> pfList = await pfService.GetAllAsync();
            listBox1.DataSource = pfList;

            listBox1.DisplayMember = "Name";
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

        private async void btnSave_Click(object sender, EventArgs e)//I start tab, 
        {
            if (tbNewFeedName.Text != string.Empty)
            {
                pf.Name = tbNewFeedName.Text;
                if (comboBox1.SelectedItem is Category selectedCat)
                {

                    pf.CategoryId = selectedCat.Name;
                }
                await pfService.AddPodFeedAsync(pf);
            }
            else { tbeEmptyName.Text = "Fyll Namn för RSS Feed"; }

            refreshEvent?.Invoke();
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
            try
            {
                if (listBox2.SelectedItem is Category selectedCat)
                {
                    List<PodFeed> pfLista = await pfService.GetAllAsync();

                    var query = from enPf in pfLista
                                where enPf.CategoryId.Equals(selectedCat.Name)
                                select enPf;

                    foreach (var enPf in query)
                    {
                        await pfService.UpdatePodFeedAsync(enPf, tbCategoryUpdate.Text);

                    }
                    selectedCat.Name = tbCategoryUpdate.Text;
                    await catService.UpdateCategoryAsync(selectedCat);
                }
            }
            catch (Exception ec) { Debug.WriteLine("Engine e kaput"); }
            refreshEvent?.Invoke();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (listBox2.SelectedItem is Category selectedCat)
                {
                    var confirm = MessageBox.Show(
                        $"Are you sure you want to delete this category called {selectedCat.Name}?",
                        "Confirm Deletion of Category",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        List<PodFeed> pfLista = await pfService.GetAllAsync();

                        var query = pfLista.Where(p => p.CategoryId == selectedCat.Name);

                        foreach (var pf in query)
                        {
                            await pfService.UpdatePodFeedAsync(pf, "Uncategorized");
                        }

                        await catService.DeleteCategoryAsync(selectedCat.Id);
                    }

                }

            }
            catch (Exception ec) { Debug.WriteLine(ec.Message); }
            refreshEvent?.Invoke();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is PodFeed selectedPf)
            {
                listBox3.DataSource = selectedPf.podList;
                listBox3.DisplayMember = "Titel";
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem is Pod selectedPod)
            {
                List<string> aPodValues = new();
                
                aPodValues.Add($"Id: {selectedPod.Id}");
                aPodValues.Add($"Titel: {selectedPod.Titel}");
                aPodValues.Add($"Link: {selectedPod.Link}");
                aPodValues.Add($"LinkRef: {selectedPod.LinkRef}");

                listBox4.DataSource = aPodValues;
            }
        }
    }
}
