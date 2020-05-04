using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System;
using HelpClass;

namespace SeleniumUsePageObjects
{
    public class SearchPage
    {
        IWebDriver _driver;
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        //elements
        [FindsBy(How = How.XPath, Using = "//div[@class='result-form__search ']/input[@name='q']")]
        public IWebElement SearchField;
        [FindsBy(How = How.CssSelector, Using = "label[for=searchCheck2]")]
        public IWebElement SearchCheckbox;
        [FindsBy(How = How.CssSelector, Using = "[name=search_date]")]
        public IWebElement SearchDate;
        [FindsBy(How = How.ClassName, Using = "news-inline-item")]
        public IList<IWebElement> Search_results { get; set; }

        //get_values
        public string GetSearchResult() { return Search_results[0].FindElement(By.XPath(".//span")).Text; }
        

        //actions
        public SearchPage ClickSearchButton()
        {
            SearchField.FindElement(By.XPath("../button")).Click();
            return this;
        }
        public SearchPage SetSearchValue(string item)
        {
            SearchField.SendKeys(item);
            return this;
        }
        public SearchPage SetSearchDate(string date)
        {
            SearchDate.SendKeys(String.Concat(date, " - ", date));
            return this;
        }
        public SearchPage SetCheckBox()
        {
            SearchCheckbox.Click();
            return this;
        }
        public bool CompareSearchResults(string search_item,string search_date,ref string problems)
        {
            bool are_equal = true;
            foreach(IWebElement e in Search_results)
            {
                string item_result = e.FindElement(By.XPath(".//*[@class='search--query']")).Text;
                if (search_item.Contains(item_result.Substring(0, item_result.Length - 1).ToLower()))
                {
                    string item_date_result = e.FindElement(By.XPath(".//*[@class='item time']")).Text;
                    if (!item_date_result.Contains(Help.ReplaceMonth(search_date)))
                    {
                        are_equal = false;
                        problems = String.Format("Search date expected - {0}, but was - {1}", Help.ReplaceMonth(search_date), item_date_result);
                        break;
                    }
                }
                else
                {
                    are_equal = false;
                    problems = String.Format("The search result expected to be {0},but was - {1}", search_item, item_result);
                    break;
                }
                
            }
            return are_equal;
        }
        
    }
}
