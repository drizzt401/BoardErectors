Accent Design .NET Web Developer Technical Test
===============================================

## Coding Test

We would like you to create a web application using C#.NET that queries an API and displays the information received. 

One of Accent's major clients manages property 'For Sale' boards for estate agents across the UK. For this test, we have made an API available at http://boarderectors-api.accentstaging.co.uk/ that you will use to get information about properties managed by a specified estate agent, including the address of each property, the type of board at the property and the board's current status. We'd like you to use the PropertiesByCustomer endpoint that is documented at http://boarderectors-api.accentstaging.co.uk/swagger.

As an example, http://boarderectors-api.accentstaging.co.uk/agents/ACC001/properties returns a list of properties managed by Accent Estate Agents, who have the customer code 'ACC001', including current board types and statuses.

The task is to build upon the provided MVC application to add functionality that accepts customer code as a parameter, and does the following:

* Displays the following information about each property managed by the customer, by querying our API:
  * Property Address
  * Erected Board Type
  * Total Fee Charged
* Apply a levy to the fee charged for certain properties
  * For properties which have an erected board type of "sold", a levy of 7.5% must be applied to the total fee charged before it is displayed
  * For those with "sale agreed", a 4% levy should be applied
* Shows "grand total" of the fees charged for the properties

Feel free to spend as much or as little time on the exercise as you like as long as the following requirements have been met.

Your code should compile and run in one step.
Feel free to use whatever libraries / packages you like.
You should include tests for the most criticial code
Please avoid including artefacts from your local build (such as NuGet packages or the bin folder(s)) in your final ZIP file


## Technical Questions

1. How long did you spend on the coding test? What would you add to your solution if you had more time?  

 **ANSWER: About a day** 

2. What is the most useful feature that was recently added to .NET? Please include a snippet of code that shows how you've used it. 

 **ANSWER: I think "most useful" is subjective to opinion however one that I like is the hot reload feature in Visual Studio that enables you to make changes to your code while it's running. Another feature which I like but didn't use due to my older version of Visual Studio is the ability of System.Text.Json Serializer to asynchronously deserialize/serialize IAsyncEnumerable objects which means we don't have to use the former <Task<IEnumerable<T>> which was a blocking code**
 
3. How would you track down a performance issue in production? Have you ever had to do this?

 **ANSWER: Most performance issues can be tracked with proper logging i.e logging request times and response times. External applications like Sentry can also be used **
 
