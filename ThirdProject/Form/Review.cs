using DevExpress.Utils.Behaviors.Common;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.Layout;
using System;
using System.Collections;
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
using ThirdProject.Properties;

namespace ThirdProject
{
    public partial class Review : RootForm
    {
        Member LoggedInMember { get; set; }
        Restaurant SelectedRestaurant { get; set; }
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
            pcbRestaurantImage.Image = Properties.Resources.chobab;
            pcbGrade.Image = Properties.Resources.star;

            // 선택된 가게의 메인 사진을 가져온다.
            // Restaurant-imageLocation
            string imagePath = DataRepository.Restaurant.Get(SelectedRestaurant.RestaurantId).ImageLocation;

            if (imagePath == null)
                pcbRestaurantImage.Image = Resources.defaultImage;
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

                txbDays.Text = $"휴무일: {offDays}";

            }
            else
            {
                txbDays.Text = "휴무일을 등록하지 않았습니다.";
            }

            // 5점, 4점, 3점, 2점, 1점 인원 구하기
            int grade5 = DataRepository.Review.GetGrade(5).Count();
            int grade4 = DataRepository.Review.GetGrade(4).Count();
            int grade3 = DataRepository.Review.GetGrade(3).Count();
            int grade2 = DataRepository.Review.GetGrade(2).Count();
            int grade1 = DataRepository.Review.GetGrade(1).Count();

            txbGrade5.Text = grade5.ToString();
            txbGrade4.Text = grade4.ToString();
            txbGrade3.Text = grade3.ToString();
            txbGrade2.Text = grade2.ToString();
            txbGrade1.Text = grade1.ToString();

            // 선택된 가게의 모든 리뷰들을 불러온다.
            var selectedRetarantReviews = DataRepository.Review.Get(SelectedRestaurant.RestaurantId);

            // 총 평점의 평균
            if (selectedRetarantReviews.Count() > 0)
            {
                double sumGrades = selectedRetarantReviews.Sum(x => x.Grade);
                int gradesCount = selectedRetarantReviews.Count();
                double gradesAvg = sumGrades / gradesCount;
                lblGrade.Text = $"{gradesAvg}";
            }
            else
            {
                lblGrade.Text = "0.0";
            }

            // 리뷰 보여주기
            // 멤버 이름 / 평점 / 코멘트
            dgvReviews.ColumnCount = 4;
            dgvReviews.Columns[0].Name = "사진";
            dgvReviews.Columns[1].Name = "멤버 이름";
            dgvReviews.Columns[2].Name = "평점";
            dgvReviews.Columns[3].Name = "코멘트";

           

            foreach (Data.Review review in selectedRetarantReviews)
            {
                ArrayList row = new ArrayList();

                // 사진 추가
                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = 30;
                pictureBox.Height = 30;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if (review.ImageLocation == null)
                {
                    pictureBox.Image = Resources.defaultImage;
                }
                else
                {
                    pictureBox.Load(review.ImageLocation);
                }
                row.Add(pictureBox);

                // 멤버
                Member reviewedMember = DataRepository.Member.GetOneMember(review.MemberId);

                // 평가 점수
                int? grade = review.Grade;
                if(grade == null)
                {
                    row.Add("X");
                } else
                {
                    row.Add(grade);
                }

                // 코멘트
                string comment = review.Comment;
                if (string.IsNullOrEmpty(comment))
                {
                    row.Add("");
                }
                else
                {
                    row.Add(comment);
                }

                dgvReviews.Rows.Add(row.ToArray());

            }

            // add row
            /*
            ArrayList row = new ArrayList();
            row.Add("0");
            row.Add("1");
            row.Add("2");
            row.Add("3");
            row.Add("4");
            dgvReviews.Rows.Add(row.ToArray());
            */


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


        Image jungsikImage = Image.FromFile("c:\\중식.png");

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "사진")
            {
                e.DefaultDraw();
                if (Convert.ToInt32(e.CellValue) == 0)
                    e.Cache.DrawImage(jungsikImage, e.Bounds.Location);
            }
        }
    }
}
