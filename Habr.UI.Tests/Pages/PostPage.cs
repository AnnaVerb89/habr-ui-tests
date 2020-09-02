﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class PostPage : BasePage
    {
        public PostPage(IWebDriver driver) : base(driver)
        {

        }
        private const string _defaultPostNumber = "502746";

        public IWebElement ElementTabsPublications
        {
            get
            {
                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[1]/div/a[1]/h3"));
            }
        }
        public IWebElement ButtonBookmark
        {
            get
            {

                return Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button"));
                //By.TagName("onclick"));
                //Xpath.("/html/body/div[1]/div[3]/div/section/div[1]/div[2]/ul/li[1]/article/footer/ul/li[2]/button")
            }
        }
        public IWebElement ElementPost
        {
            get
            {

                return Driver.FindElement(By.Id("post_515544"));
            }
        }
        public void PostAddtoFavoriteBySearch(string posttext)
        {
            SeachFieldProcess(posttext);
            ButtonBookmark.Click();

            //posts_add_to_favorite(this);
            //posts_add_to_favorite(this);
            //page.SeachFieldProcess(posttext);
            //page.ButtonSearch.Click();
            //page.SearchFieldForm.SendKeys(text);
        }
        public void PostAddtoFavorite(string postNumber = _defaultPostNumber)
        {
            GoToPostPage(postNumber);

            if (!IsLogedIn)
            {
                Login();
            }

            ButtonBookmark.Click();
        }

        public void GoToPostPage(string postNumber = _defaultPostNumber)
        {
            Driver.Navigate().GoToUrl($"{MainAddress}post/{postNumber}/");
        }

    }
}
