# Basic Auth - Nancy

This sample shows how to implement basic authentication within Nancy and shows how to secure routes using Nancy's security.

Modules are marked with `this.RequiresAuthentication();` and each request for that route is inspected by `IUserValidator`.

