using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class Review : RootForm
    {
        public Review()
        {
            InitializeComponent();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {

            
        }

        private void Review_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.chobab;
            pictureBox2.Image = Properties.Resources.star;

            //리뷰보여주기 (지금은 모두 다 불러오는것)
            List<Data.Review> reviews = DataRepository.Review.GetAll();
            bdsReview.DataSource = reviews;

            //this.StartPosition = FormStartPosition.CenterScreen;

         

            // 레스토랑DB에 있는 Name을 매개변수로 넘겨받았다고 가정 후 textbox에 보여주기
            //txbRestaurantName.Text = GetRestaurantName("미스터 피자");

        }



        //Registration으로 레스토랑DB에 있는 Name 가져오기
        //public string GetRestaurantName(string restaurantName)
        //{
        //    var context = new MatZipEntities();
        //    context.Configuration.ProxyCreationEnabled = false;

        //    var query = from x in context.Registrations
        //                select x;

        //    if (restaurantName != null)
        //        query = query.Where(x => x.Restaurant.Name.Contains(restaurantName));

        //    return query.Select(x => x.Restaurant.Name).ToString();
        //}

        //레스토랑Id로 메뉴3개 메뉴가져오기
        //public List<Menu> GetMenus(int restaurantId)
        //{
        //    var context = new MatZipEntities();
        //    context.Configuration.ProxyCreationEnabled = false;

        //    var query = from x in context.Restaurants
        //                select x;

        //    if (restaurantId != null)
        //        query = query.Where(x => x.RestaurantId.

        //    return query.Select(x => x.Menus).ToList();
        //}
    }
}
