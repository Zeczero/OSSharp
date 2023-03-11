# OSSharp
Simple HTTP API Wrapper for [onlinesim.io](https://onlinesim.io/).
An online virtual phone number provider.

## 🏁 Getting started

### Sample code
```cs
var smsReception = new SMSReception(new HttpClient(), "YOUR API KEY");
var orderNumber = await smsReception.OrderNumber("vkcom");
var statistics = await smsReception.GetNumberStatistics("telegram").Price;
var orderState = await smsReception.GetOrderState();
var phoneNumber = orderState[0].Number;

```
