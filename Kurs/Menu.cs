using System;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
        }

        private void egoldsCard1_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com";
            Browser browser = new Browser(url);
            this.Hide();
            browser.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        public void egoldsCard4_Click(object sender, EventArgs e)
        {
            string url = "https://www.disneyplus.com/";
            Browser browser = new Browser(url);
            this.Hide();
            browser.Show();
        }

        private void egoldsCard2_Click(object sender, EventArgs e)
        {
            string url = "https://www.googleadservices.com/pagead/aclk?sa=L&ai=DChcSEwj2mdzag-HpAhXZmtUKHdeTDnoYABAAGgJ3cw&ohost=www.google.com&cid=CAESQOD2Cp60o6BT3rTS51Su4iBi4zN36E4KgGrXG7Ugke0mt90TDgxcEvO8BST_bUC7Oh3VtHvvRs5c4Ap59yq0sNs&sig=AOD64_0uw-6-nRvqraQYvDlYP9Sw307wkA&q=&ved=2ahUKEwiii9Pag-HpAhXJ4KQKHYxhAQQQ0Qx6BAghEAE&adurl=";
            Browser browser = new Browser(url);
            this.Hide();
            browser.Show();
        }

        private void egoldsCard3_Click(object sender, EventArgs e)
        {
            string url = "https://www.netflix.com/";
            Browser browser = new Browser(url);
            this.Hide();
            browser.Show();
        }
    }
}
 