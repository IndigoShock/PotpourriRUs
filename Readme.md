# Welcome to Potpourri-R-Us!
Check out our site here - https://puffyamiyumi20180802033427.azurewebsites.net/

## Overview
Potpourri-R-Us is an E-Commerce site that sells only Potpourri for users who are interested in a specialty or niche store.

**Authors**: Collin Hintzke & Stephen Harper<br />
**Version**: 1.0.0

## Getting Started
**The following is required to run the program.**
1. Visual Studio 2017 
2. The .NET desktop development workload enabled
3. ASP.NET web API packages

## Visuals
Home Page
- ![HomePage](PuffyAmiYumi/wwwroot/asset/PotpourriHome.JPG)

Shop Page
- ![Visual 2](PuffyAmiYumi/wwwroot/asset/PotpourriShop.JPG)

Cart Page
- ![Visual 3](PuffyAmiYumi/wwwroot/asset/PotpourriCart.JPG)

Payment Page
- ![Visual 4](PuffyAmiYumi/wwwroot/asset/PotpourriPayment.JPG)

## Architecture
This application is created using ASP.NET Core 2.1 Web Application <br />
*Languages*: C#, SQL <br />
*Libraries*: ASP.NET, Bootstrap, SwaggerUI <br />
*Type of Application*: Web Application <br />

## Claims
The claims we are enforcing are First Name, Last Name, Birthday, Email and Password. We chose these because for someone to register, the basics is to have their name, birthday and email. It seems to make sense since people would want to if they were to purchase at a store. And if they want to login to their account unique to them, they would create a password.

## Policies
The policies we are enforcing are Email and whichever role the user is assigned. The two roles are Member and Admin. We want these two policies because each user will upon registration have an email. And that email will be connected to a Member or an Admin role. If the email is for aa Admin, they will have Admin privileges. Otherwise, the user will have Member access.

##OAuth Providers
The OAuth Providers we chose are Microsoft and Google.

## Database Schema
![Db Schema](PuffyAmiYumi/wwwroot/asset/PotpourriDbSchema.png)

#Explanation Of Database Schema
This application is using two databases. One called the YumiDatabase and the other called the ApplicationDatabase. The YumiDatabase is primarily for the products. The ApplicationDatabase is primarily for the Application Users.
Since the YumiDatabase is more about the products and the basket, this will be explained more here. The Application database is connected to the YumiDatabase by the Products and Cart but only so through Identity. Once the user is registered then logged in, they will have access to the YumiDatabase. Depending on their access, they will have access to Products or the Cart plus CartItem. Admins have access to the Products while the Member will have access to the Cart and CartItem. Products are in line with every piece of detail of the item such as the Product Name, Products Id, SKU, how much left in Stock and Price.  The product information is derived from the hard-coded info stored in the database.The Member will be able to see all of these except for the stock since this information is more private.
Since the YumiDatabase is more about the products and the basket, this will be explained more here. The Application database is connected to the YumiDatabase by the Products and Cart but only so through Identity. Once the user is registered then logged in, they will have access to the YumiDatabase. 
Depending on their access, they will have access to Products or the Cart plus CartItem. Admins have access to the Products while the Member will have access to the Cart and CartItem. Products are in line with every piece of detail of the item such as the Product Name, Products Id, SKU, how much left in Stock and Price.  The product information is derived from the hard-coded info stored in the database.The Member will be able to see all of these except for the stock since this information is more private.
Instead, they see the Cart and CartItem, which will be attached to their account. Each Cart will have a list of CartItems. And the CartItems have more detailed properties like Name, ProductId, Image, Pricing and so on.

## Vulnerability Report
Here is a link to our [VulnerabilityReport](VulnerabilityReport.md)
