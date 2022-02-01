using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infra.Migrations
{
    public partial class StartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersCredentials",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCredentials", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "BankClients",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CredentialsCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankClients", x => x.Code);
                    table.ForeignKey(
                        name: "FK_BankClients_UsersCredentials_CredentialsCode",
                        column: x => x.CredentialsCode,
                        principalTable: "UsersCredentials",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasLimit = table.Column<bool>(type: "bit", nullable: false),
                    LimitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ClientCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Code);
                    table.ForeignKey(
                        name: "FK_BankAccounts_BankClients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "BankClients",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.Code);
                    table.ForeignKey(
                        name: "FK_BankTransactions_BankAccounts_BankAccountCode",
                        column: x => x.BankAccountCode,
                        principalTable: "BankAccounts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransfers",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransfers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_MoneyTransfers_BankAccounts_BankAccountCode",
                        column: x => x.BankAccountCode,
                        principalTable: "BankAccounts",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_ClientCode",
                table: "BankAccounts",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_BankClients_CredentialsCode",
                table: "BankClients",
                column: "CredentialsCode");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_BankAccountCode",
                table: "BankTransactions",
                column: "BankAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfers_BankAccountCode",
                table: "MoneyTransfers",
                column: "BankAccountCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "MoneyTransfers");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "BankClients");

            migrationBuilder.DropTable(
                name: "UsersCredentials");
        }
    }
}
