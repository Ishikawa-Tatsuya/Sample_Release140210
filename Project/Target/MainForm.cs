using System;
using System.Windows.Forms;

namespace Target
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //新しいドメインでフォーム起動
        static int i = 0;
        public void StartNewDomain()
        {
            AppDomain.CreateDomain("new domain " + i++).DoCallBack(()=>new Form().Show());
        }
    }
}
