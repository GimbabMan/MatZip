using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;
using ThirdProject.Properties;

namespace ThirdProject
{
    public partial class Review : RootForm
    {
        private Member loggedInMember;
        private Restaurant selectedRestaurant;
        private string reviewComment;
        private byte[] reviewImage;
        private string menuName;
        private double reviewPrice;
        private int reviewGrade;
        private int rowCount = 0;
        private string restaurantStartTime;
        private string restaurantFinishTime;
        private bool[] daysOff; 
        
        private Review()
        {
            InitializeComponent();
        }

        public Review(Member loggedInMember, Restaurant selectedRestaurant) : this()
        {
            this.loggedInMember = loggedInMember;
            this.selectedRestaurant = selectedRestaurant;
        }

        private void Review_Load(object sender, EventArgs e)
        {
            pcbRestaurantImage.Image = Resources.chobab;
            pcbGrade.Image = Resources.star;
            lblRestaurantName.Text = selectedRestaurant.Name.ToString();
           
            // 선택된 가게의 메인 사진을 가져온다.
            // Restaurant-imageLocation
            byte[] image = DataRepository.Restaurant.Get(selectedRestaurant.RestaurantId).Image;

            if (image == null)
                pcbRestaurantImage.Image = Resources.black;
            else
            {
                pcbRestaurantImage.Image = ConvertBinaryToImage(image);
                pcbRestaurantImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            // 운영 시간 표시
            // 선택된 가게에서 운영 시간을 가져온다.
            string startTime = selectedRestaurant.StartTime;
            string finishTime = selectedRestaurant.FinishTime;

            if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(finishTime))
            {
                lblHours.Text = "운영 시간 미등록";
            }
            else
            {
                lblHours.Text = $"{startTime} ~ {finishTime}";
            }

            // 휴무일을 가져온다.
            var selectedInformations = DataRepository.Information.Get(selectedRestaurant.RestaurantId);

            if (selectedInformations.Count > 0)
            {
                List<Code> selectedCodes = new List<Code>();
                foreach (Information selectedInformation in selectedInformations)
                {
                    selectedCodes.Add(DataRepository.Code.Get(selectedInformation.CodeId));
                }

                Queue<string> days = new Queue<string>();
                foreach (Code selectedCode in selectedCodes)
                {
                    if (selectedCode.CodeId >= 10 && selectedCode.CodeId <= 16)
                    {
                        days.Enqueue(selectedCode.Text);
                    }
                }

                string offDays = "";
                while (days.Count > 0)
                {
                    offDays += (days.Dequeue() + " ");
                }

                if(days.Count > 0)
                    txbDays.Text = $"휴무일: {offDays}";
                else
                    txbDays.Text = "휴무일 미등록";
            }
            else
            {
                txbDays.Text = "휴무일을 등록하지 않았습니다.";
            }

            // 5점, 4점, 3점, 2점, 1점 인원 구하기
            SetGrade();
            
            // 선택된 가게의 모든 리뷰들을 불러온다.
            var selectedRetarantReviews = DataRepository.Review.Get(selectedRestaurant.RestaurantId);

            // 총 평점의 평균
            SetGradeAvg(selectedRetarantReviews);

            // 리뷰 보여주기
            // 멤버 이름 / 평점 / 코멘트
            dgvReviews.ReadOnly = true;
            dgvReviews.RowTemplate.Height = 100;
            dgvReviews.AllowUserToAddRows = false;

            dgvReviews.ColumnCount = 3;
            dgvReviews.Columns[0].Name = "멤버 이름";
            dgvReviews.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReviews.Columns[1].Name = "평점";
            dgvReviews.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReviews.Columns[2].Name = "코멘트";

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "사진";
            dgvReviews.Columns.Insert(3, imageColumn);

            foreach (Data.Review review in selectedRetarantReviews)
            {
                // 멤버 Id
                Data.Member reviewedMember = DataRepository.Member.GetOneMember(review.MemberId);
                string memberId = reviewedMember.Id;

                // 평가 점수
                int? grade = review.Grade;

                // 코멘트
                string comment = review.Comment;
                if (string.IsNullOrEmpty(comment))
                {
                    comment = "";
                }

                object[] row = new object[] { memberId, grade, comment };
                dgvReviews.Rows.Add(row);

                // 사진 추가

                Bitmap bitmap = null;
                if (review.Image == null)
                    bitmap = new Bitmap(Resources.black); 
                else
                    bitmap = new Bitmap(ConvertBinaryToImage(review.Image)); 
                
                ((DataGridViewImageCell)dgvReviews.Rows[rowCount].Cells[3]).Value = bitmap;
                ((DataGridViewImageCell)dgvReviews.Rows[rowCount].Cells[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                rowCount++;

            }

            dgvReviews.Columns[0].Width = 50;
            dgvReviews.Columns[1].Width = 20;
            dgvReviews.Columns[2].Width = 200;
            dgvReviews.Columns[3].Width = 200;

            var seletedMenus = DataRepository.Menu.Get(selectedRestaurant.RestaurantId).ToList();

            txbMenus.Text = "";
            //메뉴불러오기
            if(seletedMenus.Count > 0)
            {
                foreach(Data.Menu menu in seletedMenus)
                {
                    txbMenus.Text += $"{menu.Name}\t{menu.Price:C0}\r\n";
                }
            }

            //시작 시간, 마감 시간 불러오기
            if(string.IsNullOrEmpty(selectedRestaurant.StartTime) || string.IsNullOrEmpty(selectedRestaurant.FinishTime))
            {
                lblHours.Text = "업무 시간 등록하지 않음";
            } else
            {
                lblHours.Text = $"{selectedRestaurant.StartTime} ~ {selectedRestaurant.FinishTime}";
            }

            //휴무일 불러오기

            var informations = DataRepository.Information.Get(selectedRestaurant.RestaurantId);
            List<Code> codes = new List<Code>();
            foreach (Information information in informations)
            {
                if (information.CodeId >= 10 && information.CodeId <= 16)
                    codes.Add(DataRepository.Code.Get(information.CodeId));
            }

            if (codes.Count > 0)
            {

                txbDays.Text = "휴무일 : ";
                foreach (Code code in codes)
                {
                    txbDays.Text += $"{code.Text} ";
                }
            }
            else
            {
                txbDays.Text = "휴무일 등록하지 않음";
            }

        }

        private Image ConvertBinaryToImage(byte[] image)
        {
            using (MemoryStream memoryStream = new MemoryStream(image))
            {
                return Image.FromStream(memoryStream);
            }

        }

        private void SetGrade()
        {
            int[] grades = new int[5];
            for(int i = 5; i >= 1; i--)
            {
                grades[i-1] = DataRepository.Review.GetGrade(i, selectedRestaurant.RestaurantId).Count();
            }

            txbGrade5.Text = grades[4].ToString();
            txbGrade4.Text = grades[3].ToString();
            txbGrade3.Text = grades[2].ToString();
            txbGrade2.Text = grades[1].ToString();
            txbGrade1.Text = grades[0].ToString();
        }

        private void SetGradeAvg(List<Data.Review> selectedRetarantReviews)
        {
            if (selectedRetarantReviews.Count() > 0)
            {
                double sumGrades = selectedRetarantReviews.Sum(x => x.Grade);
                int gradesCount = selectedRetarantReviews.Count();
                double gradesAvg = sumGrades / gradesCount;
                lblGrade.Text = $"{gradesAvg:N1} 점";
            }
            else
            {
                lblGrade.Text = "0.0 점";
            }
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

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetReviewInformation(string comment, byte[] image, int grade)
        {
            reviewComment = comment;
            reviewImage = image;
            reviewGrade = grade;
        }

        public void GetMenuInformation(string menuName, double price)
        {
            this.menuName = menuName;
            reviewPrice = price;
        }

        public void GetDaysOffInformation(bool[] daysOff)
        {
            this.daysOff = daysOff;
        }

        public void GetHoursInformation(string startTime, string finishTime)
        {
            restaurantStartTime = startTime;
            restaurantFinishTime = finishTime;
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            inputReview inputReview = new inputReview(this, loggedInMember);
            inputReview.ShowDialog();

            if (string.IsNullOrEmpty(reviewComment))
                return;

            InsertReview();

            // 멤버
            string memberId = loggedInMember.Id;

            // 평가 점수
            int? grade = reviewGrade;

            // 코멘트
            string comment = reviewComment;
            if (string.IsNullOrEmpty(comment))
            {
                comment = "";
            }

            // 사진 추가
            object[] row = new object[] { memberId, grade, comment };
            dgvReviews.Rows.Add(row);

            // 사진 추가

            Bitmap bitmap = null;
            if (reviewImage == null)
                bitmap = new Bitmap(Resources.black);
            else
                bitmap = new Bitmap(ConvertBinaryToImage(reviewImage));

            ((DataGridViewImageCell)dgvReviews.Rows[rowCount].Cells[3]).Value = bitmap;
            ((DataGridViewImageCell)dgvReviews.Rows[rowCount].Cells[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            rowCount++;
            
            dgvReviews.Columns[0].Width = 50;
            dgvReviews.Columns[1].Width = 20;
            dgvReviews.Columns[2].Width = 200;
            dgvReviews.Columns[3].Width = 200;

            SetGrade();
            var selectedRetarantReviews = DataRepository.Review.Get(selectedRestaurant.RestaurantId);
            SetGradeAvg(selectedRetarantReviews);

        }

        private void InsertReview()
        {
            Data.Review insertReview = new Data.Review();
            insertReview.MemberId = loggedInMember.MemberId;
            insertReview.RestaurantId = selectedRestaurant.RestaurantId;
            insertReview.Grade = reviewGrade;
            insertReview.Comment = reviewComment;
            insertReview.Image = reviewImage != null ? reviewImage : ConvertImageToBinary(Resources.black);
            DataRepository.Review.Insert(insertReview);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            InputMenu inputMenu = new InputMenu(this);
            inputMenu.ShowDialog();

            if (menuName == null)
                return;

            Data.Menu insertMenu = new Data.Menu();
            insertMenu.RestaurantId = selectedRestaurant.RestaurantId;
            insertMenu.Name = menuName;
            insertMenu.Price = (decimal)reviewPrice;
            DataRepository.Menu.Insert(insertMenu);

            menuName = null;

            // 메뉴 최신화
            var seletedMenus = DataRepository.Menu.Get(selectedRestaurant.RestaurantId).ToList();
            txbMenus.Text = "";
            //메뉴 불러오기
            if (seletedMenus.Count > 0)
            {
                foreach (Data.Menu menu in seletedMenus)
                {
                    txbMenus.Text += $"{menu.Name}\t{menu.Price:C0}\r\n";
                }
            }

        }

        private byte[] ConvertImageToBinary(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (ImageFormat.Jpeg.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Jpeg);
                }
                else if (ImageFormat.Png.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                }
                else if (ImageFormat.Gif.Equals(image.RawFormat))
                {
                    image.Save(memoryStream, ImageFormat.Gif);
                }
                return memoryStream.ToArray();
            }
        }

        private void btnHours_Click(object sender, EventArgs e)
        {
            InputHours inputHours = new InputHours(this);
            inputHours.ShowDialog();

            if (restaurantStartTime == null || restaurantFinishTime == null)
                return;

            selectedRestaurant.StartTime = restaurantStartTime;
            selectedRestaurant.FinishTime = restaurantFinishTime;
            DataRepository.Restaurant.Update(selectedRestaurant);

            lblHours.Text = $"{restaurantStartTime} ~ {restaurantFinishTime}";

            restaurantStartTime = null;
            restaurantFinishTime = null;

        }

        private void btnDaysOff_Click(object sender, EventArgs e)
        {
            InPutDaysOff inPutDaysOff = new InPutDaysOff(this);
            inPutDaysOff.ShowDialog();

            Dictionary<int, int> insertDays = new Dictionary<int, int>();
            for(int i = 0; i < daysOff.Length; i++)
            {
                insertDays[i] = i + 10;
            }
            
            for(int i = 0; i < daysOff.Length; i++)
            {
                if(daysOff[i] ==  true)
                {
                    Information information = new Information();
                    information.RestaurantId = selectedRestaurant.RestaurantId;
                    information.CodeId = insertDays[i];
                    DataRepository.Information.Insert(information);
                }
            }

           
            var informations = DataRepository.Information.Get(selectedRestaurant.RestaurantId);
            List<Code> codes = new List<Code>();
            foreach(Information information in informations)
            {
                if(information.CodeId >= 10 && information.CodeId <= 16)
                    codes.Add(DataRepository.Code.Get(information.CodeId));
            }

            txbDays.Text = "휴무일 : ";
            foreach (Code code in codes)
            {
                txbDays.Text += $"{code.Text} ";
            }
        }

    }
}

             