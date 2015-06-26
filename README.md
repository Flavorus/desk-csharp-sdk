Desk.com C# SDK
===============

The Desk.com C# SDK is a work in progress (really, nothing more). The
solution contains classes that helps you connect to and work with the
desk.com API.

If you need an SDK that supports everything that the desk.com API has
to offer, this is not for you (at least not yet). The SDK can be used
for all desk.com API services, but only has strongly-typed components
for some of them.

However, since the core logic is very general, extending the SDK with
what you miss should be a breeze. Just have a look at the things that
already exists, and follow the same patten.


Resources
---------

You can find more information about the SDK at the following places:

	Project:		http://github.com/danielsaidi/desk-csharp-sdk
	NuGet package:	http://nuget.org/packages/desk
	Blog:			http://danielsaidi.wordpress.com
	Twitter:		@danielsaidi
	
Contributions to this project are more than welcome. If you build the
next great feature, fix a bug, improve a unit test etc., just send me
a pull request or get in touch.


Getting started
---------------

To get started with SDK, either grab the source code from the project
site, download a zip from the release section or add a reference from
within Visual Studio, using NuGet.

Once you have a reference in place, you can create a DeskApi instance,
using the base url to your desk.com app's API, the key and the secret
of your desk app, as well as an OAUTH token and token secret. As such:

	var api = new DeskApi("url", "key", "secret", "token", "token secret");

With a DeskApi instance in place, you can start calling the API. This
approach is very flexible and supports all existing API services, but
you will have to know the url to each service as well as which params
each service supports. Use the call method to call the API:

	var response = api.Call("topics.json", Method.GET)
	
If you do not want to care about service urls, request parameters and
If you do not want to sremember service urls, request parameters and
other API details, use the DeskApiMapper class. To create an instance,
you must provide it with an already setup api instance.

	var apiMapper = new DeskApiMapper(api);

The DeskApiMapper class adds a strongly typed layer on top of the API.
It has methods for each service (the ones it supports) and a strongly
typed set of request parameters, which makes it really easy to define
what to send to the API when making a request.

The DeskApiMapper is really convenient, but until all API methods are
mapped, you will need the DeskApi class as well.


Mapped API resources
--------------------

Content resources
 - topics 



Unmapped API resources (todo)
-----------------------------

Case resources
 - cases 
 - cases/show 
 - case/update 

Customer resources
 - customers 
 - customers/show 
 - customers/create 
 - customers/update 
 - customers/emails/create 
 - customers/emails/update 
 - customers/phones/create 
 - customers/phones/update 

Interaction resources
 - interactions 
 - interaction/create 

User resources
 - groups 
 - groups/show 
 - users 
 - users/show 

Content resources
 - topics/show 
 - topics/create 
 - topics/update 
 - topics/destroy 
 - topics/articles 
 - topics/articles/create 
 - articles/show 
 - articles/update 
 - articles/destroy 

Macro resources
 - macros 
 - macros/create 
 - macros/show 
 - macros/update 
 - macros/destroy 
 - macros/actions 
 - macros/actions/show 
 - macros/actions/update 

