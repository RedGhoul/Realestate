using System.Diagnostics;
using Application.Queries.Home;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Service;

namespace RealEstate.Controllers;

public class IndexController : Controller
{
    private readonly IMediator _mediator;

    public IndexController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var randomHomes = await _mediator.Send(new RandomHomeQuery() { randomHomeCount = 5 });
        
        var aggregateHomeInfoResponse = await _mediator.Send(new AggregateHomeInfoQuery() {
            Cities = true,
            LandType = true,
            ListingCount = true,
            GroupedCities = true,
            LandTypesFromHomes = true,
        });

        var countByCity = await _mediator.Send(new CountByCityQuery()
        {
            MinNumberCountOfHomes = 800,
            MaxNumberOfHomesToReturn = 20
        });

        IndexViewModel vm = new()
        {
            ListingCount = aggregateHomeInfoResponse.ListingCount,
            Cities = aggregateHomeInfoResponse.Cities,
            LandTypesForHomes = aggregateHomeInfoResponse.LandTypesFromHomes,
            GroupedCities = aggregateHomeInfoResponse.GroupedCities,
            LandType = aggregateHomeInfoResponse.LandType,
            CountByCity = countByCity.countModels,
            RandomHomes = randomHomes,
        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}