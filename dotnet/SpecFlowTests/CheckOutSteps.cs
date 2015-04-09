using System;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class CheckOutSteps
    {
        [Given(@"That there are items in the shopping cart")]
public void GivenThatThereAreItemsInTheShoppingCart()
{
    ScenarioContext.Current.Pending();
}

        [When(@"The User confirms the order")]
public void WhenTheUserConfirmsTheOrder()
{
    ScenarioContext.Current.Pending();
}

        [When(@"The User inputs the billing information")]
public void WhenTheUserInputsTheBillingInformation()
{
    ScenarioContext.Current.Pending();
}

        [When(@"The System confirms the order")]
public void WhenTheSystemConfirmsTheOrder()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"The System updates the inventory")]
public void ThenTheSystemUpdatesTheInventory()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"The System displays order confirmation")]
public void ThenTheSystemDisplaysOrderConfirmation()
{
    ScenarioContext.Current.Pending();
}
    }
}
