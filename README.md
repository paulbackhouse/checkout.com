<h1>Checkout.com Cart Api Test</h1>
<p>
    <strong>Current Api Version:</strong> 1.0
    <br />
    <br />
  A <strong>Sandbox</strong><sup>*</sup> is available as part of the project where you can find information about the supported HTTP request types,
    the models along with a playground where you can try each request out with real data.
  <br /><strong>Sandbox Url</strong> http://localhost:&lt;port&gt:/swagger
</p>

*<strong>Note</strong> the sandbox makes use of SwaggerUI and currently there is a bug where by you have to click each request header twice to view more information about the request and expectations. TODO: Fix bug

<h2>Continuous Integration &amp; Deployment</h2>
<p>
This repository currently integrates and deploys into an Azure environment where Production Urls are as follows: 
</p>

<ul>
    <li>Website: <a href="https://checkoutcartapi.azurewebsites.net/home" target="_blank">https://checkoutcartapi.azurewebsites.net/home</a> where you will find client libraries available for download</li>
    <li>Sandbox: <a href="https://checkoutcartapi.azurewebsites.net/swagger" target="_blank">https://checkoutcartapi.azurewebsites.net/swagger</a></li>
</ul>


<h2>Prerequisties</h2>

<p>
    This solution is developed in Dot Net 2.0 and requires Visual Studio Community 2017 or higher to correctly open, view and run. For more details see: <a href="https://www.visualstudio.com/" target="_blank">https://www.visualstudio.com/</a>
</p>

<p>
Using the Task View window (Visual Studio > View > Task List) TODO tasks are noted as expected refactor/code update before beta.
</p>

<h2>Solution</h2>
<p>
    This test consists of the following projects:
</p>

<ul>
    <li>
        <strong>Checkout.Application</strong>
        <br />Contains business logic for services and repositories responsible for data operations, such as retrieving and saving data;
    </li>
    <li>
        <strong>Checkout.Application.Tests</strong>
        <br />Unit tests for Checkout.Application;
    </li>
    <li>
        <strong>Checkout.EntityFramework</strong>
        <br />Contains database configuration (such as model indexes or complex keys) and initialsation i.e. seed data. It is worth noting this prototype uses an <i>In Memory</i> representation of the database;
    </li>
    <li>
        <strong>Checkout.Models</strong>
        <br />Contains entity definitions which describe the structures in which data can be saved, i.e. tables;
    </li>
    <li>
        <strong>Checkout.Web</strong>
        <br />The core WebApi application, containing REST API controller Endpoints for countries, products and cart management;
    </li>
    <li>
        <strong>Checkout.Web.Client</strong>
        <br />Contains generated client library code, based off <a href="https://github.com/RSuter/NSwag" target="_blank">nswag.json</a> configuration file.
        Examples are available in <i>CSharp</i> and <i>Typescript</i>;
    </li>
    <li>
        <strong>Checkout.Web.Console</strong>
        <br />Provides a real world example of how to use the CSharp client library code in Checkout.Web.Client. The file Program.cs demonstrates how to use the Client Library and has examples of each endpoint usage.
    </li>
    <li>
        <strong>Checkout.Web.Tests</strong>
        <br />Unit tests for Checkout.Web.
    </li>
</ul>

<h2>Setup</h2>

<p>
    Clone or download this repository to your local machine. Then click the file <strong>Checkout.com.sln</strong> file, this should open the solution correctly whereby you will be presented with an N-layer solution. Ensure you set the Startup project to Checkout.Web. Then, right click the solution icon and select BUILD.
</p>

