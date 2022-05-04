# DDD_MediatR_Clean

Project Specs:
    Language: C#
    Framework: ASP.Net Core 5
    Approach: DDD
    Database: SQL SERVER
    Type: Rest Api

Description:
    create a .net core web api project that implements two endpoints:

    1. Get list of products with pagination
       Endpoint : /Products
       Product  Structure (properties) :
           Id : Guid
           Title : string
           Type : enum
           Price : double
           Color : enum

    2. Search Products with pagination
       Endpoint : /Products/Search
       Search Params : type, color


    *secure endpoints using basic authentication
