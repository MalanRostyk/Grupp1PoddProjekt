using BBBusiness_Layer;
using DDModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        private event Action RefreshEvent;

        private IService service;//Dependcy injection måste, ej gjort
        private IPodFeedService pfService;
        private ICategoryService catService;
        private IXmlService xmlService;
        private PodFeed pf;
        //private Category c;
        public Form1(IService service, IPodFeedService pFs, ICategoryService catService, IXmlService xmlService)
        {
            this.xmlService = xmlService;
            this.service = service;
            this.catService = catService;
            pfService = pFs;

            RefreshEvent += ClearListBox2;
            RefreshEvent += FillRegisterListBox;
            RefreshEvent += FillUpdateListBox;
            RefreshEvent += FillDeleteListBox;
            RefreshEvent += DisplayAllCategoryData;


            InitializeComponent();
            GetLastResult();
            RefreshEvent?.Invoke();
        }



        private void ClearListBox2() => listBox2.DataSource = null;
        private async void DisplayAllCategoryData()
        {
            List<Category> catList = await catService.GetAllCategoriesAsync();
            listBox2.DataSource = catList;
            listBox2.DisplayMember = "Name";
            comboBox1.DataSource = catList;
            comboBox1.DisplayMember = "Name";
            comboBox3.DataSource = catList;
            comboBox3.DisplayMember = "Name";
        }

        private async Task<List<PodFeed>> GetFilteredPodFeedList()
        {
            List<PodFeed> filteredList = new();
            if (comboBox3.SelectedItem is Category selectedCat)
            {
                filteredList = await pfService.GetAllFilteredAsync(selectedCat.Name);
            }
            return filteredList;
        }
        private async void FillRegisterListBox()
        {
            List<PodFeed> pfList = await GetFilteredPodFeedList();
            listBox1.DataSource = pfList;

            listBox1.DisplayMember = "Name";
        }
        //private async void FillRegisterListBox()
        //{
        //    List<PodFeed> pfList = await pfService.GetAllAsync();
        //    listBox1.DataSource = pfList;

        //    listBox1.DisplayMember = "Name";
        //}
        private async void FillUpdateListBox()
        {
            List<PodFeed> pfList = await pfService.GetAllAsync();
            listBox5.DataSource = pfList;

            listBox5.DisplayMember = "Name";
        }
        private async void FillDeleteListBox()
        {
            List<PodFeed> pfList = await pfService.GetAllAsync();
            listBox6.DataSource = pfList;

            listBox6.DisplayMember = "Name";
        }

        //private async Task GetLastResult()
        //{
        //    PodFeed pf = await xmlService.LoadPodFeedFromXml();
        //    lbSearchedResults.DataSource = pf.podList;
        //    lbSearchedResults.DisplayMember = "Titel"; //Det som visas i listBox samma som p.Titel i loopen
        //    tbLink.Text = pf.Link;
        //}
        private async Task GetLastResult()
        {
            PodFeed pf = await pfService.GetTempPodFeedAsync();
            lbSearchedResults.DataSource = pf.podList;
            lbSearchedResults.DisplayMember = "Titel"; //Det som visas i listBox samma som p.Titel i loopen
            tbLink.Text = pf.Link;
        }
        private async void button1_Click(object sender, EventArgs e) //I Start tab, Search knapp
        {
            PodFeed instanceForNewId = new();
            pf = await pfService.GetTempPodFeedAsync(); //En feed att använda
            pf.Id = instanceForNewIdn.Id;
            pf.Link = tbLink.Text; //Rss feed i form av länk användaren vill se
            pf.podList = await service.ReadAllPodAsync(pf); //Fyll listan med Pod objekt från länken
            await pfService.UpdateRecentlySearchedAsync(pf);

            lbSearchedResults.DataSource = pf.podList;
            lbSearchedResults.DisplayMember = "Titel"; //Det som visas i listBox samma som p.Titel i loopen

            await xmlService.SavePodFeedToXml(pf);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//I Start Tabben
        {
            if (lbSearchedResults.SelectedItem is not Pod selectedPod)
            {
                return;
            }
            /*Pod p = pf.podList[lbSearchedResults.SelectedIndex];*///Välj motsvarande index i listBox från podList
            rtbSearchedPodInfo.Text = $"{selectedPod.Link}"; //Det som visas i richTextBox när vi valt en pod i listBox
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

            //tbLink.Clear(); Ska vara kvar när det är färdigt
            tbNewFeedName.Clear();
            RefreshEvent?.Invoke();
        }

        private async void button4_Click(object sender, EventArgs e)//Category tab, add category
        {
            Category cat = new();
            cat.Name = tbCreateCategoryName.Text;
            await catService.AddCategoryAsync(cat);

            tbCreateCategoryName.Clear();
            RefreshEvent?.Invoke();
        }
        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)//Category tab
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedItem is Category cat)
                tbCategoryUpdate.Text = cat.Name;
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

            RefreshEvent?.Invoke();
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
            RefreshEvent?.Invoke();
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
            richTextBox1.Clear();
            if (listBox3.SelectedItem is Pod selectedPod)
            {
                List<string> aPodValues = new();

                aPodValues.Add($"Id: {selectedPod.Id}\n");
                aPodValues.Add($"Titel: {selectedPod.Titel}\n");
                aPodValues.Add($"Description: {selectedPod.Description}\n");
                aPodValues.Add($"Published Date: {selectedPod.PublishedDate}\n");
                aPodValues.Add($"Link: {selectedPod.Link}\n");
                aPodValues.Add($"LinkRef: {selectedPod.LinkRef}");

                foreach (string value in aPodValues)
                {
                    richTextBox1.Text += value;
                }
            }
        }

        private async void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Category> catList = await catService.GetAllCategoriesAsync();
            if (listBox5.SelectedItem is PodFeed pf)
            {
                lblToUpdate.Text = pf.Id;
                lblDisplayLink.Text = pf.Link;
                tbUpdateName.Text = pf.Name;

                comboBox2.DataSource = catList;

                comboBox2.DisplayMember = "Name";
                comboBox2.SelectedItem = catList.FirstOrDefault(c => c.Name == pf.CategoryId);

            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            PodFeed newPf = new();
            newPf.Id = lblToUpdate.Text;
            if (listBox5.SelectedItem is PodFeed pf)
                newPf.podList = pf.podList;
            newPf.Link = lblDisplayLink.Text;
            newPf.Name = tbUpdateName.Text;
            if (comboBox2.SelectedItem is Category cat)
            {
                newPf.CategoryId = cat.Name;
            }
            await pfService.UpdatePodFeedAsync(newPf);

            RefreshEvent?.Invoke();
        }

        private async void btnDeletePodFeed_Click(object sender, EventArgs e)
        {
            if (listBox6.SelectedItem is PodFeed pf)
            {
                var confirm = MessageBox.Show($"Are you sure you want to delete the PodFeed {pf.Name}?",
                    "Confirm deletion of PodFeed",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                    await pfService.DeletePodFeedAsync(pf.Id);
            }
            RefreshEvent?.Invoke();
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox6.SelectedItem is PodFeed pf)
            {
                listBox7.DataSource = pf.podList;
                listBox7.DisplayMember = "Titel";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillRegisterListBox();
        }
    }
}
