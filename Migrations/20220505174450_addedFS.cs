using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace RealEstate.Migrations
{
    public partial class addedFS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "searchvector",
                table: "realestatebroker",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "name", "brokerage" });

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "searchvector",
                table: "location",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "city", "exact_address", "postal_code" });

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "searchvector",
                table: "home",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "generalized_address", "mls_number", "brokerage", "type", "sub_type", "year_built", "neighbor_hood", "description", "features_and_finishes", "gen_slug" });

            migrationBuilder.CreateIndex(
                name: "IX_realestatebroker_SearchVector",
                table: "realestatebroker",
                column: "searchvector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_location_SearchVector",
                table: "location",
                column: "searchvector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_home_SearchVector",
                table: "home",
                column: "searchvector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_realestatebroker_SearchVector",
                table: "realestatebroker");

            migrationBuilder.DropIndex(
                name: "IX_location_SearchVector",
                table: "location");

            migrationBuilder.DropIndex(
                name: "IX_home_SearchVector",
                table: "home");

            migrationBuilder.DropColumn(
                name: "searchvector",
                table: "realestatebroker");

            migrationBuilder.DropColumn(
                name: "searchvector",
                table: "location");

            migrationBuilder.DropColumn(
                name: "searchvector",
                table: "home");
        }
    }
}
