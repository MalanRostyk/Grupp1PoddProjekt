using BBBusiness_Layer;
using System.ComponentModel;
using System.Threading.Tasks;
using DDModels;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        private Service service;
        private List<Pod> podList;
        public Form1(Service service)
        {
            this.service = service;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            PodFeed pf = new(); //En feed att använda
            pf.Link = textBox1.Text; //Rss feed i form av länk användaren vill se
            podList = await service.ReadAllPodAsync(pf); //Fyll listan med Pod objekt från länken

            foreach (Pod p in podList)
            {
                listBox1.Items.Add(p);
            }

            listBox1.DisplayMember = "Titel"; //Det som visas i listBox samma som p.Titel i loopen
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pod p = podList[listBox1.SelectedIndex];//Välj motsvarande index i listBox från podList
            richTextBox1.Text = $"{p.Link}"; //Det som visas i richTextBox när vi valt en pod i listBox
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) //radera ej
        {

        }
    }
}
