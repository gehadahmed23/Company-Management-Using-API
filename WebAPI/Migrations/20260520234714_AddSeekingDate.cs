using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeekingDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b6a2c3d-4444-5555-6666-abcdef654321", null, "User", "USER" },
                    { "9a7b3c1d-1111-2222-3333-abcdef123456", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAgree", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7c5b1a2d-7777-8888-9999-abcdefabcdef", 0, "89f5f11b-1d16-47a5-b780-1f5f6c32b98e", "admin@gmail.com", true, true, false, null, "Gehad Admin", "ADMIN@gmail.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHu2JTrAYJS4at2RBkDq3oW5j0e34YVJuO0ZGe559SVPCT4SVp3VVT5KYgIYfZVN8w==", null, false, "36b8763b-161a-4731-ae03-c68f598bd4f4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9a7b3c1d-1111-2222-3333-abcdef123456", "7c5b1a2d-7777-8888-9999-abcdefabcdef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b6a2c3d-4444-5555-6666-abcdef654321");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a7b3c1d-1111-2222-3333-abcdef123456", "7c5b1a2d-7777-8888-9999-abcdefabcdef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a7b3c1d-1111-2222-3333-abcdef123456");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c5b1a2d-7777-8888-9999-abcdefabcdef");
        }
    }
}
