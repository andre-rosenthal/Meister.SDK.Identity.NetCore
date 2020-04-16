using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meister.SDK.Identity.NetCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeisterConnection",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Gateway = table.Column<string>(nullable: false),
                    Client = table.Column<string>(nullable: true),
                    SAPUser = table.Column<string>(nullable: false),
                    SAPPassword = table.Column<byte[]>(nullable: true),
                    Authentication = table.Column<int>(nullable: false),
                    CompanyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeisterConnection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Secret = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Secret = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ConnectionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_MeisterConnection_ConnectionId",
                        column: x => x.ConnectionId,
                        principalTable: "MeisterConnection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_ConnectionId",
                table: "Company",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserId",
                table: "Company",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeisterConnection_CompanyId",
                table: "MeisterConnection",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeisterConnection_Company_CompanyId",
                table: "MeisterConnection",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Company_CompanyId",
                table: "User",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_MeisterConnection_ConnectionId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_User_UserId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "MeisterConnection");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
