using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace prBall
{
    public partial class AddPrBallArticleForm : Form
    {
        private List<CFData2016> cfData;

        public AddPrBallArticleForm()
        {
            InitializeComponent();
        }

        public AddPrBallArticleForm(List<CFData2016> cfData):this()
        {
            this.cfData = cfData;
        }

        private void AddArticle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVuzName.Text) || string.IsNullOrEmpty(txtKeywords.Text)||string.IsNullOrEmpty(txtMetaDescription.Text)||string.IsNullOrEmpty(txtTitle.Text))
            {
                return;
            }

            if (cfData != null)
            {

                string articleText = BallsParser.GetBallsArticleText(cfData, txtVuzName.Text, 2017);


                Article article = new Article()
                {
                    ArticleID = -1,
                    PortalID = 0,
                    UserID = 3,
                    Title = txtTitle.Text,//1
                    SubTitle = txtSubtitle.Text, //2
                    Summary = "", //3
                    ArticleText = articleText, //4
                    ArticleImage = "",
                    DateAdded = DateTime.Now.AddHours(-5),//смещение часовых поясов - 5
                    LastModified = DateTime.Now.AddHours(-5),
                    PublishDate = DateTime.Now.AddHours(-5),
                    ExpireDate = DateTime.Now.AddYears(1000),
                    NumberOfViews = 0,
                    RatingValue = 0,
                    RatingCount = 0,
                    TitleLink = UrlsData.GetUrlStringFromTitle(txtTitle.Text),//5
                    DetailType = "Text",
                    DetailTypeData = "",
                    DetailMediaData = "",
                    DetailsTemplate = "DEFAULT",
                    DetailsTheme = "DEFAULT",
                    GalleryPosition = "bottom",
                    GalleryDisplayType = "lightbox",
                    CommentsTheme = "DEFAULT",
                    ArticleImageFolder = "",
                    NumberOfComments = 0,
                    MetaDecription = txtMetaDescription.Text,//6
                    MetaKeywords = txtKeywords.Text,//7
                    DisplayStyle = "DEFAULT",
                    DetailTarget = "_self",
                    CleanArticleData = CleanText(articleText),//8
                    ArticleFromRSS = false,
                    HasPermissions = false,
                    EventArticle = false,
                    DetailMediaType = "",
                    AuthorAliasName = "",
                    ShowGallery = false,
                    ArticleGalleryID = null,
                    MainImageTitle = "",
                    MainImageDescription = "",
                    HideDefaultLocale = false,
                    Featured = false,
                    Approved = true,
                    AllowComments = true,
                    Active = true,
                    ShowMainImage = false,
                    ShowMainImageFront = false,
                    ArticleImageSet = false,
                    CFGroupeID = null,
                    DetailsDocumentsTemplate = null,
                    DetailsLinksTemplate = null,
                    DetailsRelatedArticlesTemplate = null,
                    ContactEmail = null,
                    TitleTag = null
                };

                int tagIdPrBalls2017 = 1714;
                int abiturientCategoryId = 45;

                Data.CreateNewArticle(article);

                if (article.ArticleID > 0)
                {
                    Data.SetTag(article.ArticleID, tagIdPrBalls2017);
                    Data.SetCategory(article.ArticleID, abiturientCategoryId);
                }

                MessageBox.Show("Статья о проходных баллах добавлена в БД.");
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            if (ofdLoad.ShowDialog() == DialogResult.OK)
            {
                cfData = ExcelData.LoadFromExcel(ofdLoad.FileName);



                foreach (var control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Enabled = true;
                    }
                }
            }

        }

        public static string CleanText(string input)
        {
            string str = Regex.Replace(input, "<.*?>", " ");

           

            bool isNotDoubleSpaces = false;

            while(isNotDoubleSpaces)
            {
                str = str.Replace("  ", " ");
                if (!str.Contains("  "))
                {
                    isNotDoubleSpaces = true;
                }
            }
            str = str.Trim();

            return str;
        }

        private void txtVuzName_Leave(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = ((TextBox)control).Text.Replace("<>", txtVuzName.Text);
                }
            }
        }
    }
}
