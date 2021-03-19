using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWork.Migrations
{
    public partial class CreateAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Running",
                columns: table => new
                {
                    RunningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunningCode = table.Column<string>(type: "varchar(20)", nullable: true),
                    RunningDes = table.Column<string>(type: "varchar(50)", nullable: true),
                    RunningPrefix = table.Column<string>(type: "varchar(50)", nullable: true),
                    RunningYear = table.Column<string>(type: "varchar(5)", nullable: true),
                    RunningPrevious = table.Column<int>(type: "int", nullable: false),
                    RunningLast = table.Column<int>(type: "int", nullable: false),
                    RunningNext = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Running", x => x.RunningId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Fullname = table.Column<string>(type: "varchar(100)", nullable: true),
                    TelNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "char(2)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Running");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
