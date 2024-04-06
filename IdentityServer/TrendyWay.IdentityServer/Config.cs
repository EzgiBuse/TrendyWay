﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace TrendyWay.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog")
           {
               Scopes={"CatalogFullPermission","CatalogReadPermission"}
           },
           new ApiResource("ResourceDiscount")
           {
               Scopes={"DiscountFullPermission"}
           },
           new ApiResource("ResourceOrder")
           {
               Scopes={"OrderFullPermission"}
           },
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
          
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()

        };



        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for Catalog operations"),
            new ApiScope("CatalogReadPermission","Authority for Catalog read operations"),
            new ApiScope("DiscountFullPermission","Full authority for Discount operations"),
            new ApiScope("OrderFullPermission","Full authority for Order operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="TrendywayVisitorId",
                ClientName="TrendyWayVisitorUser",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("trendywaysecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission" }

             },
            //Manager
            new Client
            {
                ClientId="TrendywayManagerId",
                ClientName="TrendyWayManagerUser",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("trendywaysecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }

             },
            //Admin
            new Client
            {
                ClientId="TrendywayAdminId",
                ClientName="TrendyWayAdminUser",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("trendywaysecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission" ,
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile

                },
                AccessTokenLifetime=900


             }
        };
    }
}