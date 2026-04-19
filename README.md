# Yarp.ApiGateway
YARP (Yet Another Reverse Proxy) is a highly customizable, high-performance reverse proxy library developed by Microsoft to help .NET developers build API Gateways for microservices. Unlike pre-packaged gateways like NGINX or Kong, YARP is a toolkit built on top of ASP.NET Core, allowing you to customize routing and security logic using familiar C# code and middleware.

Api Gateways are used to remove the cross cutting concern problems like security, logging etc. It basically helps to avoid repeated code so we dont need to write same code in every service. For this POC, I just picked one example, JWT auth. We can have the validation logic in YARP and just blindly route it to other services. But that is not a secured practice. Because if YARP is compromised, other services are also compromised. So for that reason we are validating JWT in every service. For that I used a extension method that is from some other project, added to this project as a dll. Refer to appsettings.json for how service to service routing is configured. We have created a clusters that catches if route parameter is matching (/api/Auth/{*catch-all*}).

Flow goes like this Client -----> YARP --------> Individual Services.
Client basically calls the YARP endpoints not the actual service endpoints.
