using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EinkaufslisteV2
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //http://adicodes.com/tip-disable-mobile-master-page-in-asp-net/
            var AlternateView = "Desktop";
            var switchViewRouteName = "AspNet.FriendlyUrls.SwitchView";
            var url = GetRouteUrl(switchViewRouteName, new { view = AlternateView, __FriendlyUrls_SwitchViews = true });
            url += "?ReturnUrl=" + HttpUtility.UrlEncode(Request.RawUrl);
            Response.Redirect(url);

        }
    }
}