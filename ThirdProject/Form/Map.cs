using DevExpress.Map;
using DevExpress.XtraMap;
using DevExpress.XtraMap.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;
using ThirdProject.Properties;

namespace ThirdProject
{
    public partial class Map : RootForm, IInputRestaurantInformationToMap
    {
        private VectorItemsLayer vectorItemLayer = new VectorItemsLayer();
        private MapItemStorage storage = new MapItemStorage();
        private MapPushpin mapPushpin = null;
        private Member LoggedInMember { get; set; }
        public Color Red { get; private set; }

        private string restaurantName = null;
        private string restaurantFoodType = null;
        private string restaurantFilePath = null;

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
            var othersRestaurantIds = new List<int>();

            foreach (Registration register in registers)
            {
                if (LoggedInMember.MemberId == register.MemberId)
                    myRestaurantIds.Add(register.RestaurantId);
                else
                    othersRestaurantIds.Add(register.RestaurantId);

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
                        
                        MapPushpin insertPushPin = new MapPushpin() { Location = p, Text = "나", TextColor = Color.Red };
                        
                        storage.Items.Add(insertPushPin);
                        mapControl.Refresh();
                        
                    }
                }
            }

            // 다른 사람 pin
            foreach (int restaurantId in othersRestaurantIds)
            {
                foreach (Restaurant restaurant in restaurants)
                {
                    if (restaurant.RestaurantId == restaurantId)
                    {
                        double latitude = (double)restaurant.Latitude;
                        double longitude = (double)restaurant.Longitude;
                        GeoPoint p = new GeoPoint(latitude, longitude);
                        MapItem insertPushPin = new MapPushpin() { Location = p, Text = "타인" };

                        bool isAlreadyMapPushPin = false;
                        foreach(MapPushpin mapPushpin in storage.Items)
                        {
                            if(mapPushpin.Location.GetY() == latitude && mapPushpin.Location.GetX() == longitude)
                            {
                                isAlreadyMapPushPin = true;
                                break;
                            }
                        }

                        if (isAlreadyMapPushPin)
                            break;

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

        void IInputRestaurantInformationToMap.SetName(string name, string foodType, string filePath)
        {
            restaurantFilePath = filePath;
            restaurantName = name;
            restaurantFoodType = foodType;
        }

        private void InsertMapPushPin(object sender, MouseEventArgs e)
        {
            CoordPoint p = mapControl.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));

            // 가게명을 입력받는다.
            InputRestaurantInformation inputRestaurantInformation = new InputRestaurantInformation(this);
            inputRestaurantInformation.ShowDialog();

          
            if (string.IsNullOrEmpty(restaurantName))
            {
                //MessageBox.Show("가게명을 입력받지 못했습니다.");
                return;
            }

            Restaurant restaurant = new Restaurant();
            restaurant.Name = restaurantName;
            restaurant.Latitude = (decimal)p.GetY();
            restaurant.Longitude = (decimal)p.GetX();
            restaurant.ImageLocation = restaurantFilePath;
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

            MapPushpin insertPushPin = new MapPushpin() { Location = p, Text = "나", TextColor = Color.Red };

            //insertPushPin.Image = bmpMarker;
            storage.Items.Add(insertPushPin);
           
            mapControl.Refresh();
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

            if (deleteRegistration == null)
            {
                MessageBox.Show("타인의 관심 음식점은 지울 수 없습니다.");
                return;
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

            var menus = DataRepository.Menu.Get(deleteRegistration.RestaurantId);

            foreach(Data.Menu menu in menus)
            {
                DataRepository.Menu.Delete(menu);
            }

            var reviews = DataRepository.Review.Get(deleteRestaurant.RestaurantId);
            
            foreach(Data.Review review in reviews)
            {
                DataRepository.Review.Delete(review);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        
        private void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            MapHitInfo information = mapControl.CalcHitInfo(e.Location);
            MapPushpin pin = null;
            if (information.InMapPushpin)
            {
                pin = information.MapPushpin;
            }

            if (pin == null)
            {
                mapPushpin = null;
                return;
            }

            if(mapPushpin == pin)
                return;

            mapPushpin = pin;

            decimal latitude = (decimal)pin.Location.GetY();
            decimal longitude = (decimal)pin.Location.GetX();

            var restaurants = DataRepository.Restaurant.Get(latitude, longitude);
            var registrations = DataRepository.Registration.GetAll();

            List<Registration> selectedRegistrations = new List<Registration>();
            foreach (Restaurant restaurant in restaurants)
            {
                foreach (Registration registration in registrations)
                {
                    if (restaurant.RestaurantId == registration.RestaurantId)
                    {
                        selectedRegistrations.Add(registration);
                        break;
                    }
                }
            }

            Registration selectedRegistration = null;
            foreach (Registration registration in selectedRegistrations)
            {
                if (registration.MemberId == LoggedInMember.MemberId)
                {
                    selectedRegistration = registration;
                    break;
                }
            }

            if (selectedRegistration == null)
                selectedRegistration = selectedRegistrations[0];

            Restaurant thumbnailRestaurant = null;
            foreach (Restaurant restaurant in restaurants)
            {
                if (restaurant.RestaurantId == selectedRegistration.RestaurantId)
                {
                    thumbnailRestaurant = restaurant;
                }
            }
            Thumbnail thumbnail = new Thumbnail(LoggedInMember, thumbnailRestaurant);
            
            thumbnail.ShowDialog();

        }

        private void Map_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoggedInMember.IsLogIn = false;
            DataRepository.Member.Update(LoggedInMember);
            MessageBox.Show("로그아웃 되었습니다.");
        }
    }
}
