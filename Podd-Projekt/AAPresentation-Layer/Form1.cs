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
            PodFeed pf = new();
            pf.Link = textBox1.Text;
            podList = await service.ReadAllPodAsync(pf);

            foreach(Pod p in podList)
            {
                listBox1.Items.Add(p.Link);
            }
        }
    }
}
