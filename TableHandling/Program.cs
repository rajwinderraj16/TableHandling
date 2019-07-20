using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TableHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the driver
            IWebDriver driver = new ChromeDriver();

            //Launch the url
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/admin/viewSystemUsers");

            driver.Manage().Window.Maximize();
            //Enter the username
            driver.FindElement(By.XPath("//input[@id='txtUsername']")).SendKeys("Admin");

            //Enter the password
            driver.FindElement(By.XPath("//input[@id='txtPassword']")).SendKeys("admin123");

            //Click on the login btn
            driver.FindElement(By.XPath("//input[@id='btnLogin']")).Click();


            //Mouse Hover on Admin tab to select it
            IWebElement admin = driver.FindElement(By.XPath("//b[contains(text(),'Admin')]"));
            Actions act = new Actions(driver);
            act.MoveToElement(admin).Build().Perform();


            //Mouse Hover on usermanagement 
            IWebElement usermanage = driver.FindElement(By.XPath("//a[@id='menu_admin_UserManagement']"));
            act.MoveToElement(usermanage).Build().Perform();

            //Click on usermanagement 
            driver.FindElement(By.XPath("//a[@id='menu_admin_viewSystemUsers']")).Click();

            //Retreive the all value from all Rows in the table
            IList<IWebElement> rows = driver.FindElements(By.XPath("//table[@id='resultTable']//tbody//tr"));
            for (int r = 2; r <= rows.Count; r++)
            {

                String rowval = driver.FindElement(By.XPath("//table[@id='resultTable']//tbody//tr[" + r + "]")).Text;

                Console.WriteLine(rowval);

            }

            //Retreive the all value from all Rows in the table with Enhanced for loop
            IList<IWebElement> rows1 = driver.FindElements(By.XPath("//table[@id='resultTable']//tbody//tr"));

            int totalrow = rows1.Count;
            Console.WriteLine(totalrow);

            foreach (IWebElement row in rows1)
            {
                string RowValue = row.Text;
                Console.WriteLine(RowValue);
            }




            // Retreive the all values of coulumns header in the table with for enhanced loop
            IList<IWebElement> colss = driver.FindElements(By.XPath("//table[@id='resultTable']//tr//th"));

            int totalcolunm = colss.Count;
            Console.WriteLine(totalcolunm);

            Thread.Sleep(2000);
            foreach (IWebElement col in colss)
            {
                string ColValue = col.Text;
                Console.WriteLine(ColValue);


                //To Check how many Employees are enabled
                IList<IWebElement> Enablerows = driver.FindElements(By.XPath("//table[@id='resultTable']//tbody//tr//td[5]"));

                int status = 0;

                for (int e = 2; e <= Enablerows.Count; e++)
                {

                    String rowval = driver.FindElement(By.XPath("//table[@id='resultTable']//tbody//tr[" + e + "]//td[5]")).Text;

                    if (rowval.Equals("Enabled"))
                    {
                        status = status + 1;
                    }

                }

                Console.WriteLine("The total number of enabled employee" + status);


                //To Retrive a particular employee from the table
                IList<IWebElement> rrows = driver.FindElements(By.XPath("//table[@id='resultTable']//tbody//tr//td[5]"));

                Thread.Sleep(2000);
                for (int r = 2; r <= rrows.Count; r++)
                {

                    String username = driver.FindElement(By.LinkText("linda.anderson")).Text;


                    if (username == "linda.anderson")
                    {
                        Console.WriteLine(username);
                    }


                    //To Retrive a values from particular row
                    String firstrow = driver.FindElement(By.XPath("//table[@id='resultTable']//tbody//tr[1]")).Text;
                    Console.WriteLine(firstrow);


                    //To Retrive particular entire coulumn/ AND verify particular record is present  in that row or not
                    String beforexpath = "html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[1]/form[1]/div[4]/table[1]/tbody[1]/tr[";
                    String afterxpath = "]/td[2]/a[1]";

                    for (int e = 1; e <= 28; e++)
                    {
                        String actualxpath = beforexpath + e + afterxpath;
                        IWebElement usersname = driver.FindElement(By.XPath(actualxpath));
                        Console.WriteLine(usersname.Text);

                        if (usersname.Text.Equals("Rishabh Ambani"))
                        {
                            Console.WriteLine("The user name: " + usersname.Text + "is found" + "at position:" + e);

                            break;
                        }
                    }

                    //Count the total number of columns
                    String beforexpathh = "/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[1]/form[1]/div[4]/table[1]/thead[1]/tr[1]/th[";
                    String afterxpathh = "]";

                    IList<IWebElement> totalcol = driver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[1]/form[1]/div[4]/table[1]/thead[1]/tr[1]/th"));

                    int cols = totalcol.Count;

                    Console.WriteLine("The total number of cols are: " + cols);


                    Console.WriteLine("The cols values are: ");

                    for (int e = 1; e <= cols; e++)
                    {
                        IWebElement actpath = driver.FindElement(By.XPath(beforexpathh + e + afterxpathh));

                        String colval = actpath.Text;

                        Console.WriteLine(colval);
                    }


                }
            }
        }
    }


}












