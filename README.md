#SPA Authentication

When I started looking at Single Page Applications I wanted to understand what the authentication story was, but the information was fragmented and often had no examples or the example was difficult to follow.

The idea behind this repository was to provide a single place where you can find simple examples of authentication that you can follow and understand what and how its doing it.

#Samples

Currently the repository only has samples around Web Api as that is what I have been working on but hopefully there will be more as time goes on.

Each sample is a standalone project with, in .Net projects, NuGet restore so that everything that is needed is pulled down when you build it.

You'll find more information about each sample in the readme in each project. 

## Username & password
All of the samples follow the [Thinktecture samples](https://github.com/thinktecture/Thinktecture.IdentityModel.45/tree/master/Samples/Web%20API%20Security) in that to sucessfully log in username just has to match the password, except for Forms Auth sample the page will have username bob and password filled in for you.

##HTTPS

To make it easier to run the samples they are currently configured to run over HTTP but in reality **all** of them should be run under HTTPS especially anything only using basic authentication.