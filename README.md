<h1>Checkout.com Cart Api Test</h1>

<hr />
<p>
    <strong>Current Api Version:</strong> 1.0
    <br />
    <br />
  A <strong>Sandbox</strong><sup>*</sup> is available as part of the project where you can find information about the supported HTTP request types,
    the models along with a playground where you can try each request out with real data.
  <br /><strong>Sandbox Url</strong> http://localhost:<port>/swagger
</p>

* <strong>Note</strong> the sandbox makes use of SwaggerUI and currently there is a bug where by you have to click each request header twice to view more information about the request and expectations. TODO: Fix bug

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
        <br />Provides a real world example of how to use the CSharp client library code in Checkout.Web.Client;
    </li>
    <li>
        <strong>Checkout.Web.Tests</strong>
        <br />Unit tests for Checkout.Web;
    </li>
</ul>
