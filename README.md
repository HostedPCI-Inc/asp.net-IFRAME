asp.net-IFRAME
==============

iframe asp.net demo


Need to set configuration parameters of HosterPCI IFrame.

They are in javascript in the view:
https://github.com/HostedPCI-Inc/asp.net-IFRAME/blob/master/HostedPCI.WebUI/Views/Shared/_Layout.cshtml

Parameters:
var hpciLocation = ""; //  - is the location reference within the HPCI application. Locations are configured through the HPCI customer portal.

var hpciSiteId = ""; // - is the site id (a number) configured and provided by HPCI after the activation of the HPCI account. There will be a different Site Id for staging and live sites.

var thisSiteHostName = ""; // - is the full hostname where the parent ecommerce site resides (not the iframe).

var thisURLQueryString = ""; //  - is the query string currently used by the payment page where the iframe resides. This parameter is required for backward compatibility with browsers that do not support “post” frame messages. This string has to match the current url that appears on the browser address bar.

For example, at http://hostedpci-iframe.demo.com/Order/checkout these parameters are:
var hpciLocation = "checkout1";
var hpciSiteId = "528160";
var thisSiteHostName = "http://hostedpci-iframe.demo.com";
var thisURLQueryString = "/order/checkout";
