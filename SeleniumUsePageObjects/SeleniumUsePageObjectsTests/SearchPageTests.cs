using System;
using NUnit.Framework;
using SeleniumUsePageObjects;

namespace SeleniumUsePageObjectsTests
{
    [TestFixture]
    class SearchPageTests:BaseTestClass
    {
        string _url = "https://www.unian.ua/search";
        [SetUp]
        public void NavigateNeedLink()
        {
            base.StartBrowser(_url);
        }

        [TestCase("погода")]
        public void Search_ByTitle_ShouldReturnValidResults(string search_item)
        {
            var SearchPage = new SearchPage(driver);

            SearchPage.SetSearchValue(search_item).SetCheckBox().ClickSearchButton();

            string result_item = SearchPage.GetSearchResult();
            StringAssert.Contains(result_item.Substring(0, result_item.Length - 1).ToLower(), search_item,
                String.Format("The search result expected to be {0}", search_item));           
        }
        [TestCase("погода", "04.03.2020")]
        [TestCase("поранення", "24.04.2020")]
        [TestCase("жителька", "08.04.2020")]
        [TestCase("справа", "23.04.2020")]
        public void Search_ByTitleAndOneDate_ShouldReturnListOfValidResults(string search_item, string search_date)
        {
            var SearchPage = new SearchPage(driver);
            string problems_message = "";

            SearchPage.SetSearchValue(search_item).SetCheckBox().SetSearchDate(search_date).ClickSearchButton();

            bool are_equal=SearchPage.CompareSearchResults(search_item, search_date, ref problems_message);
            Assert.IsTrue(are_equal, problems_message);
        }




    }
}
