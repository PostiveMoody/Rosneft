using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rosneft.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RequestCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "RequestCardIdSequence",
                minValue: 1L,
                maxValue: 100000L);

            migrationBuilder.CreateTable(
                name: "RequestCard",
                columns: table => new
                {
                    RequestCardId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR RequestCardIdSequence"),
                    Initiator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectOfAppeal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeadlineForHiring = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestCardVersion = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCard", x => x.RequestCardId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestCard");

            migrationBuilder.DropSequence(
                name: "RequestCardIdSequence");
        }
    }
}
