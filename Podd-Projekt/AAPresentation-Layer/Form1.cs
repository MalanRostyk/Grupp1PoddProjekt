using BBBusiness_Layer;
using DDModels;
using CCData_Access_Layer;
using System.ComponentModel;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        public delegate void RefreshDelegat();
        public event RefreshDelegat refreshEvent;

        //Data dependency injection 
        IPodFeedService podFeedService = new PodFeedService(new PodFeedRepository());
        List<string> participantsList = new();
        public Form1()
        {
            InitializeComponent();
            FillListBoxAll();
            refreshEvent += ClearForRefresh;
            refreshEvent += FillListBoxAll;

        }

        private async void FillListBoxAll()
        {
            List<Pod> podList = await podFeedService.GetPodsAsync();

            foreach (Pod enPod in podList)
            {
                listBox2.Items.Add(enPod.GetAllPodInfo());
            }
        }

        private void ClearForRefresh()
        {
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await podFeedService.AddPodAsync(new Pod(
                textBox1.Text,
                textBox2.Text,
                participantsList,
                textBox4.Text,
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                int.Parse(textBox9.Text)
                ));
            listBox1.Items.Clear();
            Pod? enPod = await podFeedService.GetPodAsync("3");
            label1.Text = enPod.Category;
            refreshEvent?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            participantsList.Add(textBox3.Text);
            FillListBoxAddParticipants();
            textBox3.Clear();
        }

        private void FillListBoxAddParticipants()
        {
            listBox1.Items.Clear();
            foreach (string participant in participantsList)
            {
                listBox1.Items.Add(participant);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
