# Dynamicweb
> A Xamarin solution containing various code for Dynamicweb CMS system.

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
