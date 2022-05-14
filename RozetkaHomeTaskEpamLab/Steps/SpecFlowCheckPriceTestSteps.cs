using NUnit.Framework;
using RozetkaHomeTaskEpamLab.rozetkaPages;
using RozetkaHomeTaskEpamLab.rozetkaTests;
using System;
using TechTalk.SpecFlow;

namespace RozetkaHomeTaskEpamLab.Steps
{

    [Binding]
    public class SpecFlowCheckPriceTestSteps : BaseTest
    {
        private const int timeToWait = 10;
        HomePage homePage;
        SearchPage searchPage;
        CartPage cartPage;


        [Given(@"I enter search text '(.*)' in search input field")]
        public void EnterSearchTextInSearchInputField(string searchText)
        {
            homePage = GetHomePage();
            homePage.SendKeysToSearchInput(searchText);
        }
        
        [Given(@"I press search button")]
        public void PressSearchButton()
        {
            homePage.ClickSearhcButton();
        }
        
        [When(@"I input the brand '(.*)' in brand search menu")]
        public void InputTheBrandInBrandSearchMenu(string brand)
        {
            searchPage = GetSearchPage();
            searchPage.WaitElementIsEnable(timeToWait, searchPage.GetSearchBrandInput());
            searchPage.SendKeysToSearchBrandInput(brand);
        }
        
        [When(@"I click brand checkbox")]
        public void ClickBrandCheckbox()
        {
            
            searchPage.ClickCheckBox();
        }
        
        [When(@"I sort items by necessary '(.*)' in sorting drop-down menu")]
        public void SortItemsInSortingMenu(string typeOfSort)
        {
            searchPage.checkSortOfPriceFromDropdownMenu(typeOfSort);
        }
        
        [When(@"I take the first product and click order to cart button")]
        public void TakeTheFirstProductAndClickOrderToCartButton()
        {
            searchPage.WaitElementIsEnable(timeToWait, searchPage.GetFirstProduct());
            searchPage.ChooseFirstProduct();
            searchPage.ClickCartButton();
        }
        
        [When(@"I click cart button ang go to cart window")]
        public void ClickCartButtonAngGoToCartWindow()
        {
            
            cartPage = GetCartPage();
            cartPage.WaitElementIsEnable(timeToWait, cartPage.GetPriceWindow());
        }
        
        [Then(@"I check if price of product in cart is less then price limit '(.*)'")]
        public void CheckIfPriceOfProductIsLessThenPriceLimit(string priceLimit)
        {
            Assert.IsTrue(cartPage.GetTextFromPriceWindow() < int.Parse(priceLimit));
        }
    }
}
