

using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Dtos;

public class HomeDto
{
    public int Id { get; set; }
    [Required]
    public string GeneralizedAddress { get; set; }
    public string? MlsNumber { get; set; }
    public double BedRooms { get; set; }
    public double BathRooms { get; set; }
    public long Price { get; set; }
    public string? Brokerage { get; set; }
    public string? Type { get; set; }
    public string? SubType { get; set; }
    public string? YearBuilt { get; set; }
    public string? NeighborHood { get; set; }
    public string? Basement { get; set; }
    public string? Description { get; set; }
    public string LinkUrl { get; set; } = null!;
    public bool NewConstruction { get; set; }
    public bool FromRemax { get; set; }
    public bool Rentable { get; set; }
    public string? BuilderName { get; set; }
    public string? FeaturesAndFinishes { get; set; }
    public long? RentPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? AddressFkId { get; set; }
    public int? RealEstateBrokerFkId { get; set; }
    public string? GenSlug { get; set; }

    public  Location? AddressFk { get; set; }
    public  Realestatebroker? RealEstateBrokerFk { get; set; }
    public  ICollection<Imagelink>? Imagelinks { get; set; }
    public  ICollection<Room>? Rooms { get; set; }
}