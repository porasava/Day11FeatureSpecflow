using Day11FeatureSpecflow.Pages;
using Day11FeatureSpecflow.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Day11FeatureSpecflow.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I loged into TurnUp portal successfully")]
        public void GivenILogedIntoTurnUpPortalSuccessfully()
        {
            driver2 = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActionTM(driver2);

        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver2);
        }

        [Then(@"I create a new time record")]
        public void ThenICreateANewTimeRecord()
        {
            TMPage TMPageObj = new TMPage();

            //Create
            TMPageObj.Create_TimeRecord(driver2);
        }

        [Then(@"the time record should be created successfully")]
        public void ThenTheTimeRecordShouldBeCreatedSuccessfully()
        {
           TMPage tmPageObject = new TMPage();
            string newCode = tmPageObject.GetCode(driver2);
            string newDescription = tmPageObject.GetDescription(driver2);
            string newPrice =tmPageObject.GetPrice(driver2);
            Assert.That(newCode == "HelloTan", "New Code and expected code do Not match.");
            Assert.That(newDescription == "HelloTanDes", "New Description and expected code do Not match.");
            Assert.That(newPrice == "$111.00", "New Price and expected code do Not match.");
          

        }

        [Then(@"I edit a time record")]
        public void ThenIEditATimeRecord()
        {
            TMPage TMPageObj = new TMPage();
            TMPageObj.Update_TimeRecord(driver2);
        }

        [Then(@"the time record should be edited successfully")]
        public void ThenTheTimeRecordShouldBeEditedSuccessfully()
        {
            TMPage tmPageObject = new TMPage();
            string newCode = tmPageObject.GetCode(driver2);
            string newDescription = tmPageObject.GetDescription(driver2);
            string newPrice = tmPageObject.GetPrice(driver2);


            Assert.That(newCode == "HelloTan1", "New Code and expected code do Not match.");
            Assert.That(newDescription == "HelloTanDes1", "New Description and expected code do Not match.");
            Assert.That(newPrice == "$111.00", "New Price and expected code do Not match.");
            
        }

        [Then(@"I delete a time record")]
        public void ThenIDeleteATimeRecord()
        {
            TMPage TMPageObj = new TMPage();
            TMPageObj.Delete_TimeRecord(driver2);
        }

        [Then(@"the time record should be deleted successfully")]
        public void ThenTheTimeRecordShouldBeDeletedSuccessfully()
        {
            TMPage tmPageObject = new TMPage();
            string DeletedRecord = tmPageObject.GetLastRecordDeleted(driver2);
            Assert.AreNotEqual("HelloTan1", DeletedRecord, "Last record is equal to 'HelloTan1'.");
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver1 != null)
            {
                driver1.Quit();
                driver1 = null; // Optional: Set it to null after quitting to avoid accidental usage
            }

            // Check if the second driver is not null before quitting
            if (driver2 != null)
            {
                driver2.Quit();
                driver2 = null; // Optional: Set it to null after quitting to avoid accidental usage
            }
        }
    }
}
