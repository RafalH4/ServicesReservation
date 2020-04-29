using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UpdateServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Advance",
                table: "Services",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Services",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfReservation",
                table: "Services",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Services",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "FullPrice",
                table: "Services",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LeftToPay",
                table: "Services",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceProviderId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Services",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Services_ClientId",
                table: "Services",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatedById",
                table: "Services",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceProviderId",
                table: "Services",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_ClientId",
                table: "Services",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_ServiceProviderId",
                table: "Services",
                column: "ServiceProviderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_ClientId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_ServiceProviderId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ClientId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CreatedById",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceProviderId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Advance",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DateOfReservation",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FullPrice",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LeftToPay",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Services");
        }
    }
}
