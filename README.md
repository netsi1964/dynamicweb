# Dynamicweb

[![Join the chat at https://gitter.im/netsi1964/dynamicweb](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/netsi1964/dynamicweb?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
> A Xamarin solution containing various code for Dynamicweb CMS system.

> How about you? Would you like also to contribute to this repository?
> Lets build some usefull extensions for Dynamicweb! TagExtensions which makes life nicer for us coding CMS using Dynamicweb.
> I ask you to contact me on twitter: @netsi1964

## The idea
We need to share code for Dynamicweb. As I have just begun coding backend code using Xamarin Studio (on Mac!) it has opened doors and I have only just begun! No man is an island, so I would love others to share their code and contribute here. I would love to have a DLL containing some usefull stuff, like TagExtensions.

I write this version as a Solution which can also be opened in Visual Studio. I try to seperate the code in different classes and I try to make my classes as generic as possible. For instance I write:

*  A console project, for testing offline functions
*  A class containing functionality and serving as a "util" or "Base" class. For instance my Tag Extensions use it when doing their job, they only serve as proxies. Functionality is not put into the Tag Extensions, as I want the function of them to be useful for Razor templates also.
*  Tag Extensions live in their own namespace
*  Backend created items. A sandbox where I want to put basic example of how to create items using backend code.
  
So You are free to use it!

## Class: netsi1964.util
This class contains the raw functions like `TimeAgo()` which can be used in your Dynamicweb Templates if they use `Razor` based templates.

## Class: netsi1964.tagExtension
Dynamicweb CMS lets you code your own "tag extensions". They allow you to manipulate output from tags in general, in same way as jQuery does using *method chaining*. Look at this example:


```
	<!--@News:Date-->
```
That tag will return the date of a news item. It could be say: `2014/06/01`. If you then extend the output as this:

```
	<!--@News:Date.TimeAgo()-->
```
You will take the value (date) of the news date and convert it into a "relative date" like this:
`5 months ago`.

Another thing with tagExtensions is that you can choose to *ignore* the value of the current tag value, giving the tagExtension a "life of its own". It can for instance be used to pull out a relative time without actually having a tag with a date like this:

```
	<!--@News:Date.TimeAgo("2014/06/01")-->
```

### Request(string Url, string xpath)
This tagextension lets you do a server side request and insert the elements found using the given xpath [default:"//body"].
For example:

```
	<!--@News:Date.Request("http://www.dr.dk", "")-->
```

Result will be HTML from `<body>` of dr.dk

## Class: netsi1964.Experimental
Here I put code which are on a "sandbox" state - for instance "`request (string Url, string xPathSearch)`" which will pull content from any given `Url`, run a `XPath` on the requested HTML using specified `xPathSearch` (if you have ever used XSLT, you will know XPath). and return the resulting HTML.

### getDatalistAsXML(int datalistid)
This is a way to insert XML output from a datalist publication. You will need to create a datalist and add a publication.
You do not need to assign an XSLT but normally you would transform into the required format.

```
	<!--@News:Date.getDatalistAsXML(1)-->
```

### getDatalistAsJSON(int datalistid)
This is a way to insert a JSON version of XML output from a datalist publication. You will need to create a datalist and add a publication. You do not need to assign an XSLT but normally you would transform into the required format.

```
	<!--@News:Date.getDatalistAsJSON(1)-->
```

### Method: String transform(string xmlInput, string xslInput)
I found a need to be able to transform two strings: An XML and an XSLT, so that method is also in the Experimental class.
It is not exposed as a tagExtension, however it can be used in Razor like this:

```
	@transform("<xml..>", "<xslt...>")
```
