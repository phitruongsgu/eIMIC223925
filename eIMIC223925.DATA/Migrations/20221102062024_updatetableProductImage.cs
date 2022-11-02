using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eIMIC223925.DATA.Migrations
{
    public partial class updatetableProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 13, 31, 40, 584, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("139b9d0b-967b-454a-b471-b2bb5f6c7522"),
                column: "ConcurrencyStamp",
                value: "773b5370-9f32-47fc-af7c-3a1f1293a650");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e456f0d6-9364-47c8-bfa0-0c9bdbfe0e64", "AQAAAAEAACcQAAAAEH3uJLcbIbBYr6rrhVJXbaXyj1F0efoETk028HBEn0/bqHfac/6npF4PG7b6+5CFzA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 2, 13, 20, 24, 102, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 13, 31, 40, 584, DateTimeKind.Local).AddTicks(2271),
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("139b9d0b-967b-454a-b471-b2bb5f6c7522"),
                column: "ConcurrencyStamp",
                value: "ff01d3ec-f025-450d-b162-d26badce3e25");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d1799cc-d3db-4f3d-b717-29290f741924", "AQAAAAEAACcQAAAAEEQSiPKFssrTqKYIbE8m71Y86mVPE+goL+9UDS4hO+2UKrTlp0Lfy0dANJFuOtw5lQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 1, 13, 31, 40, 600, DateTimeKind.Local).AddTicks(1513));
        }
    }
}
