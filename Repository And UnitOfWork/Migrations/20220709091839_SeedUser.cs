using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FirstProject_MVC.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 0;i < 50;i++)
            {
                migrationBuilder.InsertData(
                    "Users",
                    columns: new []
                    {
                        "Id",
                        "UserName",
                        "Email",
                        "SecurityStamp",
                        "EmailConfirmed",
                        "PhoneNumberConfirmed",
                        "TwoFactorEnabled",
                        "LockoutEnabled",
                        "AccessFailedCount",
                    },
                    values: new object[]
                    {
                        Guid.NewGuid().ToString(),
                        $"User-{i}",
                        $"email{i}@gmail.com",
                        Guid.NewGuid().ToString(),
                        true, 
                        false, 
                        false,
                        false,
                        0
                    }

                );
            }    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
