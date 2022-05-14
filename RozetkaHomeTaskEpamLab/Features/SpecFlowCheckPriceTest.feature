Feature: SpecFlowCheckPriceTest
	In order to purchase new product
	As a User
	I want to find product from search input window, input brand into search brand input window,
	than sort products by drop-down menu, order first and check that product's price lower than price limit.

@smoke
Scenario Outline: Sorting of products, ordering first product and checking that price lower than the limit
	Given I enter search text '<searchText>' in search input field
	And I press search button
	When I input the brand '<brand>' in brand search menu
	And I click brand checkbox
	And I sort items by necessary '<typeOfSort>' in sorting drop-down menu
	And I take the first product and click order to cart button
	And I click cart button ang go to cart window
	Then I check if price of product in cart is less then price limit '<priceLimit>'

	Examples: 
	| searchText | brand | typeOfSort             | priceLimit |
	| laptop     | razer | От дорогих к дешевым   | 120000     |
	| телефон    | nokia | Популярные             | 1500       |
