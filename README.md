# ZooParkWeb

> University-era ASP.NET MVC 5 project: a zoo/park website with animal exhibit management, an image carousel, and a visitor guestbook.

`University coursework` · Individual (unconfirmed — no group roster or commit history survived to check)
**Stack:** ASP.NET MVC 5 · C# · Razor views · SQL Server (via `System.Data.SqlClient`) · Bootstrap 3 / jQuery (NuGet content packages)

## Overview

Despite the controller name `DepEmpController` (a leftover from the ASP.NET MVC scaffolding template — "Department/Employee" is the classic tutorial CRUD example), the actual views under it are animal-exhibit management (`動物管理.cshtml`) and a public animal-park showcase (`園區動物介紹.cshtml`). `FinalController` serves the homepage (`首頁.cshtml`) and a visitor guestbook (`評論區.cshtml`) with create/edit/reply actions. Each feature follows the same three-layer shape: a Controller, a `*DBService` class that talks to SQL Server directly via `System.Data.SqlClient`, and a `*ViewModel` that shapes data for the Razor view.

## Running It

This is a classic (non-SDK-style) ASP.NET MVC 5 project targeting the full .NET Framework — it needs Visual Studio, not just the `dotnet` CLI. Verified in this environment: `dotnet build ZooParkWeb.sln` fails with `MSB4019: 找不到 Import 專案 ...Microsoft.WebApplication.targets` — that target only ships with Visual Studio's "ASP.NET and web development" workload, not the .NET SDK.

1. Open `ZooParkWeb.sln` in Visual Studio 2019+ (with the ASP.NET and web development workload installed).
2. Let Visual Studio restore NuGet packages (Build > Restore NuGet Packages, or right-click the solution > Restore NuGet Packages). This reinstalls `packages/` **and** the content files this repo intentionally does not track — `Scripts/*.js` (jQuery, jQuery Validate, Modernizr) and `Content/bootstrap*.css` (Bootstrap). The `.csproj` still lists these as `<Content Include>` items; they will show as missing in Solution Explorer until NuGet restores them.
3. Update the connection string in `ZooParkWeb/Web.config` (`<connectionStrings>`) to point at your own SQL Server instance — the original pointed at `Server=localhost` with a blank `User ID`/`Password`, which won't work outside the original dev machine.
4. Build and run (F5).

## Limitations

- Not verified to actually build end-to-end: this environment has no Visual Studio / MSBuild with the web-application targets and no classic `nuget.exe`, so the NuGet content-package restore step above is documented but untested here.
- No database schema or seed data is included — `Web.config`'s `Initial Catalog` name is the only clue to what the database should be called; table structure has to be inferred from the `Models/` and `*DBService` classes.
- No tests.

## Structure

    ZooParkWeb/Controllers/     DepEmp (animal exhibits), Final (homepage + guestbook), Home
    ZooParkWeb/Services/        Direct SQL Server data access (one *DBService per feature)
    ZooParkWeb/ViewModels/      View-shaping types passed from Services to Views
    ZooParkWeb/Views/           Razor views (mixed English/Chinese filenames)
    ZooParkWeb/Content/Site.css Project's own stylesheet (Bootstrap CSS itself is not tracked, see above)
