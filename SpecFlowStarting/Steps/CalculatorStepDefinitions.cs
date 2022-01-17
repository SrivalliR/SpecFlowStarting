using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;

namespace SpecFlowStarting.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the number is (.*)")]
        public void GivenTheNumberIs(int numbers)
        {
            Console.WriteLine("The number is "+ numbers);
        }


        //[Given("the first number is (.*)")]
        //public void GivenTheFirstNumberIs(int number)
        //{
        //    Console.WriteLine("The First Number is ", number);
        //}

        //[Given("the second number is (.*)")]
        //public void GivenTheSecondNumberIs(int number)
        //{
        //    Console.WriteLine("The Second Number is ", number);
        //}

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("Press Add button");
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            if(result==120)
                Console.WriteLine("Test Passed");
            else
            {
                Console.WriteLine("Test Failed");
                throw new Exception("Values are different");

            }
        }
        
        //scenerio 2 & 5
        [When(@"I filled all the fields")]
        public void WhenIFilledAllTheFields(Table table)
        {
            //var details = table.CreateSet<EmployeeDetails>();

            //foreach (EmployeeDetails emp in details)
            //{
            //    Console.WriteLine("The details of Employee " + emp.name);
            //    Console.WriteLine("----------------------------------");

            //    Console.WriteLine(emp.name);
            //    Console.WriteLine(emp.age);
            //    Console.WriteLine(emp.phone);
            //    Console.WriteLine(emp.email);
            //}

            //Create dynamic 
            var emplist = table.CreateDynamicSet();
            foreach (var employee in emplist)
            {
                Console.WriteLine(employee.Name);
                Console.WriteLine(employee.Age);
                Console.WriteLine(employee.Phone);
                Console.WriteLine(employee.Email);
            }
        }

        //scenerio 3 - Scenerio Outline & Examples

        //[When(@"I filled all the fields (.*), (.*), (.*) and (.*)")]
        //public void WhenIFilledAllTheFieldsKarthikAndKarthinkGmail_Com(string name,int age,Int64 phone, string email)
        //{
        //    Console.WriteLine(name);
        //    Console.WriteLine(age);
        //    Console.WriteLine(phone);
        //    Console.WriteLine(email);

        //}

        //Scenerio 4- Scenerio Context

        [When(@"I filled all the fields (.*), (.*), (.*) and (.*)")]
        [Obsolete]
        public void WhenIFilledAllTheFieldsKarthikAndKarthinkGmail_Com(string name, int age, Int64 phone, string email)
        {
            //Console.WriteLine(name);
            //Console.WriteLine(age);
            //Console.WriteLine(phone);
            //Console.WriteLine(email);

            ScenarioContext.Current["Message"] = "ScenerioContext Message";
            Console.WriteLine(ScenarioContext.Current["Message"].ToString());

            List<EmployeeDetails> EmpDetails = new List<EmployeeDetails>()
            {
                new EmployeeDetails
                {
                    name="ABC",
                    age=30,
                    phone=898788788,
                    email="ads@kdkf.com"
                },
                new EmployeeDetails
                {
                    name="Xyz",
                    age=35,
                    phone=6776777777,
                    email="ajd@dklsd.com"
                },
                new EmployeeDetails
                {
                    name="Asdf",
                    age=23,
                    phone=3343353343,
                    email="sdf@dfsd"
                }
            };

            //Save the values in SceneioContext
            ScenarioContext.Current.Add("empdetails", EmpDetails);

            //Retrieve the values from ScenerioContext

            var emplist = ScenarioContext.Current.Get<IEnumerable<EmployeeDetails>>("empdetails");

            foreach (EmployeeDetails emp in emplist)
            {
                Console.WriteLine("Employee Name" + emp.name);
                Console.WriteLine("Employee age" + emp.age);
                Console.WriteLine("Employee phone" + emp.phone);
                Console.WriteLine("Employee email" + emp.email);
                Console.WriteLine("-----------------------------");
            }

            Console.WriteLine(ScenarioContext.Current.CurrentScenarioBlock);
            Console.WriteLine(ScenarioContext.Current.Count);
            Console.WriteLine(ScenarioContext.Current.ScenarioInfo.Title);


        }

    }
}
