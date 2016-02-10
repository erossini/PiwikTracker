using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piwik.Tracker.Samples
{
    public class GenerateVisits
    {
        static string myToken = "f458a833a8acfb78d06e85e8e5f01d26";
        static List<string> browsers = new List<string>() { "Firefox", "Safari", "Chrome", "Internet Explorer", "Microsoft Edge" };
        static List<Country> countries = new List<Country>() {
                                                                new Country() { City = "London, City of, United Kingdom", CountryCode = "gb", Language = "English", Region = "London, City of, United Kingdom" },
                                                                new Country() { City = "Bristol, City of, United Kingdom", CountryCode = "gb", Language = "English" },
                                                                new Country() { City = "Leeds, United Kingdom", CountryCode = "gb", Language = "English" },
                                                                new Country() { City = "Manchester, Manchester, United Kingdom", CountryCode = "gb", Language = "English" },
                                                                new Country() { City = "Maharashtra, India", CountryCode = "in", Language = "English", Region = "Mumbai, Maharashtra, India" },
                                                                new Country() { City = "Maharashtra, India", CountryCode = "in", Language = "", Region = "Bangalore, Karnataka, India" },
                                                                new Country() { City = "Bayern, Germany", CountryCode = "de", Language = "German" },
                                                                new Country() { City = "Isleworth, Hounslow, United Kingdom", CountryCode = "gb", Language = "English", Region = "Isleworth, Hounslow, United Kingdom" },
                                                                new Country() { City = "Knowle, Solihull, United Kingdom", CountryCode = "gb", Language = "English", Region = "Solihull, United Kingdom" },
                                                                new Country() { City = "Rochdale, Rochdale, United Kingdom", CountryCode = "gb", Language = "English", Region = "Rochdale, United Kingdom" },
                                                                new Country() { City = "Liverpool, Liverpool, United Kingdom", CountryCode = "gb", Language = "English", Region = "Liverpool, United Kingdom" },
                                                                new Country() { City = "Georgia, United States", CountryCode = "us", Language = "English" },
                                                                new Country() { City = "Texas, United States", CountryCode = "us", Language = "English" },
                                                                new Country() { City = "", CountryCode = "", Language = ""  },
                                                             };
        static List<Resolution> resl = new List<Resolution>() {
                                                                new Resolution() { Width = 1920, Height = 1080 },
                                                                new Resolution() { Width = 1440, Height = 900 },
                                                                new Resolution() { Width = 1366, Height = 768 },
                                                                new Resolution() { Width = 1280, Height = 1024 },
                                                                new Resolution() { Width = 800, Height = 600 },
                                                                new Resolution() { Width = 640, Height = 480 },
                                                              };
        static List<string> urls = new List<string>() {
            // CIZ                                            
            //"https://www.ciz-openreach.co.uk/contact",
            //"https://www.ciz-openreach.co.uk/Infrastructure/Home/34",
            //"https://www.ciz-openreach.co.uk/Infrastructure/content/138/CAS-T-Assured-Service-formerly-IL2-compliance",
            //"https://www.ciz-openreach.co.uk/Business/Home/1",
            //"https://www.ciz-openreach.co.uk/Business/content/293/2015-Ethernet-price-reductions-slide-deck",
            //"https://www.ciz-openreach.co.uk/Business/content/173/Ethernet-Access-Direct-EAD-explained",
            //"https://www.ciz-openreach.co.uk/Business/content/247/Products-services-solutions-brochure-to-help-you-sell-business-connectivity-locally",
            //"https://www.ciz-openreach.co.uk/Business/content/124/Excess-Construction-Charges-fact-sheet",
            //"https://www.ciz-openreach.co.uk/Business/content/354/Advancing-Market-Insight",
            //"https://www.ciz-openreach.co.uk/Business/content/296/Migrating-WES-WEES-circuits-to-EAD-offer-refresh-and-expansion-slide-deck",
            //"https://www.ciz-openreach.co.uk/Business/content/359/Digital-Economy-Firm-Market-Insight",
            //"https://www.ciz-openreach.co.uk/Business/content/309/EAD-10G-available-to-order-now-slide-deck",
            //"https://www.ciz-openreach.co.uk/Business/content/134/Fibre-to-the-Premises-on-Demand-fact-sheet",
            //"https://www.ciz-openreach.co.uk/Business/search/1?f_groupname=Superfast+Fibre+Access&f_productname=GEA+FTTP&page=1",
            //"https://www.ciz-openreach.co.uk/Business/search/1?f_groupname=Superfast+Fibre+Access&f_productname=SFFA+for+Business&page=1",
            //"https://www.ciz-openreach.co.uk/Business/search/1?f_contenttype=Fact+sheet",
            //"https://www.ciz-openreach.co.uk/Consumer/Home/18",
            //"https://www.ciz-openreach.co.uk/Consumer/content/134/Fibre-to-the-Premises-on-Demand-fact-sheet",
            //"https://www.ciz-openreach.co.uk/Consumer/content/182/Phone-or-broadband-problem-",
            //"https://www.ciz-openreach.co.uk/Consumer/content/117/Generic-Ethernet-Access-over-Fibre-to-the-Premise-fact-sheet",

            // Home and work
            "http://www.homeandwork.openreach.co.uk/",
            "http://www.homeandwork.openreach.co.uk/who-to-contact/",
            "http://www.homeandwork.openreach.co.uk/who-to-contact/Complaint.aspx",
            "http://www.homeandwork.openreach.co.uk/problems-with-your-phone-or-broadband/search.aspx",
            "http://www.homeandwork.openreach.co.uk/engineer-visit/",
            "http://www.homeandwork.openreach.co.uk/openreach-explained/",
            "http://www.homeandwork.openreach.co.uk/fibre-index/",
            "http://www.homeandwork.openreach.co.uk/problems-with-your-phone-or-broadband/Default.aspx",
            "http://www.homeandwork.openreach.co.uk/problems-with-your-phone-or-broadband/incidentfaq.aspx",
        };

        /// <summary>
        /// Records a simple page view with advanced user, browser and server properties
        /// </summary>
        static public void RecordSimplePageViewWithCustomProperties(int idSite, string token, DateTime dtForceVisitServer, DateTime dtForceVisitLocal)
        {
            var piwikTracker = new PiwikTracker(idSite);
            piwikTracker.setUserAgent(browsers.PickRandom().ToString());

            //piwikTracker.setResolution(1600, 1400);

            Country c = new Country();
            c = (Country)countries.PickRandom(1).First();
            piwikTracker.setCountry(c.CountryCode);
            piwikTracker.setCity(c.City);
            if (!string.IsNullOrEmpty(c.Region))
            {
                piwikTracker.setRegion(c.Region);
            }

            string visit = "";
            piwikTracker.setUserId(visit.RandomString(16));
            //piwikTracker.setVisitorId("33c31B01394bdc65");

            piwikTracker.setForceVisitDateTime(dtForceVisitServer);

            Resolution r = new Resolution();
            r = (Resolution)resl.PickRandom(1).First();
            piwikTracker.setResolution(r.Width, r.Height);

            piwikTracker.setTokenAuth(token);

            var browserPluginsToSet = new BrowserPlugins();
            browserPluginsToSet.silverlight = true;
            browserPluginsToSet.flash = true;
            piwikTracker.setPlugins(browserPluginsToSet);
            piwikTracker.setBrowserHasCookies(true);
            piwikTracker.setBrowserLanguage(c.Language);

            piwikTracker.setLocalTime(dtForceVisitLocal);

            piwikTracker.setUrl(urls.PickRandom(1).First().ToString());
            //piwikTracker.setUrlReferrer("http://supernovadirectory.org");

            try
            {
                var response = piwikTracker.doTrackPageView("Document title of current page view");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //displayDebugInfo(response);
        }
    }
}
