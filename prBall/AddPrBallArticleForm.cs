using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            if (string.IsNullOrEmpty(txtKeywords.Text)||string.IsNullOrEmpty(txtMetaDescription.Text)||string.IsNullOrEmpty(txtSubtitle.Text)||string.IsNullOrEmpty(txtTitle.Text))
            {
                return;
            }

            string articleText = BallsParser.GetBallsArticleText(cfData, "БГУ", 2017);


            Article article = new Article()
            {
                ArticleID = -1,
                PortalID = 0,
                UserID = 3,
                Title = txtTitle.Text,//1
                SubTitle = txtSubtitle.Text, //2
                Summary = "", //3
                ArticleText = articleText, //4
                ArticleImage = null,
                DateAdded = DateTime.Now,
                LastModified = DateTime.Now,
                PublishDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1000),
                NumberOfViews = 0,
                RatingValue = 0,
                RatingCount = 0,
                TitleLink = UrlsData.GetUrlStringFromTitle(txtTitle.Text),//5
                DetailType = "Text",
                DetailTypeData = null,
                DetailsTemplate = "DEFAULT",
                DetailsTheme = "DEFAULT",
                GalleryPosition = "bottom",
                GalleryDisplayType = "lightbox",
                CommentsTheme = "DEFAULT",
                ArticleImageFolder = null,
                NumberOfComments = 0,
                MetaDecription = txtMetaDescription.Text,//6
                MetaKeywords = txtKeywords.Text,//7
                DisplayStyle = "DEFAULT",
                DetailTarget = "_self",
                CleanArticleData = CleanText(articleText),//8
                ArticleFromRSS = false,
                HasPermissions = false,
                EventArticle = false,
                DetailMediaType = null,
                AuthorAliasName = null,
                ShowGallery = false,
                ArticleGalleryID = null,
                MainImageTitle = null,
                MainImageDescription = null,
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

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = true;
                }
            }
        }

        public static string CleanText(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
