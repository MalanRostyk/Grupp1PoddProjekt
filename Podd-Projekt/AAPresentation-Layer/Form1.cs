using BBBusiness_Layer;
using DDModels;
using CCData_Access_Layer;

namespace AAPresentation_Layer
{
    public partial class Form1 : Form
    {
        //Data dependency injection 
        IPodFeedService podFeedService = new PodFeedService(new PodFeedRepository());
        List<string> participantsList = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            podFeedService.AddPodAsync(new Pod(
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            participantsList.Add(textBox3.Text);
            FillListBox();
        }

        private void FillListBox()
        {
            listBox1.Items.Clear();
            foreach (string participant in participantsList)
            {
                listBox1.Items.Add(participant);
            }

        }

    }
}
