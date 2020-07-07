using DevExpress.Map;
using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;

namespace ThirdProject
{
    public partial class Map : RootForm, IDataTransferInterface
    {
        private VectorItemsLayer vectorItemLayer = new VectorItemsLayer();
        private MapItemStorage storage = new MapItemStorage();
        private MapPushpin mapPushpin = null;
        private Member LoggedInMember { get; set; }
        private string restaurantName = null;
        private string restaurantFoodType = null;

        public Map()
        {
            InitializeComponent();
        }

        public Map(Member member) : this()
        {
            LoggedInMember = member;
        }

        private void Map_Load(object sender, EventArgs e)
        {
            vectorItemLayer.Data = storage;
            mapControl.Layers.Add(vectorItemLayer);

            var registers = DataRepository.Registration.GetAll();
            var myRestaurantIds = new List<int>();

            foreach(Registration register in registers)
            {
                if (LoggedInMember.MemberId == register.MemberId)
                    myRestaurantIds.Add(register.RestaurantId);
            }

            var restaurants = DataRepository.Restaurant.GetAll();
            foreach(int restaurantId in myRestaurantIds)
            {
                foreach(Restaurant restaurant in restaurants)
                {
                    if(restaurant.RestaurantId == restaurantId)
                    {
                        double laptitude = (double)restaurant.Latitude;
                        double longitude = (double)restaurant.Longitude;
                        GeoPoint p = new GeoPoint(laptitude, longitude);
                        MapItem insertPushPin = new MapPushpin() { Location = (CoordPoint)p, Text = "나" };
                       
                        storage.Items.Add(insertPushPin);
                        mapControl.Refresh();
                        
                    }
                }
            }
            
        }

        private void mapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mapPushpin != null)
                return;
            
            if(MessageBox.Show("MapPushPin을 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                InsertMapPushPin(sender, e);
        }

        void IDataTransferInterface.SetName(string name, string foodType)
        {
            restaurantName = name;
            restaurantFoodType = foodType;
        }

        private void InsertMapPushPin(object sender, MouseEventArgs e)
        {
            CoordPoint p = mapControl.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
            
            //Text = $"{p.GetY()} / {p.GetX()}";

            foreach (MapPushpin mapPushPin in storage.Items)
            {
                if (p.GetY() == mapPushPin.Location.GetY() && p.GetX() == mapPushPin.Location.GetX())
                {
                    MessageBox.Show("이미 핀이 존재합니다.");
                    return;
                }
            }

            // 가게명을 입력받는다.
            InputRestaurantInformation inputRestaurantName = new InputRestaurantInformation(this);
            inputRestaurantName.ShowDialog();

            if (string.IsNullOrEmpty(restaurantName))
            {
                MessageBox.Show("가게명을 입력받지 못했습니다.");
                return;
            }

            Restaurant restaurant = new Restaurant();
            restaurant.Name = restaurantName;
            restaurant.Latitude = (decimal)p.GetY();
            restaurant.Longitude = (decimal)p.GetX();
            DataRepository.Restaurant.Insert(restaurant);

            Registration registration = new Registration();
            registration.MemberId = LoggedInMember.MemberId;
            registration.RestaurantId = restaurant.RestaurantId;
            DataRepository.Registration.Insert(registration);

            Information information = new Data.Information();
            information.RestaurantId = restaurant.RestaurantId;
            if (restaurantFoodType == "한식")
                information.CodeId = 1;
            else if (restaurantFoodType == "중식")
                information.CodeId = 2;
            else if (restaurantFoodType == "일식")
                information.CodeId = 3;
            else if (restaurantFoodType == "양식")
                information.CodeId = 4;

            DataRepository.Information.Insert(information);

            MapItem insertPushPin = new MapPushpin() { Location = p, Text = "나" };
            storage.Items.Add(insertPushPin);
            mapControl.Refresh();

            restaurantName = null;

        }

        private void mapControl_MapItemDoubleClick(object sender, MapItemClickEventArgs e)
        {
            if (IsMapPushPinClicked(sender, e))
            {
                mapPushpin = (MapPushpin)e.Item;
                Thumbnail thumbnail = new Thumbnail(LoggedInMember);
                thumbnail.Show();
            }
        }

        private void mapControl_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            if(IsMapPushPinClicked(sender, e))
            {
                mapPushpin = (MapPushpin)e.Item;
            }
        }

        private bool IsMapPushPinClicked(object sender, MapItemClickEventArgs e)
        {
            if (e.MouseArgs.Button == MouseButtons.Left && e.Item is MapPushpin)
                return true;
            else
                return false;
        }

        private void mapControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (mapPushpin == null)
                return;

            if(e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("MapPushPin을 삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteMapPushPin();
                }
            }
        }

        private void DeleteMapPushPin()
        {
            decimal latitude = (decimal)mapPushpin.Location.GetY();
            decimal longitue = (decimal)mapPushpin.Location.GetX();

            var restaurants = DataRepository.Restaurant.GetAll();
            var registrations = DataRepository.Registration.GetAll();
            var informations = DataRepository.Information.GetAll();

            var deleteRestaurantIds = new List<int>();

            foreach(Restaurant restaurant in restaurants)
            {
                if(restaurant.Latitude == latitude && restaurant.Longitude == longitue)
                {
                    deleteRestaurantIds.Add(restaurant.RestaurantId);
                }
            }

            Registration deleteRegistration = null;
            bool isFindDeleteRegistration = false;
            // registration 삭제
            foreach(int deleteRestaurantId in deleteRestaurantIds)
            {
                foreach(Registration registration in registrations)
                {
                    if(registration.RestaurantId == deleteRestaurantId && registration.MemberId == LoggedInMember.MemberId)
                    {
                        deleteRegistration = registration;
                        isFindDeleteRegistration = true;
                        break;
                    }
                }
                if (isFindDeleteRegistration)
                    break;
            }

            Restaurant deleteRestaurant = new Restaurant();
            // restaurant 삭제
            foreach(Restaurant restaurant in restaurants)
            {
                if(restaurant.RestaurantId == deleteRegistration.RestaurantId)
                {
                    deleteRestaurant = restaurant;
                }
            }

            var deleteInformations = new List<Information>();
            foreach(Information information in informations)
            {
                if (information.RestaurantId == deleteRestaurant.RestaurantId)
                    deleteInformations.Add(information);
            }

            foreach (Information deleteInformation in deleteInformations)
            {
                DataRepository.Information.Delete(deleteInformation);
            }
            DataRepository.Registration.Delete(deleteRegistration);
            DataRepository.Restaurant.Delete(deleteRestaurant);

            storage.Items.Remove(mapPushpin);
            mapControl.Refresh();
            mapPushpin = null;
            
        }

        private void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
            mapPushpin = null;
        }

       
    }
}
