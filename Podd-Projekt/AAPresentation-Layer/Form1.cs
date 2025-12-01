using BBBusiness_Layer;
using DDModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBBusiness_Layer.Validation;
namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        private event Action RefreshEvent;
        private bool linkValid;
        private IService service;//Dependcy injection m?ste, ej gjort
        private IPodFeedService pfService;
        private ICategoryService catService;
        public Form1(IService service, IPodFeedService pFs, ICategoryService catService)
        {
            this.service = service;
            this.catService = catService;
            pfService = pFs;

            RefreshEvent += ClearTextBoxes;
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
        private void ClearTextBoxes()
        {

            tbNewFeedName.Clear();
            tbUpdateName.Clear();
            tbCreateCategoryName.Clear();
            tbCategoryUpdate.Clear();
        }
        private async void DisplayAllCategoryData()
        {
            List<Category> catList = await catService.GetAllCategoriesAsync();
            catList = catList.OrderBy(c => c.Name).ToList();

            listBox2.DataSource = catList;
            listBox2.DisplayMember = "Name";

            catList.Add(new Category("General"));

            comboBox1.DataSource = catList;
            comboBox1.DisplayMember = "Name";
            FillComboBox(catList);
        }

        private void FillComboBox(List<Category> catList)
        {
            catList.Reverse();
            catList.Add(new Category("None"));
            catList.Reverse();
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

        private async Task GetLastResult()
        {
            PodFeed pf = await pfService.GetTempPodFeedAsync();
            if (pf != null)
            {
                lbSearchedResults.DataSource = pf.podList;
                lbSearchedResults.DisplayMember = "Titel"; //Det som visas i listBox samma som p.Titel i loopen
                tbLink.Text = pf.Link;
            }
            else
            {
                PodFeed dummyPf = new();
                dummyPf.podList = new();
                await pfService.AddTempPodFeedAsync(dummyPf);
                lbSearchedResults.DataSource = dummyPf.podList;
                lbSearchedResults.DisplayMember = "Titel"; //Det som visas i listBox samma som p.Titel i loopen
                tbLink.Text = dummyPf.Link;
            }
        }
        private async void button1_Click(object sender, EventArgs e) //I Start tab, Search knapp
        {
            try
            {
                PodFeed pfOld = await pfService.GetTempPodFeedAsync();
                PodFeed pfNew = new();
                pfNew.Link = tbLink.Text;
                pfNew.podList = await service.ReadAllPodAsync(pfNew.Link);

                string listResult = pfService.ValidateList(pfNew.podList);
                var inputResult = FeedValidator.ValidateTextBox(tbLink.Text);
                if (!inputResult.IsValid)
                {
                    MessageBox.Show(inputResult.Errors[0]);
                    linkValid = false;
                    return;
                }
                if (!string.IsNullOrWhiteSpace(listResult))
                {
                    MessageBox.Show(listResult);
                    linkValid = false;
                    return;
                }

                await pfService.InsertDeleteTempAsync(pfNew, pfOld);
                lbSearchedResults.DataSource = pfNew.podList;
                lbSearchedResults.DisplayMember = "Name";
                linkValid = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            RefreshEvent?.Invoke();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//I Start Tabben
        {
            if (lbSearchedResults.SelectedItem is not Pod selectedPod)
            {
                return;
            }
            rtbSearchedPodInfo.Text = $"{selectedPod.Link}"; //Det som visas i richTextBox när vi valt en pod i listBox
        }

        private void Form1_Load(object sender, EventArgs e)//Dont touch
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)//I start tab, 
        {
            if (!linkValid)
            {
                MessageBox.Show("Warning: You must first search for a valid feed link before saving.");
                return;
            }
            string nameToCheck = tbNewFeedName.Text;
            var validation = FeedValidator.ValidateTextBox(nameToCheck);
            var duplicateValidation = FeedValidator.ValidateDuplicateNames(
                await pfService.GetAllAsync(), tbNewFeedName.Text);

            if (!validation.IsValid)
            {
                MessageBox.Show($"Warning: {validation.GetErrorString()}");
                return;
            }
            if (!duplicateValidation.IsValid)
            {
                MessageBox.Show($"Warning: {duplicateValidation.GetErrorString()}");
                return;
            }
            try
            {
                PodFeed toSave = await pfService.GetTempPodFeedAsync();
                if (toSave != null)
                {
                    toSave.Name = tbNewFeedName.Text;


                    if (comboBox1.SelectedItem is Category selectedCat)
                    {

                        toSave.CategoryId = selectedCat.Name;
                    }
                    else
                    {
                        toSave.CategoryId = "General";
                    }
                    await pfService.AddPodFeedAsync(toSave);
                }
            }
            catch (NullReferenceException nfEx)
            {
                Debug.WriteLine(nfEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            linkValid = false;
            //tbLink.Clear(); Ska vara kvar när det är färdigt

            RefreshEvent?.Invoke();
        }

        private async void button4_Click(object sender, EventArgs e)//Category tab, add category
        {
            var validationResult = FeedValidator.ValidateTextBox(tbCreateCategoryName.Text);
            if (validationResult.IsValid)
            {
                try
                {
                    Category cat = new();
                    cat.Name = tbCreateCategoryName.Text;
                    await catService.AddCategoryAsync(cat);
                }
                catch (FormatException fEx)
                {
                    Debug.WriteLine(fEx.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(validationResult.GetErrorString());
                return;
            }


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
                var validationResult = FeedValidator.ValidateTextBox(tbCategoryUpdate.Text);
                if (validationResult.IsValid)
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
                else
                {
                    MessageBox.Show(validationResult.GetErrorString());
                    return;
                }

            }
            catch (Exception ec) { Debug.WriteLine("Engine e kaput"); }

            RefreshEvent?.Invoke();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (listBox2.SelectedItems.Count == 0)
                {
                    MessageBox.Show(
                        $"Are you sure you want to delete nothing, what did nothing do to you?",
                        "Confirm Deletion of nothing",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                }
                else
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
                                await pfService.UpdatePodFeedAsync(pf, "General");
                            }

                            await catService.DeleteCategoryAsync(selectedCat.Id);
                        }
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

                catList.Add(new Category("General"));
                comboBox2.DataSource = catList;

                comboBox2.DisplayMember = "Name";
                comboBox2.SelectedItem = catList.FirstOrDefault(c => c.Name == pf.CategoryId);

            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var validationResult = FeedValidator.ValidateTextBox(tbUpdateName.Text);
                if (validationResult.IsValid)
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
                }
                else
                {
                    MessageBox.Show(validationResult.GetErrorString());
                    return;
                }
            }
            catch (NullReferenceException nullRefEx)
            {
                MessageBox.Show("Could not find the selected feed.");
                Debug.WriteLine(nullRefEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error updating.");
                Debug.WriteLine(ex.Message);
            }

            RefreshEvent?.Invoke();
        }

        private async void btnDeletePodFeed_Click(object sender, EventArgs e)
        {

            if (listBox2.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    $"Are you sure you want to delete nothing, what did nothing do to you?",
                    "Confirm Deletion of nothing",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
            }
            else
            {
                if (listBox6.SelectedItem is PodFeed pf)
                {
                    var confirm = MessageBox.Show($"Are you sure you want to delete the PodFeed {pf.Name}?",
                        "Confirm deletion of PodFeed",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        await pfService.DeletePodFeedAsync(pf.Id);
                        listBox7.DataSource = null;
                    }

                }
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
            listBox3.DataSource = null;
            FillRegisterListBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblDisplayLink_Click(object sender, EventArgs e)
        {

        }
    }
}
