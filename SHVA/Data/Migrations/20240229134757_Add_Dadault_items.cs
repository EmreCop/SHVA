using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHVA.Migrations
{
    /// <inheritdoc />
    public partial class Add_Dadault_items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fa6823d-3004-47ee-b55b-86554da82ee9", null, "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c17ea01a-bd38-4d4d-9c97-597c481c0542", 0, "06be31d8-2cc6-4fcb-9c11-5619f83402df", "Admin@Admin.com", true, false, null, null, "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEHs8qsBZiHjVXTwnpf7lLaD5a+csu3RzglxieaBDv2UwV5XoZADRAMrfENY6VOXqFQ==", null, false, "ZKZ4CTLIQRJTWOY6QFECHZLSQUOZNEBQ", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6fa6823d-3004-47ee-b55b-86554da82ee9", "c17ea01a-bd38-4d4d-9c97-597c481c0542" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6fa6823d-3004-47ee-b55b-86554da82ee9", "c17ea01a-bd38-4d4d-9c97-597c481c0542" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa6823d-3004-47ee-b55b-86554da82ee9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c17ea01a-bd38-4d4d-9c97-597c481c0542");
        }
    }
}
