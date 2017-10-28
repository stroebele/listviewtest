using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListViewImages.Properties;

namespace ListViewImages
{
    public partial class Form1 : Form
    {
        private ISomeRepo _repo;
        public Form1()
        {
            InitializeComponent();
            _repo = new FakeRepo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var suspects = _repo.GetSuspects().ToArray();

            listView1.Clear();
            ImageList myImageList1 = new ImageList();
            myImageList1.ImageSize = new System.Drawing.Size(80, 80);
            listView1.LargeImageList = myImageList1;
            listView1.View = View.LargeIcon;
            
            for(int i=0; i<suspects.Count();i++)
            {
                var item = new ListViewItem();
                myImageList1.Images.Add(suspects[i].Pic);
                item.ImageIndex = i;
                item.Text = suspects[i].Name;
                listView1.Items.Add(item);


            }



        }


    }

    public class FakeRepo : ISomeRepo
    {
        public IEnumerable<SuspectData> GetSuspects()
        { 
            var retval = new List<SuspectData>();
            retval.Add(new SuspectData() { Name = "Test1", Pic = Resources.download});
            retval.Add(new SuspectData() {Name = "Test2", Pic = Resources.blue_bull_80x80_2005});
            return retval;
        }
    }

    public interface ISomeRepo
    {
        IEnumerable<SuspectData> GetSuspects();
    }

    public class SuspectData
    {
        public Image Pic { get; set; }
        public string Name { get; set; }
    }
}
