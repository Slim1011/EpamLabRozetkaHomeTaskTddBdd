using NUnit.Framework;
using RozetkaHomeTaskEpamLab.DataSource;
using RozetkaHomeTaskEpamLab.rozetkaPages;
using RozetkaHomeTaskEpamLab.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RozetkaHomeTaskEpamLab.rozetkaTests
{
    class VerifyThatBucketContainsGoodAndPriceIsCorrectTest : BaseTest
    {
        private const int timeToWait = 10;

        [Test]
        
        public void VerifyThatBucketContainsProductWithCorrectPriceTest()
        {
            try
            {
                Filters.InitCurrent();
                HomePage homePage = GetHomePage();
                homePage.SendKeysToSearchInput(Filters.Current.TypeOfGood);
                homePage.ClickSearhcButton();
                SearchPage searchPage = GetSearchPage();
                searchPage.WaitElementIsEnable(timeToWait, searchPage.GetSearchBrandInput());
                searchPage.SendKeysToSearchBrandInput(Filters.Current.Brand);
                searchPage.ClickCheckBox();
                searchPage.checkSortOfPriceFromDropdownMenu(Filters.Current.TypeOfSort);
                searchPage.WaitElementIsEnable(timeToWait, searchPage.GetFirstProduct());
                searchPage.ChooseFirstProduct();
                searchPage.ClickCartButton();
                CartPage cartPage = GetCartPage();
                cartPage.WaitVisibilityOfElement(timeToWait, GetCartPage().GetPriceWindow());
                Assert.IsTrue(GetCartPage().GetTextFromPriceWindow() < Filters.Current.PriceLimit);

            }
            catch (Exception ex)
            {

                Log.Error(ex, "Error log");
            }

            
        }
    }
}
