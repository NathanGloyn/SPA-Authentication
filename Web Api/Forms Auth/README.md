# Forms Authentication

This sample uses the standard .Net forms authentication mechanism.

Users need to log in through a separate view to the SPA itself, but once logged in the auth cookie will be sent on each request.


## Timeout 

If the users auth cookie expires it is possible to login over ajax but it requires that the action you call explicitly creates the auth cookie and ideally shouldn't return a view just a 200 Ok response.

The timeout has been set to 1 minute to make it easy to see what happens when an auth cookie expires, it also has additional code to call the original action requested if the cookie is expired.