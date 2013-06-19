using GalaxySports.WebUI.HtmlHelpers;
using GalaxySports.WebUI.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GalaxySports.UnitTests.GalaxySports.WebUI.Tests
{
    [TestFixture]
    public class PagingHelpersTests
    {
        [Test]
        public void PageLinks_PageInfo_CorrectLinksOnPages()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = PagingHelpers.PageLinks(myHelper, pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>", result.ToString());
        }
    }
}
