using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prBall
{
    public partial class AddPrBallArticleForm : Form
    {
        public AddPrBallArticleForm()
        {
            InitializeComponent();
        }

        private void AddArticle_Click(object sender, EventArgs e)
        {
            Article article = new Article()
            {
                ArticleID = -1,
                PortalID = 0,
                UserID = 3,
                Title = "",//1
                SubTitle = "", //2
                Summary = "", //3
                ArticleText = "", //4
                ArticleImage = null,
                DateAdded = DateTime.Now,
                LastModified = DateTime.Now,
                PublishDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1000),
                NumberOfViews = 0,
                RatingValue = 0,
                RatingCount = 0,
                TitleLink = "",//5
                DetailType = "Text",
                DetailTypeData = null,
                DetailsTemplate = "DEFAULT",
                DetailsTheme = "DEFAULT",
                GalleryPosition = "bottom",
                GalleryDisplayType = "lightbox",
                CommentsTheme = "DEFAULT",
                ArticleImageFolder = null,
                NumberOfComments = 0,
                MetaDecription = "",//6
                MetaKeywords = "",//7
                DisplayStyle = "DEFAULT",
                DetailTarget = "_self",
                CleanArticleData = "",//8
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
    }
}
