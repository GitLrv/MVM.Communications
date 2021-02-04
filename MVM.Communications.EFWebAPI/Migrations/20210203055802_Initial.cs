using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVM.Communications.EFWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsgStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsgType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsecutiveControl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgTypeId = table.Column<int>(nullable: false),
                    Prefix = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    Sec = table.Column<int>(nullable: false),
                    Consecutive_Length = table.Column<int>(nullable: false),
                    Date_Control = table.Column<DateTime>(type: "datetime", nullable: false, comment: "The last number asignated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsecutiveControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsecutiveControl_MsgType",
                        column: x => x.MsgTypeId,
                        principalTable: "MsgType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Profile",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    FirsName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Mobil = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Employee1",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MsgRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefix = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    Sec = table.Column<int>(nullable: false),
                    DocManagerContactId = table.Column<int>(nullable: false),
                    Received_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Delivered_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    MsgTypeId = table.Column<int>(nullable: false, comment: "Communication Type"),
                    Digitalization = table.Column<bool>(nullable: false, comment: "Determina si la comunicación ya fue digitalizada."),
                    MsgStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgRecord", x => x.Id);
                    table.UniqueConstraint("AK_MsgRecord_Sec", x => x.Sec);
                    table.ForeignKey(
                        name: "FK_MsgRecord_Contacts",
                        column: x => x.DocManagerContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MsgRecord_MsgStatus",
                        column: x => x.MsgStatusId,
                        principalTable: "MsgStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MsgRecord_MsgType",
                        column: x => x.MsgTypeId,
                        principalTable: "MsgType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Digitalization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgRecordSec = table.Column<int>(nullable: false),
                    MediaTypeId = table.Column<int>(nullable: false),
                    ResourcePath = table.Column<string>(maxLength: 500, nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Digitalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Digitalization_MediaType",
                        column: x => x.MediaTypeId,
                        principalTable: "MediaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Digitalization_MsgRecord",
                        column: x => x.MsgRecordSec,
                        principalTable: "MsgRecord",
                        principalColumn: "Sec",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MsgContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgRecordSec = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    ContactTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MsgContact_Contacts",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MsgContact_ContactType",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MsgContact_MsgRecord",
                        column: x => x.MsgRecordSec,
                        principalTable: "MsgRecord",
                        principalColumn: "Sec",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsecutiveControl_MsgTypeId",
                table: "ConsecutiveControl",
                column: "MsgTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_OrganizationId",
                table: "Department",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Digitalization_MediaTypeId",
                table: "Digitalization",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Digitalization_MsgRecordSec",
                table: "Digitalization",
                column: "MsgRecordSec");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProfileId",
                table: "Employee",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MsgContact_ContactId",
                table: "MsgContact",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MsgContact_ContactTypeId",
                table: "MsgContact",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MsgContact_MsgRecordSec",
                table: "MsgContact",
                column: "MsgRecordSec");

            migrationBuilder.CreateIndex(
                name: "IX_MsgRecord_DocManagerContactId",
                table: "MsgRecord",
                column: "DocManagerContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MsgRecord_MsgStatusId",
                table: "MsgRecord",
                column: "MsgStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MsgRecord_MsgTypeId",
                table: "MsgRecord",
                column: "MsgTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsecutiveControl");

            migrationBuilder.DropTable(
                name: "Digitalization");

            migrationBuilder.DropTable(
                name: "MsgContact");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "MsgRecord");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "MsgStatus");

            migrationBuilder.DropTable(
                name: "MsgType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
