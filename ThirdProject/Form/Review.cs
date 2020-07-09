using DevExpress.XtraEditors.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ThirdProject.BaseForm;
using ThirdProject.Data;
using ThirdProject.Properties;

namespace ThirdProject
{
    public partial class Review : RootForm, IInputReviewToReview
    {
        private Member LoggedInMember { get; set; }
        private Restaurant SelectedRestaurant { get; set; }

        private string Comment { get; set; }
        private string FilePath { get; set; }
        private int Grade { get; set; }
        private int RowCount { get; set; }
        
        private Review()
        {
            InitializeComponent();
        }

        public Review(Member loggedInMember, Restaurant selectedRestaurant) : this()
        {
            LoggedInMember = loggedInMember;
            SelectedRestaurant = selectedRestaurant;
        }

        private void Review_Load(object sender, EventArgs e)
        {
            pcbRestaurantImage.Image = Resources.chobab;
            pcbGrade.Image = Resources.star;
            lblRestaurantName.Text = SelectedRestaurant.Name;
            
            // 선택된 가게의 메인 사진을 가져온다.
            // Restaurant-imageLocation
            string imagePath = DataRepository.Restaurant.Get(SelectedRestaurant.RestaurantId).ImageLocation;

            if (imagePath == null)
                pcbRestaurantImage.Image = Resources.black;
            else
            {
                pcbRestaurantImage.ImageLocation = imagePath;
                pcbRestaurantImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            // 운영 시간 표시
            // 선택된 가게에서 운영 시간을 가져온다.
            string startTime = SelectedRestaurant.StartTime;
            string finishTime = SelectedRestaurant.FinishTime;

            if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(finishTime))
            {
                lblHours.Text = "운영 시간 미등록";
            }
            else
            {
                lblHours.Text = $"{startTime} ~ {finishTime}";
            }

            // 휴무일을 가져온다.
            var selectedInformations = DataRepository.Information.Get(SelectedRestaurant.RestaurantId);

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
            var selectedRetarantReviews = DataRepository.Review.Get(SelectedRestaurant.RestaurantId);

            // 총 평점의 평균
            SetGradeAvg(selectedRetarantReviews);

            // 리뷰 보여주기
            // 멤버 이름 / 평점 / 코멘트

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
                Member reviewedMember = DataRepository.Member.GetOneMember(review.MemberId);
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
                if (review.ImageLocation == null)
                    bitmap = new Bitmap(Resources.black); 
                else
                    bitmap = new Bitmap(review.ImageLocation); 
                
                ((DataGridViewImageCell)dgvReviews.Rows[RowCount].Cells[3]).Value = bitmap;
                ((DataGridViewImageCell)dgvReviews.Rows[RowCount].Cells[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                RowCount++;

            }

            dgvReviews.Columns[0].Width = 50;
            dgvReviews.Columns[1].Width = 20;
            dgvReviews.Columns[2].Width = 200;
            dgvReviews.Columns[3].Width = 200;

        }

        private void SetGrade()
        {
            int grade5 = DataRepository.Review.GetGrade(5, SelectedRestaurant.RestaurantId).Count();
            int grade4 = DataRepository.Review.GetGrade(4, SelectedRestaurant.RestaurantId).Count();
            int grade3 = DataRepository.Review.GetGrade(3, SelectedRestaurant.RestaurantId).Count();
            int grade2 = DataRepository.Review.GetGrade(2, SelectedRestaurant.RestaurantId).Count();
            int grade1 = DataRepository.Review.GetGrade(1, SelectedRestaurant.RestaurantId).Count();

            txbGrade5.Text = grade5.ToString();
            txbGrade4.Text = grade4.ToString();
            txbGrade3.Text = grade3.ToString();
            txbGrade2.Text = grade2.ToString();
            txbGrade1.Text = grade1.ToString();
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

        public void SetData(string comment, string filePath, int grade)
        {
            Comment = comment;
            FilePath = filePath;
            Grade = grade;
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            InputReview inputReview = new InputReview(this, LoggedInMember);
            inputReview.ShowDialog();

            if (string.IsNullOrEmpty(Comment))
                return;

            InsertReview();

            // 멤버
            string memberId = LoggedInMember.Id;

            // 평가 점수
            int? grade = Grade;

            // 코멘트
            string comment = Comment;
            if (string.IsNullOrEmpty(comment))
            {
                comment = "";
            }

            // 사진 추가
            object[] row = new object[] { memberId, grade, comment };
            dgvReviews.Rows.Add(row);

            // 사진 추가

            Bitmap bitmap = null;
            if (FilePath == null)
                bitmap = new Bitmap(Resources.black);
            else
                bitmap = new Bitmap(FilePath);

            ((DataGridViewImageCell)dgvReviews.Rows[RowCount].Cells[3]).Value = bitmap;
            ((DataGridViewImageCell)dgvReviews.Rows[RowCount].Cells[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            RowCount++;
            
            dgvReviews.Columns[0].Width = 50;
            dgvReviews.Columns[1].Width = 20;
            dgvReviews.Columns[2].Width = 200;
            dgvReviews.Columns[3].Width = 200;

            SetGrade();
            var selectedRetarantReviews = DataRepository.Review.Get(SelectedRestaurant.RestaurantId);
            SetGradeAvg(selectedRetarantReviews);

        }

        private void InsertReview()
        {
            Data.Review insertReview = new Data.Review();
            insertReview.MemberId = LoggedInMember.MemberId;
            insertReview.RestaurantId = SelectedRestaurant.RestaurantId;
            insertReview.Grade = Grade;
            insertReview.Comment = Comment;
            insertReview.ImageLocation = !string.IsNullOrEmpty(FilePath) ? FilePath : null;
            DataRepository.Review.Insert(insertReview);
        }

        
    }
}


/*
               * 
               //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
              //imageColumn.Name = "ImageColumn";

              string filePath = null;
              if (review.ImageLocation == null)
                  filePath = System.Reflection.Assembly.GetExecutingAssembly()
                 .Location + @"\..\..\Resources\defaultImage.PNG";
              else
                  filePath = review.ImageLocation;

              Image image = Image.FromFile(filePath);

              imageColumn.Image = image;
              imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
              dgvReviews.Columns.Add(imageColumn);

               */
