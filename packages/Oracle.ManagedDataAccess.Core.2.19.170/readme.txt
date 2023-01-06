Oracle.ManagedDataAccess.Core NuGet Package 2.19.170 README
===========================================================
Release Notes: Oracle Data Provider for .NET Core

October 2022

This provider supports .NET Core 3.1 and .NET 6.

This document provides information that supplements the Oracle Data Provider for .NET (ODP.NET) documentation.

You have downloaded Oracle Data Provider for .NET. The license agreement is available here:
https://www.oracle.com/downloads/licenses/distribution-license.html


Bug Fixes since Oracle.ManagedDataAccess.Core NuGet Package 2.19.160
====================================================================
Bug 34322469 - CONNECTION POOL THROWS "CONNECTION REQUEST TIMED OUT" EXCEPTION DUE TO LOOPING WITHIN POOLMANAGER.GET()
Bug 34535726 - OPTIMIZE SOCKET LEVEL CHECKS WHEN CONNECTIONS ARE CHECKED-IN / CHECKED-OUT
Bug 34540655 - USE DEDICATED THREADS WHEN CREATING CONNECTIONS FOR "MIN POOL SIZE"
Bug 34521258 - BULKCOPY OPERATION RESULTS IN ORA-39776
Bug 33956107 - BIND BY NAME PERFORMANCE OPTIMIZATION


Known Issues and Limitations
============================
1) BindToDirectory throws NullReferenceException on Linux when LdapConnection AuthType is Anonymous

https://github.com/dotnet/runtime/issues/61683

This issue is observed when using System.DirectoryServices.Protocols, version 6.0.0.
To workaround the issue, use System.DirectoryServices.Protocols, version 5.0.1.

 Copyright (c) 2021, 2022, Oracle and/or its affiliates. 
