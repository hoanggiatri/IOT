using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoT.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "WeatherDatas");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "DeviceInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "DeviceInfos");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "WeatherDatas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
