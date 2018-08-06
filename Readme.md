#Welcome to Potpourri-R-Us!#
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
- ![Visual 1](~asset/PotpourriHome.JPG)
- ![Visual 2](~asset/PotpourriShop.JPG)
- ![Visual 3](~asset/PotpourriCart.JPG)
- ![Visual 4](~assetPotpourriPayment.JPG)

## Architecture
This application is created using ASP.NET Core 2.1 Web Application <br />
*Languages*: C#, SQL <br />
*Libraries*: ASP.NET, Bootstrap, SwaggerUI <br />
*Type of Application*: Web Application <br />

##Claims
The claims we are enforcing are First Name, Last Name, Birthday, Email and Password. We chose these because for someone to register, the basics is to have their name, birthday and email. It seems to make sense since people would want to if they were to purchase at a store. And if they want to login to their account unique to them, they would create a password.

##Policies
The policies we are enforcing are Email and whichever role the user is assigned. The two roles are Member and Admin. We want these two policies because each user will upon registration have an email. And that email will be connected to a Member or an Admin role. If the email is for aa Admin, they will have Admin privileges. Otherwise, the user will have Member access.

##OAuth Providers
The OAuth Providers we chose are Microsoft and Google.

##Database Schema
![Db Schema](~/asset/PotpourriDbSchema.png)

#Explanation Of Database Schema
This application is using two databases. One called the YumiDatabase and the other called the ApplicationDatabase. The YumiDatabase is primarily for the products. The ApplicationDatabase is primarily for the Application Users.
Since the YumiDatabase is more about the products and the basket, this will be explained more here. The Application database is connected to the YumiDatabase by the Products and Cart but only so through Identity. Once the user is registered then logged in, they will have access to the YumiDatabase. Depending on their access, they will have access to Products or the Cart plus CartItem. Admins have access to the Products while the Member will have access to the Cart and CartItem. Products are in line with every piece of detail of the item such as the Product Name, Products Id, SKU, how much left in Stock and Price.  The product information is derived from the hard-coded info stored in the database.The Member will be able to see all of these except for the stock since this information is more private.
Since the YumiDatabase is more about the products and the basket, this will be explained more here. The Application database is connected to the YumiDatabase by the Products and Cart but only so through Identity. Once the user is registered then logged in, they will have access to the YumiDatabase. 
Depending on their access, they will have access to Products or the Cart plus CartItem. Admins have access to the Products while the Member will have access to the Cart and CartItem. Products are in line with every piece of detail of the item such as the Product Name, Products Id, SKU, how much left in Stock and Price.  The product information is derived from the hard-coded info stored in the database.The Member will be able to see all of these except for the stock since this information is more private.
Instead, they see the Cart and CartItem, which will be attached to their account. Each Cart will have a list of CartItems. And the CartItems have more detailed properties like Name, ProductId, Image, Pricing and so on.

## Change Log
**Week One** <br />
*Monday* - Scaffold files, deployed to azure, implemented seed data, Set up databases, YumiDb and ApplicationDb.<br />
*Tuesday* - Created Homepage, Login Page, Register Account Page, Implemented Identity
*Wednesday* - Added in Products into Database. Shared-navbar made. Set up Claims and Policy for Admin and Member users. Handler has a class which requires Email. ViewModel made for Login and Register.<br /> 
*Thursday* - Created Admin controller. Added more onto the AccountController.<br />
*Friday* - <br />

**Week Two** <br />
*Monday* - Created a products page to show all of the products in the store.<br />
*Tuesday* - Added more onto the AdminController.<br />
*Wednesday* - Created ShopController with CRUD operations. Created Interfaces for Cart. <br />
*Thursday* - Created Cart with cart items. Created CartController. Created View Components. Added OAuth for Microsoft and Google.<br />
*Friday* - Day was taken off for Career Development Day.

**Week Three** <br />
*Monday* - TBD <br />
*Tuesday* - TBD <br />
*Wednesday* - TBD <br />
*Thursday* - TBD <br />
*Friday* - TBD <br />