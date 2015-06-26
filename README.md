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



Contact
-------

For more info about this project and other things that I'm working on:

	Project site:	http://github.com/danielsaidi/desk-csharp-sdk
	NuGet package:	http://nuget.org/packages/desk
	Blog:			http://danielsaidi.wordpress.com
	Twitter:		@danielsaidi
	
Contributions to this project are more than welcome. If you build the
next great feature, fix a bug, improve a unit test etc., just send me
a pull request or get in touch.