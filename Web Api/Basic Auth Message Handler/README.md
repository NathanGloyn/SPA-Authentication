# Basic Auth - Mesage Handler

This sample uses a Message Handler which will receive the requests before they hit the controllers allowing our custom authentication and then to use the normal .Net Authorize filter.

## Note

This has code in the handler which when first logging in will return the request without actually hitting the controllers at all, it seems nice and *acts* like the Thinktecture samples but is most likely a **HACK** if you wanted to do this yourself I would not recommend following this approach without further research.