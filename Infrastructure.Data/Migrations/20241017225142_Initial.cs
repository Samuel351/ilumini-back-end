using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "form",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recipient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "forminstance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaunchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forminstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_forminstance_form_FormId",
                        column: x => x.FormId,
                        principalTable: "form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    LikertType = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_question_form_FormId",
                        column: x => x.FormId,
                        principalTable: "form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormInstanceRecipient",
                columns: table => new
                {
                    FormInstancesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormInstanceRecipient", x => new { x.FormInstancesId, x.RecipientsId });
                    table.ForeignKey(
                        name: "FK_FormInstanceRecipient_forminstance_FormInstancesId",
                        column: x => x.FormInstancesId,
                        principalTable: "forminstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormInstanceRecipient_recipient_RecipientsId",
                        column: x => x.RecipientsId,
                        principalTable: "recipient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "option",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_option_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forminstanceresponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forminstanceresponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_forminstanceresponse_forminstance_FormInstanceId",
                        column: x => x.FormInstanceId,
                        principalTable: "forminstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_forminstanceresponse_option_OptionId",
                        column: x => x.OptionId,
                        principalTable: "option",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_forminstanceresponse_recipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "recipient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_forminstance_FormId",
                table: "forminstance",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormInstanceRecipient_RecipientsId",
                table: "FormInstanceRecipient",
                column: "RecipientsId");

            migrationBuilder.CreateIndex(
                name: "IX_forminstanceresponse_FormInstanceId",
                table: "forminstanceresponse",
                column: "FormInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_forminstanceresponse_OptionId",
                table: "forminstanceresponse",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_forminstanceresponse_RecipientId",
                table: "forminstanceresponse",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_option_QuestionId",
                table: "option",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_question_FormId",
                table: "question",
                column: "FormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormInstanceRecipient");

            migrationBuilder.DropTable(
                name: "forminstanceresponse");

            migrationBuilder.DropTable(
                name: "forminstance");

            migrationBuilder.DropTable(
                name: "option");

            migrationBuilder.DropTable(
                name: "recipient");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "form");
        }
    }
}
