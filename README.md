# Jf.MySql.Data.Collations

![GitHub License](https://img.shields.io/github/license/jeffraska/Jf.MySql.Data.Collations)
![Nuget](https://img.shields.io/nuget/v/Jf.MySql.Data.Collations)


This library solves connection problems of [MySQL Connector/NET](https://github.com/mysql/mysql-connector-net) to newest versions of MariaDB (>=10.10.1) with implemented UCA-14.0.0 collations.

## Licensing

This library is released under [MIT license](LICENSE.txt).

## How it works

Library modifies `SHOW COLLATION` query using `BaseCommandInterceptor` to prevent fetching collations with NULL Id's.
There is also small piece of code which append `utf8mb3` charset to MySql.Data's internal mapping Dictionary allowing
to read fields with utf8mb3 collations.

## Usage

1. Install NuGet package
2. Append following line to your connection string

    `;commandinterceptors=Jf.MySql.Data.Collations.Interceptor,Jf.MySql.Data.Collations`
3. Call `Utf8mb3.Enable()` before opening first MySql connection.
