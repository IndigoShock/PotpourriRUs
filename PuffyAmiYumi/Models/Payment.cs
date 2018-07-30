﻿using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class Payment
    {
        public static IConfiguration Configuration;

        public Payment(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string RunPayment(Order order, ApplicationUser user)
        {
            // Set the environment that we will be running. 
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication =
                new merchantAuthenticationType()
                {
                    name = "4U4g2Z4FsJSR",
                    ItemElementName = ItemChoiceType.transactionKey,
                    Item = "49n6jV6aLrc46RuR",
                };


            // We can either hardcode the CC number, or bring it into the method. 
            // Maybe we even want to save it in a secrets file?

            // Maybe create an ENUM that will check against the different CC types and 
            // set the cc number based on the enum value
            var creditCard = new creditCardType
            {
                cardNumber = "4007000000027",
                expirationDate = "0718"
            };

            //This information is something we should be capturing from the user that signed up. 
            // It may be a good idea to capture this information in our checkout process, adn save
            // it to our Orders table. We do not have to save addresses to a users profile
            // it is ok for the user to have to manualy put it in everytime. 

            customerAddressType billingAddress = GetAddress(order, user);

            //Once we set the payment type...whcih will be CreditCard...
            var paymentType = new paymentType { Item = creditCard };



            // we need to create a transaction request so that we can eventually charge the card.
            // Note the line items attachment
            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = order.Total,
                payment = paymentType,
                billTo = billingAddress,
                lineItems = GetLineItems(order.Products),
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            // createtransactioncontroller is a controller on the AUth.net side. We need
            // to create a new controller so that we can execute the requrest. 
            var controller = new createTransactionController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            if (response != null)
            {
                // We should be getting an OK response type. 
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    // Notice the different information that we rae receiving back from the trasnaction call.
                    // Should we be saving this information into the database?
                    if (response.transactionResponse.messages != null)
                    {
                        Console.WriteLine("Successfully created transaction with Transaction ID: " +
                            response.transactionResponse.transId);
                        Console.WriteLine("Response Code: " +
                            response.transactionResponse.responseCode);
                        Console.WriteLine("Message Code: " +
                            response.transactionResponse.messages[0].code);
                        Console.WriteLine("Description: " +
                            response.transactionResponse.messages[0].description);
                        Console.WriteLine("Success, Auth Code : " +
                            response.transactionResponse.authCode);
                    }
                    else
                    {
                        Console.WriteLine("Failed Transaction.");
                        if (response.transactionResponse.errors != null)
                        {
                            Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                            Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed Transaction.");

                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                        Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                    }
                    else
                    {
                        Console.WriteLine("Error Code: " + response.messages.message[0].code);
                        Console.WriteLine("Error message: " + response.messages.message[0].text);
                    }
                }
            }
            else
            {
                Console.WriteLine("Null Response.");
            }

            return "invalid";

        }

        private static customerAddressType GetAddress(Order order, ApplicationUser user)
        {
            customerAddressType addres = new customerAddressType()
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                address = order.Street,
                city = order.City,
                zip = order.Zip
            };

            // Do database magic to get address;

            return addres;
        }


        private static lineItemType[] GetLineItems(List<OrderItems> products)
        {
            //Get line items from the order
            var lineItems = new lineItemType[products.Count];
            int count = 0;
            foreach (OrderItems p in products)
            {

                lineItems[count] = new lineItemType
                {
                    itemId = (p.ItemID).ToString(),
                    name = p.ItemName,
                    unitPrice = p.Price,
                    quantity = p.Quantity,
                    
                };

                count++;
            }
            return lineItems;
        }
    }
}